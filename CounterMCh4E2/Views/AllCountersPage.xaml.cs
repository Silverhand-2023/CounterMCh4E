using CounterMCh4E2.Models;
using System.Diagnostics;

namespace CounterMCh4E2.Views;

public partial class AllCountersPage : ContentPage
{
    private AllCounters allCounters;

    private string[] Colors = { "Red", "Blue", "Green", "Yellow", "Magenta", "Cyan" };

	public AllCountersPage()
	{
        allCounters = new AllCounters();
        BindingContext = allCounters;
        InitializeComponent();
	}

    private void AddCounter_Clicked(object sender, EventArgs e)
    {
        string name = NameEntry.Text;
        string initialValueString = InitialValueEntry.Text;
        int initialValue = 0;
        if(string.IsNullOrWhiteSpace(name) || name.Length == 0)
        {
            ErrorLabel.Text = "Nazwa nie mo¿e byæ pusta";
            ErrorLabel.IsVisible = true;
            return;
        }
        if (name.Length > 20)
        {
            ErrorLabel.Text = "Nazwa nie mo¿e zawieraæ wiêcej ni¿ 20 znaków";
            ErrorLabel.IsVisible = true;
            return;
        }
        if (!int.TryParse(initialValueString, out initialValue))
        {
            ErrorLabel.Text = "Wartoœæ pocz¹tkowa musi byæ liczb¹ ca³kowit¹ lub jest za du¿a";
            ErrorLabel.IsVisible = true;
            return;
        }

        ErrorLabel.IsVisible = false;
        NameEntry.Text = "";
        InitialValueEntry.Text = "";
        int color = ColorPicker.SelectedIndex;
        allCounters.AddCounter(name, initialValue, Colors[color]);
    }
}