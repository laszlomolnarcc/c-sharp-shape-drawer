using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SinusOnCanvas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Shape> shapeList = new List<Shape>();

        public MainWindow()
        {
            InitializeComponent();
            AddSineWaves();
            AddCircles();
            Draw();
        }

        private void Draw()
        {
            foreach (Shape shape in shapeList)
            {
                shape.Draw(canvas);
            }
        }

        private void AddSineWaves()
        {
            Color startColor = new Color();
            startColor.R = startColor.G = startColor.B = 50; startColor.A = 255;

            ColorRotator rotator = new ColorRotator(startColor, new SignedColor(2, 0, 1, 1));
            shapeList.Add(new SineWave(1.7, 180, 0.02, rotator));

            rotator = new ColorRotator(startColor, new SignedColor(0, 1, 1, 1));
            shapeList.Add(new SineWave(0, 200, 0.01, rotator));

            rotator = new ColorRotator(startColor, new SignedColor(1, 0, 1, 1));
            shapeList.Add(new SineWave(3.1, 190, 0.025, rotator));

            rotator = new ColorRotator(startColor, new SignedColor(1, 1, 0, 2));
            shapeList.Add(new SineWave(2.5, 250, 0.015, rotator));
        }

        private void AddCircles()
        {
            Color startColor = new Color();
            startColor.R = startColor.G = startColor.B = 50; startColor.A = 255;

            ColorRotator rotator = new ColorRotator(startColor, new SignedColor(1, 0, 0, 0));
            shapeList.Add(new Circle(100, 100, 0.3, 0.1, rotator));

            rotator = new ColorRotator(startColor, new SignedColor(0, 1, 0, 0));
            shapeList.Add(new Circle(100, 100, 1.2, 0.15, rotator));

            rotator = new ColorRotator(startColor, new SignedColor(0, 1, 0, 0));
            shapeList.Add(new Circle(100, 100, 2.2, 0.5, rotator));
        }

        // this method is not used. See the comment in GradientHorizon.cs
        private void AddGradientHorizon()
        {
            Color startColor = new Color();
            startColor.R = startColor.G = startColor.B = 50; startColor.A = 255;

            ColorRotator rotator = new ColorRotator(startColor, new SignedColor(0, 0, 0, 0));
            shapeList.Add(new GradientHorizon(rotator));
        }

        private void CanvasMouseDown(object sender, MouseButtonEventArgs e)
        {
            // dispatcher calls DispatcherTimerTick() method periodically
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimerTick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 26);
            dispatcherTimer.Start();
        }

        private void DispatcherTimerTick(object sender, EventArgs e)
        {
            Draw();
            canvas.InvalidateVisual();
            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
