using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Task8
{
    public partial class ModelView : Window
    {
        private Model md;
        private BitmapImage carBitmapImg;
        private BitmapImage pedBitmapImg;
        private BitmapImage emergencyCarBitmapImg;

        public ModelView()
        {
            InitializeComponent();
            
            carBitmapImg = new BitmapImage();
            carBitmapImg.BeginInit();
            carBitmapImg.UriSource = new Uri(Config.CAR_IMG_PATH, UriKind.Relative);
            carBitmapImg.EndInit();
            
            pedBitmapImg = new BitmapImage();
            pedBitmapImg.BeginInit();
            pedBitmapImg.UriSource = new Uri(Config.PEDESTRIAN_IMG_PATH, UriKind.Relative);
            pedBitmapImg.EndInit();
            
            emergencyCarBitmapImg = new BitmapImage();
            emergencyCarBitmapImg.BeginInit();
            emergencyCarBitmapImg.UriSource = new Uri(Config.EMERGENCY_CAR_IMG_PATH, UriKind.Relative);
            emergencyCarBitmapImg.EndInit();
            
            md = new Model();
            md.textCallback += LogText;
            md.stepCallback += Redraw;
        }

        private void Redraw()
        {
            Canvas.Children.Clear();
            
            Image myImage3 = new Image();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(Config.ROAD_IMG_PATH, UriKind.Relative);
            bi3.EndInit();
            myImage3.Height = 400;
            myImage3.Stretch = Stretch.Fill;
            myImage3.Source = bi3;

            Canvas.Children.Add(myImage3);
            Canvas.SetTop(myImage3, 0);
            Canvas.SetLeft(myImage3, 0);
            
            foreach(var obj in md.Objects)
            {
                switch (obj.Tag)
                {
                    case "Pedestrian":
                        Image pedestrianImg = new Image();
                        pedestrianImg.Stretch = Stretch.None;
                        pedestrianImg.Source = pedBitmapImg;
                        Canvas.Children.Add(pedestrianImg);
                        Canvas.SetTop(pedestrianImg, obj.Top);
                        Canvas.SetLeft(pedestrianImg, obj.Left);
                        break;
                    case "EmergencyCar":
                        Image carEImg = new Image();
                        carEImg.Stretch = Stretch.None;
                        carEImg.Source = carBitmapImg;
                        Canvas.Children.Add(carEImg);
                        Canvas.SetTop(carEImg, obj.Top);
                        Canvas.SetLeft(carEImg, obj.Left);
                        break;
                    case "Car":
                        Image carImg = new Image();
                        carImg.Stretch = Stretch.None;
                        carImg.Source = carBitmapImg;
                        Canvas.Children.Add(carImg);
                        Canvas.SetTop(carImg, obj.Top);
                        Canvas.SetLeft(carImg, obj.Left);
                        break;
                }
            }
        }

        private void LogText(string s)
        {
            logText.Text = s;
        }

        private void StartBtn_OnClick(object sender, RoutedEventArgs e)
        {
            md.StartSim();
            logText.Text = "Sim started";
        }
    }
}