using System;
using System.Diagnostics;
using System.IO;
using System.Timers;

namespace HomeAutomation.Shared
{
    public class ShellHelper
    {
        private Process process;
        public void Bash(string args)
        {
            Timer timer = new Timer(5000);
            timer.Elapsed += TimerOnElapsed;
            timer.Start();
            //cmd = " -m get -u bjarne -o /home/bjarne/.homeautomation/devices/ikea/coapclient.json -B 3 -k K2FdNhdmGBGDb1ni coaps://192.168.1.51:5684/15001";    
            //var escapedArgs = cmd.Replace("\"", "\\\"");
            process = new Process();
            process.StartInfo.FileName = "coap-client";
            process.StartInfo.Arguments = args;
            //process.StartInfo.Arguments = cmd;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();

            process.WaitForExit();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            process.Kill();
        }
    }
}