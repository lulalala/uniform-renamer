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
            resources.ApplyResources(this.cbRemoveBrackets, "cbRemoveBrackets");
            this.cbRemoveBrackets.Name = "cbRemoveBrackets";
            this.cbRemoveBrackets.UseVisualStyleBackColor = true;
            // 
            // cbRemoveMultipleSpace
            // 
            resources.ApplyResources(this.cbRemoveMultipleSpace, "cbRemoveMultipleSpace");
            this.cbRemoveMultipleSpace.Name = "cbRemoveMultipleSpace";
            this.cbRemoveMultipleSpace.UseVisualStyleBackColor = true;
            // 
            // cbRemoveEndSpace
            // 
            resources.ApplyResources(this.cbRemoveEndSpace, "cbRemoveEndSpace");
            this.cbRemoveEndSpace.Name = "cbRemoveEndSpace";
            this.cbRemoveEndSpace.UseVisualStyleBackColor = true;
            // 
            // okayButton
            // 
            resources.ApplyResources(this.okayButton, "okayButton");
            this.okayButton.Name = "okayButton";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.okayButton_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OptionForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.cbRemoveEndSpace);
            this.Controls.Add(this.cbRemoveMultipleSpace);
            this.Controls.Add(this.cbRemoveBrackets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionForm";
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