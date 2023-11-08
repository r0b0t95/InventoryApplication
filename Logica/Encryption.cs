using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Encryption
    {

        //ROBERT H. CHAVES PEREZ 2023

        const string key = "12345678123456781234567812345678";
        const string iv = "1234567812345678";

        // -> METHOD, ENCRYPTION

        public string EncryptText( string text )
        {
            StringBuilder sb = new StringBuilder();

            byte[] keyBytes = Encoding.UTF8.GetBytes( key );
            byte[] ivBytes = Encoding.UTF8.GetBytes( iv );

            try
            {
                using ( Aes aes = Aes.Create() )
                {
                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Key = keyBytes;
                    aes.IV = ivBytes;

                    ICryptoTransform encryptor = aes.CreateEncryptor( aes.Key, aes.IV );

                    byte[] plaintextBytes = Encoding.UTF8.GetBytes( text );
                    byte[] ciphertextBytes = encryptor.TransformFinalBlock( plaintextBytes, 0, plaintextBytes.Length );

                    sb.Append( Convert.ToBase64String( ciphertextBytes ) );
                }

                return sb.ToString();
            }
            catch ( FormatException ex )
            {
                sb.Append(string.Format( "Error {0}", ex.Message ) );

                return sb.ToString();
            }
            catch ( ArgumentException ex )
            {
                sb.Append( string.Format( "Error {0}", ex.Message ) );

                return sb.ToString();
            }
            catch ( Exception ex )
            {
                sb.Append( string.Format( "Error {0}", ex.Message ) );

                return sb.ToString();
            }
        }


        // DECRYPTION

        public string DecryptText( string Pass )
        {
            StringBuilder sb = new StringBuilder();

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = Encoding.UTF8.GetBytes(iv);

            try
            {
                using ( Aes aes = Aes.Create() )
                {
                    aes.KeySize = 256;
                    aes.BlockSize = 128;
                    aes.Mode = CipherMode.CBC;
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Key = keyBytes;
                    aes.IV = ivBytes;

                    ICryptoTransform decryptor = aes.CreateDecryptor( aes.Key, aes.IV );

                    byte[] ciphertextBytes = Convert.FromBase64String( Pass );
                    byte[] plaintextBytes = decryptor.TransformFinalBlock( ciphertextBytes, 0, ciphertextBytes.Length );

                    sb.Append(Encoding.UTF8.GetString( plaintextBytes ) );
                }

                return sb.ToString();
            }
            catch ( FormatException ex )
            {
                sb.Append( string.Format( "Error {0}", ex.Message ) );

                return sb.ToString();
            }
            catch  ( ArgumentException ex )
            {
                sb.Append( string.Format( "Error {0}", ex.Message ) );

                return sb.ToString();
            }
            catch ( Exception ex )
            {
                sb.Append( string.Format( "Error {0}", ex.Message ) );

                return sb.ToString();
            }
        }






    }
}
