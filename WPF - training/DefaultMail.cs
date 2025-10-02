using System;
using System.IO;

namespace WPF___training
{
    internal static class DefaultMail
    {
        private static readonly string filePath = "defaultmail.txt";

        //Exemple de defaultmail.txt
        //    exemple@gmail.com
        //    mdp d'application

        public static string Email { get; private set; }
        public static string Password { get; private set; }

        // Charger depuis le fichier si existe
        public static void Load()
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                if (lines.Length >= 2)
                {
                    Email = lines[0];
                    Password = lines[1];
                }
            }
        }

        // Sauvegarder (si tu veux retenir les valeurs actuelles)
        public static void Save(string email, string password)
        {
            File.WriteAllLines(filePath, new string[] { email, password });
            Email = email;
            Password = password;
        }

        // Supprimer le fichier (reset)
        public static void Clear()
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            Email = null;
            Password = null;
        }
    }
}
