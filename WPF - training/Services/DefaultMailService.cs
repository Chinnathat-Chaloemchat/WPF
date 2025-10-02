using System.IO;

namespace WPF___training.Services
{
    internal static class DefaultMailService
    {
        private static readonly string filePath = "defaultmail.txt";

        public static (string Email, string Password) Load()
        {
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                if (lines.Length >= 2)
                {
                    return (lines[0], lines[1]);
                }
            }
            return (null, null);
        }

        public static void Save(string email, string password)
        {
            File.WriteAllLines(filePath, new[] { email, password });
        }
    }
}
