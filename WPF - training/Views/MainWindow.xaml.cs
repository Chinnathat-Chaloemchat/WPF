using System.Windows;

namespace WPF___training.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OuvrirMailPage_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new MailPage());
        }

        private void Quitter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
