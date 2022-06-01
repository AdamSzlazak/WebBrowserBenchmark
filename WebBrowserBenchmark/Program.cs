using System;
using OpenQA.Selenium;
using System.Diagnostics;
namespace WebBrowserBenchmark
{
    internal class Program
    {
        public void StopProc(Process processName)
        {
            processName.Kill();
        }
        public static void processValues(string processName, int time)
        {
            // variables to track memory usage
            long peakPagedMem = 0, peakWorkingSet = 0, peakVirtualMem = 0, physMemAverage = 0, pagedMemAverage = 0;
            int exitTime = 0;
            Process[] myProcess = Process.GetProcessesByName(processName);
            // Display the process statistics until
            // the user closes the program.
            for (int i = 0; i < myProcess.Length; i++)
            {
                do
                {
                    if (!myProcess[i].HasExited)
                    {
                        myProcess[i].Refresh();

                        Console.WriteLine($"{myProcess[i]}");
                        Console.WriteLine("--------------");

                        Console.WriteLine($"  Process ID                  : {myProcess[i].Id}");
                        Console.WriteLine($"  Physical memory usage       : {myProcess[i].WorkingSet64 / (8 * 1024)}KB");
                        Console.WriteLine($"  Base priority               : {myProcess[i].BasePriority}");
                        Console.WriteLine($"  Priority class              : {myProcess[i].PriorityClass}");
                        Console.WriteLine($"  User processor time         : {myProcess[i].UserProcessorTime}");
                        Console.WriteLine($"  Privileged processor time   : {myProcess[i].PrivilegedProcessorTime}");
                        Console.WriteLine($"  Total processor time        : {myProcess[i].TotalProcessorTime}");
                        Console.WriteLine($"  Pageable system memory size : {myProcess[i].PagedSystemMemorySize64 / (8 * 1024)}KB");
                        Console.WriteLine($"  Paged memory size           : {myProcess[i].PagedMemorySize64 / (8 * 1024)}KB");

                        physMemAverage += myProcess[i].PeakWorkingSet64;
                        pagedMemAverage += myProcess[i].PagedSystemMemorySize64;

                        if (peakPagedMem <= myProcess[i].PeakPagedMemorySize64)
                        {
                            peakPagedMem = myProcess[i].PeakPagedMemorySize64;
                        }

                        if (peakVirtualMem <= myProcess[i].PeakVirtualMemorySize64)
                        {
                            peakVirtualMem = myProcess[i].PeakVirtualMemorySize64;
                        }
                        if (peakWorkingSet <= myProcess[i].PeakWorkingSet64)
                        {
                            peakWorkingSet = myProcess[i].PeakWorkingSet64;
                        }
                        if (myProcess[i].Responding)
                        {
                            Console.WriteLine("Status = Running");
                        }
                        else
                        {
                            Console.WriteLine("Status = Not Responding");
                        }
                        exitTime += 1;
                        if (exitTime == time)
                        {
                            Console.WriteLine($"  Peak physical memory usage : {peakWorkingSet / (8 * 1024)}KB");
                            Console.WriteLine($"  Peak paged memory usage    : {peakPagedMem / (8 * 1024)}KB");
                            Console.WriteLine($"  Peak virtual memory usage  : {peakVirtualMem / (8 * 1024)}KB");
                            Console.WriteLine($"  Average physical memory usage in {time} seconds : {physMemAverage / time / (8 * 1024)}KB");
                            Console.WriteLine($"  Average physical memory usage in {time} seconds : {pagedMemAverage / time / (8 * 1024)}KB");
                            Console.WriteLine($"  Total processor time        : {myProcess[i].TotalProcessorTime}");
                            Console.WriteLine();
                            return;
                        }
                    }
                } while (!myProcess[i].WaitForExit(2000));
            }


        }
        static void Main(string[] args)
        {
            string webEngineDirectory = System.IO.Directory.GetCurrentDirectory();
            webEngineDirectory = webEngineDirectory.Remove(webEngineDirectory.Length - 36, 36) + "WebEngines";


            //var edge = EdgeHelper.setEdge(webEngineDirectory);
            //string[] dupa = { "youtube", "instagram", "reddit" };
            //int sec = 5;
            //for (int i = 0; i < dupa.Length; i++)
            //{
            //    EdgeHelper.openPage(edge, dupa[i]);

            //    switch (dupa[i])
            //    {
            //        case "youtube":
            //            Console.WriteLine("DUPA");
            //            EdgeHelper.acceptCookie(edge);
            //            processValues("msedge", 5);
            //            System.Threading.Thread.Sleep(sec * 1000);
            //            break;
            //        case "instagram":
            //            EdgeHelper.acceptCookie(edge);
            //            EdgeHelper.logInToWebsite(edge);
            //            EdgeHelper.performAction(edge);
            //            processValues("msedge", 5);
            //            System.Threading.Thread.Sleep(sec * 1000);

            //            break;
            //        case "reddit":
            //            EdgeHelper.acceptCookie(edge);
            //            EdgeHelper.performAction(edge);
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //edge.Quit();

            var firefox = FirefoxHelper.setFirefox(webEngineDirectory);
            string[] dupa = { "youtube", "instagram", "reddit" };
            int sec = 5;


            for (int i = 1; i < dupa.Length; i++)
            {
                FirefoxHelper.openPage(firefox, dupa[i]);

                switch (dupa[i])
                {
                    case "youtube":
                        Console.WriteLine("DUPA");
                        FirefoxHelper.acceptCookie(firefox);
                        FirefoxHelper.performAction(firefox);
                        processValues("msedge", 5);
                        System.Threading.Thread.Sleep(sec * 1000);
                        break;
                    case "instagram":
                        FirefoxHelper.acceptCookie(firefox);
                        FirefoxHelper.logInToWebsite(firefox);
                        FirefoxHelper.performAction(firefox);
                        processValues("msedge", 5);
                        System.Threading.Thread.Sleep(sec * 1000);

                        break;
                    case "reddit":
                        FirefoxHelper.acceptCookie(firefox);
                        FirefoxHelper.performAction(firefox);
                        break;
                    default:
                        break;
                }
            }
            firefox.Quit();
        }
    }

}
