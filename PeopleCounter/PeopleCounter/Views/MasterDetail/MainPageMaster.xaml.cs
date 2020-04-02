using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PeopleCounter.Views.MasterDetail
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPageMaster : ContentPage
	{
		public ListView ListView;

		public MainPageMaster()
		{
			InitializeComponent();
			if (!DesignMode.IsDesignModeEnabled)
			{
				BindingContext = new MainPageMasterViewModel();
				ListView = MenuItemsListView;
			}
		}

		class MainPageMasterViewModel : INotifyPropertyChanged
		{
			public ObservableCollection<MainPageMasterMenuItem> MenuItems { get; set; }

			public MainPageMasterViewModel()
			{
				MenuItems = new ObservableCollection<MainPageMasterMenuItem>(new[]
				{
					new MainPageMasterMenuItem { Id = 0, Title = "About", ImagePath="drawable/info", TargetType=typeof(AboutPage) },
					new MainPageMasterMenuItem { Id = 1, Title = "Settings", ImagePath="drawable/settings", TargetType=typeof(SettingsPage) },
					new MainPageMasterMenuItem { Id = 2, Title = "Counter 1", ImagePath="drawable/delete", TargetType=typeof(CounterPage) },
					new MainPageMasterMenuItem { Id = 3, Title = "01.04", ImagePath="drawable/delete", TargetType=typeof(CounterPage) },
					new MainPageMasterMenuItem { Id = 4, Title = "02.04", ImagePath="drawable/delete", TargetType=typeof(CounterPage) },
				});
			}

			#region INotifyPropertyChanged Implementation
			public event PropertyChangedEventHandler PropertyChanged;
			void OnPropertyChanged([CallerMemberName] string propertyName = "")
			{
				if (PropertyChanged == null)
					return;

				PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
			#endregion
		}
	}
}