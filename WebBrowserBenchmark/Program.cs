using System.Diagnostics;
using System.ComponentModel;

Process[] testProcess = Process.GetProcesses();
Console.WriteLine("Lista pobranych procesów:");
for(int i = 0; i < testProcess.Length; i++)
{
    Console.WriteLine(testProcess[i]);
}

Process[] listEdgeProcesses = Process.GetProcessesByName("msedge");
Console.WriteLine();
Console.WriteLine("Procesy edge");
foreach(Process process in listEdgeProcesses)
{
    Console.WriteLine(process.NonpagedSystemMemorySize64);
}