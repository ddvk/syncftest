using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms.Internals;

namespace Test
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public MainViewModel()
		{
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(field, value)) return false;
			field = value;
			OnPropertyChanged(propertyName);
			return true;
		}

		private LayoutState _currentState = LayoutState.None;
		public LayoutState CurrentState
		{
			get => this._currentState;
			set => SetField(ref this._currentState, value);
		}

		public ObservableCollection<int> Items { get; set; } = new();

		public async Task Load()
		{
			CurrentState = LayoutState.Loading;

			await Task.Delay(300);

			Enumerable.Range(0, 100).ForEach(x => Items.Add(x));

			CurrentState = LayoutState.None;
		}
	}
}
