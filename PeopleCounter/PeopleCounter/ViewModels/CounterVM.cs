using PeopleCounter.Models;
using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PeopleCounter.ViewModels
{
	public class CounterVM
	{
		public Counter Counter { get; set; }
		public ICommand Increment { get; set; }
		public ICommand Decrement { get; set; }

		public CounterVM()
		{
			Counter = new Counter();

			Increment = new Command(() =>
			{
				increment();
			});
			Decrement = new Command(() =>
			{
				decrement();
			});
		}

		private void increment(int n = 1)
		{
			Counter.Plus += n;
			Counter.LastClick = Color.Green;
			if (Counter.Current > Counter.Max) Counter.Max = Counter.Current;
			if(Settings.Strenght > 0)
				Vibration.Vibrate((int)Settings.Strenght);
			if (Settings.PlaySound)
			{
				var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
				player.Load("Click1.wav");
				player.Play();
			}
		}

		private void decrement(int n = 1)
		{
			Counter.Minus += n;
			Counter.LastClick = Color.Red;
			if (Counter.Current < Counter.Min) Counter.Min = Counter.Current;

			if(Settings.Strenght > 0)
				Vibration.Vibrate((int)Settings.Strenght);
			if (Settings.PlaySound)
			{
				var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
				player.Load("Click2.wav");
				player.Play();
			}
		}

		public void Edit(string s)
		{
			int target = Convert.ToInt32(s);
			if (target > Counter.Current) increment(target - Counter.Current);
			if (target < Counter.Current) decrement(target - Counter.Current);
		}

		public void Reset()
		{
			Counter.Max = 0;
			Counter.Min = 0;
			Counter.Plus = 0;
			Counter.Minus = 0;
			Counter.LastClick = Color.Black;
		}
	}
}
