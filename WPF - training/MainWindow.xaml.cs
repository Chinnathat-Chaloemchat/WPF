using System;
using System.Windows;

namespace WPF___training
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnEnvoyer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailTo.SendMail(
                    mail_sender.Text.Trim(),
                    mdp_sender.Password,
                    mail_reciever.Text.Trim(),
                    mail_object.Text,
                    mail_content.Text
                );

                MessageBox.Show("Email envoyé avec succès ✅", "Succès",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            mail_sender.Clear();
            mdp_sender.Clear();
            mail_reciever.Clear();
            mail_object.Clear();
            mail_content.Clear();
        }
    }
}
