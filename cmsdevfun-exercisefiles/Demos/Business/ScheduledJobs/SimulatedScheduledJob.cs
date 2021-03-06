﻿using EPiServer.PlugIn;
using EPiServer.Scheduler;
using System;

namespace AlloyDemo.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = JobName,
        Description = "This job simulates about 20 seconds of work.")]
    public class SimulatedScheduledJob : ScheduledJobBase
    {
        public const string JobName = "Simulated Job";

        private bool _stopSignaled;

        public SimulatedScheduledJob()
        {
            IsStoppable = true;
        }

        /// <summary>
        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            _stopSignaled = true;
        }

        /// <summary>
        /// Called when a scheduled job executes
        /// </summary>
        /// <returns>A status message to be stored in the database log and visible from admin mode</returns>
        public override string Execute()
        {
            //Call OnStatusChanged to periodically notify progress of job for manually started jobs
            OnStatusChanged($"Starting execution of {JobName}...");

            int percent = 0;
            var r = new Random();

            while (percent < 100)
            {
                System.Threading.Thread.Sleep(900);

                percent += r.Next(3, 8);

                OnStatusChanged($"{JobName} is {percent}% complete. Please wait...");

                //For long running jobs periodically check if stop is signaled and if so stop execution
                if (_stopSignaled)
                {
                    return $"Stop of {JobName} was called.";
                }

            }

            return $"{JobName} finished successfully.";
        }
    }
}
