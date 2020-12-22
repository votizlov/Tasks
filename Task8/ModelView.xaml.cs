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
        private int i = 0;
        private BitmapImage carBitmapImg;
        private BitmapImage pedBitmapImg;
        private BitmapImage emergencyCarBitmapImg;

        public ModelView()
        {
            InitializeComponent();
            
            carBitmapImg = new BitmapImage();
            carBitmapImg.BeginInit();
            carBitmapImg.UriSource = new Uri(Config.CAR_IMG_PATH, UriKind.Absolute);
            carBitmapImg.EndInit();
            
            pedBitmapImg = new BitmapImage();
            pedBitmapImg.BeginInit();
            pedBitmapImg.UriSource = new Uri(Config.PEDESTRIAN_IMG_PATH, UriKind.Absolute);
            pedBitmapImg.EndInit();
            
            emergencyCarBitmapImg = new BitmapImage();
            emergencyCarBitmapImg.BeginInit();
            emergencyCarBitmapImg.UriSource = new Uri(Config.EMERGENCY_CAR_IMG_PATH, UriKind.Absolute);
            emergencyCarBitmapImg.EndInit();
            
            md = new Model();
            md.stepCallback += Redraw;
        }

        private void Redraw()
        {
            Canvas.Children.Clear();
            
            Image myImage3 = new Image();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(Config.ROAD_IMG_PATH, UriKind.Absolute);
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
                        Canvas.Children.Add(new Image());
                        break;
                    case "EmergencyCar":
                        ;
                        break;
                    case "Car":
                         Image carImg = new Image();
                         carImg.Height = 400;
                        carImg.Stretch = Stretch.Fill;
                        carImg.Source = carBitmapImg;
                        Canvas.Children.Add(carImg);
                        Canvas.SetTop(carImg, obj.Top);
                        Canvas.SetLeft(carImg, obj.Left);

                        break;
                }
            }
        }

        private void StartBtn_OnClick(object sender, RoutedEventArgs e)
        {
           
            md.StartSim();
            logText.Text = "Sim started";
        }
    }
}