using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Try4.Model {
    public class Board : Grid {
        public int Size { get; set; }
        public Tile[,] GameGrid { get; set; }

        public Board() : base() {
            GameGrid = new Tile[8, 8];

            for (int i = 0; i < 8; i++) {
                ColumnDefinition cd = new ColumnDefinition();
                ColumnDefinitions.Add(cd);
            }
            for (int i = 0; i < 8; i++) {
                RowDefinition rd = new RowDefinition();
                RowDefinitions.Add(rd);
            }

            for (int i = 0; i < Size; i++) {
                for (int j = 0; j < Size; j++) {
                    Tile tile = new(i, j);
                    GameGrid[i, j] = tile;
                    Rectangle r = tile.Background;
                    Grid.SetRow(r, i);
                    Grid.SetColumn(r, j);
                    Children.Add(r);
                }
            }

            //Tile gt = new Tile('A', 1);
            //Grid.SetColumn(gt, 0);
            //Grid.SetRow(gt, 0);
            
        }

        public void MarkNextLegalMoves(Tile currentTile, PieceType pieceType) {
            // Clear prev
            for(int i = 0; i< Size;i++) {
                for(int j =0; j< Size; j++) {
                    //Grid[i, j].LegalNextMove = false;
                    //Grid[i, j].HasPiece = false;
                }
            }


            // find legal
            switch (pieceType) {
                case PieceType.Knight:
                    //Grid[currentTile.Row + 2, currentTile.Col + 1].LegalNextMove = true;
                    //Grid[currentTile.Row + 2, currentTile.Col - 1].LegalNextMove = true;
                    //Grid[currentTile.Row - 2, currentTile.Col + 1].LegalNextMove = true;
                    //Grid[currentTile.Row - 2, currentTile.Col - 1].LegalNextMove = true;
                    //Grid[currentTile.Row + 1, currentTile.Col + 2].LegalNextMove = true;
                    //Grid[currentTile.Row + 1, currentTile.Col - 2].LegalNextMove = true;
                    //Grid[currentTile.Row - 1, currentTile.Col + 2].LegalNextMove = true;
                    //Grid[currentTile.Row - 1, currentTile.Col - 2].LegalNextMove = true;

                    break;
            }
        }
    }
}
