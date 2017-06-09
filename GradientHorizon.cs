using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

// This class is not used because I haven't had the time to sort out a drawing order bug
// If you can fix it, let me know. :)
namespace SinusOnCanvas
{
    public class GradientHorizon : Shape
    {
        public GradientHorizon(ColorRotator colorRotator)
            : base(1, 1, colorRotator)
        {
        }

        override public void Draw(Canvas canvas)
        {
            if (lines.Count == 0)
            {
                CreateLines(canvas);
            }

            int x2 = x + LineLength;
            int offsetY = y;
            foreach (Line line in lines)
            {
                DrawLine(line, x, x2, offsetY, offsetY);
                offsetY += 2;
            }
        }

        override protected void CreateLines(Canvas canvas)
        {
            LineLength = (int)canvas.RenderSize.Width;
            int numOfLines = (int)(canvas.RenderSize.Width / 2);
            for (double pointX = 0; pointX < numOfLines; ++pointX)
            {
                MakeLine(canvas);
            }
        }
    }
}
