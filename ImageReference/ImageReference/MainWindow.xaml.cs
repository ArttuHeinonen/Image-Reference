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

namespace ImageReference
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Image img;
        private Point mousePos = new Point();
        private Point startPos = new Point();
        private Point move = new Point();
        private Boolean mouseDown = false;
        private int scaleValue = 20;

        public MainWindow()
        {
            InitializeComponent();
            Keyboard.Focus(image);
        }

        private void image_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void image_DragOver(object sender, DragEventArgs e)
        {

        }

        private void image_Drop(object sender, DragEventArgs e)
        {
            
        }

        private void image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPos = PointToScreen(e.GetPosition(null));
            mouseDown = true;
        }

        private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseDown = false;
        }

        private void image_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (mouseDown)
            {
                mousePos = PointToScreen(e.GetPosition(null));
                move.X = mousePos.X - startPos.X;
                move.Y = mousePos.Y - startPos.Y;
                startPos = PointToScreen(e.GetPosition(null));
                this.Left += move.X;
                this.Top += move.Y;
            }
        }

        private void image_MouseLeave(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            //Shrink
            if(e.Delta < 0)
            {
                if (!IsImageTooSmall(this.Width - scaleValue, this.Height - scaleValue))
                {
                    this.Width -= scaleValue;
                    this.Height -= scaleValue;
                }
            }
            //Grow
            else
            {
                if (!IsOverScreenResolution(this.Width + scaleValue, this.Height + scaleValue))
                {
                    this.Width += scaleValue;
                    this.Height += scaleValue;
                }
                
            }
        }

        private Boolean IsOverScreenResolution(double width, double height)
        {
            if(width > SystemParameters.PrimaryScreenWidth || height > SystemParameters.PrimaryScreenHeight)
            {
                return true;
            }
            return false;
        }

        private Boolean IsImageTooSmall(double width, double height)
        {
            if(width < 40 || height < 40)
            {
                return true;
            }
            return false;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Application.Current.Shutdown();
            }
        }
    }
}
