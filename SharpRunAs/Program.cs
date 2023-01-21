using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRunAs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Options.Usage();
                Environment.Exit(1);
            }

            Options options = new Options();
            if (!Parser.Default.ParseArguments(args, options))
            {
                Console.WriteLine("[-] Error: Unknown argument/s");
                Environment.Exit(1);
            }

            if (options.Help)
            {
                Options.Usage();
                Environment.Exit(1);
            }

            if (options.Username == null & options.Password == null & options.Cmd == null)
            {
                Options.Usage();
                Environment.Exit(1);
            }
            else if (options.Username == null)
            {
                Options.Usage();
                Environment.Exit(1);
            }
            else if (options.Password == null)
            {
                Options.Usage();
                Environment.Exit(1);
            }
            else if (options.Cmd == null)
            {
                Options.Usage();
                Environment.Exit(1);
            }
            else if (options.Username != null & options.Password != null & options.Cmd != null)
            {
                ExecuteCommandSync(options.Username, options.Password, options.Cmd);
            }
        }
        /// <summary>
        /// Executes a shell command synchronously.
        /// </summary>
        /// <param name="username">string username</param>
        /// <param name="password">string password</param>
        /// <param name="command">string command</param>
        /// <returns>string, as output of the command.</returns>
        public static void ExecuteCommandSync(string username, string password, object command)
        {
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run, and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows, and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);
                // The following commands are needed to redirect the standard output. 
                //This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.UserName = username;
                procStartInfo.PasswordInClearText = password;
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                procStartInfo.WorkingDirectory = "C:\\Windows\\System32\\";
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();

                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();

                // Display the command output.
                Console.WriteLine(result);
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine("Command has failed: " + ex.Message);
            }
        }
    }
}
