using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Try4.Model;

namespace Try4.ViewModel
{
    public partial class GameViewModel : ObservableObject {

        [ObservableProperty]
        private object? currentGame;

        [ObservableProperty]
        private GameBoard board;

        public GameViewModel() {

            Board = new GameBoard();
            Board.Height = 700;
            Board.Width = 700;
           

            currentGame = board;
        }
    }
}
