using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne
{
    public partial class PoBackgroundJob
    {
        private static readonly object Sync = new object();
        private static readonly Dictionary<string, Task> BackgroundJobs;

        static PoBackgroundJob()
        {
            BackgroundJobs = new Dictionary<string, Task>();
        }

        public static string Enqueue(Expression<Action> methodCall, string name = null)
        {
            lock (Sync)
            {
                var randStr = PoCommonStrings.GenerateRandomStr();
                var jobId = string.IsNullOrWhiteSpace(name) ? randStr : $"{name}_{randStr}";
                var t = new Task(methodCall.Compile());
                t.ContinueWith(CallOnTaskCompleted);
                BackgroundJobs.TryAdd(jobId, t);
                t.Start();
                PoLogger.Log(PoLogSource.Default, PoLogType.Info, $"Background job started: {jobId}");
                return jobId;
            }
        }

        static void CallOnTaskCompleted(Task task)
        {
            lock (Sync)
            {
                foreach (var bj in BackgroundJobs)
                {
                    if (bj.Value != task) continue;
                    PoLogger.Log(PoLogSource.Default, PoLogType.Info, $"Background job completed: {bj.Key}");
                    BackgroundJobs.Remove(bj.Key);
                    break;
                }
            }
        }
    }
}
