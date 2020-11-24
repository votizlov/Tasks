using System;
using System.Windows;

namespace Task7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            string error;
            if (!RuntimeLoader.test(PathText.Text,out error))
            {
                PathText.Text = error;
            }
            else
            {
                PathText.Text = "test success";
            }
        }
    }
}