using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Task7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        Regex methodRe = new Regex(@"[^\.]+$");
        Regex classRe = new Regex(@"^(.*\.)");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            string error;
            if (!RuntimeLoader.LoadAssembly(PathText.Text, out error))
            {
                PathText.Text = error;
            }
            else
            {
                Type[] types = RuntimeLoader.GetTypes();
                foreach (var type in types)
                {
                    foreach (var methodInfo in type.GetMethods())
                    {
                        Button btn = new Button();
                        btn.Content = type.FullName + "." + methodInfo.Name;
                        btn.Click += MethodBtn;
                        sp.Children.Add(btn);
                    }
                }
            }
        }

        private void MethodBtn(object sender, RoutedEventArgs e)
        {
            Button temp = (Button) sender;
            Match m1 = classRe.Match(temp.Content.ToString());
            Match m2 = methodRe.Match(temp.Content.ToString());
            RuntimeLoader.ExecuteMethod(
                classRe.Match(temp.Content.ToString()).Value
                    .Remove(classRe.Match(temp.Content.ToString()).Value.Length - 1),
                methodRe.Match(temp.Content.ToString()).Value);
        }
    }
}