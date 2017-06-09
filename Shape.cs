using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SinusOnCanvas
{
    public abstract class Shape
    {
        public int LineLength { get; set; }
        protected List<Line> lines = new List<Line>();
        protected ColorRotator color;
        protected int x;
        protected int y;

        public abstract void Draw(Canvas canvas);
        protected abstract void CreateLines(Canvas canvas);

        public Shape(int x, int y, ColorRotator colorRotator)
        {
            this.x = x;
            this.y = y;
            color = colorRotator;
        }

        protected void DrawLine(Line line, double x, double y, double lengthY)
        {
            DrawLine(line, x, x, y, y + lengthY);
        }

        protected void DrawLine(Line line, double x1, double x2, double y1, double y2)
        {
            SolidColorBrush brush = new SolidColorBrush();
            brush.Color = color.getColor();
            line.Stroke = brush;
            line.X1 = x1;
            line.X2 = x2;
            line.Y1 = y1;
            line.Y2 = y2;
        }

        protected void MakeLine(Canvas canvas)
        {
            Line myLine = new Line();
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;
            myLine.StrokeThickness = 2;
            lines.Add(myLine);
            canvas.Children.Add(myLine);
        }
    }
}
