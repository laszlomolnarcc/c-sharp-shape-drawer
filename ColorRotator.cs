using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SinusOnCanvas
{
    public class SignedColor
    {
        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }
        public int A { get; set; }

        public SignedColor(int r, int g, int b, int a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }

    public class ColorRotator
    {
        SignedColor colorChanger;
        private Color actualColor;
 
        public ColorRotator(Color startColor, SignedColor colorChanger)
        {
            actualColor = startColor;
            this.colorChanger = colorChanger;
        }

        public Color getColor()
        {
            RotateColors();
            return actualColor;
        }

        private void RotateColors()
        {
            // this could have been simplified to remove most of the repetition. How? :)
            if (IsChangeValid(actualColor.R, colorChanger.R))
                actualColor.R = (byte)(actualColor.R + colorChanger.R);
            else colorChanger.R = -colorChanger.R;

            if (IsChangeValid(actualColor.G, colorChanger.G))
                actualColor.G = (byte)(actualColor.G + colorChanger.G);
            else colorChanger.G = -colorChanger.G;

            if (IsChangeValid(actualColor.B, colorChanger.B))
                actualColor.B = (byte)(actualColor.B + colorChanger.B);
            else colorChanger.B = -colorChanger.B;

            if (IsChangeValid(actualColor.A, colorChanger.A))
                actualColor.A = (byte)(actualColor.A + colorChanger.A);
            else colorChanger.A = -colorChanger.A;
        }

        private bool IsChangeValid(byte color, int change)
        {
            int result = color + change;
            if (result <= 255 && result >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
