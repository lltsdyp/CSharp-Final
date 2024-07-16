namespace Final
{
    partial class FormGomoku
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
            PictureBox pictureBox1;
            tableLayoutPanelMain = new TableLayoutPanel();
            panelGuide = new Panel();
            labelGuide = new Label();
            panelInformation = new Panel();
            label2 = new Label();
            comboBoxLevel = new ComboBox();
            panel1 = new Panel();
            label1 = new Label();
            textBoxPlayerName = new TextBox();
            buttonConfirm = new Button();
            buttonGiveup = new Button();
            panelMatch = new Panel();
            labelAI = new Label();
            labelPlayerName = new Label();
            textBoxDialog = new TextBox();
            panelMain = new Panel();
            pictureBoxGobangPanel = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanelMain.SuspendLayout();
            panelGuide.SuspendLayout();
            panelInformation.SuspendLayout();
            panel1.SuspendLayout();
            panelMatch.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxGobangPanel).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = GamePictures.Versus;
            pictureBox1.Location = new Point(61, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(85, 45);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 2;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanelMain.Controls.Add(panelGuide, 0, 0);
            tableLayoutPanelMain.Controls.Add(panelInformation, 0, 1);
            tableLayoutPanelMain.Controls.Add(panelMain, 1, 1);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(0, 0);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 2;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tableLayoutPanelMain.Size = new Size(1015, 636);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelGuide
            // 
            tableLayoutPanelMain.SetColumnSpan(panelGuide, 2);
            panelGuide.Controls.Add(labelGuide);
            panelGuide.Dock = DockStyle.Fill;
            panelGuide.Location = new Point(3, 3);
            panelGuide.Name = "panelGuide";
            panelGuide.Size = new Size(1009, 89);
            panelGuide.TabIndex = 1;
            // 
            // labelGuide
            // 
            labelGuide.Dock = DockStyle.Fill;
            labelGuide.Font = new Font("Microsoft YaHei UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            labelGuide.Location = new Point(0, 0);
            labelGuide.Name = "labelGuide";
            labelGuide.Size = new Size(1009, 89);
            labelGuide.TabIndex = 0;
            labelGuide.Text = "此处由程序修改";
            labelGuide.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelInformation
            // 
            panelInformation.Controls.Add(label2);
            panelInformation.Controls.Add(comboBoxLevel);
            panelInformation.Controls.Add(panel1);
            panelInformation.Controls.Add(panelMatch);
            panelInformation.Controls.Add(textBoxDialog);
            panelInformation.Dock = DockStyle.Fill;
            panelInformation.Location = new Point(3, 98);
            panelInformation.Name = "panelInformation";
            panelInformation.Size = new Size(197, 535);
            panelInformation.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label2.Location = new Point(0, 219);
            label2.Name = "label2";
            label2.Size = new Size(69, 25);
            label2.TabIndex = 8;
            label2.Text = "难度：";
            // 
            // comboBoxLevel
            // 
            comboBoxLevel.FormattingEnabled = true;
            comboBoxLevel.Location = new Point(73, 219);
            comboBoxLevel.Name = "comboBoxLevel";
            comboBoxLevel.Size = new Size(121, 25);
            comboBoxLevel.TabIndex = 7;
            comboBoxLevel.SelectedIndexChanged += comboBoxLevel_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBoxPlayerName);
            panel1.Controls.Add(buttonConfirm);
            panel1.Controls.Add(buttonGiveup);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(197, 71);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(197, 19);
            label1.TabIndex = 0;
            label1.Text = "玩家名称：";
            // 
            // textBoxPlayerName
            // 
            textBoxPlayerName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxPlayerName.Location = new Point(1, 22);
            textBoxPlayerName.Name = "textBoxPlayerName";
            textBoxPlayerName.Size = new Size(165, 23);
            textBoxPlayerName.TabIndex = 1;
            textBoxPlayerName.Text = "新玩家";
            // 
            // buttonConfirm
            // 
            buttonConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonConfirm.Location = new Point(91, 45);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(75, 23);
            buttonConfirm.TabIndex = 4;
            buttonConfirm.Text = "确认";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // buttonGiveup
            // 
            buttonGiveup.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonGiveup.Enabled = false;
            buttonGiveup.Location = new Point(0, 45);
            buttonGiveup.Name = "buttonGiveup";
            buttonGiveup.RightToLeft = RightToLeft.No;
            buttonGiveup.Size = new Size(75, 23);
            buttonGiveup.TabIndex = 3;
            buttonGiveup.Text = "投降";
            buttonGiveup.UseVisualStyleBackColor = true;
            buttonGiveup.Click += buttonGiveup_Click;
            // 
            // panelMatch
            // 
            panelMatch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelMatch.Controls.Add(labelAI);
            panelMatch.Controls.Add(pictureBox1);
            panelMatch.Controls.Add(labelPlayerName);
            panelMatch.Location = new Point(0, 77);
            panelMatch.Name = "panelMatch";
            panelMatch.Size = new Size(195, 136);
            panelMatch.TabIndex = 5;
            // 
            // labelAI
            // 
            labelAI.Dock = DockStyle.Bottom;
            labelAI.Font = new Font("幼圆", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            labelAI.Location = new Point(0, 88);
            labelAI.Name = "labelAI";
            labelAI.Size = new Size(195, 48);
            labelAI.TabIndex = 2;
            labelAI.Text = "AIMode";
            labelAI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelPlayerName
            // 
            labelPlayerName.Dock = DockStyle.Top;
            labelPlayerName.Font = new Font("幼圆", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            labelPlayerName.Location = new Point(0, 0);
            labelPlayerName.Name = "labelPlayerName";
            labelPlayerName.Size = new Size(195, 50);
            labelPlayerName.TabIndex = 1;
            labelPlayerName.Text = "新玩家";
            labelPlayerName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxDialog
            // 
            textBoxDialog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBoxDialog.Enabled = false;
            textBoxDialog.Location = new Point(0, 246);
            textBoxDialog.Multiline = true;
            textBoxDialog.Name = "textBoxDialog";
            textBoxDialog.ScrollBars = ScrollBars.Vertical;
            textBoxDialog.Size = new Size(197, 289);
            textBoxDialog.TabIndex = 2;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(pictureBoxGobangPanel);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(206, 98);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(806, 535);
            panelMain.TabIndex = 3;
            // 
            // pictureBoxGobangPanel
            // 
            pictureBoxGobangPanel.Dock = DockStyle.Fill;
            pictureBoxGobangPanel.Image = GamePictures.Panel;
            pictureBoxGobangPanel.Location = new Point(0, 0);
            pictureBoxGobangPanel.Name = "pictureBoxGobangPanel";
            pictureBoxGobangPanel.Size = new Size(806, 535);
            pictureBoxGobangPanel.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxGobangPanel.TabIndex = 1;
            pictureBoxGobangPanel.TabStop = false;
            pictureBoxGobangPanel.MouseDown += pictureBoxGobangPanel_MouseDown;
            // 
            // FormGomoku
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 636);
            Controls.Add(tableLayoutPanelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormGomoku";
            Text = "FormGomoku";
            Load += FormGobang_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanelMain.ResumeLayout(false);
            panelGuide.ResumeLayout(false);
            panelInformation.ResumeLayout(false);
            panelInformation.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelMatch.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxGobangPanel).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanelMain;
        private Panel panelGuide;
        private Panel panelInformation;
        private TextBox textBoxDialog;
        private TextBox textBoxPlayerName;
        private Label label1;
        private Button buttonGiveup;
        private Button buttonConfirm;
        private PictureBox pictureBox1;
        private Label labelAI;
        private Label labelPlayerName;
        private Panel panelMatch;
        private Label labelGuide;
        private Panel panel1;
        private Panel panelMain;
        private PictureBox pictureBoxGobangPanel;
        private Label label2;
        private ComboBox comboBoxLevel;
    }
}