namespace CounterMCh4E2.Views;
using CounterMCh4E2.Models;
using System.Diagnostics;

public partial class CounterView : ContentView
{
    public static readonly BindableProperty CounterObjectProperty = BindableProperty.Create(nameof(CounterObject), typeof(Models.Counter), typeof(CounterView), null);

    public Counter CounterObject
    {
        get => (Models.Counter)GetValue(CounterView.CounterObjectProperty);
        set => SetValue(CounterView.CounterObjectProperty, value);
    }

	public CounterView()
	{
		InitializeComponent();
	}

    private void Increase_Clicked(object sender, EventArgs e)
    {
        CounterObject.Increase();
    }

    private void Decrease_Clicked(object sender, EventArgs e)
    {
        CounterObject.Decrease();
    }

    private void Reset_Clicked(object sender, EventArgs e)
    {
        CounterObject.Reset();
    }

    private void Remove_Clicked(object sender, EventArgs e)
    {
        CounterObject.RemoveSelf();
    }
}