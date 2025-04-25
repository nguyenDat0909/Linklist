namespace SocialNetworkApp
{
    partial class AdminForm
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
            this.lvUsersPosts = new System.Windows.Forms.ListView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.BtnRandomUsers = new System.Windows.Forms.Button();
            this.BtnRandomPosts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvUsersPosts
            // 
            this.lvUsersPosts.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lvUsersPosts.Dock = System.Windows.Forms.DockStyle.Right;
            this.lvUsersPosts.HideSelection = false;
            this.lvUsersPosts.Location = new System.Drawing.Point(179, 0);
            this.lvUsersPosts.Name = "lvUsersPosts";
            this.lvUsersPosts.Size = new System.Drawing.Size(921, 562);
            this.lvUsersPosts.TabIndex = 0;
            this.lvUsersPosts.UseCompatibleStateImageBehavior = false;
            this.lvUsersPosts.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvUsersPosts_MouseClick);
            this.lvUsersPosts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvUsersPosts_MouseDoubleClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(12, 411);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(161, 38);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.AutoSize = true;
            this.btnLogout.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Location = new System.Drawing.Point(12, 473);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(161, 38);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // BtnSearch
            // 
            this.BtnSearch.AutoSize = true;
            this.BtnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSearch.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnSearch.Location = new System.Drawing.Point(12, 54);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(161, 38);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "Tìm kiếm";
            this.BtnSearch.UseVisualStyleBackColor = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(161, 36);
            this.txtSearch.TabIndex = 5;
            // 
            // BtnRandomUsers
            // 
            this.BtnRandomUsers.AutoSize = true;
            this.BtnRandomUsers.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnRandomUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRandomUsers.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnRandomUsers.Location = new System.Drawing.Point(12, 284);
            this.BtnRandomUsers.Name = "BtnRandomUsers";
            this.BtnRandomUsers.Size = new System.Drawing.Size(161, 38);
            this.BtnRandomUsers.TabIndex = 6;
            this.BtnRandomUsers.Text = "Tạo người dùng";
            this.BtnRandomUsers.UseVisualStyleBackColor = false;
            this.BtnRandomUsers.Click += new System.EventHandler(this.BtnRandomUsers_Click);
            // 
            // BtnRandomPosts
            // 
            this.BtnRandomPosts.AutoSize = true;
            this.BtnRandomPosts.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnRandomPosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRandomPosts.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnRandomPosts.Location = new System.Drawing.Point(12, 347);
            this.BtnRandomPosts.Name = "BtnRandomPosts";
            this.BtnRandomPosts.Size = new System.Drawing.Size(161, 38);
            this.BtnRandomPosts.TabIndex = 7;
            this.BtnRandomPosts.Text = "Tạo bài đăng";
            this.BtnRandomPosts.UseVisualStyleBackColor = false;
            this.BtnRandomPosts.Click += new System.EventHandler(this.BtnRandomPosts_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1100, 562);
            this.Controls.Add(this.BtnRandomPosts);
            this.Controls.Add(this.BtnRandomUsers);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lvUsersPosts);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvUsersPosts;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button BtnRandomUsers;
        private System.Windows.Forms.Button BtnRandomPosts;
    }
}