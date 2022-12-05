using SimpleChess.PieceModel;
using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace SimpleChess.BoardModel {

    

    public class Tile {
        private static SolidColorBrush light = new SolidColorBrush(Color.FromRgb(255, 198, 184));
        private static SolidColorBrush dark = new SolidColorBrush(Color.FromRgb(255, 106, 71));
        private static SolidColorBrush marked = new SolidColorBrush(Color.FromRgb(149, 245, 66));
        public Rectangle Background { get; }

        public Piece? piece = null;

        public int Col { get; }
        public int Row { get; }

        public Tile(int col, int row) {
            Col = col;
            Row = row;
            Background = new Rectangle();
        }

        public void Mark() {
            Background.Fill = marked;
        }

        public void Unmark() {
            if (Row % 2 == 0) {
                Background.Fill = Col % 2 == 0 ? light : dark;
            } else {
                Background.Fill = Col % 2 == 0 ? dark : light;
            }
        }

        public static void MovePiece(Tile from, Tile to) {
            if(from==to) return;
            to.piece = from.piece; from.piece = null;
            Grid.SetColumn(to.piece, to.Col);
            Grid.SetRow(to.piece, to.Row);
        }

    }
}
