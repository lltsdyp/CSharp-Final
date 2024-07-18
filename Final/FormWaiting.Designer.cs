namespace Final
{
    partial class FormWaiting
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
            label1 = new Label();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label1.ImageAlign = ContentAlignment.TopLeft;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(434, 99);
            label1.TabIndex = 0;
            label1.Text = "    AI正在生成棋局的分析，请稍等，强制结束该程序可能导致棋局无法保存";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(171, 102);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "取消";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormWaiting
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 130);
            Controls.Add(buttonCancel);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormWaiting";
            Text = "请等待";
            FormClosing += FormWaiting_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Button buttonCancel;
    }
}