using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using PeopleCounter.Models;
using static PeopleCounter.Models.Settings;

namespace PeopleCounter.ViewModels
{
	public class SettingsVM : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public bool KeepDisplayOn { get => Settings.KeepDisplayOn; set { Settings.SetKeepDisplayOn(value); OnPropertyChanged("KeepDisplayOn"); } }

		public bool PlaySound { get => Settings.PlaySound; set { Settings.SetPlaySound(value); OnPropertyChanged("PlaySound"); } }

		public Settings.VibrationStrenghtEnum Strenght { get => Settings.Strenght; set { Settings.SetStrenght(value); OnPropertyChanged("Strenght"); }  }

		public List<VibrationStrenghtEnum> StrenghtEnums => new List<VibrationStrenghtEnum>() {
				VibrationStrenghtEnum.Off,
				VibrationStrenghtEnum.Minimal,
				VibrationStrenghtEnum.Weak,
				VibrationStrenghtEnum.Medium,
				VibrationStrenghtEnum.Strong,
				VibrationStrenghtEnum.Overkill };

	}
}
