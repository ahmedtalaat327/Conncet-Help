using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;

namespace Help
{
    public static class QuickMession
    {

        public static bool IsVC2015Installed()
        {
            string dependenciesPath = @"SOFTWARE\Classes\Installer\Dependencies";

            using (RegistryKey dependencies = Registry.LocalMachine.OpenSubKey(dependenciesPath))
            {
                if (dependencies == null) return false;

                foreach (string subKeyName in dependencies.GetSubKeyNames().Where(n => !n.ToLower().Contains("dotnet") && !n.ToLower().Contains("microsoft")))
                {
                    using (RegistryKey subDir = Registry.LocalMachine.OpenSubKey(dependenciesPath + "\\" + subKeyName))
                    {
                        var value = subDir.GetValue("DisplayName")?.ToString() ?? null;
                        if (string.IsNullOrEmpty(value))
                        {
                            continue;
                        }
                        if (Environment.Is64BitOperatingSystem)
                        {
                            if (Regex.IsMatch(value, @"C\+\+ 2015.*\((x64|x86)\)"))
                            {
                                return true;
                            }
                        }
                        else
                        {
                            if (Regex.IsMatch(value, @"C\+\+ 2015.*\(x86\)"))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static bool IsVCRunTimeDLLExist(string pathOfCurrentExe)
        {
            bool runTimeExist = false;
            List<string> DllNames = new List<string> { "vcruntime140", "vcruntime140_1", "msvcp140" };
            List<bool> allHere = new List<bool>();
            for (int q = 0; q < DllNames.Count(); q++)
            {
                var path = pathOfCurrentExe + "\\" + DllNames[q] + ".dll";
                if (File.Exists(path))
                {
                    allHere.Add(true);
                }
                else
                {
                    allHere.Add(false);
                }
            }


            foreach(var item in allHere)
            {
                if (!((bool)item))
                {
                    runTimeExist = false;
                    break;
                }
                else
                {
                    runTimeExist = true;
                }
            }


            return runTimeExist;
        }
    }
}
