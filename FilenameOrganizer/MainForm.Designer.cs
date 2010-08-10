﻿namespace FilenameOrganizer
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
            this.AboutButton = new System.Windows.Forms.ToolStripButton();
            this.ListGrid = new SourceGrid.Grid();
            this.TargetMenu = new System.Windows.Forms.ToolStrip();
            this.TargetSelectButton = new System.Windows.Forms.ToolStripButton();
            this.TargetPrevewRename = new System.Windows.Forms.ToolStripButton();
            this.ResetRenameButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RenameButton = new System.Windows.Forms.ToolStripButton();
            this.TargetDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.RuleOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.RuleSaveAsDialog = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.RuleMenu.SuspendLayout();
            this.TargetMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer.Panel1.Controls.Add(this.RuleMenu);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.ListGrid);
            this.splitContainer.Panel2.Controls.Add(this.TargetMenu);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.newFormatTextbox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ruleTextArea, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // newFormatTextbox
            // 
            resources.ApplyResources(this.newFormatTextbox, "newFormatTextbox");
            this.newFormatTextbox.Name = "newFormatTextbox";
            // 
            // ruleTextArea
            // 
            this.ruleTextArea.AcceptsTab = true;
            this.ruleTextArea.DetectUrls = false;
            resources.ApplyResources(this.ruleTextArea, "ruleTextArea");
            this.ruleTextArea.Name = "ruleTextArea";
            this.ruleTextArea.TextChanged += new System.EventHandler(this.ruleTextArea_TextChanged);
            // 
            // RuleMenu
            // 
            this.RuleMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RuleNewButton,
            this.RuleOpenButton,
            this.RuleSaveButton,
            this.RuleSaveAsButton,
            this.AboutButton});
            resources.ApplyResources(this.RuleMenu, "RuleMenu");
            this.RuleMenu.Name = "RuleMenu";
            // 
            // RuleNewButton
            // 
            this.RuleNewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.RuleNewButton, "RuleNewButton");
            this.RuleNewButton.Name = "RuleNewButton";
            this.RuleNewButton.Click += new System.EventHandler(this.RuleNewButton_Click);
            // 
            // RuleOpenButton
            // 
            this.RuleOpenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.RuleOpenButton, "RuleOpenButton");
            this.RuleOpenButton.Name = "RuleOpenButton";
            this.RuleOpenButton.Click += new System.EventHandler(this.RuleOpenButton_Click);
            // 
            // RuleSaveButton
            // 
            this.RuleSaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.RuleSaveButton, "RuleSaveButton");
            this.RuleSaveButton.Name = "RuleSaveButton";
            this.RuleSaveButton.Click += new System.EventHandler(this.RuleSaveButton_Click);
            // 
            // RuleSaveAsButton
            // 
            this.RuleSaveAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.RuleSaveAsButton, "RuleSaveAsButton");
            this.RuleSaveAsButton.Name = "RuleSaveAsButton";
            this.RuleSaveAsButton.Click += new System.EventHandler(this.RuleSaveAsButton_Click);
            // 
            // AboutButton
            // 
            this.AboutButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.AboutButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.AboutButton, "AboutButton");
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // ListGrid
            // 
            this.ListGrid.AutoStretchColumnsToFitWidth = true;
            this.ListGrid.BackColor = System.Drawing.SystemColors.Window;
            this.ListGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ListGrid.ColumnsCount = 2;
            resources.ApplyResources(this.ListGrid, "ListGrid");
            this.ListGrid.EnableSort = false;
            this.ListGrid.FixedRows = 1;
            this.ListGrid.Name = "ListGrid";
            this.ListGrid.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.ListGrid.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.ListGrid.TabStop = true;
            this.ListGrid.ToolTipText = "";
            // 
            // TargetMenu
            // 
            this.TargetMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TargetSelectButton,
            this.TargetPrevewRename,
            this.ResetRenameButton,
            this.toolStripSeparator1,
            this.RenameButton});
            resources.ApplyResources(this.TargetMenu, "TargetMenu");
            this.TargetMenu.Name = "TargetMenu";
            // 
            // TargetSelectButton
            // 
            this.TargetSelectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.TargetSelectButton, "TargetSelectButton");
            this.TargetSelectButton.Name = "TargetSelectButton";
            this.TargetSelectButton.Click += new System.EventHandler(this.TargetSelectButton_Click);
            // 
            // TargetPrevewRename
            // 
            this.TargetPrevewRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.TargetPrevewRename, "TargetPrevewRename");
            this.TargetPrevewRename.Name = "TargetPrevewRename";
            this.TargetPrevewRename.Click += new System.EventHandler(this.TargetPrevewRename_Click);
            // 
            // ResetRenameButton
            // 
            this.ResetRenameButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.ResetRenameButton, "ResetRenameButton");
            this.ResetRenameButton.Name = "ResetRenameButton";
            this.ResetRenameButton.Click += new System.EventHandler(this.ResetRenameButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // RenameButton
            // 
            this.RenameButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.RenameButton, "RenameButton");
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // TargetDialog
            // 
            this.TargetDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            resources.ApplyResources(this.TargetDialog, "TargetDialog");
            this.TargetDialog.ShowNewFolderButton = false;
            // 
            // RuleOpenDialog
            // 
            resources.ApplyResources(this.RuleOpenDialog, "RuleOpenDialog");
            // 
            // RuleSaveAsDialog
            // 
            this.RuleSaveAsDialog.DefaultExt = "txt";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
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
        private System.Windows.Forms.ToolStripButton TargetPrevewRename;
        private System.Windows.Forms.ToolStripButton RuleNewButton;
        private SourceGrid.Grid ListGrid;
        private System.Windows.Forms.ToolStripButton RenameButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ResetRenameButton;
        private System.Windows.Forms.ToolStripButton AboutButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox newFormatTextbox;
    }
}

