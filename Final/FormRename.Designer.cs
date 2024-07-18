namespace Final
{
    partial class FormRename
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
            textBoxNewName = new TextBox();
            buttonConfirm = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 42);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(56, 17);
            label1.TabIndex = 0;
            label1.Text = "新名称：";
            // 
            // textBoxNewName
            // 
            textBoxNewName.Location = new Point(24, 81);
            textBoxNewName.Margin = new Padding(2);
            textBoxNewName.Name = "textBoxNewName";
            textBoxNewName.Size = new Size(302, 23);
            textBoxNewName.TabIndex = 1;
            // 
            // buttonConfirm
            // 
            buttonConfirm.Location = new Point(24, 128);
            buttonConfirm.Margin = new Padding(2);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(75, 25);
            buttonConfirm.TabIndex = 2;
            buttonConfirm.Text = "确认";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(249, 128);
            buttonCancel.Margin = new Padding(2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 25);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "取消";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormRename
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 180);
            Controls.Add(buttonCancel);
            Controls.Add(buttonConfirm);
            Controls.Add(textBoxNewName);
            Controls.Add(label1);
            Margin = new Padding(2);
            Name = "FormRename";
            Text = "FormRename";
            Load += FormRename_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxNewName;
        private Button buttonConfirm;
        private Button buttonCancel;
    }
}