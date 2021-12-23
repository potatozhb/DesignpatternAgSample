using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchQuestionAmazon
{
    public class SubMatrixMaxSum
    {
        //public int[,] Matrixdata = new int[4,4];//two dimentional array
        //public int[][] jaggedArray = new int[4][];//jagged array
        public List<List<int>> Matrixdata = new List<List<int>>();

        public SubMatrixMaxSum()
        {
            List<int> row = new List<int>();
            row.Add(112);
            row.Add(42);
            row.Add(83);
            row.Add(119);
            Matrixdata.Add(row);

            row = new List<int>();
            row.Add(56);
            row.Add(125);
            row.Add(56);
            row.Add(49);
            Matrixdata.Add(row);

            row = new List<int>();
            row.Add(15);
            row.Add(78);
            row.Add(101);
            row.Add(43);

            Matrixdata.Add(row);

            row = new List<int>();
            row.Add(62);
            row.Add(98);
            row.Add(114);
            row.Add(108);

            Matrixdata.Add(row);
        }

        public int FindMaxSubTopLeftQuadrantSum()
        {
            int maxsum = 0;

            for(int i=0;i<Matrixdata.Count;i++)
            {
                int tempmaxsum = CaculateSum();
                if(tempmaxsum > maxsum)
                    maxsum = tempmaxsum;
                for(int j=0;j<Matrixdata[i].Count;j++)
                {
                    ReverseColumnOrRow(-1, j);
                    tempmaxsum = CaculateSum();
                    if(tempmaxsum > maxsum)
                    {
                        maxsum = tempmaxsum;
                    }

                    ReverseColumnOrRow(-1, j);//reverse back
                }
            }

            return maxsum;
        }

        private List<List<int>> ReverseColumnOrRow(int nrow, int ncol)
        {
            List<List<int>> temparr = Matrixdata;
           
            if(ncol>=0 && ncol < Matrixdata[0].Count)
            {
                for (int i = 0; i<Matrixdata[0].Count/2; i++)
                {
                    int ntemp = Matrixdata[i][ncol];
                    Matrixdata[i][ncol] = Matrixdata[Matrixdata.Count-1-i][ncol];
                    Matrixdata[Matrixdata.Count-1-i][ncol] = ntemp;
                }
            }

            if (nrow>=0 && nrow < Matrixdata.Count)
            {
                for (int i = 0; i<Matrixdata.Count/2; i++)
                {
                    int ntemp = Matrixdata[nrow][i];
                    Matrixdata[nrow][i] = Matrixdata[nrow][Matrixdata.Count-1-i];
                    Matrixdata[nrow][Matrixdata.Count-1-i] = ntemp;
                }
            }

            return temparr;
        }

        private int CaculateSum()
        {
            int sum = 0;

            for (int i=0;i< Matrixdata.Count/2;i++)
            {
                for(int j=0;j<Matrixdata.Count/2; j++)
                {
                    sum+=Matrixdata[i][j];
                }
            }
            return sum;
        }
    }
}
