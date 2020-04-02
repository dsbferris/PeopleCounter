using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using Entry = Microcharts.Entry;
using SkiaSharp;

namespace PeopleCounter.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChartPage : ContentPage
	{
		public ChartPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			var entries = new[]
				{
				new Entry(0)
				{
					Label = "14:00",
					ValueLabel = "0",
					Color = SKColor.Parse(Color.Red.ToHex())
				},
				new Entry(20)
				{
					Label = "14:15",
					ValueLabel = "20",
					Color = SKColor.Parse("#266489")
				},
				new Entry(60)
				{
					Label = "14:30",
					ValueLabel = "60",
					Color = SKColor.Parse("#68B9C0")
				},
				new Entry(40)
				{
					Label = "14:45",
					ValueLabel = "40",
					Color = SKColor.Parse("#90D585")
				},
				new Entry(20)
				{
					Label = "15:00",
					ValueLabel = "20",
					Color = SKColor.Parse("#266489")
				},
				new Entry(0)
				{
					Label = "15:15",
					ValueLabel = "0",
					Color = SKColor.Parse("#266489")
				},
			};
			var chart = new LineChart() { Entries = entries };
			chartView.Chart = chart;
		}
	}
}