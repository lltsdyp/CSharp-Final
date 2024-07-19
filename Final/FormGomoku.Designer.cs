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
            components = new System.ComponentModel.Container();
            PictureBox pictureBox1;
            tableLayoutPanelMain = new TableLayoutPanel();
            panelGuide = new Panel();
            labelGuide = new Label();
            panelInformation = new Panel();
            label3 = new Label();
            buttonExport = new Button();
            buttonOpen = new Button();
            listBoxHistory = new ListBox();
            contextMenuStripHistory = new ContextMenuStrip(components);
            打开ToolStripMenuItem = new ToolStripMenuItem();
            重命名ToolStripMenuItem = new ToolStripMenuItem();
            删除ToolStripMenuItem = new ToolStripMenuItem();
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
            panelMain = new Panel();
            pictureBoxGobangPanel = new PictureBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanelMain.SuspendLayout();
            panelGuide.SuspendLayout();
            panelInformation.SuspendLayout();
            contextMenuStripHistory.SuspendLayout();
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
            pictureBox1.Location = new Point(122, 73);
            pictureBox1.Margin = new Padding(6, 5, 6, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(212, 82);
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
            tableLayoutPanelMain.Margin = new Padding(6, 5, 6, 5);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 2;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tableLayoutPanelMain.Size = new Size(2240, 1165);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelGuide
            // 
            tableLayoutPanelMain.SetColumnSpan(panelGuide, 2);
            panelGuide.Controls.Add(labelGuide);
            panelGuide.Dock = DockStyle.Fill;
            panelGuide.Location = new Point(6, 5);
            panelGuide.Margin = new Padding(6, 5, 6, 5);
            panelGuide.Name = "panelGuide";
            panelGuide.Size = new Size(2228, 164);
            panelGuide.TabIndex = 1;
            // 
            // labelGuide
            // 
            labelGuide.Dock = DockStyle.Fill;
            labelGuide.Font = new Font("Microsoft YaHei UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 134);
            labelGuide.Location = new Point(0, 0);
            labelGuide.Margin = new Padding(6, 0, 6, 0);
            labelGuide.Name = "labelGuide";
            labelGuide.Size = new Size(2228, 164);
            labelGuide.TabIndex = 0;
            labelGuide.Text = "此处由程序修改";
            labelGuide.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelInformation
            // 
            panelInformation.Controls.Add(label3);
            panelInformation.Controls.Add(buttonExport);
            panelInformation.Controls.Add(buttonOpen);
            panelInformation.Controls.Add(listBoxHistory);
            panelInformation.Controls.Add(label2);
            panelInformation.Controls.Add(comboBoxLevel);
            panelInformation.Controls.Add(panel1);
            panelInformation.Controls.Add(panelMatch);
            panelInformation.Dock = DockStyle.Fill;
            panelInformation.Location = new Point(6, 179);
            panelInformation.Margin = new Padding(6, 5, 6, 5);
            panelInformation.Name = "panelInformation";
            panelInformation.Size = new Size(436, 981);
            panelInformation.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 452);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(134, 31);
            label3.TabIndex = 12;
            label3.Text = "历史棋谱：";
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(6, 934);
            buttonExport.Margin = new Padding(6, 5, 6, 5);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(150, 42);
            buttonExport.TabIndex = 11;
            buttonExport.Text = "导出";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // buttonOpen
            // 
            buttonOpen.Location = new Point(286, 934);
            buttonOpen.Margin = new Padding(6, 5, 6, 5);
            buttonOpen.Name = "buttonOpen";
            buttonOpen.Size = new Size(150, 42);
            buttonOpen.TabIndex = 10;
            buttonOpen.Text = "打开";
            buttonOpen.UseVisualStyleBackColor = true;
            buttonOpen.Click += buttonOpen_Click;
            // 
            // listBoxHistory
            // 
            listBoxHistory.CausesValidation = false;
            listBoxHistory.ContextMenuStrip = contextMenuStripHistory;
            listBoxHistory.FormattingEnabled = true;
            listBoxHistory.Location = new Point(6, 487);
            listBoxHistory.Margin = new Padding(6, 5, 6, 5);
            listBoxHistory.Name = "listBoxHistory";
            listBoxHistory.Size = new Size(422, 438);
            listBoxHistory.TabIndex = 9;
            listBoxHistory.MouseDoubleClick += listBoxHistory_MouseDoubleClick;
            listBoxHistory.MouseDown += listBoxHistory_MouseDown;
            // 
            // contextMenuStripHistory
            // 
            contextMenuStripHistory.ImageScalingSize = new Size(32, 32);
            contextMenuStripHistory.Items.AddRange(new ToolStripItem[] { 打开ToolStripMenuItem, 重命名ToolStripMenuItem, 删除ToolStripMenuItem });
            contextMenuStripHistory.Name = "contextMenuStripHistory";
            contextMenuStripHistory.Size = new Size(161, 118);
            // 
            // 打开ToolStripMenuItem
            // 
            打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            打开ToolStripMenuItem.Size = new Size(160, 38);
            打开ToolStripMenuItem.Text = "打开";
            打开ToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // 重命名ToolStripMenuItem
            // 
            重命名ToolStripMenuItem.Name = "重命名ToolStripMenuItem";
            重命名ToolStripMenuItem.Size = new Size(160, 38);
            重命名ToolStripMenuItem.Text = "重命名";
            重命名ToolStripMenuItem.Click += RenameToolStripMenuItem_Click;
            // 
            // 删除ToolStripMenuItem
            // 
            删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            删除ToolStripMenuItem.Size = new Size(160, 38);
            删除ToolStripMenuItem.Text = "删除";
            删除ToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 134);
            label2.Location = new Point(0, 399);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(136, 50);
            label2.TabIndex = 8;
            label2.Text = "难度：";
            // 
            // comboBoxLevel
            // 
            comboBoxLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLevel.FormattingEnabled = true;
            comboBoxLevel.Location = new Point(146, 399);
            comboBoxLevel.Margin = new Padding(6, 5, 6, 5);
            comboBoxLevel.Name = "comboBoxLevel";
            comboBoxLevel.Size = new Size(280, 39);
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
            panel1.Margin = new Padding(6, 5, 6, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(436, 129);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 134);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(436, 35);
            label1.TabIndex = 0;
            label1.Text = "玩家名称：";
            // 
            // textBoxPlayerName
            // 
            textBoxPlayerName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxPlayerName.Location = new Point(2, 40);
            textBoxPlayerName.Margin = new Padding(6, 5, 6, 5);
            textBoxPlayerName.Name = "textBoxPlayerName";
            textBoxPlayerName.Size = new Size(424, 38);
            textBoxPlayerName.TabIndex = 1;
            textBoxPlayerName.Text = "新玩家";
            // 
            // buttonConfirm
            // 
            buttonConfirm.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonConfirm.Location = new Point(280, 82);
            buttonConfirm.Margin = new Padding(6, 5, 6, 5);
            buttonConfirm.Name = "buttonConfirm";
            buttonConfirm.Size = new Size(150, 42);
            buttonConfirm.TabIndex = 4;
            buttonConfirm.Text = "确认";
            buttonConfirm.UseVisualStyleBackColor = true;
            buttonConfirm.Click += buttonConfirm_Click;
            // 
            // buttonGiveup
            // 
            buttonGiveup.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            buttonGiveup.Enabled = false;
            buttonGiveup.Location = new Point(0, 82);
            buttonGiveup.Margin = new Padding(6, 5, 6, 5);
            buttonGiveup.Name = "buttonGiveup";
            buttonGiveup.RightToLeft = RightToLeft.No;
            buttonGiveup.Size = new Size(150, 42);
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
            panelMatch.Location = new Point(0, 140);
            panelMatch.Margin = new Padding(6, 5, 6, 5);
            panelMatch.Name = "panelMatch";
            panelMatch.Size = new Size(432, 248);
            panelMatch.TabIndex = 5;
            // 
            // labelAI
            // 
            labelAI.Dock = DockStyle.Bottom;
            labelAI.Font = new Font("幼圆", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            labelAI.Location = new Point(0, 160);
            labelAI.Margin = new Padding(6, 0, 6, 0);
            labelAI.Name = "labelAI";
            labelAI.Size = new Size(432, 88);
            labelAI.TabIndex = 2;
            labelAI.Text = "AIMode";
            labelAI.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelPlayerName
            // 
            labelPlayerName.Dock = DockStyle.Top;
            labelPlayerName.Font = new Font("幼圆", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 134);
            labelPlayerName.Location = new Point(0, 0);
            labelPlayerName.Margin = new Padding(6, 0, 6, 0);
            labelPlayerName.Name = "labelPlayerName";
            labelPlayerName.Size = new Size(432, 91);
            labelPlayerName.TabIndex = 1;
            labelPlayerName.Text = "新玩家";
            labelPlayerName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(pictureBoxGobangPanel);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(454, 179);
            panelMain.Margin = new Padding(6, 5, 6, 5);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1780, 981);
            panelMain.TabIndex = 3;
            // 
            // pictureBoxGobangPanel
            // 
            pictureBoxGobangPanel.Dock = DockStyle.Fill;
            pictureBoxGobangPanel.Image = GamePictures.Panel;
            pictureBoxGobangPanel.Location = new Point(0, 0);
            pictureBoxGobangPanel.Margin = new Padding(6, 5, 6, 5);
            pictureBoxGobangPanel.Name = "pictureBoxGobangPanel";
            pictureBoxGobangPanel.Size = new Size(1780, 981);
            pictureBoxGobangPanel.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxGobangPanel.TabIndex = 1;
            pictureBoxGobangPanel.TabStop = false;
            pictureBoxGobangPanel.MouseDown += pictureBoxGobangPanel_MouseDown;
            // 
            // FormGomoku
            // 
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2240, 1165);
            Controls.Add(tableLayoutPanelMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(6, 5, 6, 5);
            MaximizeBox = false;
            Name = "FormGomoku";
            Text = "基于AI算法的智能五子棋对弈及分析程序";
            FormClosing += FormGomoku_FormClosing;
            Load += FormGobang_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanelMain.ResumeLayout(false);
            panelGuide.ResumeLayout(false);
            panelInformation.ResumeLayout(false);
            panelInformation.PerformLayout();
            contextMenuStripHistory.ResumeLayout(false);
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
        private ListBox listBoxHistory;
        private Button buttonExport;
        private Button buttonOpen;
        private ContextMenuStrip contextMenuStripHistory;
        private ToolStripMenuItem 打开ToolStripMenuItem;
        private ToolStripMenuItem 重命名ToolStripMenuItem;
        private ToolStripMenuItem 删除ToolStripMenuItem;
        private Label label3;
    }
}