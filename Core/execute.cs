using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{   

    public class execute
    {
        public static string dlocation = null;
        public static Dictionary<string, string> Aliases = new Dictionary<string, string>
        {
            { "ls", @".\Tools\FileSystem\ListDirectories.exe" },
            { "clear", @".\Tools\Internal\Clear.exe" },
            { "extip", @".\Tools\Network\Externalip.exe" },
            { "ispeed", @".\Tools\Network\InternetSpeed.exe" },
            { "icheck", @".\Tools\Network\CheckDomain.exe" },
            { "md5", @".\Tools\FileSystem\CheckMD5.exe"  },
            { "fcopy", @".\Tools\FileSystem\FCopy.exe"  },
            { "fmove", @".\Tools\FileSystem\FMove.exe"  },
            { "frename", @".\Tools\FileSystem\FRename.exe"  },
            { "cmd", "cmd"  },
            { "ps", "powershell"  },
            { "cd", @".\Tools\FileSystem\CDirectory.exe"  },
            { "cat", @".\Tools\FileSystem\StringView.exe"  },
            { "del", @".\Tools\FileSystem\Delete.exe"  },
            { "mkdir", @".\Tools\FileSystem\MakeDirectory.exe"  },
            { "mkfile", @".\Tools\FileSystem\MKFile.exe"  },
            { "speedtest", @".\Tools\netcoreapp3.1\TestNet.exe"  },
            { "email", @".\Tools\Network\eMailS.exe"  },
            { "wget", @".\Tools\Network\WGet.exe"  },
            { "edit", @".\Tools\FileSystem\xEditor.exe"  },
            { "cp", @".\Tools\FileSystem\CheckPermission.exe"  },
            { "bios", @".\Tools\Hardware\BiosInfo.exe"  },
            { "sinfo", @".\Tools\Hardware\sdc.exe"  },
            { "flappy", @".\Tools\Game\FlappyBirds.exe"  }
        };
        public static void Execute(string input, bool waitForExit)
        {
            if (Aliases.Keys.Contains(input))
            {
                var process = new Process();

                if (input == "cmd" || input == "ps")
                {
                    process.StartInfo = new ProcessStartInfo(Aliases[input])
                    {
                        UseShellExecute = false,
                        WorkingDirectory = dlocation
                    };
                    if (File.Exists(Aliases[input]))
                    {
                        process.Start();

                        if (waitForExit)
                            process.WaitForExit();
                    }
                    else
                        FileSystem.ErrorWriteLine($"Couldn't find file \"{Aliases[input]}\" to execute. Reinstalling should fix the issue ");
                    return;
                }
                process.StartInfo = new ProcessStartInfo(Aliases[input])
                {
                    UseShellExecute = false,
                };
                if (File.Exists(Aliases[input]))
                {
                    process.Start();
                    if (waitForExit)
                        process.WaitForExit();
                }
                else
                    FileSystem.ErrorWriteLine($"Couldn't find file \"{Aliases[input]}\" to execute. Reinstalling should fix the issue ");
                return;
            }
        }
        //process execute 

        public static void ProcessExecute(string input, string arguments,bool useShellExe = true)
        {
            var process = new Process();
            process.StartInfo = new ProcessStartInfo(input)
            {
                UseShellExecute = useShellExe,
                Arguments = arguments
            };
            if (File.Exists(input))
                process.Start();
            else
                FileSystem.ErrorWriteLine($"Couldn't find file \"{input}\" to execute");
            return;
        }
        //process execute  with 1 arg
        public static int ExecuteWithArgs(string input, string args, bool waitForExit)
        {
            if (Aliases.Keys.Contains(input))
            {
                var process = new Process();
                process.StartInfo = new ProcessStartInfo(Aliases[input])
                {
                    UseShellExecute = false,
                    Arguments = args
                };

                if (File.Exists(Aliases[input]))
                {
                    process.Start();
                    if (waitForExit)
                        process.WaitForExit();
                }
                else
                    FileSystem.ErrorWriteLine($"Couldn't find file \"{Aliases[input]}\" to execute. Reinstalling should fix the issue ");

                return 0;
            }

            return 1;
        }
        //------------------------

        //process execute  with 2 arg
        public static int ExecuteWithArgs2(string input, string args, string args2, bool waitForExit)
        {
            if (Aliases.Keys.Contains(input))
            {
                var process = new Process();
                process.StartInfo = new ProcessStartInfo(Aliases[input])
                {
                    UseShellExecute = false,
                    Arguments = args + " " + args2
                };
                if (File.Exists(Aliases[input]))
                {
                    process.Start();
                    if (waitForExit)
                        process.WaitForExit();
                }
                else
                    FileSystem.ErrorWriteLine($"Couldn't find file \"{Aliases[input]}\" to execute. Reinstalling should fix the issue ");
                return 0;
            }

            return 1;
        }
        //------------------------

    }
}
