using Tools.Cryptography;

namespace DemoEncryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Generate a public/private key pair.  
            //RSA rsa = RSA.Create(2048);
            //string privateKey = rsa.ExportRSAPrivateKeyPem();
            //Console.WriteLine(privateKey);

            //string publicKey = rsa.ExportRSAPublicKeyPem();
            //Console.WriteLine(publicKey);
            
            ////Pour encrypter
            //rsa = RSA.Create();
            //rsa.ImportFromPem(publicKey);
            //byte[] data = Encoding.Default.GetBytes("Hello World!");
            //byte[] cypher = rsa.Encrypt(data, RSAEncryptionPadding.OaepSHA512);


            ////pour décrypter
            //rsa = RSA.Create();
            //rsa.ImportFromPem(privateKey);
            //data = rsa.Decrypt(cypher, RSAEncryptionPadding.OaepSHA512);
            //Console.WriteLine(Encoding.Default.GetString(data));

            ICryptoRSA cryptoRSA = new CryptoRSA(KeySizes.S4096);
            byte[] cypher = Encrypt(cryptoRSA.PublicKey, "Hello Salle 2");
            Console.WriteLine(Decrypt(cryptoRSA.PrivateKey, cypher));

        }

        static byte[] Encrypt(string publicKey, string text)
        {
            ICryptoRSA cryptoRSA = new CryptoRSA(publicKey);
            return cryptoRSA.Encrypt(text);
        }

        static string Decrypt(string privateKey, byte[] cypher)
        {
            ICryptoRSA cryptoRSA = new CryptoRSA(privateKey);
            return cryptoRSA.Decrypt(cypher);
        }
    }
}
