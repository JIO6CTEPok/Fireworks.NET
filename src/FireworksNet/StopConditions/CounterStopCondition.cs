﻿using System;
using System.Threading;
using FireworksNet.Model;

namespace FireworksNet.StopConditions
{
	// Counts something; stops when count exceeds some threshold
	// TODO: Maybe create ControllableCounterStopCondition, that would allow to set counter value explicitly?
	public class CounterStopCondition : IStopCondition
	{
		private int count;

        public int Threshold { get; private set; }

        public CounterStopCondition(int threshold)
        {
			if (threshold < 0)
            {
				throw new ArgumentOutOfRangeException("threshold");
            }

			this.Threshold = threshold;
			this.count = 0;
        }

        public virtual bool ShouldStop(AlgorithmState state)
        {
			return count >= Threshold;
        }

        public virtual void IncrementCounter(object sender, object e)
		{
			Interlocked.Increment(ref count);
		}
	}
}