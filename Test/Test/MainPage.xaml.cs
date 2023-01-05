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

		private async void Button_OnClickedAsync(object sender, EventArgs e)
		{
			await((MainViewModel)this.BindingContext).LoadAsync();
			this.listView.LayoutManager.ScrollToRowIndex(50, true);
		}

		private async void Button_OnClickedAsyncMainThread(object sender, EventArgs e)
		{
			await((MainViewModel)this.BindingContext).LoadAsyncMainThread();
			this.listView.LayoutManager.ScrollToRowIndex(50, true);
		}

		private void Button_OnClickedSync(object sender, EventArgs e)
		{
			((MainViewModel)this.BindingContext).LoadSync();
			this.listView.LayoutManager.ScrollToRowIndex(50, true);
		}

		private void Button_OnClickedSyncMainThread(object sender, EventArgs e)
		{
			((MainViewModel)this.BindingContext).LoadSyncMainThread();
			this.listView.LayoutManager.ScrollToRowIndex(50, true);
		}
	}
}
