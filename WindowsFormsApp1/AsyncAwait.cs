using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsFormsApp1
{
    
    public class ProgressReport
    {
        public int DownloadedPercentage = 0;
        public string DownloadedPercentageDes = "";
    }

    public class AsyncAwaitDemo
    {
        delegate string aadele();
         
        private int milliseconds = 0;
        private int TTmilliseconds = 0;

        public async Task RunsyncTest(IProgress<ProgressReport> progress , CancellationTokenSource cancellationTokenSource)
        {
            SingletonPatternLog.ClearLog();
        
            Stopwatch swt = Stopwatch.StartNew();

            try
            {
                await Task.Run(() => RunTimerConsumerAsyncParallelV2(progress, cancellationTokenSource.Token));
            }
            catch(OperationCanceledException e)
            {

                SingletonPatternLog.AddLog("RunTimerConsumerAsyncParallelV2 ： Cancelled task, message is " + e.Message);
            }

            swt.Stop();

            SingletonPatternLog.AddLog("RunTimerConsumerAsyncParallelV2 Total time is " + swt.Elapsed.TotalMilliseconds.ToString());

            swt.Restart();

            try
            {
                await Task.Run(() => RunTimerConsumerAsyncWait(progress, cancellationTokenSource.Token));

            }
            catch(OperationCanceledException e)
            {
                SingletonPatternLog.AddLog("Cancelled task, message is " + e.Message);
            }

            swt.Stop();
            SingletonPatternLog.AddLog("Total time is " + swt.Elapsed.TotalMilliseconds.ToString());



        }


        private void RunTimerConsumersync()
        {
            SingletonPatternLog.AddLog("sync process start");
      
        }


        private async Task RunTimerConsumerAsyncParallel()
        {
            SingletonPatternLog.AddLog("Async process start");
            List<Task> tasks = new List<Task>();
            List<string> data = preData();

            foreach (string key in data)
            {
                tasks.Add(Task.Run(() => Download(key)));
            }

            await Task.WhenAll(tasks);
        }


        private async Task RunTimerConsumerAsyncParallelV2(IProgress<ProgressReport> progress, CancellationToken clt)
        {
            SingletonPatternLog.AddLog("Async process start");
            List<Task> tasks = new List<Task>();
            List<string> data = preData();
            ProgressReport pr = new ProgressReport();

            int finished = 0;

            await Task.Run(() =>
            {
                Parallel.ForEach<string>(data, async (site) =>
               {
                   Download(site);
                   finished++;
                   pr.DownloadedPercentage = finished * 100 / data.Count;
                   pr.DownloadedPercentageDes = "percentage is " + finished * 100 / data.Count;
                   progress.Report(pr);

               });
            });

             
            clt.ThrowIfCancellationRequested();

        }



        private async Task RunTimerConsumerAsyncWait(IProgress<ProgressReport> progress, CancellationToken clt)
        {
            SingletonPatternLog.AddLog("Async wait process start");
            ProgressReport pr = new ProgressReport();

            List<string> data = preData();

            for (int i = 0; i < data.Count; i++)
            {
                await Task.Run(() => Download(data[i]));

                pr.DownloadedPercentage = (i + 1) * 100 / data.Count;
                pr.DownloadedPercentageDes = "percentage is " + (i + 1) * 100 / data.Count;
                progress.Report(pr);
                                
                clt.ThrowIfCancellationRequested();
            }

            //foreach (string key in data)
            //{
            //    await Task.Run(()=> Download(key));
            //}



        }


        private async Task Download(string webaddress)
        {

            Stopwatch sw = Stopwatch.StartNew();

            WebClient client = new WebClient();

            byte[] bb = client.DownloadData(webaddress);

            sw.Stop();
            SingletonPatternLog.AddLog("Time is " +
            sw.Elapsed.TotalMilliseconds.ToString() + "; Length is " + bb.Length.ToString());


        }

        private List<string> preData()
        {
            List<string> data = new List<string>();
            data.Add("https://www.google.com");
            data.Add("https://www.apple.com");
            data.Add("https://www.stackoverflow.com");
            data.Add("https://www.baidu.com");
            data.Add("https://www.microsoft.com");
            data.Add("https://www.cnn.com");
            data.Add("https://www.bbc.com");
           

            return data;
        }


    }

    
}
