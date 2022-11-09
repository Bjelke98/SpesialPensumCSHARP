using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Try4 {
    public partial class MainWindowViewModel : ObservableObject {

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ClickCommand))]
        private string? firstName = "Bjelke";

        partial void OnFirstNameChanged(string? value) {

        }

        private bool CanClick() => FirstName == "Bjelke";

        [RelayCommand(CanExecute = nameof(CanClick))]
        private void Click() {
            FirstName = "Not Bjelke";
        }
        
        // Click Command in async
        //[RelayCommand(CanExecute = nameof(CanClick))]
        //private async Task ClickA() {
        //    await Task.Delay(1_000);
        //    FirstName = "Not Bjelke";
        //}





    }
}