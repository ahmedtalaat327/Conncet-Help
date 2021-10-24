using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.Win32;
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
    }
}
