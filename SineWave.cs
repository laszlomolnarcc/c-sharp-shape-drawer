using System;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SinusOnCanvas
{

    public class SineWave : Shape
    {
        public double WaveLength { get; set; }
        private double radianY;
        private double waveSpeed;

        public SineWave(double radianY, int y, double waveSpeed, ColorRotator colorRotator)
            : base(1, y, colorRotator)
        {
            this.radianY = radianY;
            this.waveSpeed = waveSpeed;
            WaveLength = 20;
            LineLength = 100;
        }

        override public void Draw(Canvas canvas)
        {
            if (lines.Count == 0)
            {
                CreateLines(canvas);
            }

            double currentRadian = radianY;
            x = 1;
            foreach (Line line in lines)
            {
                DrawLine(line, x, y + Math.Sin(currentRadian) * WaveLength, LineLength);
                currentRadian += waveSpeed;
                ++x;
            }
            radianY += 0.1; // move the waves
        }

        override protected void CreateLines(Canvas canvas)
        {
            for (int x = 1; x < canvas.Width; x += 1)
            {
                MakeLine(canvas);
            }
        }
    }    
}
