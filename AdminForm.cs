using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SocialNetworkApp
{
    public partial class AdminForm : Form
    {
 

        public AdminForm()
        {
            InitializeComponent();
            SetupListView();
            LoadUserAndPosts();
        }



        private void SetupListView()
        {
            lvUsersPosts.View = View.Details;
            lvUsersPosts.FullRowSelect = true;
            lvUsersPosts.GridLines = true;

            // Thiết lập các cột
            lvUsersPosts.Columns.Add("Avatar", 50);
            lvUsersPosts.Columns.Add("Username", 100);
            lvUsersPosts.Columns.Add("Content", 200);
            lvUsersPosts.Columns.Add("Image", 150);
            lvUsersPosts.Columns.Add("Timestamp", 120);
            lvUsersPosts.Columns.Add("Type", 80);

            // ImageList cho avatar
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(40, 40);
            lvUsersPosts.SmallImageList = imageList;
        }

        private void LoadUserAndPosts(string usernameFilter = "")
        {
            lvUsersPosts.Items.Clear();
            lvUsersPosts.SmallImageList.Images.Clear();

            User user = Program.userList.Head;
            while (user != null)
            {
                if (!string.IsNullOrEmpty(usernameFilter) &&
                    user.Username.IndexOf(usernameFilter, StringComparison.OrdinalIgnoreCase) == -1) // Kiểm tra nếu không tìm thấy
                {
                    user = user.Next;
                    continue;
                }

                // Hiển thị thông tin User
                ListViewItem userItem = new ListViewItem();

                // Xử lý avatar (chỉ cho hàng User)
                if (!string.IsNullOrEmpty(user.AvatarPath) && File.Exists(user.AvatarPath))
                {
                    string avatarKey = user.AvatarPath;
                    if (!lvUsersPosts.SmallImageList.Images.ContainsKey(avatarKey))
                    {
                        lvUsersPosts.SmallImageList.Images.Add(avatarKey, Image.FromFile(user.AvatarPath));
                    }
                    userItem.ImageKey = avatarKey;
                }

                userItem.SubItems.Add(user.Username);
                userItem.SubItems.Add(""); // Không có content cho user
                userItem.SubItems.Add(""); // Không có ảnh cho user
                userItem.SubItems.Add(""); // Không có timestamp cho user
                userItem.SubItems.Add("User");
                userItem.Tag = new Tuple<string, object>("User", user); // Lưu loại đối tượng và dữ liệu
                userItem.BackColor = Color.LightGray;
                lvUsersPosts.Items.Add(userItem);

                // Hiển thị các bài post của user
                Post post = user.FirstPost;
                while (post != null)
                {
                    ListViewItem postItem = new ListViewItem();
                    postItem.SubItems.Add(user.Username);
                    postItem.SubItems.Add(post.Content);

                    // Xử lý hiển thị ảnh bài viết
                    if (!string.IsNullOrEmpty(post.ImagePath) && File.Exists(post.ImagePath))
                    {
                        postItem.SubItems.Add(Path.GetFileName(post.ImagePath));
                        postItem.ToolTipText = "Click để xem ảnh";
                    }
                    else
                    {
                        postItem.SubItems.Add("");
                    }

                    postItem.SubItems.Add(post.Timestamp.ToString());
                    postItem.SubItems.Add("Post");
                    postItem.Tag = new Tuple<string, object>("Post", post);
                    postItem.IndentCount = 1;
                    lvUsersPosts.Items.Add(postItem);

                    // Hiển thị các comment của post
                    Comment comment = post.FirstComment;
                    while (comment != null)
                    {
                        ListViewItem commentItem = new ListViewItem();
                        commentItem.SubItems.Add(comment.Author);
                        commentItem.SubItems.Add(comment.Content);
                        commentItem.SubItems.Add("");
                        commentItem.SubItems.Add(comment.Timestamp.ToString());
                        commentItem.SubItems.Add("Comment");
                        commentItem.Tag = new Tuple<string, object>("Comment", comment);
                        commentItem.IndentCount = 2;
                        lvUsersPosts.Items.Add(commentItem);

                        comment = comment.Next;
                    }

                    post = post.Next;
                }

                user = user.Next;
            }
        }

        private void lvUsersPosts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvUsersPosts.SelectedItems.Count == 0) return;

            var selectedItem = lvUsersPosts.SelectedItems[0];
            var itemData = (Tuple<string, object>)selectedItem.Tag;
            string itemType = itemData.Item1;
            object itemObject = itemData.Item2;

            switch (itemType)
            {
                case "User":
                    // Xóa user và tất cả bài viết, comment của user đó
                    User userToDelete = (User)itemObject;
                    if (MessageBox.Show($"Bạn có chắc muốn xóa user {userToDelete.Username} và tất cả nội dung liên quan?",
                        "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Program.userList.DeleteUser(userToDelete.Username);
                        LoadUserAndPosts();
                    }
                    break;

                case "Post":
                    // Xóa bài viết cụ thể
                    Post postToDelete = (Post)itemObject;
                    if (MessageBox.Show($"Bạn có chắc muốn xóa bài viết này?",
                        "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string username = selectedItem.SubItems[1].Text;
                        Program.userList.DeleteUserPost(username, postToDelete.Content);
                        LoadUserAndPosts();
                    }
                    break;

                case "Comment":
                    // Xóa comment cụ thể
                    Comment commentToDelete = (Comment)itemObject;
                    if (MessageBox.Show($"Bạn có chắc muốn xóa bình luận này?",
                        "Xác nhận xóa", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        // Tìm post chứa comment này
                        ListViewItem parentPostItem = FindParentPostItem(selectedItem);
                        if (parentPostItem != null)
                        {
                            Post parentPost = (Post)((Tuple<string, object>)parentPostItem.Tag).Item2;
                            string postUsername = parentPostItem.SubItems[1].Text;
                            Program.userList.DeleteComment(postUsername, parentPost.Content, commentToDelete.Content);
                            LoadUserAndPosts();
                        }
                    }
                    break;
            }
        }

        private ListViewItem FindParentPostItem(ListViewItem commentItem)
        {
            int index = commentItem.Index - 1;
            while (index >= 0)
            {
                ListViewItem item = lvUsersPosts.Items[index];
                if (item.SubItems[4].Text == "Post")
                {
                    return item;
                }
                index--;
            }
            return null;
        }
        private void lvUsersPosts_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hit = lvUsersPosts.HitTest(e.Location);

            if (hit.Item != null && hit.SubItem != null)
            {
                // Xử lý click để xem ảnh (chỉ cho Post có ảnh)
                var itemData = (Tuple<string, object>)hit.Item.Tag;
                if (itemData.Item1 == "Post" && hit.SubItem == hit.Item.SubItems[3] && !string.IsNullOrEmpty(hit.Item.SubItems[3].Text))
                {
                    Post post = (Post)itemData.Item2;
                    if (!string.IsNullOrEmpty(post.ImagePath) && File.Exists(post.ImagePath))
                    {
                        ImageViewerForm imageViewer = new ImageViewerForm(post.ImagePath);
                        imageViewer.ShowDialog();
                    }
                }
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            LoadUserAndPosts(keyword);
        }

        private void BtnRandomUsers_Click(object sender, EventArgs e)
        {
            Program.userList.GenerateRandomUsers(3);
            LoadUserAndPosts();
        }

        private void BtnRandomPosts_Click(object sender, EventArgs e)
        {
            Program.userList.GenerateRandomPosts(2);
            LoadUserAndPosts();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUserAndPosts();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form1().Show();
        }
    }
}
