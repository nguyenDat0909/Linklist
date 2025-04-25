namespace SocialNetworkApp
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPost = new System.Windows.Forms.Button();
            this.txtPost = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.picUserAvatar = new System.Windows.Forms.PictureBox();
            this.pictureBoxPost = new System.Windows.Forms.PictureBox();
            this.btnUploadImage = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnComment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picUserAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPost
            // 
            this.btnPost.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPost.Location = new System.Drawing.Point(301, 127);
            this.btnPost.Margin = new System.Windows.Forms.Padding(4);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(155, 42);
            this.btnPost.TabIndex = 0;
            this.btnPost.Text = "Đăng bài";
            this.btnPost.UseVisualStyleBackColor = false;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // txtPost
            // 
            this.txtPost.Location = new System.Drawing.Point(12, 126);
            this.txtPost.Multiline = true;
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(282, 43);
            this.txtPost.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(142, 19);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(263, 25);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "Bạn có thể đăng bài ở đây";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLogout.Location = new System.Drawing.Point(181, 489);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(155, 42);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(12, 337);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(282, 42);
            this.txtComment.TabIndex = 6;
            // 
            // picUserAvatar
            // 
            this.picUserAvatar.Location = new System.Drawing.Point(12, 0);
            this.picUserAvatar.Name = "picUserAvatar";
            this.picUserAvatar.Size = new System.Drawing.Size(79, 65);
            this.picUserAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUserAvatar.TabIndex = 8;
            this.picUserAvatar.TabStop = false;
            // 
            // pictureBoxPost
            // 
            this.pictureBoxPost.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pictureBoxPost.InitialImage = null;
            this.pictureBoxPost.Location = new System.Drawing.Point(12, 176);
            this.pictureBoxPost.Name = "pictureBoxPost";
            this.pictureBoxPost.Size = new System.Drawing.Size(282, 155);
            this.pictureBoxPost.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPost.TabIndex = 9;
            this.pictureBoxPost.TabStop = false;
            // 
            // btnUploadImage
            // 
            this.btnUploadImage.AutoSize = true;
            this.btnUploadImage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnUploadImage.Location = new System.Drawing.Point(300, 289);
            this.btnUploadImage.Name = "btnUploadImage";
            this.btnUploadImage.Size = new System.Drawing.Size(155, 42);
            this.btnUploadImage.TabIndex = 10;
            this.btnUploadImage.Text = "Chọn ảnh";
            this.btnUploadImage.UseVisualStyleBackColor = false;
            this.btnUploadImage.Click += new System.EventHandler(this.btnUploadImage_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(461, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(639, 562);
            this.flowLayoutPanel1.TabIndex = 11;
            // 
            // btnComment
            // 
            this.btnComment.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnComment.Location = new System.Drawing.Point(300, 337);
            this.btnComment.Name = "btnComment";
            this.btnComment.Size = new System.Drawing.Size(155, 42);
            this.btnComment.TabIndex = 12;
            this.btnComment.Text = "Bình luận";
            this.btnComment.UseVisualStyleBackColor = false;
            this.btnComment.Click += new System.EventHandler(this.btnComment_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1100, 562);
            this.Controls.Add(this.btnComment);
            this.Controls.Add(this.btnUploadImage);
            this.Controls.Add(this.pictureBoxPost);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.picUserAvatar);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtPost);
            this.Controls.Add(this.btnPost);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "giao diện ";
            ((System.ComponentModel.ISupportInitialize)(this.picUserAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.TextBox txtPost;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.PictureBox picUserAvatar;
        private System.Windows.Forms.PictureBox pictureBoxPost;
        private System.Windows.Forms.Button btnUploadImage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnComment;
    }
}