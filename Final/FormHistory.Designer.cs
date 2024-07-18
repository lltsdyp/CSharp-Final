namespace Final
{
    partial class FormHistory
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
            pictureBoxPanel = new PictureBox();
            webViewComment = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPanel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webViewComment).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxPanel
            // 
            pictureBoxPanel.Dock = DockStyle.Right;
            pictureBoxPanel.Image = GamePictures.Panel;
            pictureBoxPanel.Location = new Point(293, 0);
            pictureBoxPanel.Margin = new Padding(2);
            pictureBoxPanel.Name = "pictureBoxPanel";
            pictureBoxPanel.Size = new Size(444, 445);
            pictureBoxPanel.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPanel.TabIndex = 0;
            pictureBoxPanel.TabStop = false;
            // 
            // webViewComment
            // 
            webViewComment.AllowExternalDrop = true;
            webViewComment.CreationProperties = null;
            webViewComment.DefaultBackgroundColor = Color.White;
            webViewComment.Dock = DockStyle.Fill;
            webViewComment.Location = new Point(0, 0);
            webViewComment.Margin = new Padding(2);
            webViewComment.Name = "webViewComment";
            webViewComment.Size = new Size(293, 445);
            webViewComment.TabIndex = 1;
            webViewComment.ZoomFactor = 1D;
            // 
            // FormHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 445);
            Controls.Add(webViewComment);
            Controls.Add(pictureBoxPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "FormHistory";
            Text = "FormHistory";
            Load += FormHistory_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxPanel).EndInit();
            ((System.ComponentModel.ISupportInitialize)webViewComment).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxPanel;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewComment;
    }
}