using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
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

		private string _beforeOperation = null;
		public string BeforeOperation
		{
			get => this._beforeOperation;
			set => SetField(ref this._beforeOperation, value);
		}

		private string _duringOperation = null;
		public string DuringOperation
		{
			get => this._duringOperation;
			set => SetField(ref this._duringOperation, value);
		}

		private string _afterOperation = null;
		public string AfterOperation
		{
			get => this._afterOperation;
			set => SetField(ref this._afterOperation, value);
		}

		public async Task LoadAsync()
		{
			this.BeforeOperation = this.DuringOperation = this.AfterOperation = null;

			this.BeforeOperation = MainThread.IsMainThread ? "on main thread" : "on other thread";
			CurrentState = LayoutState.Loading;

			this.DuringOperation = MainThread.IsMainThread ? "on main thread" : "on other thread";
			Enumerable.Range(0, 100).ForEach(x => Items.Add(x));

			CurrentState = LayoutState.None;
			this.AfterOperation = MainThread.IsMainThread ? "on main thread" : "on other thread";

			await Task.CompletedTask;
		}

		public async Task LoadAsyncMainThread()
		{
			this.BeforeOperation = this.DuringOperation = this.AfterOperation = null;

			this.BeforeOperation = MainThread.IsMainThread ? "on main thread" : "on other thread";
			CurrentState = LayoutState.Loading;

			Device.BeginInvokeOnMainThread(() =>
			{
				this.DuringOperation = MainThread.IsMainThread ? "on main thread" : "on other thread";
				Enumerable.Range(0, 100).ForEach(x => Items.Add(x));
			});

			CurrentState = LayoutState.None;
			this.AfterOperation = MainThread.IsMainThread ? "on main thread" : "on other thread";

			await Task.CompletedTask;
		}

		public void LoadSync()
		{
			this.BeforeOperation = this.DuringOperation = this.AfterOperation = null;

			this.BeforeOperation = MainThread.IsMainThread ? "on main thread" : "on other thread";
			CurrentState = LayoutState.Loading;

			this.DuringOperation = MainThread.IsMainThread ? "on main thread" : "on other thread";
			Enumerable.Range(0, 100).ForEach(x => Items.Add(x));

			CurrentState = LayoutState.None;
			this.AfterOperation = MainThread.IsMainThread ? "on main thread" : "on other thread";
		}

		public void LoadSyncMainThread()
		{
			this.BeforeOperation = this.DuringOperation = this.AfterOperation = null;

			this.BeforeOperation = MainThread.IsMainThread ? "on main thread" : "on other thread";
			CurrentState = LayoutState.Loading;

			Device.BeginInvokeOnMainThread(() =>
			{
				this.DuringOperation = MainThread.IsMainThread ? "on main thread" : "on other thread";
				Enumerable.Range(0, 100).ForEach(x => Items.Add(x));
			});

			CurrentState = LayoutState.None;
			this.AfterOperation = MainThread.IsMainThread ? "on main thread" : "on other thread";
		}
	}
}
