

using System.Collections.Generic;

namespace WindowsFormsApp1
{
    public class CompositePattern
    {
        public void Run()
        {
            GroupData groupData = new GroupData("Root");
            GroupData Level11 = new GroupData("Level11");
            groupData.Add(Level11);
            Level11.Add(new IndependentInfo("II1"));
            Level11.Add(new IndependentInfo("II2"));

            GroupData Level12 = new GroupData("Level12");
            groupData.Add(Level12);
            Level12.Add(new IndependentInfo("II3"));
            Level12.Add(new IndependentInfo("II4"));


            groupData.Add(new IndependentInfo("II5"));
            groupData.Add(new IndependentInfo("II6"));

            CompositePatternBase data = groupData.GetData("II6");

            groupData.Remove("II3");

        }
    }

    public abstract class CompositePatternBase
    {
        public virtual void Add(CompositePatternBase data)
        {
            throw new System.Exception();
        }

        public virtual void Remove(string uniquename)
        {
            throw new System.Exception();
        }

        public virtual CompositePatternBase GetData(string uniquename)
        {
            throw new System.Exception();
        }

        public virtual void ShowAllInfo()
        {
            throw new System.Exception();
        }

        public virtual string GetGroupName()
        {
            throw new System.Exception();
        }

        public virtual string GetIndependentName()
        {
            throw new System.Exception();
        }
    }
    public class GroupData : CompositePatternBase
    {
        private string _groupName = "";
        private List<CompositePatternBase> _data = new List<CompositePatternBase>();

        public GroupData(string n)
        {
            _groupName = n;
        }

        public override void Add(CompositePatternBase newdata)
        {
            _data.Add(newdata);
        }

        public override void Remove(string uniquename)
        {
            RemoveDataHelper(_data,uniquename);
        }

        private void RemoveDataHelper(List<CompositePatternBase> root, string uniquename)
        {
            foreach (CompositePatternBase data in root)
            {
                string type = data.GetType().Name;
                if (type =="GroupData")
                {
                    string name = ((GroupData)data).GetGroupName();
                    if (name == uniquename)
                    {
                        root.Remove(data);
                        return;
                    }
                    else
                    {
                        RemoveDataHelper(((GroupData)data).GetRoot(), uniquename);
                    }
                }
                else
                {
                    string name = ((IndependentInfo)data).GetIndependentName();
                    if (name == uniquename)
                    {
                        root.Remove(data);
                        return;
                    }
                }
            }
            return;
        }

        public List<CompositePatternBase> GetRoot()
        {
            return _data;
        }

        public override CompositePatternBase GetData(string uniquename)
        {
            return GetDataHelper(_data, uniquename);
        }

        private CompositePatternBase GetDataHelper(List<CompositePatternBase> root, string uniquename)
        {
            CompositePatternBase rs = null;

            foreach (CompositePatternBase data in root)
            {
                string type = data.GetType().Name;
                if (type =="GroupData")
                {
                    string name = ((GroupData)data).GetGroupName();
                    if(name == uniquename)
                    {
                        return data;
                    }
                    else
                    {
                        rs = GetDataHelper(((GroupData)data).GetRoot(), uniquename);
                    }
                }
                else
                {
                    string name = ((IndependentInfo)data).GetIndependentName();
                    if (name == uniquename)
                    {
                        return data;
                    }
                }
            }
            return rs;
        }

        public override void ShowAllInfo()
        {
             
            //foreach (CompositePatternBase data in data)
            //{
            //    string type = data.GetType().Name;
            //    if (type =="GroupData")
            //}
        }

        public string GetGroupName()
        {
            return _groupName;
        }

    }

    public class IndependentInfo : CompositePatternBase
    {
        private string _name = "";

        public IndependentInfo(string n)
        {
            _name = n;
        }

        public override string GetIndependentName()
        {
            return _name;
        }
    }
}
