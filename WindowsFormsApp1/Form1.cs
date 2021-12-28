using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Analysis;
using Microsoft.ML;


namespace WindowsFormsApp1
{


    public partial class Form1 : Form
    {
        SingletonPatternLog log;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log = SingletonPatternLog.GetInstance();
            SingletonPatternLog.AddLog("start APP");

        }

        private string readlog()
        {
            List<string> log = SingletonPatternLog.ReadLog();
            string logstr = "";
            for (int i = 0; i < log.Count; i++)
            {
                logstr += log[i] + "\r\n";
            }

            return logstr;
        }

        private async Task<string> readlogasync()
        {
            List<string> log = SingletonPatternLog.ReadLog();
            string logstr = "";
            for (int i = 0; i < log.Count; i++)
            {
                logstr += log[i] + "\r\n";
            }

            return logstr;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            SingletonPatternLog.AddLog("Bridge Pattern");
            RemoteTVpauseBridgePattern remote = new RemoteTVpauseBridgePattern(new Television(200));
            remote.PowerOn();
            remote.PowerOff();
            remote.VolumeUp();
            remote.VolumeDown();
            remote.VolumeDown();
            remote.VolumeDown();
            remote.ChannelUp();
            remote.ChannelDown();
            remote.pause();


            this.textBox1.Text = readlog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SingletonPatternLog.AddLog("Strategy Pattern");

            Dog dd= new Dog();
            dd.Fly();

            Bird bb = new Bird();
            bb.Fly();

            bb.SetFly(new notFly());
            bb.Fly();

            dd.Fly();

            bb.SetFly(new sickFly());
            bb.Fly();

            this.textBox1.Text = readlog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ss = "dbcabcabddda";
            Tries tries = new Tries();
            tries.InsertNode("abc");
            tries.InsertNode("abd");
            tries.InsertNode("bbc");

            List<string> slist = tries.Becontains(ss);

            this.textBox1.Text = readlog();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            //Task.Run(() =>
            //{
            SingletonPatternLog.ClearLog();
            this.textBox1.Text = readlog();
            strlog = "";

            BinarySearchTree bst = new BinarySearchTree();

            Random rd = new Random();
            for (int i = 0; i<1500; i++)
            {
                bst.Insert(new Node(rd.Next(30000)));
            }

            bst.Display();

            SingletonPatternLog.AddLog("AVL banlance***********");

            bst.BanlanceBT();

            bst.Display();

            await Task<string>.Run(async () =>
            {
                var temp = readlogasync();
                strlog =  temp.Result;
            });

            //});
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StrongConnection sc = new StrongConnection();


            this.textBox1.Text = readlog();
        }

        public class AirportInfo
        {
            public string airportname;
            public bool isDegreezero;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            PlayTV myTV = new PlayTV();
            myTV.Play();


            this.textBox1.Text = readlog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            StatePattern sp = new StatePattern();
            sp.RunStatePattern();


            this.textBox1.Text = readlog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            Progress<ProgressReport> progress = new Progress<ProgressReport>();
            clt = new CancellationTokenSource();

            progress.ProgressChanged += Progress_ProgressChanged;
            AsyncAwaitDemo aad = new AsyncAwaitDemo();
            aad.RunsyncTest(progress, clt);


        }

        private void Progress_ProgressChanged(object sender, ProgressReport e)
        {
            SingletonPatternLog.AddLog(e.DownloadedPercentageDes);
            progressBar1.Value = e.DownloadedPercentage; 
            this.textBox1.Text = readlog();
        }

        string strlog = "";

        private async void timer1_Tick(object sender, EventArgs e)
        {
         
            strlog = readlog(); 
            textBox1.Text = strlog;
            //textBox1.Select(textBox1.Text.Length, 0);
            //textBox1.ScrollToCaret();
        }

        CancellationTokenSource clt = new CancellationTokenSource();

        private void button9_Click(object sender, EventArgs e)
        {
            clt.Cancel();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            IBusiness business = FactoryPattern.Create();

            business.produce();

            var config = Convert.ToBoolean(ConfigurationManager.AppSettings["foo"]);
            if (config)
                ConfigurationManager.AppSettings["foo"] = "false";
            else
                ConfigurationManager.AppSettings["foo"] = "true";

            this.textBox1.Text = readlog();
        }

        private async void button12_Click(object sender, EventArgs e)
        {
            SingletonPatternLog.ClearLog();
            Progress<string> progress = new Progress<string>();
            progress.ProgressChanged+=Progress_ProgressChanged1;

            await Task.Run(() => UpdateStocks(progress));

            
        }

