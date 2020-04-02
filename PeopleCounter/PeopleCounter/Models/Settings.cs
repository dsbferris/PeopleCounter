using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;

namespace PeopleCounter.Models
{
	public static partial class Settings
	{
		public static bool KeepDisplayOn => Preferences.Get("KeepDisplayOn", true); 
		public static void SetKeepDisplayOn(bool value)
		{
			DeviceDisplay.KeepScreenOn = value;
			Preferences.Set("KeepDisplayOn", value); 
		}

		public static bool PlaySound => Preferences.Get("PlaySound", false); 
		public static void SetPlaySound(bool value)
		{ 
			Preferences.Set("PlaySound", value);
		}

		public static VibrationStrenghtEnum Strenght => (VibrationStrenghtEnum)Preferences.Get("Strenght", (int)VibrationStrenghtEnum.Medium);
		public static void SetStrenght(VibrationStrenghtEnum value)
		{ 
			Preferences.Set("Strenght", (int)value);
		}
	}

	public static partial class Settings
	{
		public enum VibrationStrenghtEnum : int
		{
			Off = 0,
			Minimal = 1,
			Weak = 10,
			Medium = 40,
			Strong = 100,
			Overkill = 300
		}
	}
}
