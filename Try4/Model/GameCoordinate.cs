using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try4.Model
{
    public class GameCoordinate {
        public char col { get; }
        public int row { get; }
        public GameCoordinate(char col, int row) {
            this.col = col;
            this.row = row;
        }
    }
}
