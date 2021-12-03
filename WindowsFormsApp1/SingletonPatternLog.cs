using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class SingletonPatternLog
    {
        private static SingletonPatternLog signletonInstance = null;
        private static List<string> log = new List<string>();

        private SingletonPatternLog() { }

        public static SingletonPatternLog GetInstance()
        {
            if (null == signletonInstance)
            {
                signletonInstance = new SingletonPatternLog();
            }
            return signletonInstance;
        }

        public static void AddLog(string str)
        {
            log.Add(str);
        }

        public static void AddtoTopLog(string str)
        {
            log.Insert(0,str);
        }

        public static List<string> ReadLog()
        {
           
            return log;
        }

        public static void ClearLog()
        {
            log.Clear ();
        }
    }
}
