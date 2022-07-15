using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace NetAz_UpAndDown.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private int _value;

        private readonly ObservableCollection<int> _items;

        public ObservableCollection<int> Items
        {
            get
            {
                return _items;
            }
        }

        public int Value
        {
            get
            {
                return _value;
            }

            set
            {
                if (_value != value)
                {
                    _value = value;
                    //Thread Safe
                    PropertyChangedEventHandler? propertyChanged = PropertyChanged;
                    propertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                }
            }
        }

        public MainViewModel()
        {
            _items = new ObservableCollection<int>() { 0, 1, 2, 4, 5 };            
        }

        private ICommand? _incrementCommand;
        public ICommand IncrementCommand
        {
            get
            {
                return _incrementCommand ??= new DelegateCommand(Increment, CanIncrement);
            }
        }

        #region Commandes
        private void Increment()
        {
            Value++;
        }

        private bool CanIncrement()
        {
            return Value < 9;
        }

        private ICommand? _decrementCommand;
        public ICommand DecrementCommand
        {
            get
            {
                return _decrementCommand ??= new DelegateCommand(Decrement, CanDecrement);
            }
        }

        private void Decrement()
        {
            Value--;
        }

        private bool CanDecrement()
        {
            return Value > 0;
        }

        private ICommand? _addCommand;
        public ICommand AddCommand
        {
            get
            {
                return _addCommand ??= new DelegateCommand(Add);
            }
        }

        private void Add()
        {
            Items.Add(Value);
            if (Items.Count > 10)
                Items.Clear();
        }
        #endregion
    }
}