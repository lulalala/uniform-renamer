namespace UniformRenamer
{
    partial class FilenameExistsPrompt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilenameExistsPrompt));
            this.label1 = new System.Windows.Forms.Label();
            this.newNameTextBox = new System.Windows.Forms.TextBox();
            this.renameButton = new System.Windows.Forms.Button();
            this.oldNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.skipButton = new System.Windows.Forms.Button();
            this.newNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // newNameTextBox
            // 
            resources.ApplyResources(this.newNameTextBox, "newNameTextBox");
            this.newNameTextBox.Name = "newNameTextBox";
            // 
            // renameButton
            // 
            this.renameButton.DialogResult = System.Windows.Forms.DialogResult.Retry;
            resources.ApplyResources(this.renameButton, "renameButton");
            this.renameButton.Name = "renameButton";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // oldNameLabel
            // 
            resources.ApplyResources(this.oldNameLabel, "oldNameLabel");
            this.oldNameLabel.Name = "oldNameLabel";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // skipButton
            // 
            this.skipButton.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            resources.ApplyResources(this.skipButton, "skipButton");
            this.skipButton.Name = "skipButton";
            this.skipButton.UseVisualStyleBackColor = true;
            this.skipButton.Click += new System.EventHandler(this.skipButton_Click);
            // 
            // newNameLabel
            // 
            resources.ApplyResources(this.newNameLabel, "newNameLabel");
            this.newNameLabel.Name = "newNameLabel";
            // 
            // FilenameExistsPrompt
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.skipButton;
            this.Controls.Add(this.newNameLabel);
            this.Controls.Add(this.skipButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.oldNameLabel);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.newNameTextBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilenameExistsPrompt";
            this.ShowIcon = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button renameButton;
        public System.Windows.Forms.TextBox newNameTextBox;
        private System.Windows.Forms.Label oldNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button skipButton;
        private System.Windows.Forms.Label newNameLabel;
    }
}