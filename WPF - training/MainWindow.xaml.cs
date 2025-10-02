using System.Windows;

namespace WPF___training
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Charger email/mdp par défaut si disponibles
            DefaultMail.Load();

            if (!string.IsNullOrEmpty(DefaultMail.Email))
                mail_sender.Text = DefaultMail.Email;

            if (!string.IsNullOrEmpty(DefaultMail.Password))
                mdp_sender.Password = DefaultMail.Password;
        }

        private void BtnEnvoyer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MailTo.SendMail(
                    mail_sender.Text.Trim(),
                    mdp_sender.Password.Trim(),
                    mail_reciever.Text.Trim(),
                    mail_object.Text.Trim(),
                    mail_content.Text
                );

                MessageBox.Show("Email envoyé avec succès ✅", "Succès",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                // Sauvegarde de l’email + mdp comme valeurs par défaut
                DefaultMail.Save(mail_sender.Text.Trim(), mdp_sender.Password.Trim());
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            mail_reciever.Clear();
            mail_object.Clear();
            mail_content.Clear();
        }
    }
}
