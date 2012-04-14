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
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cannot rename";
            // 
            // newNameTextBox
            // 
            this.newNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.newNameTextBox.Location = new System.Drawing.Point(12, 149);
            this.newNameTextBox.Name = "newNameTextBox";
            this.newNameTextBox.Size = new System.Drawing.Size(359, 22);
            this.newNameTextBox.TabIndex = 1;
            // 
            // renameButton
            // 
            this.renameButton.DialogResult = System.Windows.Forms.DialogResult.Retry;
            this.renameButton.Location = new System.Drawing.Point(377, 149);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(75, 23);
            this.renameButton.TabIndex = 2;
            this.renameButton.Text = "Rename";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // oldNameLabel
            // 
            this.oldNameLabel.AutoSize = true;
            this.oldNameLabel.Location = new System.Drawing.Point(24, 33);
            this.oldNameLabel.Name = "oldNameLabel";
            this.oldNameLabel.Size = new System.Drawing.Size(48, 12);
            this.oldNameLabel.TabIndex = 3;
            this.oldNameLabel.Text = "old name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(420, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "because there is already a file with the same name. You can skip or change the ne" +
                "w name.";
            // 
            // skipButton
            // 
            this.skipButton.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.skipButton.Location = new System.Drawing.Point(377, 110);
            this.skipButton.Name = "skipButton";
            this.skipButton.Size = new System.Drawing.Size(75, 23);
            this.skipButton.TabIndex = 5;
            this.skipButton.Text = "Skip";
            this.skipButton.UseVisualStyleBackColor = true;
            // 
            // newNameLabel
            // 
            this.newNameLabel.AutoSize = true;
            this.newNameLabel.Location = new System.Drawing.Point(24, 55);
            this.newNameLabel.Name = "newNameLabel";
            this.newNameLabel.Size = new System.Drawing.Size(52, 12);
            this.newNameLabel.TabIndex = 6;
            this.newNameLabel.Text = "new name";
            // 
            // FilenameExistsPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.skipButton;
            this.ClientSize = new System.Drawing.Size(464, 184);
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filename already exists";
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