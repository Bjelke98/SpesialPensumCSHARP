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
    public class Piece : Image {
        protected static CroppedBitmap MakeSprite(int x, int y, int width, int height) {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(Statics.path + "piecesSheet.png");
            bitmapImage.EndInit();

            CroppedBitmap croppedBitmap = new CroppedBitmap();
            croppedBitmap.BeginInit();
            croppedBitmap.Source = bitmapImage;
            croppedBitmap.SourceRect = new Int32Rect(0, 0, (int)bitmapImage.Width / 6, (int)bitmapImage.Height / 2);
            croppedBitmap.EndInit();

            return croppedBitmap;
        }
        
        public Piece() {
            base.Source= MakeSprite(0, 0, 0, 0);
        }
    }
}