        private async void UpdateStocks(Progress<string> progress)
        {
            SubjectObserverPattern subject = new SubjectObserverPattern(progress);
            StockObserver stockObserver = new StockObserver(subject);

            StockObserver stockObserver2 = new StockObserver(subject);

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                subject.SetGooGPrice(100.1 + new Random().Next(10));
                subject.SetAPPLPrice(120.7+ new Random().Next(10));
                subject.SetFacebookPrice(114.3+ new Random().Next(10));

                if(i==5)
                    subject.UnRegister(stockObserver);
            }

        }

        private void Progress_ProgressChanged1(object sender, string e)
        {
            this.textBox1.Text = e;
        }


        OriginatorMemento origin = new OriginatorMemento();

        private void button13_Click(object sender, EventArgs e)
        {//memento save
            MementoData data = new MementoData();
            data.Article = textBox3.Text;
            data.dateTime = DateTime.Now;

            origin.CreateMemento(data);


            this.textBox1.Text = readlog();
        }

        private void button14_Click(object sender, EventArgs e)
        {//privious
            button14.Enabled = true;
            button15.Enabled = true;
            MementoData data = origin.RestoreMemento(true);
            if(data == null)
                button14.Enabled = false;
            else
                textBox3.Text = data.Article;  


            this.textBox1.Text = readlog();
        }

        private void button15_Click(object sender, EventArgs e)
        {//next

            button14.Enabled = true;
            button15.Enabled = true;
            MementoData data = origin.RestoreMemento(false);
            if (data == null)
                button15.Enabled = false;
            else
                textBox3.Text = data.Article;


            this.textBox1.Text = readlog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            BuilderPattern bp = new BuilderPattern();
            bp.BulidArms();
            bp.BulidHead();
            bp.BulidLegs();
            bp.BulidTorso();

            CanBulid robot =  bp.GetProduct();

            SingletonPatternLog.AddLog($"bulid sucess, name is {robot.GetProduct()}");

            this.textBox1.Text = readlog();

        }

        private void button17_Click(object sender, EventArgs e)
        {
            PrototypePattern bp = new PrototypePattern();   
            bp.RunPattern();

            this.textBox1.Text = readlog();

        }

        private void button18_Click(object sender, EventArgs e)
        {
            SingletonPatternLog.AddLog("**************Tank***************");
            Tank tank = new Tank();
            tank.Load();
            tank.Fire();
            tank.Operation("Jim");

            SingletonPatternLog.AddLog("**************Robot***************");
            RobotKiller robotKiller = new RobotKiller();
            robotKiller.Charge();
            robotKiller.Laser();
            robotKiller.Pilot("Tom");

            SingletonPatternLog.AddLog("**************Adapter***************");
            AdapterPattern adapterPattern = new AdapterPattern(robotKiller);
            adapterPattern.Load();
            adapterPattern.Fire();
            adapterPattern.Operation("Sellina");


            this.textBox1.Text = readlog();


        }

        private void button19_Click(object sender, EventArgs e)
        {
            IteratorPattern iteratorPattern = new IteratorPattern();
            iteratorPattern.Run();

            this.textBox1.Text = readlog();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            SingletonPatternLog.ClearLog();
        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            AbstractFactoryTest abstractFactoryTest = new AbstractFactoryTest();
            abstractFactoryTest.Run();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            LazyInitializationPattern lazyInitializationPattern = new LazyInitializationPattern();
            lazyInitializationPattern.Run();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            ObjectPattern obj1 = ObjectPoolPattern.GetObject();
            ObjectPattern obj2 = ObjectPoolPattern.GetObject();
            ObjectPoolPattern.ReleaseObject(obj1);
            ObjectPattern obj3 = ObjectPoolPattern.GetObject();
            ObjectPattern obj4 = ObjectPoolPattern.GetObject();

            ObjectPoolPattern.ReleaseObject(obj2);
            ObjectPattern obj5 = ObjectPoolPattern.GetObject();
            ObjectPattern obj6 = ObjectPoolPattern.GetObject();

            ObjectPoolPattern.ReleaseObject(obj3);
            ObjectPoolPattern.ReleaseObject(obj4);
            ObjectPattern obj7 = ObjectPoolPattern.GetObject();
            ObjectPattern obj8 = ObjectPoolPattern.GetObject();

        }
    }
}
