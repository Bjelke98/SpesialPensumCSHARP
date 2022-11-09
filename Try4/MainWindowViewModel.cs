using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Windows.Input;

namespace Try4 {
    public partial class MainWindowViewModel : ObservableObject {

        [ObservableProperty]
        private string firstName = "Bjelke";

        public ICommand ClickCommand { get; }

        public MainWindowViewModel() {
            ClickCommand = new RelayCommand(OnClick);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnClick() {
            FirstName = "Not Bjelke";
        }

    }
}