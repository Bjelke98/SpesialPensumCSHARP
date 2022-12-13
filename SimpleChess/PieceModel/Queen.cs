using SimpleChess.BoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChess.PieceModel {
    public class Queen : Piece{
        public Queen(PieceColor pc) : base(PieceType.Queen, pc) {

        }

        public override bool isLegalMove(Tile piece) {
            return true;
        }
    }
}
