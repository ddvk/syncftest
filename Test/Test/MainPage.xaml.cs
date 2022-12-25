using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Test
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			this.BindingContext = new MainViewModel();

			InitializeComponent();
		}

		private  async void TabViewEx_OnSelectionChanged(object sender, Syncfusion.XForms.TabView.SelectionChangedEventArgs e)
		{
			if (e.Index >= 1)
			{
				await ((MainViewModel)this.BindingContext).Load();
			} 
		}
	}
}
