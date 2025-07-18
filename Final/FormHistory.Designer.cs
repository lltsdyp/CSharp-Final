﻿namespace Final
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
            components = new System.ComponentModel.Container();
            pictureBoxPanel = new PictureBox();
            webViewComment = new Microsoft.Web.WebView2.WinForms.WebView2();
            tableLayoutPanelHorizonal = new TableLayoutPanel();
            tableLayoutPanelVertical = new TableLayoutPanel();
            piecePosition = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)pictureBoxPanel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)webViewComment).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxPanel
            // 
            pictureBoxPanel.Dock = DockStyle.Right;
            pictureBoxPanel.Image = GamePictures.Panel;
            pictureBoxPanel.Location = new Point(293, 0);
            pictureBoxPanel.Margin = new Padding(2, 2, 2, 2);
            pictureBoxPanel.Name = "pictureBoxPanel";
            pictureBoxPanel.Size = new Size(444, 445);
            pictureBoxPanel.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPanel.TabIndex = 0;
            pictureBoxPanel.TabStop = false;
            pictureBoxPanel.MouseEnter += pictureBoxPanel_MouseEnter;
            pictureBoxPanel.MouseLeave += pictureBoxPanel_MouseLeave;
            // 
            // webViewComment
            // 
            webViewComment.AllowExternalDrop = true;
            webViewComment.CreationProperties = null;
            webViewComment.DefaultBackgroundColor = Color.White;
            webViewComment.Dock = DockStyle.Fill;
            webViewComment.Location = new Point(0, 0);
            webViewComment.Margin = new Padding(2, 2, 2, 2);
            webViewComment.Name = "webViewComment";
            webViewComment.Size = new Size(293, 445);
            webViewComment.TabIndex = 1;
            webViewComment.ZoomFactor = 1D;
            // 
            // tableLayoutPanelHorizonal
            // 
            tableLayoutPanelHorizonal.AutoSize = true;
            tableLayoutPanelHorizonal.BackColor = Color.White;
            tableLayoutPanelHorizonal.ColumnCount = 15;
            tableLayoutPanelHorizonal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelHorizonal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelHorizonal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanelHorizonal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanelHorizonal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanelHorizonal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanelHorizonal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanelHorizonal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanelHorizonal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanelHorizonal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanelHorizonal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanelHorizonal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanelHorizonal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanelHorizonal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanelHorizonal.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 10F));
            tableLayoutPanelHorizonal.Location = new Point(313, 0);
            tableLayoutPanelHorizonal.Margin = new Padding(2, 2, 2, 2);
            tableLayoutPanelHorizonal.Name = "tableLayoutPanelHorizonal";
            tableLayoutPanelHorizonal.RowCount = 1;
            tableLayoutPanelHorizonal.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelHorizonal.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelHorizonal.Size = new Size(200, 21);
            tableLayoutPanelHorizonal.TabIndex = 2;
            // 
            // tableLayoutPanelVertical
            // 
            tableLayoutPanelVertical.AutoSize = true;
            tableLayoutPanelVertical.ColumnCount = 1;
            tableLayoutPanelVertical.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelVertical.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelVertical.Location = new Point(293, 0);
            tableLayoutPanelVertical.Margin = new Padding(2, 2, 2, 2);
            tableLayoutPanelVertical.Name = "tableLayoutPanelVertical";
            tableLayoutPanelVertical.RowCount = 15;
            tableLayoutPanelVertical.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelVertical.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelVertical.RowStyles.Add(new RowStyle(SizeType.Absolute, 11F));
            tableLayoutPanelVertical.RowStyles.Add(new RowStyle(SizeType.Absolute, 11F));
            tableLayoutPanelVertical.RowStyles.Add(new RowStyle(SizeType.Absolute, 11F));
            tableLayoutPanelVertical.RowStyles.Add(new RowStyle(SizeType.Absolute, 11F));
            tableLayoutPanelVertical.RowStyles.Add(new RowStyle(SizeType.Absolute, 11F));
            tableLayoutPanelVertical.RowStyles.Add(new RowStyle(SizeType.Absolute, 11F));
            tableLayoutPanelVertical.RowStyles.Add(new RowStyle(SizeType.Absolute, 11F));
            tableLayoutPanelVertical.RowStyles.Add(new RowStyle(SizeType.Absolute, 11F));
            tableLayoutPanelVertical.RowStyles.Add(new RowStyle(SizeType.Absolute, 11F));
            tableLayoutPanelVertical.RowStyles.Add(new RowStyle(SizeType.Absolute, 11F));
            tableLayoutPanelVertical.RowStyles.Add(new RowStyle(SizeType.Absolute, 11F));
            tableLayoutPanelVertical.RowStyles.Add(new RowStyle(SizeType.Absolute, 11F));
            tableLayoutPanelVertical.RowStyles.Add(new RowStyle(SizeType.Absolute, 11F));
            tableLayoutPanelVertical.Size = new Size(15, 143);
            tableLayoutPanelVertical.TabIndex = 3;
            // 
            // FormHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 445);
            Controls.Add(tableLayoutPanelVertical);
            Controls.Add(tableLayoutPanelHorizonal);
            Controls.Add(webViewComment);
            Controls.Add(pictureBoxPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            Name = "FormHistory";
            Text = "FormHistory";
            Load += FormHistory_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxPanel).EndInit();
            ((System.ComponentModel.ISupportInitialize)webViewComment).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxPanel;
        private Microsoft.Web.WebView2.WinForms.WebView2 webViewComment;
        private TableLayoutPanel tableLayoutPanelHorizonal;
        private TableLayoutPanel tableLayoutPanelVertical;
        private ToolTip piecePosition;
    }
}