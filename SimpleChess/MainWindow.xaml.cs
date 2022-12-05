using SimpleChess.BoardModel;
using SimpleChess.PieceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleChess {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        Board board = new Board();

        public MainWindow() {
            InitializeComponent();
            Piece piece = new Piece();
            VisualBoard.Children.Add(piece);
            board.AddPiece(piece, 0, 0);
            //piece.MouseDown(ClickPiece);
        }

        private void ClickBoard(object sender, MouseButtonEventArgs e) {
            //VisualBoard.Children.Clear();
            Grid grid = (Grid)sender;

            double tileHeight = grid.Height/8;
            double tileWidth = grid.Width/8;

            Point p = e.GetPosition(grid);
            
            Tile selected = board.GetTile((int)(p.X / tileWidth), (int)(p.Y / tileHeight));
            
            if(board.clickState == ClickState.None) {
                if (selected.piece != null) {
                    board.selected = selected;
                    board.clickState = ClickState.Marked;
                }
            } else if(board.clickState==ClickState.Marked) {
                if(board.selected!=null)
                Tile.MovePiece(board.selected, selected);
                board.clickState = ClickState.None;
            }
            //Tile moveTo = board.GetTile(((int)(p.X / tileWidth))+1, ((int)(p.Y / tileHeight))+1);
            //Tile.MovePiece(selected, moveTo);
        }
    }
}
