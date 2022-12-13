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

            StartGame();

            
            //piece.MouseDown(ClickPiece);
        }

        private void StartGame() {
            // Brint board grid
            board.PrintBG(VisualBoard);

            // Add White Pieces

            // // Pawn
            for (int i = 0; i < 8; i++) {
                AddBoth(new Pawn(PieceColor.White), 6, i);
            }
            // // Rook
            AddBoth(new Rook(PieceColor.White), 7, 0);
            AddBoth(new Rook(PieceColor.White), 7, 7);
            // // Knight
            AddBoth(new Knight(PieceColor.White), 7, 1);
            AddBoth(new Knight(PieceColor.White), 7, 6);
            // // Bishop
            AddBoth(new Bishop(PieceColor.White), 7, 2);
            AddBoth(new Bishop(PieceColor.White), 7, 5);
            // // Queen
            AddBoth(new Queen(PieceColor.White), 7, 3);
            // // King
            AddBoth(new King(PieceColor.White), 7, 4);

            // Add Black Pieces

            // // Pawn
            for (int i = 0; i < 8; i++) {
                AddBoth(new Pawn(PieceColor.Black), 1, i);
            }
            // // Rook
            AddBoth(new Rook(PieceColor.Black), 0, 0);
            AddBoth(new Rook(PieceColor.Black), 0, 7);
            // // Knight
            AddBoth(new Knight(PieceColor.Black), 0, 1);
            AddBoth(new Knight(PieceColor.Black), 0, 6);
            // // Bishop
            AddBoth(new Bishop(PieceColor.Black), 0, 2);
            AddBoth(new Bishop(PieceColor.Black), 0, 5);
            // // Queen
            AddBoth(new Queen(PieceColor.Black), 0, 3);
            // // King
            AddBoth(new King(PieceColor.Black), 0, 4);
        }

        private void AddBoth(Piece piece, int row, int col) {
            VisualBoard.Children.Add(piece);
            board.AddPiece(piece, col, row);
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
                    selected.Mark();
                }
            } else if(board.clickState==ClickState.Marked) {
                if(board.selected!=null)
                    Tile.MovePiece(board.selected, selected, grid);
                board.clickState = ClickState.None;
            }
            //Tile moveTo = board.GetTile(((int)(p.X / tileWidth))+1, ((int)(p.Y / tileHeight))+1);
            //Tile.MovePiece(selected, moveTo);
        }
    }
}
