using System;
using CommandLine;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SharpRunAs
{
    internal class Options
    {
        [Option('u', "username", Required = false)]
        public string Username { get; set; }

        [Option('p', "password", Required = false)]
        public string Password { get; set; }

        [Option('c', "cmd", Required = false)]
        public string Cmd { get; set; }

        [Option('h', "help", Required = false)]
        public bool Help { get; set; }

        // ASCII Art: https://patorjk.com/software/taag/#p=display&f=Big&t=ParsingTest
        public static void Usage()
        {
            string Usage = @"
   _____ _                      _____                          
  / ____| |                    |  __ \               /\        
 | (___ | |__   __ _ _ __ _ __ | |__) |   _ _ __    /  \   ___ 
  \___ \| '_ \ / _` | '__| '_ \|  _  / | | | '_ \  / /\ \ / __|
  ____) | | | | (_| | |  | |_) | | \ \ |_| | | | |/ ____ \\__ \
 |_____/|_| |_|\__,_|_|  | .__/|_|  \_\__,_|_| |_/_/    \_\___/
                         | |                                   
                         |_|                                                                          
    
                    Author: @pwnlog
                    Version: 0.0.1


Usage:
    SharpRunAs --username <username> --password <password> --cmd <command>
    

Options:
    -u, --username       User name
    -p, --password       User password
    -c, --cmd            Command to execute as another user
    -h, --help           Display help menu


Important:
    Only use single quotes (' ') when there are special characters
    If there aren't any special characters don't use single quotes (' '), instead use double quotes


Examples:
    SharpRunAs --username bob.smith --password 'p@$$w0rd' --cmd 'powershell -c whoami'
    SharpRunAs --username bob.smith --password 'p@$$w0rd' --cmd 'powershell -c whoami'
";
            Console.WriteLine(Usage);
        }
    }
}
