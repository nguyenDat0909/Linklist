using System;
using System.Windows.Forms;

namespace SocialNetworkApp
{
    static class Program
    {
        public static UserDoubleLinkedList userList = new UserDoubleLinkedList();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }


    public class Comment
    {
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime Timestamp { get; set; }
        public Comment Prev { get; set; }
        public Comment Next { get; set; }

        public Comment(string content, string author)
        {
            Content = content;
            Author = author;
            Timestamp = DateTime.Now;
        }
    }

    public class Post
    {
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public DateTime Timestamp { get; set; }
        public Post Prev { get; set; }
        public Post Next { get; set; }
        public Comment FirstComment { get; set; }
        public string Author { get; set; } // Thêm thuộc tính Author

        public Post(string content, string author, string imagePath = null)
        {
            Content = content;
            Author = author;
            ImagePath = imagePath;
            Timestamp = DateTime.Now;
        }

        public void AddComment(string comment, string author)
        {
            Comment newComment = new Comment(comment, author);
            if (FirstComment == null)
                FirstComment = newComment;
            else
            {
                Comment temp = FirstComment;
                while (temp.Next != null) temp = temp.Next;
                temp.Next = newComment;
                newComment.Prev = temp;
            }
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string AvatarPath { get; set; }
        public Post FirstPost { get; set; }
        public User Prev { get; set; }
        public User Next { get; set; }

        public User(string username, string password, string avatarPath = null)
        {
            Username = username;
            Password = password;
            AvatarPath = avatarPath;
        }

        public void AddPost(string content, string imagePath = null)
        {
            Post newPost = new Post(content, Username, imagePath); // Gán tác giả là Username
            if (FirstPost == null)
                FirstPost = newPost;
            else
            {
                Post temp = FirstPost;
                while (temp.Next != null) temp = temp.Next;
                temp.Next = newPost;
                newPost.Prev = temp;
            }
        }
    }

    public class UserDoubleLinkedList
    {
        public User Head { get; set; }

        public void Register(string username, string password, string avatarPath = null)
        {
            User newUser = new User(username, password, avatarPath);
            if (Head == null)
                Head = newUser;
            else
            {
                User temp = Head;
                while (temp.Next != null) temp = temp.Next;
                temp.Next = newUser;
                newUser.Prev = temp;
            }
        }

        public User Login(string username, string password)
        {
            User temp = Head;
            while (temp != null)
            {
                if (temp.Username == username && temp.Password == password)
                    return temp;
                temp = temp.Next;
            }
            return null;
        }

        public void DeleteUser(string username)
        {
            User temp = Head;
            while (temp != null)
            {
                if (temp.Username == username)
                {
                    if (temp.Prev != null) temp.Prev.Next = temp.Next;
                    if (temp.Next != null) temp.Next.Prev = temp.Prev;
                    if (temp == Head) Head = temp.Next;
                    return;
                }
                temp = temp.Next;
            }
        }

        public void DeleteUserPost(string username, string content)
        {
            User temp = Head;
            while (temp != null)
            {
                if (temp.Username == username)
                {
                    Post p = temp.FirstPost;
                    Post prev = null;
                    while (p != null)
                    {
                        if (p.Content == content)
                        {
                            if (prev == null)
                                temp.FirstPost = p.Next;
                            else
                                prev.Next = p.Next;
                            if (p.Next != null) p.Next.Prev = prev;
                            return;
                        }
                        prev = p;
                        p = p.Next;
                    }
                }
                temp = temp.Next;
            }
        }

        public void DeleteComment(string username, string postContent, string commentContent)
        {
            User temp = Head;
            while (temp != null)
            {
                if (temp.Username == username)
                {
                    Post p = temp.FirstPost;
                    while (p != null)
                    {
                        if (p.Content == postContent)
                        {
                            Comment c = p.FirstComment;
                            Comment prev = null;
                            while (c != null)
                            {
                                if (c.Content == commentContent)
                                {
                                    if (prev == null)
                                        p.FirstComment = c.Next;
                                    else
                                        prev.Next = c.Next;
                                    if (c.Next != null) c.Next.Prev = prev;
                                    return;
                                }
                                prev = c;
                                c = c.Next;
                            }
                        }
                        p = p.Next;
                    }
                }
                temp = temp.Next;
            }
        }
        public void GenerateRandomUsers(int count)
        {
            string[] names = { "huy", "linh", "ngoc", "an", "tuan", "minh" };
            Random rand = new Random();

            for (int i = 0; i < count; i++)
            {
                string username = names[rand.Next(names.Length)] + rand.Next(1000, 9999);
                this.Register(username, "123", null); // mật khẩu mặc định, không avatar
            }
        }

        public void GenerateRandomPosts(int postsPerUser)
        {
            string[] texts = { "Hôm nay trời đẹp", "Code cả đêm", "Ăn mì gói", "Yêu AI", "Cà phê sáng" };
            Random rand = new Random();

            User current = Head;
            while (current != null)
            {
                for (int i = 0; i < postsPerUser; i++)
                {
                    string text = texts[rand.Next(texts.Length)];
                    current.AddPost(text); // bài không có ảnh
                }
                current = current.Next;
            }
        }
    }
}
