using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win32;

namespace RDPM_Password_Decryptor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private unsafe static string DecryptStringUsingLocalUser(string encryptedString)
        {
            Crypto.DataBlob dataBlob = default(Crypto.DataBlob);
            Crypto.CryptProtectPromptStruct cryptProtectPromptStruct = default(Crypto.CryptProtectPromptStruct);
            if (string.IsNullOrEmpty(encryptedString))
            {
                return string.Empty;
            }
            dataBlob.Size = 0;
            cryptProtectPromptStruct.Size = 0;
            byte[] array = System.Convert.FromBase64String(encryptedString);
            Crypto.DataBlob dataBlob2;
            dataBlob2.Size = array.Length;
            Crypto.DataBlob dataBlob3;
            string result;
            fixed (byte* ptr = array)
            {
                dataBlob2.Data = (System.IntPtr)((void*)ptr);
                if (!Crypto.CryptUnprotectData(ref dataBlob2, null, ref dataBlob, (System.IntPtr)null, ref cryptProtectPromptStruct, 0, out dataBlob3))
                {
                    //throw new System.Exception("Failed to decrypt using {0} credential".InvariantFormat(new object[]
                    //{
                    //    CredentialsUI.GetLoggedInUser()
                    //}));
                }
                char* ptr2 = (char*)((void*)dataBlob3.Data);
                char[] array2 = new char[dataBlob3.Size / 2];
                for (int i = 0; i < array2.Length; i++)
                {
                    array2[i] = ptr2[i];
                }
                result = new string(array2);
            }
            Crypto.LocalFree(dataBlob3.Data);
            return result;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            string password = DecryptStringUsingLocalUser(textBox1.Text.Trim());
            textBox2.Text = password;
        }

        private void xdpxlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/xXxTheDarkprogramerxXx/");
        }
    }
}
