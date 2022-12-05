using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Try4.Model {
    public class Tile {
        private static readonly SolidColorBrush Light = new(Color.FromRgb(255, 198, 184));
        private static readonly SolidColorBrush Dark = new(Color.FromRgb(255, 106, 71));
        
        public Rectangle Background { get; }

        public int Row { get; set; }
        public int Col { get; set; }
        public bool HasPiece { get; set; }
        public bool LegalNextMove { get; set; }

        private bool IsLight = false;
        public Tile(int row, int col) {
            Background = new Rectangle();
            if(
                (row % 2 == 0 && col % 2 == 0) || 
                (row % 2 != 0 && col % 2 != 0)
            ) {
                IsLight = true;
            }
            ResetFill();
            Row = row;
            Col = col;
        }

        public void ResetFill() {
            if (IsLight) {
                Background.Fill = Light;
            } else {
                Background.Fill = Dark;
            }
        }
    }
}
