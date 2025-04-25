using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SocialNetworkApp
{
    public partial class Form2 : Form
    {
        private User currentUser;
        private string imagePath = null;

        public Form2(User user)
        {
            InitializeComponent();
            currentUser = user;

            lblUsername.Text = "Xin chào, " + currentUser.Username;
            if (!string.IsNullOrEmpty(currentUser.AvatarPath) && File.Exists(currentUser.AvatarPath))
            {
                picUserAvatar.Image = Image.FromFile(currentUser.AvatarPath);
            }

            LoadAllPosts();
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            string content = txtPost.Text;
            if (!string.IsNullOrWhiteSpace(content))
            {
                currentUser.AddPost(content, imagePath);
                txtPost.Clear();
                pictureBoxPost.Image = null;
                imagePath = null;
                LoadAllPosts();
            }
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = openFileDialog.FileName;
                    pictureBoxPost.Image = Image.FromFile(imagePath);
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form1().Show();
        }

        private void btnComment_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn một bài viết để bình luận.");
                return;
            }

            string comment = txtComment.Text;
            if (string.IsNullOrWhiteSpace(comment)) return;

            Post selectedPost = (Post)flowLayoutPanel1.Tag;
            selectedPost.AddComment(comment, currentUser.Username);
            txtComment.Clear();
            LoadAllPosts();
        }

        private void btnDeletePost_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn bài viết của bạn để xóa!");
                return;
            }

            Post selectedPost = (Post)flowLayoutPanel1.Tag;
            if (selectedPost.Author != currentUser.Username)
            {
                MessageBox.Show("Bạn chỉ có thể xóa bài viết của chính mình!");
                return;
            }

            Program.userList.DeleteUserPost(currentUser.Username, selectedPost.Content);
            flowLayoutPanel1.Tag = null;
            LoadAllPosts();
        }

        private void LoadAllPosts()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Tag = null;

            List<(User user, Post post)> allPosts = new List<(User, Post)>();

            // Gom tất cả bài viết từ mọi người dùng
            User user = Program.userList.Head;
            while (user != null)
            {
                Post post = user.FirstPost;
                while (post != null)
                {
                    allPosts.Add((user, post));
                    post = post.Next;
                }
                user = user.Next;
            }

            // Sắp xếp bài viết mới nhất lên đầu
            allPosts.Sort((a, b) => b.post.Timestamp.CompareTo(a.post.Timestamp));

            // Hiển thị từng bài viết
            foreach (var (userItem, post) in allPosts)
            {
                Panel postPanel = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Width = flowLayoutPanel1.Width - 40,
                    AutoSize = true,
                    Padding = new Padding(10),
                    Margin = new Padding(5)
                };

                PictureBox avatar = new PictureBox
                {
                    Size = new Size(40, 40),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Image = File.Exists(userItem.AvatarPath) ? Image.FromFile(userItem.AvatarPath) : null
                };
                postPanel.Controls.Add(avatar);

                Label lblInfo = new Label
                {
                    Text = $"{userItem.Username} · {post.Timestamp:g}",
                    AutoSize = true,
                    Location = new Point(50, 5),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold)
                };
                postPanel.Controls.Add(lblInfo);

                Label lblContent = new Label
                {
                    Text = post.Content,
                    AutoSize = true,
                    MaximumSize = new Size(postPanel.Width - 20, 0),
                    Location = new Point(0, 50),
                    Font = new Font("Segoe UI", 10)
                };
                postPanel.Controls.Add(lblContent);

                int y = lblContent.Bottom + 10;

                if (!string.IsNullOrEmpty(post.ImagePath) && File.Exists(post.ImagePath))
                {
                    PictureBox postImg = new PictureBox
                    {
                        Image = Image.FromFile(post.ImagePath),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new Size(postPanel.Width - 20, 200),
                        Location = new Point(0, y)
                    };
                    postPanel.Controls.Add(postImg);
                    y = postImg.Bottom + 10;
                }

                Comment comment = post.FirstComment;
                while (comment != null)
                {
                    Label lblCmt = new Label
                    {
                        Text = $"{comment.Author}: {comment.Content}",
                        AutoSize = true,
                        ForeColor = Color.Gray,
                        Location = new Point(10, y),
                        Font = new Font("Segoe UI", 9, FontStyle.Italic)
                    };
                    postPanel.Controls.Add(lblCmt);
                    y += lblCmt.Height + 5;
                    comment = comment.Next;
                }

                // Nút Bình luận (cho tất cả bài viết)
                Button btnComment = new Button
                {
                    Text = "Bình luận",
                    Size = new Size(90, 25),
                    FlatStyle = FlatStyle.Flat
                };
                btnComment.Click += (s, e) =>
                {
                    flowLayoutPanel1.Tag = post;
                    txtComment.Focus();
                };

                int buttonSpacing = 10;
                int rightMargin = 10;

                if (post.Author == currentUser.Username)
                {
                    Button btnDelete = new Button
                    {
                        Text = "Xóa",
                        Size = new Size(70, 25),
                        FlatStyle = FlatStyle.Flat
                    };
                    btnDelete.Click += (s, e) =>
                    {
                        flowLayoutPanel1.Tag = post;
                        btnDeletePost_Click(s, e);
                    };

                    btnDelete.Location = new Point(postPanel.Width - btnDelete.Width - rightMargin, y);
                    btnComment.Location = new Point(btnDelete.Left - btnComment.Width - buttonSpacing, y);

                    postPanel.Controls.Add(btnDelete);
                    postPanel.Controls.Add(btnComment);
                }
                else
                {
                    btnComment.Location = new Point(postPanel.Width - btnComment.Width - rightMargin, y);
                    postPanel.Controls.Add(btnComment);
                }

                y += btnComment.Height + 10;


                // Gắn sự kiện chọn bài viết (click panel)
                postPanel.Cursor = Cursors.Hand;
                postPanel.Click += (s, e) =>
                {
                    flowLayoutPanel1.Tag = post;
                    txtComment.Focus();
                };

                flowLayoutPanel1.Controls.Add(postPanel);
            }
        }

    }
}
