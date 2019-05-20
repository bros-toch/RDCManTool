using System.IO;
using System.Xml.Linq;
using RdcMan;

namespace RDCManTool
{
    public sealed class RdcToolHelper
    {
        private static readonly EncryptionSettings Settings = new EncryptionSettings();

        public static void Export(string inputFile, string outputFile, string encryptionKey)
        {
            var xDocument = XDocument.Parse(File.ReadAllText(inputFile));
            var passwordNodes = xDocument.Descendants("password");
            foreach (var passwordNode in passwordNodes)
            {
                var clearPassword = Encryption.DecryptString(passwordNode.Value, Settings);
                var encryptedPassword = EncryptionHelper.Encrypt(clearPassword, encryptionKey);
                passwordNode.Value = encryptedPassword;
            }

            xDocument.Save(outputFile);
        }

        public static void Import(string inputFile, string outputFile, string encryptionKey)
        {
            var xDocument = XDocument.Parse(File.ReadAllText(inputFile));
            var passwordNodes = xDocument.Descendants("password");
            foreach (var passwordNode in passwordNodes)
            {
                var encryptedPassword = EncryptionHelper.Decrypt(passwordNode.Value, encryptionKey);
                var rdmEncryptedPassword = Encryption.EncryptString(encryptedPassword, Settings);
                passwordNode.Value = rdmEncryptedPassword;
            }

            xDocument.Save(outputFile);
        }
    }
}