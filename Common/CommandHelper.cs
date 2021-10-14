using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X.Common.Helper
{
    public static class CommandHelper
    {
        /// <summary>
        /// Execute command via cmd.exe
        /// </summary>
        /// <param name="command"></param>
        public static void ExecuteCommand(string command)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = @"c:\Windows\system32\cmd.exe",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Normal,
                Arguments = $"/C {command}"
            };

            var process = Process.Start(processStartInfo);
            process?.WaitForExit();
            process?.Dispose();
        }

        /// <summary>
        /// Execute command via cmd.exe
        /// </summary>
        /// <param name="workingDirectory">working directory</param>
        /// <param name="commands"></param>
        /// <returns></returns>
        public static string ExecuteCommand(string workingDirectory, params string[] commands)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = @"c:\Windows\system32\cmd.exe",
                CreateNoWindow = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                WorkingDirectory = workingDirectory,
                UseShellExecute = false,
            };
            Process process = new Process
            {
                StartInfo = processStartInfo,
            };
            // Useless ? 
            //process.OutputDataReceived += Process_OutputDataReceived;
            //process.ErrorDataReceived += Process_ErrorDataReceived;
            process.Start();
            foreach (var command in commands)
            {
                process.StandardInput.WriteLine(command);
            }
            process.StandardInput.WriteLine("exit");
            process.StandardInput.AutoFlush = true;
            process.WaitForExit();
            string result = process.StandardOutput.ReadToEnd();
            result += process.StandardError.ReadToEnd();
            process.Dispose();
            return result;
        }

        /// <summary>
        /// Execute command via cmd.exe
        /// </summary>
        /// <param name="workingDirectory">working directory</param>
        /// <param name="commands"></param>
        /// <returns></returns>
        public static void Start(string workingDirectory, string command)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = @"c:\Windows\system32\cmd.exe",
                WorkingDirectory = workingDirectory,
                Arguments = $"/c {command}"
            };
            Process process = new Process
            {
                StartInfo = processStartInfo,
            };

            process.Start();
        }

        // https://stackoverflow.com/questions/40764172/how-asp-net-core-execute-linux-shell-command
        public static string Execute(string command, string args)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = command,
                    Arguments = args,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (string.IsNullOrEmpty(error)) { return output; }
            else { return error; }
        }

    }
}