using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Try4.Model
{
    class GameTile : StackPanel {

        public GameCoordinate coordinate { get; }

        public GameTile(GameCoordinate gameCoordinate) : base() {
            coordinate = gameCoordinate;
        }

        public GameTile(char col, int row) : this(new GameCoordinate(col, row)) {

        }
    }
}
