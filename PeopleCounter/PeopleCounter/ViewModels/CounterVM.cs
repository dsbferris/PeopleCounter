using PeopleCounter.Models;
using System;

namespace PeopleCounter.ViewModels
{
	public class CounterVM
	{
		public Counter Counter { get; set; }

		public CounterVM()
		{
			Counter = new Counter();
		}

		public void Increment(int n = 1)
		{
			Counter.Plus += n;
			if (Counter.Current > Counter.Max) Counter.Max = Counter.Current;
		}

		public void Decrement(int n = 1)
		{
			Counter.Minus += n;
			if (Counter.Current < Counter.Min) Counter.Min = Counter.Current;
		}

		public void Edit(string s)
		{
			int target = Convert.ToInt32(s);
			if (target > Counter.Current) Increment(target - Counter.Current);
			if (target < Counter.Current) Decrement(target - Counter.Current);
		}

		public void Reset()
		{
			Counter.Max = 0;
			Counter.Min = 0;
			Counter.Plus = 0;
			Counter.Minus = 0;
		}
	}
}
