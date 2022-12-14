using SimpleChess.BoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChess.PieceModel {
    public class Pawn : Piece {
        public Pawn(PieceColor pc) : base(PieceType.Pawn, pc) {

        }

        public override bool isLegalMove(Tile piece) {
            return true;
        }
    }
}
