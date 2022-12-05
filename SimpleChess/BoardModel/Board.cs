using SimpleChess.PieceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChess.BoardModel {

    public enum ClickState {
        None,
        Marked
    }

    public class Board {
        private Tile[,] tiles = new Tile[8, 8];
        public Tile? selected { get; set; } = null;
        public ClickState clickState { get; set; } = ClickState.None;

        public Board() { 
            for(int i = 0; i < 8; i++) {
                for(int j = 0; j < 8; j++) {
                    tiles[i, j] = new Tile(i, j);
                }
            }
        }

        public void AddPiece(Piece piece, int col, int row) {
            tiles[col, row].piece = piece;
        }

        public Tile GetTile(int col, int row) {
            return tiles[col, row];
        }
    }
}
