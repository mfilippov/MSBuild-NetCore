using Task = Microsoft.Build.Utilities.Task;

namespace MyTasks
{
    public class MyTask : Task
    {
        public string Param1 { get; set; }

        public override bool Execute()
        {
            Log.LogMessage($"Hello from MyTask. Param1 = '{Param1}'");

            return !Log.HasLoggedErrors;
        }
    }
}