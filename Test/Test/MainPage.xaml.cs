using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using ScrollToPosition = Syncfusion.ListView.XForms.ScrollToPosition;

namespace Test
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			this.BindingContext = new MainViewModel();

			InitializeComponent();
		}

		private async void Button_OnClicked(object sender, EventArgs e)
		{
			await((MainViewModel)this.BindingContext).Load();
			
			await Task.Delay(1000);
			this.listView.LayoutManager.ScrollToRowIndex(50, true);
		}
	}
}
