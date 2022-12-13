using SimpleChess.BoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChess.PieceModel {
    public class Bishop : Piece {
        public Bishop(PieceColor pc) : base(PieceType.Bishop, pc) {

        }
        public override bool isLegalMove(Tile piece) {
            return true;
        }
    }
}
