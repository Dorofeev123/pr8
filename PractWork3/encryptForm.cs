using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PractWork3
{
    public partial class encryptForm : Form
    {
        public encryptForm()
        {
            InitializeComponent();
        }
        char[] alf = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ','ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        int k, x, z;
        string res;
        bool error = false;

        
        public string Encryption(string source, string key)
        {

            res = string.Empty;

            while (key.Length < source.Length)
            {
                key += key;
                if (key.Length > source.Length) key = key.Remove(source.Length);
            }
            for (int i = 0; i < source.Length; i++)
            {
                for (int id = 0; id < alf.Length; id++)
                {
                    if (alf.Contains(source[i])&& alf.Contains(key[i]))
                    {
                        if (key[i] == alf[id]) k = id;
                        if (source[i] == alf[id]) x = id;
                        z = (x + k) % alf.Length;
                    }
                    else
                    {
                        error = true;
                    }
                   
                }
                res += alf[z];
            }
            
            if(error==true)
            {
                MessageBox.Show("Неккорекные данные");
                return "";
            }
            else
            {
                return res;
            }
        }


        private void encryptButton_Click(object sender, EventArgs e)
        {
            finalTextBox.Text = Encryption(initialTextBox.Text, keyTextBox.Text);           
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            initialTextBox.Clear();
            finalTextBox.Clear();
            keyTextBox.Clear();
        }

        public string Decryption(string source, string key)
        {
            res = string.Empty;

            while (key.Length < source.Length)
            {
                key += key;
                if (key.Length > source.Length) key = key.Remove(source.Length);
            }
            for (int i = 0; i < source.Length; i++)
            {
                for (int id = 0; id < alf.Length; id++)
                {
                    if (alf.Contains(source[i]) && alf.Contains(key[i]))
                    {
                        if (key[i] == alf[id]) k = id;
                        if (source[i] == alf[id]) x = id;
                        int result = (x + k) % alf.Length;
                        z = ((result + alf.Length - k)) % alf.Length;
                    }
                    else
                    {
                        error = true;
                    }
                }
                res += alf[z];
            }
            if (error == true)
            {
                MessageBox.Show("Неккоретные данные");
                return "";
            }
            else
            {
                return res;
            }
            
        }
        private void decryptButton_Click(object sender, EventArgs e)
        {
            finalTextBox.Text = Decryption(initialTextBox.Text, keyTextBox.Text); 
        }
    }
}
