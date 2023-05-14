using System;

namespace SeleniumCSharp.Pages
{
    public static class CommonStep
    {
        public static void KillProcessLocally(string processName)
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(processName));
            if (processes.Length == 0)
            {
                Console.WriteLine($"Not found '{processName}' - nothing to kill");
            }
            else
            {
                foreach (System.Diagnostics.Process p in processes)
                {
                    try
                    {
                        p.Kill();
                        Console.WriteLine($"'{processName}' - killed successfully");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Failed to kill '{processName}':");
                        Console.WriteLine($"Exception: {ex}");
                    }
                }
            }
        }
    }
}