using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class ObjectPoolPattern
    {
        private static List<ObjectPattern> _unUsed = new List<ObjectPattern>();
        private static List<ObjectPattern> _inUse = new List<ObjectPattern>();

        public static ObjectPattern GetObject()
        {
            lock(_unUsed)
            {
                if( _unUsed.Count == 0 )
                {
                    ObjectPattern objectPattern = new ObjectPattern();
                    _inUse.Add(objectPattern);
                    SingletonPatternLog.AddLog("New Object");
                    return objectPattern;
                }
                else
                {
                    ObjectPattern objectPattern = _unUsed[0];
                    _inUse.Add(objectPattern);
                    _unUsed.RemoveAt(0);
                    SingletonPatternLog.AddLog("Reused Object");
                    return objectPattern;
                }
            }
        }

        public static void ReleaseObject(ObjectPattern oo)
        {
            oo.Data = null;

            lock( _unUsed)
            {
                _unUsed.Add(oo);
                _inUse.Remove(oo);
            }
        }
    }

    public class ObjectPattern
    {
        public string Data { get; set; }

        public ObjectPattern()
        {
            ShowInfo();
        }
        public void ShowInfo()
        {
            
        }
    }
}
