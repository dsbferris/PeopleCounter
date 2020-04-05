﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;

namespace PeopleCounter.Models
{
	public class Counter : INotifyPropertyChanged
	{
		private int max;
		private int min;
		private int plus;
		private int minus;
		private Color lastclick;
		private string name;

		public int Max { get { return max; } set { max = value; OnPropertyChanged("Max"); } }
		public int Min { get { return min; } set { min = value; OnPropertyChanged("Min"); } }
		public int Plus { get { return plus; } set { plus = value; OnPropertyChanged("Plus"); OnPropertyChanged("Current"); } }
		public int Minus { get { return minus; } set { minus = value; OnPropertyChanged("Minus"); OnPropertyChanged("Current"); } }
		public int Current => Plus - Minus;
		public string Name { get { return name; } set { name = value; OnPropertyChanged("Name"); } }

		public Color LastClick { get { return lastclick; } set { lastclick = value; OnPropertyChanged("LastClick"); } }


		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
