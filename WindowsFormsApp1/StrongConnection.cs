using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class StrongConnection
    {

        string[] airport = { "BGI", "CDG", "DEL", "DOH", "DSM", "EWR", "EYW",
            "HND","ICN","JFK","LGA","LHR","ORD","SAN","SFO","SIN","TLV","BUD"};

        String[,] routes = {
                { "DSM", "ORD" },
                { "ORD", "BGI" },
                { "BGI", "LGA" },
                { "SIN", "CDG" },
                { "CDG", "SIN" },
                { "CDG", "BUD" },
                { "DEL", "DOH" },
                { "DEL", "CDG" },
                { "TLV", "DEL" },
                { "EWR", "HND" },
                { "HND", "ICN" },
                { "HND", "JFK" },
                { "ICN", "JFK" },
                { "JFK", "LGA" },
                { "EYW", "LHR" },
                { "LHR", "SFO" },
                { "SFO", "SAN" },
                { "SAN", "EYW" },
                { "SFO", "DSM" }};

        string startingairport = "LGA";
        int[] airportDigital;
        int[,] routesDigital;


        int lowlinkvalue = -1;
        List<string[]> m_components = new List<string[]>();
        List<bool> Visited = new List<bool>();
        Stack<int> airportstack = new Stack<int>();

        public StrongConnection()
        {
            airportDigital = new int[airport.Length];
            routesDigital = new int[routes.GetLength(0), routes.GetLength(1)];

            ChangeTheNodetoDigital();

            for(int i=0;i< airport.Length;i++)
                Visited.Add(false);

            FindComponents();
        }

        private void ChangeTheNodetoDigital()
        {
            for(int i=0;i<airport.Length;i++)
            {
                airportDigital[i] = i;

                for(int j=0;j<routes.GetLength(0);j++)
                {
                    if (routes[j, 0] == airport[i])
                        routesDigital[j, 0] = i;

                    if (routes[j, 1] == airport[i])
                        routesDigital[j, 1] = i;
                }

            }
        }

        public void FindComponents()
        {
            DFSsearch();
        }

        void DFSsearch()
        {
            for (int i = 0; i < airport.Length; i++)
            {
                if (!Visited[i])
                {
                    DFS(i);
                }
            }

        }

        private void DFS(int nat)
        {
            SingletonPatternLog.AddLog(nat.ToString());
            airportstack.Push(nat);

            Visited[nat] = true;
            for(int i=0; i< routesDigital.GetLength(0);i++)
            {
                int rat = routesDigital[i,0];
                if(rat == nat)
                {
                    if (!Visited[routesDigital[i, 1]])
                        DFS(routesDigital[i, 1]);
                    else
                    {
                        for (int j = 0; j < airportstack.Count; j++)
                        {
                            int ntemp = airportstack.ElementAt(j);
                            if (ntemp == routesDigital[i, 1])
                                lowlinkvalue = routesDigital[i, 1];
                        }
                    }

                }
            }

            if (lowlinkvalue == -1)
                lowlinkvalue = nat;

            if(lowlinkvalue>=0 && airportstack.Count>0)
            {
                int curr = airportstack.Pop();
                string str = curr.ToString();
                while (curr != lowlinkvalue && airportstack.Count > 0)
                {
                    curr = airportstack.Pop();
                    str += "," + curr.ToString();
                }

                SingletonPatternLog.AddLog("component is " + str);
            }

            lowlinkvalue = -1;

        }
    }
}
