using System;
using System.Diagnostics;

namespace HomeAutomation.Shared
{
    public class ShellHelper
    {
        public string Result { get; set; }
        public void Bash(string cmd)
        {
            Debug.WriteLine("Ser jeg overhovedet debug?");
            /*

            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            int milliSec = (int) TimeSpan.FromSeconds(5).Ticks;
            process.WaitForExit(milliSec);

            return result;*/
            
            var escapedArgs = cmd.Replace("\"", "\\\"");
            ProcessStartInfo processInfo = new ProcessStartInfo("/bin/bash");
            processInfo.Arguments = $"-c \"{escapedArgs}\"";
            processInfo.ErrorDialog = false;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardOutput = true;
            processInfo.RedirectStandardError = true;
            processInfo.CreateNoWindow = false;

            using (Process proc = new Process())
            {
                proc.StartInfo = processInfo;
                proc.ErrorDataReceived += ProcOnErrorDataReceived;
                proc.OutputDataReceived +=ProcOnOutputDataReceived;
                proc.EnableRaisingEvents = true;
                proc.WaitForExit(5000);
                proc.Exited += ProcOnExited;
                proc.BeginErrorReadLine();
                proc.BeginOutputReadLine();
                proc.Start();
                var readToEnd = proc.StandardOutput.ReadToEnd();
                Debug.WriteLine($"ReadToEnd: {readToEnd}");
            }            
            //Process proc = Process.Start(processInfo);

            // You can pass any delegate that matches the appropriate 
            // signature to ErrorDataReceived and OutputDataReceived
            // proc.ErrorDataReceived += ProcOnErrorDataReceived;
            // proc.OutputDataReceived +=ProcOnOutputDataReceived;    
            // proc.Exited += ProcOnExited;
            // proc.BeginErrorReadLine();
            // proc.BeginOutputReadLine();
            // proc.Start();
            //
            // proc.WaitForExit((int)TimeSpan.FromSeconds(5).Ticks);
        }

        private void ProcOnExited(object? sender, EventArgs e)
        {
            Debug.WriteLine("Process have exited...maybe");
        }

        private void ProcOnErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.WriteLine("Shit happens all the time!!");
        }

        private void ProcOnOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Debug.WriteLine("Data, or not!");
            if (e != null)
                Result = e.Data;
        }
    }
}