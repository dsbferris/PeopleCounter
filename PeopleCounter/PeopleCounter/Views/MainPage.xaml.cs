using Android.Text.Method;
using PeopleCounter.Models;
using PeopleCounter.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PeopleCounter.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var counters = new List<Counter>();

            var files = Directory.EnumerateFiles(App.FolderPath, "*.counter");
            
            foreach (var filename in files)
            {
                Counter c = CounterFromFile(filename);
                if(c != null)
                    counters.Add(CounterFromFile(filename));
            }

            listView.ItemsSource = counters.OrderBy(d => d.Date).ToList();
        }

        private Counter CounterFromFile(string file)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Counter));
            using (FileStream fs = new FileStream(file, FileMode.Open))
            {
                return (Counter)xml.Deserialize(fs);
            }
        }

        async void OnCounterAddedClicked(object sender, EventArgs e)
        {
            var s = await DisplayPromptAsync("Name", "Enter a name for the counter", placeholder: "CounterX" , keyboard: Keyboard.Text);
            if (!String.IsNullOrEmpty(s))
            {
                await Navigation.PushAsync(new CounterPage
                {
                    BindingContext = new Counter() { Name = s }
                });
            }
            
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new CounterPage
                {
                    BindingContext = e.SelectedItem as Counter
                });
            }
        }
    }
}