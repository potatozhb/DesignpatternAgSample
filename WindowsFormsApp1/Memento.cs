using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class OriginatorMemento
    {
        private MementoCare datacare;

        public OriginatorMemento()
        {
            datacare = new MementoCare();
        }
        public void CreateMemento(MementoData newdata)
        {
            datacare.SaveMementoData(newdata);
        }

        public MementoData RestoreMemento(bool isPrevious)
        {
            if(isPrevious)
                return datacare.GetPreviousData();
            else
                return datacare.GetNextData();
        }
    }

    public class MementoData
    {
        public string Article { get; set; }
        public DateTime dateTime { get; set; }
    }

    public class Memento
    {
        private MementoData data;
        public Memento(MementoData newdata)
        {
            this.data = newdata;
        }

        public MementoData GetData()
        {
            return this.data;
        }
    }

    public class MementoCare
    {
        private static int CurrentdataIndex = 0;
        private List<MementoData> datas = new List<MementoData>();

        public MementoCare()
        {
            datas.Add(new MementoData());
        }

        public MementoData GetPreviousData()
        {
            if(CurrentdataIndex >0)
            {
                CurrentdataIndex--;

                SingletonPatternLog.AddLog($"Go to data #{ CurrentdataIndex} : datatime: {datas[CurrentdataIndex].dateTime.ToString()}");
                return datas[CurrentdataIndex];
            }
            else
                return null;
        }

        public MementoData GetNextData()
        {
            if(CurrentdataIndex < datas.Count-1)
            {
                CurrentdataIndex++;
                SingletonPatternLog.AddLog($"Go to data #{ CurrentdataIndex} : datatime: {datas[CurrentdataIndex].dateTime.ToString()}");
                return datas[CurrentdataIndex];
            }
            else
                return null ;
        }

        public void SaveMementoData(MementoData data)
        {
            while (CurrentdataIndex != datas.Count -1)
                datas.RemoveAt(CurrentdataIndex);

            datas.Add(data);
            CurrentdataIndex++;

            SingletonPatternLog.AddLog($"Save data #{ CurrentdataIndex} : datatime: {datas[CurrentdataIndex].dateTime.ToString()}");
        }


    }
}
