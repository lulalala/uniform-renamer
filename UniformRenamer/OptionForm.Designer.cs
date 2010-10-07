namespace UniformRenamer
{
    partial class OptionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionForm));
            this.cbRemoveBrackets = new System.Windows.Forms.CheckBox();
            this.cbRemoveMultipleSpace = new System.Windows.Forms.CheckBox();
            this.cbRemoveEndSpace = new System.Windows.Forms.CheckBox();
            this.okayButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbRemoveBrackets
            // 
            this.cbRemoveBrackets.AccessibleDescription = null;
            this.cbRemoveBrackets.AccessibleName = null;
            resources.ApplyResources(this.cbRemoveBrackets, "cbRemoveBrackets");
            this.cbRemoveBrackets.BackgroundImage = null;
            this.cbRemoveBrackets.Font = null;
            this.cbRemoveBrackets.Name = "cbRemoveBrackets";
            this.cbRemoveBrackets.UseVisualStyleBackColor = true;
            // 
            // cbRemoveMultipleSpace
            // 
            this.cbRemoveMultipleSpace.AccessibleDescription = null;
            this.cbRemoveMultipleSpace.AccessibleName = null;
            resources.ApplyResources(this.cbRemoveMultipleSpace, "cbRemoveMultipleSpace");
            this.cbRemoveMultipleSpace.BackgroundImage = null;
            this.cbRemoveMultipleSpace.Font = null;
            this.cbRemoveMultipleSpace.Name = "cbRemoveMultipleSpace";
            this.cbRemoveMultipleSpace.UseVisualStyleBackColor = true;
            // 
            // cbRemoveEndSpace
            // 
            this.cbRemoveEndSpace.AccessibleDescription = null;
            this.cbRemoveEndSpace.AccessibleName = null;
            resources.ApplyResources(this.cbRemoveEndSpace, "cbRemoveEndSpace");
            this.cbRemoveEndSpace.BackgroundImage = null;
            this.cbRemoveEndSpace.Font = null;
            this.cbRemoveEndSpace.Name = "cbRemoveEndSpace";
            this.cbRemoveEndSpace.UseVisualStyleBackColor = true;
            // 
            // okayButton
            // 
            this.okayButton.AccessibleDescription = null;
            this.okayButton.AccessibleName = null;
            resources.ApplyResources(this.okayButton, "okayButton");
            this.okayButton.BackgroundImage = null;
            this.okayButton.Font = null;
            this.okayButton.Name = "okayButton";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.okayButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.AccessibleDescription = null;
            this.cancelButton.AccessibleName = null;
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.BackgroundImage = null;
            this.cancelButton.Font = null;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OptionForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.cbRemoveEndSpace);
            this.Controls.Add(this.cbRemoveMultipleSpace);
            this.Controls.Add(this.cbRemoveBrackets);
            this.Font = null;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.OptionForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbRemoveBrackets;
        private System.Windows.Forms.CheckBox cbRemoveMultipleSpace;
        private System.Windows.Forms.CheckBox cbRemoveEndSpace;
        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.Button cancelButton;
    }
}