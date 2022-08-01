using System;
using System.Text;

// not my code, not my problem

namespace CringLibrary
{
    public class Sodium
    {
        private static bool initialized = false;

        public static void Init()
        {
            if (SodiumLibrary.sodium_init() < 0)
            {
                throw new Exception("Failed to initialize libsodium");
            }
            else
            {
                initialized = true;
            }
        }

        private static void CheckInitialized()
        {
            if (!initialized)
                throw new Exception("libsodium is not initialized");
        }

        public class KDF
        {
            private static uint bytesMin;
            private static uint bytesMax;
            private static uint contextBytes;
            private static uint keyBytes;

            public static uint BytesMin
            {
                get
                {
                    CheckInitialized();
                    if (bytesMin == default) bytesMin = SodiumLibrary.crypto_kdf_bytes_min();
                    return bytesMin;
                }
            }

            public static uint BytesMax
            {
                get
                {
                    CheckInitialized();
                    if (bytesMax == default) bytesMax = SodiumLibrary.crypto_kdf_bytes_max();
                    return bytesMax;
                }
            }

            public static uint ContextBytes
            {
                get
                {
                    CheckInitialized();
                    if (contextBytes == default) contextBytes = SodiumLibrary.crypto_kdf_contextbytes();
                    return contextBytes;
                }
            }

            public static uint KeyBytes
            {
                get
                {
                    CheckInitialized();
                    if (keyBytes == default) keyBytes = SodiumLibrary.crypto_kdf_keybytes();
                    return keyBytes;
                }
            }

            public static byte[] Keygen()
            {
                CheckInitialized();
                byte[] key = new byte[KeyBytes];
                SodiumLibrary.crypto_kdf_keygen(key);
                return key;
            }

            public static byte[] DeriveFromKey(uint subkeyLength, uint subkeyId, string context, byte[] key)
            {
                CheckInitialized();
                byte[] contextBytes = Encoding.ASCII.GetBytes(context);
                if(key.Length != KeyBytes)
                {
                    throw new Exception($"Invalid key length. Must be {KeyBytes} bytes.");
                }
                else if(subkeyLength < BytesMin || subkeyLength > BytesMax)
                {
                    throw new Exception($"Invalid subkey length. Must be {BytesMin}-{BytesMax} bytes.");
                }
                else if(contextBytes.Length != ContextBytes)
                {
                    throw new Exception($"Invalid context length. Must be {ContextBytes} bytes.");
                }
                else
                {
                    byte[] subkey = new byte[subkeyLength];
                    SodiumLibrary.crypto_kdf_derive_from_key(subkey, subkeyLength, subkeyId, contextBytes, key);
                    return subkey;
                }
            }
        }

        public class PwHash
        {
            private static uint strBytes;

            public static uint StrBytes
            {
                get
                {
                    CheckInitialized();
                    if (strBytes == default) strBytes = SodiumLibrary.crypto_pwhash_strbytes();
                    return strBytes;
                }
            }

            public static string Hash(string password, ulong opslimit, ulong memlimit)
            {
                CheckInitialized();
                byte[] hashBytes = new byte[StrBytes];
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                int status = SodiumLibrary.crypto_pwhash_str(hashBytes, passwordBytes, (ulong)passwordBytes.Length, opslimit, memlimit);
                if (status != 0)
                    throw new Exception("Failed to hash password");
                return Encoding.UTF8.GetString(hashBytes, 0, Array.FindIndex(hashBytes, b => b == 0));
            }

            public static bool Verify(string password, string hash)
            {
                CheckInitialized();
                byte[] hashBytes = Encoding.UTF8.GetBytes(hash + "\0");
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                int status = SodiumLibrary.crypto_pwhash_str_verify(hashBytes, passwordBytes, (ulong)passwordBytes.Length);
                return status == 0;
            } 
        }

        public class RandomBytes
        {
            public static byte[] GetBuffer(uint size)
            {
                CheckInitialized();
                byte[] buf = new byte[size];
                SodiumLibrary.randombytes_buf(buf, size);
                return buf;
            }
        }
    }
}