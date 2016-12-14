﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace wne
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool start = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            OSVersionCheck();
            foreach (String s in args){
                if (string.Compare(s, "/start") == 0)
                    start = true;
            }
            Application.Run(new UI.Main(start));
        }

        /// <summary>
        /// Checks if the OS is Vista+
        /// </summary>
        private static void OSVersionCheck()
        {
            if (Environment.OSVersion.Version.Major >= 6)
                return;
            MessageBox.Show("Windows Vista+ is required to run WNE");
            Process process = Process.GetCurrentProcess();
            process.Kill();
        }
    }
}
