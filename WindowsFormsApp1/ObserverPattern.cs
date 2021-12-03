using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface ISubject
    {
        void Register(IObserver newobserver);
        void UnRegister(IObserver deleteobserver);
        void NotifyObserver();
    }

    public class SubjectObserverPattern: ISubject
    {        
        public event EventHandler UpdateUI;

        private List<IObserver> myObservers;
        private double googprice;
        private double facebookprice;
        private double applprice;

        private IProgress<string> progress;
        
        public SubjectObserverPattern(IProgress<string> p)
        {
            myObservers = new List<IObserver>();
            googprice =0;
            facebookprice = 0;
            applprice = 0;

            progress = p;
        }

        public void Register(IObserver newobserver)
        {
            myObservers.Add(newobserver);
            SingletonPatternLog.AddLog("add an observer into the list");
        }

        public void UnRegister(IObserver deleteobserver)
        {
            int indexdo = myObservers.IndexOf(deleteobserver);
            myObservers.RemoveAt(indexdo);

            SingletonPatternLog.AddLog($"delete observer {deleteobserver.GetObserverID()} from the list");
        }

        public void NotifyObserver()
        {
            foreach (IObserver observer in myObservers)
            {
                observer.Update(googprice,facebookprice,applprice);
            }
            List<string> log = SingletonPatternLog.ReadLog();
            string logstr = "";
            for (int i = 0; i < log.Count; i++)
            {
                logstr += log[i] + "\r\n";
            }

            progress.Report(logstr) ;
        }

        public void SetGooGPrice(double newprice)
        {
            SingletonPatternLog.AddLog($"Google: {googprice} => {newprice}");
            this.googprice = newprice;
            NotifyObserver();
        }

        public void SetFacebookPrice(double newprice)
        {
            SingletonPatternLog.AddLog($"Facebook : {facebookprice} => {newprice}");
            this.facebookprice = newprice;
            NotifyObserver();
        }

        public void SetAPPLPrice(double newprice)
        {
            SingletonPatternLog.AddLog($"Apple : {applprice} => {newprice} ");
            this.applprice = newprice;
            NotifyObserver();
        }

    }

    public interface IObserver
    {
        int GetObserverID();
        void Update(double GooGprice, double Facebookprice, double APPLprice);
    }

    public class StockObserver : IObserver
    {
        private double googprice;
        private double facebookprice;
        private double applprice;

        private static int stockobserverIDtracker =0;
        private int stockobserverID;

        private SubjectObserverPattern subjectObserver;

        public StockObserver(SubjectObserverPattern newsubject)
        {
            this.subjectObserver = newsubject;
            stockobserverID = ++stockobserverIDtracker;
            this.subjectObserver.Register(this);

        }

        public int GetObserverID()
            { return stockobserverID; }

        public void Update(double GooGprice, double Facebookprice, double APPLprice)
        {
            this.googprice = GooGprice;
            this.facebookprice = Facebookprice;
            this.applprice = APPLprice;

            SingletonPatternLog.AddLog($"observer {stockobserverID} updated");
        }
    }


    //Real stock data
    public class AVConnection
    {
        private readonly string _apiKey;

        public AVConnection(string apikey)
        {
            _apiKey = apikey;
        }

        public void SaveCSVfromURL(string symbol)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://" + $"www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={_apiKey}&datatype=csv");
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();
            File.WriteAllText("stockdata.csv",results);
        }
    }


}
