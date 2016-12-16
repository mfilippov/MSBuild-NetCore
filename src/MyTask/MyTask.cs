using System;
using System.Diagnostics;
using System.Threading;
using Task = Microsoft.Build.Utilities.Task;

namespace MyTasks
{
    public class MyTask : Task
    {
        public string Param1 { get; set; }

        public override bool Execute()
        {
            Log.LogMessage($"Hello from MyTask. Param1 = '{Param1}'");

            TimeSpan sleepTime = TimeSpan.FromSeconds(3);

            Log.LogMessage($"Sleeping for {sleepTime.TotalSeconds:N0} second(s)");
            Thread.Sleep((int)sleepTime.TotalMilliseconds);
            Log.LogMessage("Done");

            Log.LogMessage($"There are {System.Diagnostics.Process.GetProcesses().Length} processes running");

            return !Log.HasLoggedErrors;
        }
    }
}