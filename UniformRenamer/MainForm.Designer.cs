﻿namespace UniformRenamer
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.newFormatTextBox = new System.Windows.Forms.TextBox();
            this.RuleMenu = new System.Windows.Forms.ToolStrip();
            this.RuleNewButton = new System.Windows.Forms.ToolStripButton();
            this.RuleOpenButton = new System.Windows.Forms.ToolStripButton();
            this.RuleSaveButton = new System.Windows.Forms.ToolStripButton();
            this.RuleSaveAsButton = new System.Windows.Forms.ToolStripButton();
            this.VersionLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.addCopyButton = new System.Windows.Forms.ToolStripButton();
            this.addDeleteButton = new System.Windows.Forms.ToolStripButton();
            this.addReplaceButton = new System.Windows.Forms.ToolStripButton();
            this.FileGrid = new SourceGrid.Grid();
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
            this.ruleGrid = new UniformRenamer.Core.RuleGrid();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.RuleMenu.SuspendLayout();
            this.TargetMenu.SuspendLayout();
            this.StatusBar.SuspendLayout();
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
            this.splitContainer.Panel2.Controls.Add(this.FileGrid);
            this.splitContainer.Panel2.Controls.Add(this.TargetMenu);
            this.splitContainer.Panel2.Controls.Add(this.StatusBar);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.ruleGrid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.newFormatTextBox);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // newFormatTextBox
            // 
            resources.ApplyResources(this.newFormatTextBox, "newFormatTextBox");
            this.newFormatTextBox.Name = "newFormatTextBox";
            this.newFormatTextBox.TextChanged += new System.EventHandler(this.newFormatTextBox_TextChanged);
            // 
            // RuleMenu
            // 
            this.RuleMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RuleNewButton,
            this.RuleOpenButton,
            this.RuleSaveButton,
            this.RuleSaveAsButton,
            this.VersionLabel,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.addCopyButton,
            this.addDeleteButton,
            this.addReplaceButton});
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
            // VersionLabel
            // 
            this.VersionLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.VersionLabel.Name = "VersionLabel";
            resources.ApplyResources(this.VersionLabel, "VersionLabel");
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            // 
            // addCopyButton
            // 
            this.addCopyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.addCopyButton, "addCopyButton");
            this.addCopyButton.Name = "addCopyButton";
            this.addCopyButton.Click += new System.EventHandler(this.addCopyButton_Click);
            // 
            // addDeleteButton
            // 
            this.addDeleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.addDeleteButton, "addDeleteButton");
            this.addDeleteButton.Name = "addDeleteButton";
            this.addDeleteButton.Click += new System.EventHandler(this.addDeleteButton_Click);
            // 
            // addReplaceButton
            // 
            this.addReplaceButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.addReplaceButton, "addReplaceButton");
            this.addReplaceButton.Name = "addReplaceButton";
            this.addReplaceButton.Click += new System.EventHandler(this.addReplaceButton_Click);
            // 
            // FileGrid
            // 
            this.FileGrid.AutoStretchColumnsToFitWidth = true;
            this.FileGrid.BackColor = System.Drawing.SystemColors.Window;
            this.FileGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FileGrid.ColumnsCount = 2;
            resources.ApplyResources(this.FileGrid, "FileGrid");
            this.FileGrid.EnableSort = false;
            this.FileGrid.FixedRows = 1;
            this.FileGrid.Name = "FileGrid";
            this.FileGrid.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.FileGrid.SelectionMode = SourceGrid.GridSelectionMode.Row;
            this.FileGrid.TabStop = true;
            this.FileGrid.ToolTipText = "";
            // 
            // TargetMenu
            // 
            this.TargetMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TargetSelectButton,
            this.RenamePreviewButton,
            this.RenameResetButton,
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
            // RenamePreviewButton
            // 
            this.RenamePreviewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.RenamePreviewButton, "RenamePreviewButton");
            this.RenamePreviewButton.Name = "RenamePreviewButton";
            this.RenamePreviewButton.Click += new System.EventHandler(this.TargetPrevewRename_Click);
            // 
            // RenameResetButton
            // 
            this.RenameResetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.RenameResetButton, "RenameResetButton");
            this.RenameResetButton.Name = "RenameResetButton";
            this.RenameResetButton.Click += new System.EventHandler(this.ResetRenameButton_Click);
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
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.ErrorLabel});
            resources.ApplyResources(this.StatusBar, "StatusBar");
            this.StatusBar.Name = "StatusBar";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.Name = "ErrorLabel";
            resources.ApplyResources(this.ErrorLabel, "ErrorLabel");
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
            // ruleGrid1
            // 
            this.ruleGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ruleGrid.ColumnsCount = 5;
            resources.ApplyResources(this.ruleGrid, "ruleGrid1");
            this.ruleGrid.EnableSort = true;
            this.ruleGrid.FixedRows = 1;
            this.ruleGrid.Name = "ruleGrid1";
            this.ruleGrid.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.ruleGrid.RowsCount = 1;
            this.ruleGrid.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.ruleGrid.TabStop = true;
            this.ruleGrid.ToolTipText = "";
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.ToolStrip TargetMenu;
        private System.Windows.Forms.ToolStripButton TargetSelectButton;
        private System.Windows.Forms.ToolStripButton RuleNewButton;
        private System.Windows.Forms.ToolStripButton RenameButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel ErrorLabel;
        private System.Windows.Forms.ToolStripLabel VersionLabel;
        private System.Windows.Forms.ToolStripButton RenamePreviewButton;
        private System.Windows.Forms.ToolStripButton RenameResetButton;
        private SourceGrid.Grid FileGrid;
        private System.Windows.Forms.TextBox newFormatTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton addCopyButton;
        private System.Windows.Forms.ToolStripButton addDeleteButton;
        private System.Windows.Forms.ToolStripButton addReplaceButton;
        private UniformRenamer.Core.RuleGrid ruleGrid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

