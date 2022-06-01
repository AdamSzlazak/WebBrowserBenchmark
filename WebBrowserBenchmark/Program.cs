using System;
using OpenQA.Selenium;

namespace WebBrowserBenchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// variables to track memory usage
            //long peakPagedMem = 0, peakWorkingSet = 0, peakVirtualMem = 0;

            //Process[] myProcess = Process.GetProcessesByName("msedge");
            //// Display the process statistics until
            //// the user closes the program.
            //for (int i = 0; i < myProcess.Length; i++)
            //{
            //    do
            //    {
            //        if (!myProcess[i].HasExited)
            //        {
            //            myProcess[i].Refresh();

            //            Console.WriteLine($"{myProcess[i]}");
            //            Console.WriteLine("--------------");

            //            Console.WriteLine($"  Physical memory usage     : {myProcess[i].WorkingSet64}");
            //            Console.WriteLine($"  Base priority             : {myProcess[i].BasePriority}");
            //            Console.WriteLine($"  Priority class            : {myProcess[i].PriorityClass}");
            //            Console.WriteLine($"  User processor time       : {myProcess[i].UserProcessorTime}");
            //            Console.WriteLine($"  Privileged processor time : {myProcess[i].PrivilegedProcessorTime}");
            //            Console.WriteLine($"  Total processor time      : {myProcess[i].TotalProcessorTime}");
            //            Console.WriteLine($"  Paged system memory size  : {myProcess[i].PagedSystemMemorySize64}");
            //            Console.WriteLine($"  Paged memory size         : {myProcess[i].PagedMemorySize64}");

            //            if (peakPagedMem <= myProcess[i].PeakPagedMemorySize64)
            //            {
            //                peakPagedMem = myProcess[i].PeakPagedMemorySize64;
            //            }

            //            if (peakVirtualMem <= myProcess[i].PeakVirtualMemorySize64)
            //            {
            //                peakVirtualMem = myProcess[i].PeakVirtualMemorySize64;
            //            }
            //            if (peakWorkingSet <= myProcess[i].PeakWorkingSet64)
            //            {
            //                peakWorkingSet = myProcess[i].PeakWorkingSet64;
            //            }
            //            if (myProcess[i].Responding)
            //            {
            //                Console.WriteLine("Status = Running");
            //            }
            //            else
            //            {
            //                Console.WriteLine("Status = Not Responding");
            //            }
            //        }
            //    } while (!myProcess[i].WaitForExit(1000));
            //}
            //Console.WriteLine();


            //// Display peak memory statistics for the process.
            //Console.WriteLine("ddddupa");
            //Console.WriteLine($"  Peak physical memory usage : {peakWorkingSet / (8 * 1024)}KB");
            //Console.WriteLine($"  Peak paged memory usage    : {peakPagedMem / (8 * 1024)}KB");
            //Console.WriteLine($"  Peak virtual memory usage  : {peakVirtualMem / (8 * 1024)}KB");

            string webEngineDirectory = System.IO.Directory.GetCurrentDirectory();
            webEngineDirectory = webEngineDirectory.Remove(webEngineDirectory.Length - 36, 36) + "WebEngines";

            var edge = EdgeHelper.setEdge(webEngineDirectory);
            string[] dupa = { "youtube", "instagram", "reddit" };
            int sec = 5;
            for (int i = 0; i < dupa.Length; i++)
            {
                EdgeHelper.openPage(edge, dupa[i]);

                switch (dupa[i])
                {
                    case "youtube":
                        Console.WriteLine("DUPA");
                        EdgeHelper.acceptCookie(edge);
                        System.Threading.Thread.Sleep(sec * 1000);
                        break;
                    case "instagram":
                        EdgeHelper.acceptCookie(edge);
                        EdgeHelper.logInToWebsite(edge);
                        for (int j = 0; j < 10; j++)
                        {
                            EdgeHelper.performAction(edge);
                        }
                        System.Threading.Thread.Sleep(sec * 1000);

                        break;
                    default:
                        break;
                }
            }
            //void openWebsite  
            edge.Quit();
        }
    }

}
