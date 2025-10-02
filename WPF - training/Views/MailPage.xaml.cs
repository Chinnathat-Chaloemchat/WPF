using System.Windows;
using System.Windows.Controls;
using WPF___training.Services;
using WPF___training.ViewModels;

namespace WPF___training.Views
{
    public partial class MailPage : Page
    {
        private MailPageViewModel vm = new MailPageViewModel();

        public MailPage()
        {
            InitializeComponent();

            // Charger valeurs par défaut
            var defaults = DefaultMailService.Load();
            vm.Sender = defaults.Email;
            vm.Password = defaults.Password;

            txtSender.Text = vm.Sender;
            txtPassword.Password = vm.Password;
        }

        private void BtnEnvoyer_Click(object sender, RoutedEventArgs e)
        {
            vm.Sender = txtSender.Text.Trim();
            vm.Password = txtPassword.Password.Trim();
            vm.Receiver = txtReceiver.Text.Trim();
            vm.Subject = txtSubject.Text.Trim();
            vm.Content = txtContent.Text;

            try
            {
                MailService.Send(vm.Sender, vm.Password, vm.Receiver, vm.Subject, vm.Content);
                MessageBox.Show("Email envoyé ✅", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);

                DefaultMailService.Save(vm.Sender, vm.Password);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            txtReceiver.Clear();
            txtSubject.Clear();
            txtContent.Clear();
        }
    }
}
