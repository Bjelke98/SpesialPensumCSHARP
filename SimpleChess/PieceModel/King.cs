using SimpleChess.BoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChess.PieceModel {
    public class King : Piece {
        public King(PieceColor pc) : base(PieceType.King, pc) {
        }

        public override bool isLegalMove(Tile to) {
            return true;
        }
    }
}
