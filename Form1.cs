using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SocialNetworkApp
{
    public partial class Form1 : Form
    {
        private string avatarPath = null;

        public Form1()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (Program.userList.Login(user, pass) != null)
                MessageBox.Show("Tài khoản đã tồn tại!");
            else
            {
                Program.userList.Register(user, pass, avatarPath);
                MessageBox.Show("Đăng ký thành công!");
                avatarPath = null;
                picAvatar.Image = null;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string pass = txtPassword.Text;

            if (user == "admin" && pass == "admin123")
            {
                new AdminForm().Show();
                this.Hide();
                return;
            }

            var loginUser = Program.userList.Login(user, pass);
            if (loginUser != null)
            {
                new Form2(loginUser).Show();
                this.Hide();
            }
            else
                MessageBox.Show("Đăng nhập thất bại!");
        }

        private void btnUploadAvatar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    avatarPath = openFileDialog.FileName;
                    picAvatar.Image = Image.FromFile(avatarPath);
                }
            }
        }
    }
}