namespace FilenameOrganizer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.targetDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.ruleTextArea = new System.Windows.Forms.RichTextBox();
            this.ruleToolStrip = new System.Windows.Forms.ToolStrip();
            this.ruleNewButton = new System.Windows.Forms.ToolStripButton();
            this.ruleOpenButton = new System.Windows.Forms.ToolStripButton();
            this.ruleSaveButton = new System.Windows.Forms.ToolStripButton();
            this.ruleSaveAsButton = new System.Windows.Forms.ToolStripButton();
            this.grid1 = new SourceGrid.Grid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.targetSelectButton = new System.Windows.Forms.ToolStripButton();
            this.targetPrevewRename = new System.Windows.Forms.ToolStripButton();
            this.ruleOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.ruleSaveAsDialog = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.ruleToolStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // targetDialog
            // 
            this.targetDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.targetDialog.SelectedPath = "D:\\temp\\[Comic] sort";
            this.targetDialog.ShowNewFolderButton = false;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.ruleTextArea);
            this.splitContainer.Panel1.Controls.Add(this.ruleToolStrip);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.grid1);
            this.splitContainer.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer.Size = new System.Drawing.Size(892, 466);
            this.splitContainer.SplitterDistance = 258;
            this.splitContainer.TabIndex = 1;
            // 
            // ruleTextArea
            // 
            this.ruleTextArea.AcceptsTab = true;
            this.ruleTextArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ruleTextArea.Location = new System.Drawing.Point(0, 25);
            this.ruleTextArea.Name = "ruleTextArea";
            this.ruleTextArea.Size = new System.Drawing.Size(258, 441);
            this.ruleTextArea.TabIndex = 1;
            this.ruleTextArea.Text = "";
            // 
            // ruleToolStrip
            // 
            this.ruleToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ruleNewButton,
            this.ruleOpenButton,
            this.ruleSaveButton,
            this.ruleSaveAsButton});
            this.ruleToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ruleToolStrip.Name = "ruleToolStrip";
            this.ruleToolStrip.Size = new System.Drawing.Size(258, 25);
            this.ruleToolStrip.TabIndex = 0;
            this.ruleToolStrip.Text = "ruleToolStrip";
            // 
            // ruleNewButton
            // 
            this.ruleNewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ruleNewButton.Image = ((System.Drawing.Image)(resources.GetObject("ruleNewButton.Image")));
            this.ruleNewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ruleNewButton.Name = "ruleNewButton";
            this.ruleNewButton.Size = new System.Drawing.Size(30, 22);
            this.ruleNewButton.Text = "New";
            // 
            // ruleOpenButton
            // 
            this.ruleOpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ruleOpenButton.Image = ((System.Drawing.Image)(resources.GetObject("ruleOpenButton.Image")));
            this.ruleOpenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ruleOpenButton.Name = "ruleOpenButton";
            this.ruleOpenButton.Size = new System.Drawing.Size(34, 22);
            this.ruleOpenButton.Text = "Open";
            this.ruleOpenButton.Click += new System.EventHandler(this.ruleOpenButton_Click);
            // 
            // ruleSaveButton
            // 
            this.ruleSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ruleSaveButton.Image = ((System.Drawing.Image)(resources.GetObject("ruleSaveButton.Image")));
            this.ruleSaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ruleSaveButton.Name = "ruleSaveButton";
            this.ruleSaveButton.Size = new System.Drawing.Size(31, 22);
            this.ruleSaveButton.Text = "Save";
            this.ruleSaveButton.Click += new System.EventHandler(this.ruleSaveButton_Click);
            // 
            // ruleSaveAsButton
            // 
            this.ruleSaveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ruleSaveAsButton.Image = ((System.Drawing.Image)(resources.GetObject("ruleSaveAsButton.Image")));
            this.ruleSaveAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ruleSaveAsButton.Name = "ruleSaveAsButton";
            this.ruleSaveAsButton.Size = new System.Drawing.Size(55, 22);
            this.ruleSaveAsButton.Text = "Save As...";
            this.ruleSaveAsButton.Click += new System.EventHandler(this.ruleSaveAsButton_Click);
            // 
            // grid1
            // 
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(0, 25);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(630, 441);
            this.grid1.TabIndex = 3;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.targetSelectButton,
            this.targetPrevewRename});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(630, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // targetSelectButton
            // 
            this.targetSelectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.targetSelectButton.Image = ((System.Drawing.Image)(resources.GetObject("targetSelectButton.Image")));
            this.targetSelectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.targetSelectButton.Name = "targetSelectButton";
            this.targetSelectButton.Size = new System.Drawing.Size(102, 22);
            this.targetSelectButton.Text = "Select Target Folder";
            this.targetSelectButton.Click += new System.EventHandler(this.targetSelectButton_Click);
            // 
            // targetPrevewRename
            // 
            this.targetPrevewRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.targetPrevewRename.Image = ((System.Drawing.Image)(resources.GetObject("targetPrevewRename.Image")));
            this.targetPrevewRename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.targetPrevewRename.Name = "targetPrevewRename";
            this.targetPrevewRename.Size = new System.Drawing.Size(87, 22);
            this.targetPrevewRename.Text = "Preview Rename";
            this.targetPrevewRename.Click += new System.EventHandler(this.targetPrevewRename_Click);
            // 
            // ruleOpenDialog
            // 
            this.ruleOpenDialog.Filter = "Rule files|*.txt";
            // 
            // ruleSaveAsDialog
            // 
            this.ruleSaveAsDialog.DefaultExt = "txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 466);
            this.Controls.Add(this.splitContainer);
            this.Name = "Form1";
            this.Text = "Filename Organizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            this.ruleToolStrip.ResumeLayout(false);
            this.ruleToolStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog targetDialog;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStrip ruleToolStrip;
        private System.Windows.Forms.ToolStripButton ruleOpenButton;
        private System.Windows.Forms.ToolStripButton ruleSaveButton;
        private System.Windows.Forms.ToolStripButton ruleSaveAsButton;
        private System.Windows.Forms.OpenFileDialog ruleOpenDialog;
        private System.Windows.Forms.SaveFileDialog ruleSaveAsDialog;
        private System.Windows.Forms.RichTextBox ruleTextArea;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton targetSelectButton;
        private System.Windows.Forms.ToolStripButton targetPrevewRename;
        private System.Windows.Forms.ToolStripButton ruleNewButton;
        private SourceGrid.Grid grid1;
    }
}

