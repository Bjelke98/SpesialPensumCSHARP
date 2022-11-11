using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Try4.ViewModel;

namespace Try4 {
    public partial class MainWindowViewModel : ObservableObject {

        private HomeViewModel HomeVM { get; set; }
        private GameViewModel GameVM { get; set; }

        [ObservableProperty]
        private object? _currentView;

        //[ObservableProperty]
        //[NotifyCanExecuteChangedFor(nameof(ClickCommand))]
        //private string? firstName = "Bjelke";

        //partial void OnFirstNameChanged(string? value) {

        //}

        [RelayCommand]
        public void HomeView() {
            if (CurrentView==HomeVM) return;
            CurrentView = HomeVM;
        }

        [RelayCommand]
        public void GameView() {
            if (CurrentView == GameVM) return;
            CurrentView = GameVM;
        }

        //private bool CanClick() => FirstName == "Bjelke";

        //[RelayCommand(CanExecute = nameof(CanClick))]
        //private void Click() {
        //    FirstName = "Not Bjelke";
        //}

        public MainWindowViewModel() {
            HomeVM = new HomeViewModel();
            GameVM = new GameViewModel();
            CurrentView = HomeVM;
        }
        
        // Click Command in async
        //[RelayCommand(CanExecute = nameof(CanClick))]
        //private async Task ClickA() {
        //    await Task.Delay(1_000);
        //    FirstName = "Not Bjelke";
        //}





    }
}