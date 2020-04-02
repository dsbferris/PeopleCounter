﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PeopleCounter.Views.MasterDetail
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			InitializeComponent();
			MasterPage.ListView.ItemSelected += ListView_ItemSelected;
		}

		private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (!(e.SelectedItem is MainPageMasterMenuItem item))
				return;

			var page = (Page)Activator.CreateInstance(item.TargetType);
			page.Title = item.Title;

			Detail = new NavigationPage(page) { BarBackgroundColor = Color.RoyalBlue };
			IsPresented = false;

			MasterPage.ListView.SelectedItem = null;
		}
	}
}