using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CounterMCh4E2.Models
{
    public partial class Counter : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int InitialValue { get; set; }
        public string Color { get; set; }

        public AllCounters Parent;

        public event PropertyChangedEventHandler? PropertyChanged;

        public Counter(AllCounters parent, string name, int initialValue, int value, string color)
        {
            Parent = parent;
            Name = name;
            InitialValue = initialValue;
            Value = value;
            Color = color;
        }

        private void NotifyValuePropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
        }

        public void Increase()
        {
            if (Value >= int.MaxValue)
                return;
            Value++;
            Parent.SaveCounters();
            NotifyValuePropertyChanged();
        }

        public void Decrease()
        {
            if (Value <= int.MinValue)
                return;
            Value--;
            Parent.SaveCounters();
            NotifyValuePropertyChanged();
        }

        public void Reset()
        {
            Value = InitialValue;
            Parent.SaveCounters();
            NotifyValuePropertyChanged();
        }

        public void RemoveSelf()
        {
            Parent.RemoveCounter(this);
        }
    }
}
