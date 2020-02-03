using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectOne
{
    public partial class PoBackgroundJob
    {
        static readonly object _backgroundJobSync = new object();
        static Dictionary<string, Task> _backgroundJobs;

        static PoBackgroundJob()
        {
            _backgroundJobs = new Dictionary<string, Task>();
        }

        public static string Enqueue(Expression<Action> methodCall)
        {
            var jobId = PoCommonStrings.GenerateRandomStr();
            var t = new Task(methodCall.Compile());
            t.ContinueWith(CallOnTaskCompleted);
            _backgroundJobs.Add(jobId, t);
            t.Start();
            PoLogger.Log(PoLogSource.Default, PoLogType.Info, $"Background job started: {jobId}");
            return jobId;
        }

        static void CallOnTaskCompleted(Task task)
        {
            lock (_backgroundJobSync)
            {
                foreach (var bj in _backgroundJobs)
                {
                    if (bj.Value != task) continue;
                    PoLogger.Log(PoLogSource.Default, PoLogType.Info, $"Background job completed: {bj.Key}");
                    _backgroundJobs.Remove(bj.Key);
                    break;
                }
            }
        }
    }
}
