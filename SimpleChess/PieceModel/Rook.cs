using SimpleChess.BoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChess.PieceModel {
    public class Rook : Piece {
        public Rook(PieceColor pc) : base(PieceType.Rook, pc) {

        }
        public override bool isLegalMove(Tile piece) {
            return true;
        }
    }
}
