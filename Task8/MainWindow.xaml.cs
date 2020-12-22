using System.Collections.Generic;
using System.Windows;

namespace Task8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private List<ModelView> models = new List<ModelView>();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ModelView modelView = new ModelView();
            models.Add(modelView);
            modelView.Show();
        }
    }
}