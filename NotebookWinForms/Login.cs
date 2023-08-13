using DocumentFormat.OpenXml.Drawing.Diagrams;
using NotebookWinForms.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace NotebookWinForms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

            //var notes = DataStore.Notes;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtPassword.Text) && !string.IsNullOrEmpty(txtUsername.Text))
            //{
            //    if (AppUser.Username == txtUsername.Text && AppUser.Password == txtPassword.Text)
            //    {
            //        Note form1 = new Note();

            //        form1.Show();
            //        this.Hide();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Kullanıcı adı veya şifre hatalı");
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Alanları boş bırakmayınız");

            //}

            Note form1 = new Note();

            form1.Show();
            this.Hide();

        }

    }
}
