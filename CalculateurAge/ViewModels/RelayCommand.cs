using System.Windows.Input;

namespace CalculateurAge.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        public RelayCommand(Action execute, 
                            Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }
        
        public bool canExecute(object p) => _canExecute?.Invoke() ?? true;

        public void Execute(object p) => _execute();

        public event EventHandler canExecuteChanged;
        public event EventHandler? CanExecuteChanged;

        public void Refresh()
            => canExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
