using SimpleChess.BoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChess.PieceModel {
    public class Knight : Piece {
        public Knight(PieceColor pc) : base(PieceType.Knight, pc) {

        }
        public override bool isLegalMove(Tile piece) {
            return true;
        }
    }
}
