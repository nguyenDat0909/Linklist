using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SocialNetworkApp
{
    public partial class ImageViewerForm : Form  // Thêm từ khóa partial
    {
        private string _imagePath;
        private PictureBox pictureBox;

        public ImageViewerForm(string imagePath)
        {
            _imagePath = imagePath;

            // Tạo và cấu hình PictureBox
            pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill, // Đặt ảnh tự động theo kích thước form
                SizeMode = PictureBoxSizeMode.Zoom // Tự động co dãn ảnh theo form
            };

            // Thêm PictureBox vào Form
            this.Controls.Add(pictureBox);

            // Tải ảnh khi form được tạo
            LoadImage();
        }

        private void LoadImage()
        {
            // Kiểm tra nếu ảnh tồn tại
            if (!string.IsNullOrEmpty(_imagePath) && File.Exists(_imagePath))
            {
                // Hiển thị ảnh trong PictureBox
                pictureBox.Image = Image.FromFile(_imagePath);
            }
            else
            {
                // Thông báo lỗi nếu ảnh không tồn tại
                MessageBox.Show("Image not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
