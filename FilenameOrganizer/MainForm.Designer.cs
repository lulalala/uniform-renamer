namespace FilenameOrganizer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.newFormatTextbox = new System.Windows.Forms.TextBox();
            this.ruleTextArea = new System.Windows.Forms.RichTextBox();
            this.RuleMenu = new System.Windows.Forms.ToolStrip();
            this.RuleNewButton = new System.Windows.Forms.ToolStripButton();
            this.RuleOpenButton = new System.Windows.Forms.ToolStripButton();
            this.RuleSaveButton = new System.Windows.Forms.ToolStripButton();
            this.RuleSaveAsButton = new System.Windows.Forms.ToolStripButton();
            this.ListGrid = new SourceGrid.Grid();
            this.TargetMenu = new System.Windows.Forms.ToolStrip();
            this.TargetSelectButton = new System.Windows.Forms.ToolStripButton();
            this.RenamePreviewButton = new System.Windows.Forms.ToolStripButton();
            this.RenameResetButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RenameButton = new System.Windows.Forms.ToolStripButton();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ErrorLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.TargetDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.RuleOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.RuleSaveAsDialog = new System.Windows.Forms.SaveFileDialog();
            this.VersionLabel = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.RuleMenu.SuspendLayout();
            this.TargetMenu.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.AccessibleDescription = null;
            this.splitContainer.AccessibleName = null;
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.BackgroundImage = null;
            this.splitContainer.Font = null;
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AccessibleDescription = null;
            this.splitContainer.Panel1.AccessibleName = null;
            resources.ApplyResources(this.splitContainer.Panel1, "splitContainer.Panel1");
            this.splitContainer.Panel1.BackgroundImage = null;
            this.splitContainer.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer.Panel1.Controls.Add(this.RuleMenu);
            this.splitContainer.Panel1.Font = null;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AccessibleDescription = null;
            this.splitContainer.Panel2.AccessibleName = null;
            resources.ApplyResources(this.splitContainer.Panel2, "splitContainer.Panel2");
            this.splitContainer.Panel2.BackgroundImage = null;
            this.splitContainer.Panel2.Controls.Add(this.ListGrid);
            this.splitContainer.Panel2.Controls.Add(this.TargetMenu);
            this.splitContainer.Panel2.Controls.Add(this.StatusBar);
            this.splitContainer.Panel2.Font = null;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AccessibleDescription = null;
            this.tableLayoutPanel1.AccessibleName = null;
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.BackgroundImage = null;
            this.tableLayoutPanel1.Controls.Add(this.newFormatTextbox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ruleTextArea, 0, 1);
            this.tableLayoutPanel1.Font = null;
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // newFormatTextbox
            // 
            this.newFormatTextbox.AccessibleDescription = null;
            this.newFormatTextbox.AccessibleName = null;
            resources.ApplyResources(this.newFormatTextbox, "newFormatTextbox");
            this.newFormatTextbox.BackgroundImage = null;
            this.newFormatTextbox.Font = null;
            this.newFormatTextbox.Name = "newFormatTextbox";
            // 
            // ruleTextArea
            // 
            this.ruleTextArea.AcceptsTab = true;
            this.ruleTextArea.AccessibleDescription = null;
            this.ruleTextArea.AccessibleName = null;
            resources.ApplyResources(this.ruleTextArea, "ruleTextArea");
            this.ruleTextArea.BackgroundImage = null;
            this.ruleTextArea.DetectUrls = false;
            this.ruleTextArea.Font = null;
            this.ruleTextArea.Name = "ruleTextArea";
            this.ruleTextArea.TextChanged += new System.EventHandler(this.ruleTextArea_TextChanged);
            // 
            // RuleMenu
            // 
            this.RuleMenu.AccessibleDescription = null;
            this.RuleMenu.AccessibleName = null;
            resources.ApplyResources(this.RuleMenu, "RuleMenu");
            this.RuleMenu.BackgroundImage = null;
            this.RuleMenu.Font = null;
            this.RuleMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RuleNewButton,
            this.RuleOpenButton,
            this.RuleSaveButton,
            this.RuleSaveAsButton,
            this.VersionLabel});
            this.RuleMenu.Name = "RuleMenu";
            // 
            // RuleNewButton
            // 
            this.RuleNewButton.AccessibleDescription = null;
            this.RuleNewButton.AccessibleName = null;
            resources.ApplyResources(this.RuleNewButton, "RuleNewButton");
            this.RuleNewButton.BackgroundImage = null;
            this.RuleNewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RuleNewButton.Name = "RuleNewButton";
            this.RuleNewButton.Click += new System.EventHandler(this.RuleNewButton_Click);
            // 
            // RuleOpenButton
            // 
            this.RuleOpenButton.AccessibleDescription = null;
            this.RuleOpenButton.AccessibleName = null;
            resources.ApplyResources(this.RuleOpenButton, "RuleOpenButton");
            this.RuleOpenButton.BackgroundImage = null;
            this.RuleOpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RuleOpenButton.Name = "RuleOpenButton";
            this.RuleOpenButton.Click += new System.EventHandler(this.RuleOpenButton_Click);
            // 
            // RuleSaveButton
            // 
            this.RuleSaveButton.AccessibleDescription = null;
            this.RuleSaveButton.AccessibleName = null;
            resources.ApplyResources(this.RuleSaveButton, "RuleSaveButton");
            this.RuleSaveButton.BackgroundImage = null;
            this.RuleSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RuleSaveButton.Name = "RuleSaveButton";
            this.RuleSaveButton.Click += new System.EventHandler(this.RuleSaveButton_Click);
            // 
            // RuleSaveAsButton
            // 
            this.RuleSaveAsButton.AccessibleDescription = null;
            this.RuleSaveAsButton.AccessibleName = null;
            resources.ApplyResources(this.RuleSaveAsButton, "RuleSaveAsButton");
            this.RuleSaveAsButton.BackgroundImage = null;
            this.RuleSaveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RuleSaveAsButton.Name = "RuleSaveAsButton";
            this.RuleSaveAsButton.Click += new System.EventHandler(this.RuleSaveAsButton_Click);
            // 
            // ListGrid
            // 
            this.ListGrid.AccessibleDescription = null;
            this.ListGrid.AccessibleName = null;
            resources.ApplyResources(this.ListGrid, "ListGrid");
            this.ListGrid.AutoStretchColumnsToFitWidth = true;
            this.ListGrid.BackColor = System.Drawing.SystemColors.Window;
            this.ListGrid.BackgroundImage = null;
            this.ListGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ListGrid.ColumnsCount = 2;
            this.ListGrid.EnableSort = false;
            this.ListGrid.FixedRows = 1;
            this.ListGrid.Font = null;
            this.ListGrid.Name = "ListGrid";
            this.ListGrid.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.ListGrid.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.ListGrid.TabStop = true;
            this.ListGrid.ToolTipText = "";
            // 
            // TargetMenu
            // 
            this.TargetMenu.AccessibleDescription = null;
            this.TargetMenu.AccessibleName = null;
            resources.ApplyResources(this.TargetMenu, "TargetMenu");
            this.TargetMenu.BackgroundImage = null;
            this.TargetMenu.Font = null;
            this.TargetMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TargetSelectButton,
            this.RenamePreviewButton,
            this.RenameResetButton,
            this.toolStripSeparator1,
            this.RenameButton});
            this.TargetMenu.Name = "TargetMenu";
            // 
            // TargetSelectButton
            // 
            this.TargetSelectButton.AccessibleDescription = null;
            this.TargetSelectButton.AccessibleName = null;
            resources.ApplyResources(this.TargetSelectButton, "TargetSelectButton");
            this.TargetSelectButton.BackgroundImage = null;
            this.TargetSelectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TargetSelectButton.Name = "TargetSelectButton";
            this.TargetSelectButton.Click += new System.EventHandler(this.TargetSelectButton_Click);
            // 
            // RenamePreviewButton
            // 
            this.RenamePreviewButton.AccessibleDescription = null;
            this.RenamePreviewButton.AccessibleName = null;
            resources.ApplyResources(this.RenamePreviewButton, "RenamePreviewButton");
            this.RenamePreviewButton.BackgroundImage = null;
            this.RenamePreviewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RenamePreviewButton.Name = "RenamePreviewButton";
            this.RenamePreviewButton.Click += new System.EventHandler(this.TargetPrevewRename_Click);
            // 
            // RenameResetButton
            // 
            this.RenameResetButton.AccessibleDescription = null;
            this.RenameResetButton.AccessibleName = null;
            resources.ApplyResources(this.RenameResetButton, "RenameResetButton");
            this.RenameResetButton.BackgroundImage = null;
            this.RenameResetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RenameResetButton.Name = "RenameResetButton";
            this.RenameResetButton.Click += new System.EventHandler(this.ResetRenameButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AccessibleDescription = null;
            this.toolStripSeparator1.AccessibleName = null;
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // RenameButton
            // 
            this.RenameButton.AccessibleDescription = null;
            this.RenameButton.AccessibleName = null;
            resources.ApplyResources(this.RenameButton, "RenameButton");
            this.RenameButton.BackgroundImage = null;
            this.RenameButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.AccessibleDescription = null;
            this.StatusBar.AccessibleName = null;
            resources.ApplyResources(this.StatusBar, "StatusBar");
            this.StatusBar.BackgroundImage = null;
            this.StatusBar.Font = null;
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ErrorLabel});
            this.StatusBar.Name = "StatusBar";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AccessibleDescription = null;
            this.toolStripStatusLabel1.AccessibleName = null;
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.BackgroundImage = null;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AccessibleDescription = null;
            this.ErrorLabel.AccessibleName = null;
            resources.ApplyResources(this.ErrorLabel, "ErrorLabel");
            this.ErrorLabel.BackgroundImage = null;
            this.ErrorLabel.Name = "ErrorLabel";
            // 
            // TargetDialog
            // 
            resources.ApplyResources(this.TargetDialog, "TargetDialog");
            this.TargetDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.TargetDialog.ShowNewFolderButton = false;
            // 
            // RuleOpenDialog
            // 
            resources.ApplyResources(this.RuleOpenDialog, "RuleOpenDialog");
            // 
            // RuleSaveAsDialog
            // 
            this.RuleSaveAsDialog.DefaultExt = "txt";
            resources.ApplyResources(this.RuleSaveAsDialog, "RuleSaveAsDialog");
            // 
            // VersionLabel
            // 
            this.VersionLabel.AccessibleDescription = null;
            this.VersionLabel.AccessibleName = null;
            this.VersionLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.VersionLabel, "VersionLabel");
            this.VersionLabel.BackgroundImage = null;
            this.VersionLabel.Name = "VersionLabel";
            // 
            // MainForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.splitContainer);
            this.Font = null;
            this.Icon = null;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.RuleMenu.ResumeLayout(false);
            this.RuleMenu.PerformLayout();
            this.TargetMenu.ResumeLayout(false);
            this.TargetMenu.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog TargetDialog;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolStrip RuleMenu;
        private System.Windows.Forms.ToolStripButton RuleOpenButton;
        private System.Windows.Forms.ToolStripButton RuleSaveButton;
        private System.Windows.Forms.ToolStripButton RuleSaveAsButton;
        private System.Windows.Forms.OpenFileDialog RuleOpenDialog;
        private System.Windows.Forms.SaveFileDialog RuleSaveAsDialog;
        private System.Windows.Forms.RichTextBox ruleTextArea;
        private System.Windows.Forms.ToolStrip TargetMenu;
        private System.Windows.Forms.ToolStripButton TargetSelectButton;
        private System.Windows.Forms.ToolStripButton RenamePreviewButton;
        private System.Windows.Forms.ToolStripButton RuleNewButton;
        private SourceGrid.Grid ListGrid;
        private System.Windows.Forms.ToolStripButton RenameButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton RenameResetButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox newFormatTextbox;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ErrorLabel;
        private System.Windows.Forms.ToolStripLabel VersionLabel;
    }
}

