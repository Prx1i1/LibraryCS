using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace CringLibrary
{
    public class SodiumLibrary
    {
        #region core.h
        [DllImport("libsodium")]
        public static extern int sodium_init();
        #endregion

        #region crypto_kdf.h
        [DllImport("libsodium", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint crypto_kdf_bytes_min();

        [DllImport("libsodium", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint crypto_kdf_bytes_max();

        [DllImport("libsodium", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint crypto_kdf_contextbytes();

        [DllImport("libsodium", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint crypto_kdf_keybytes();

        [DllImport("libsodium", CallingConvention = CallingConvention.Cdecl)]
        public static extern int crypto_kdf_derive_from_key(byte[] subkey, uint subkey_len, ulong subkey_id, byte[] ctx, byte[] key);

        [DllImport("libsodium", CallingConvention = CallingConvention.Cdecl)]
        public static extern void crypto_kdf_keygen(byte[] k);
        #endregion

        #region crypto_pwhash.h
        [DllImport("libsodium", CallingConvention = CallingConvention.Cdecl)]
        public static extern uint crypto_pwhash_strbytes();

        [DllImport("libsodium", CallingConvention = CallingConvention.Cdecl)]
        public static extern int crypto_pwhash_str(byte[] _out, byte[] passwd, ulong passwdlen, ulong opslimit, ulong memlimit);

        [DllImport("libsodium", CallingConvention = CallingConvention.Cdecl)]
        public static extern int crypto_pwhash_str_verify(byte[] str, byte[] passwd, ulong passwdlen);
        #endregion

        #region randombytes.h
        [DllImport("libsodium", CallingConvention = CallingConvention.Cdecl)]
        public static extern void randombytes_buf(byte[] buf, uint size);
        #endregion
    }
}