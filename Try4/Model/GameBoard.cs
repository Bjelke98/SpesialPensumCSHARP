using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Try4.Model
{
    public class GameBoard : Grid {

        private GameTile[,] tiles = new GameTile[8,8];

        public GameBoard() : base() {
            ShowGridLines = true;
            for (int i = 0; i < 8; i++) {
                ColumnDefinition cd = new ColumnDefinition();
                //cd.Width = new GridLength(1, GridUnitType.Star);
                ColumnDefinitions.Add(cd);
            }
            for (int i = 0; i < 8; i++) {
                RowDefinition rd = new RowDefinition();
                //rd.Height = new GridLength(1, GridUnitType.Star);
                RowDefinitions.Add(rd);
            }
            GameTile gt = new GameTile('A', 1);
            Grid.SetColumn(gt, 0);
            Grid.SetRow(gt, 0);
            Children.Add(gt);
        }
    }
}
