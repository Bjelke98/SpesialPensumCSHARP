using SimpleChess.BoardModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace SimpleChess.PieceModel {

    public enum PieceType {
        King = 0,
        Queen = 1,
        Bishop = 2,
        Knight = 3,
        Rook = 4,
        Pawn = 5
    }

    public enum PieceColor {
        Black = 1,
        White = 0
    }

    public abstract class Piece : Image {
        protected static CroppedBitmap MakeSprite(int x, int y, int width, int height) {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(Statics.path + "piecesSheetv2.png");
            bitmapImage.EndInit();

            CroppedBitmap croppedBitmap = new();
            croppedBitmap.BeginInit();
            croppedBitmap.Source = bitmapImage;
            croppedBitmap.SourceRect = new Int32Rect(x, y, width, height);
            croppedBitmap.EndInit();

            return croppedBitmap;
        }

        protected PieceType pieceType;
        protected PieceColor pieceColor;

        private int boxwh = 320;

        public Piece(PieceType pt, PieceColor pc) {
            base.Source= MakeSprite(boxwh*PtValue(pt), boxwh*PcValue(pc), boxwh, boxwh);
            pieceType = pt;
            pieceColor = pc;
        }

        private static int PtValue(PieceType pt) {
            return pt switch {
                PieceType.King => 0,
                PieceType.Queen => 1,
                PieceType.Bishop => 2,
                PieceType.Knight => 3,
                PieceType.Rook => 4,
                PieceType.Pawn => 5,
                _ => -1,
            };
        }
        private static int PcValue(PieceColor pc) {
            return pc switch {
                PieceColor.Black => 1,
                PieceColor.White => 0,
                _ => -1,
            };
        }

        public abstract bool isLegalMove(Tile to);
    }
}
