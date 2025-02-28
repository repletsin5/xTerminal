﻿using System;
using System.Net;
using System.Text.RegularExpressions;
using Core;

namespace Externalip
{
    /// <summary>
    /// Geting exernel ip via http://checkip.dyndns.org
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string blackshit;
                blackshit = (new WebClient()).DownloadString("http://checkip.dyndns.org");
                blackshit = (new Regex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}"))
                             .Matches(blackshit)[0].ToString();
                Console.WriteLine("Your external IP address is: " + blackshit);
            }
            catch { FileSystem.ErrorWriteLine("Canno't verify external IP. Check your internet connection!"); }
        }
    }
}
