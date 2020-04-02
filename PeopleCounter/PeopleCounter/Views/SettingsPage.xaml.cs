using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PeopleCounter.Models;
using Xamarin.Essentials;
using PeopleCounter.ViewModels;

namespace PeopleCounter.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		private readonly SettingsVM svm = new SettingsVM();

		public SettingsPage()
		{
			BindingContext = svm;
			InitializeComponent();
		}

		private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			svm.Strenght = ((Settings.VibrationStrenghtEnum)(sender as Picker).SelectedItem);
			Vibration.Vibrate((int)svm.Strenght);
		}

		private async void Button_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new ChartPage());
		}
	}

	
}