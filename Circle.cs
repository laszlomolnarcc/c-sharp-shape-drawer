using System;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SinusOnCanvas
{
    class Circle : Shape
    {
        public int Diameter {get; set;}
        private double step;
        private double radianY;

        public Circle(int x, int y, double radianY, double step, ColorRotator colorRotator)
            : base(x, y, colorRotator)
        {
            this.step = step;
            this.radianY = radianY;
            LineLength = 2;
            Diameter = 20;
        }

        override public void Draw(Canvas canvas)
        {
            if (lines.Count == 0)
            {
                CreateLines(canvas);
            }

            double radianX = 0;
            foreach (Line line in lines)
            {
                DrawLine(line, 
                    x + Math.Cos(radianX) * Diameter, 
                    y + Math.Sin(radianY) * Diameter,
                    LineLength);
                radianX += step;
                radianY += step;
            }
        }

        override protected void CreateLines(Canvas canvas)
        {
            for (double pointX = 0; pointX < 6.28318531; pointX += step)
            {
                MakeLine(canvas);
            }
        }
    }
}
