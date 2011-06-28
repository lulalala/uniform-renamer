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
            this.cbRemoveBrackets = new System.Windows.Forms.CheckBox();
            this.cbRemoveMultipleSpace = new System.Windows.Forms.CheckBox();
            this.cbRemoveEndSpace = new System.Windows.Forms.CheckBox();
            this.okayButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbRemoveBrackets
            // 
            this.cbRemoveBrackets.AutoSize = true;
            this.cbRemoveBrackets.Location = new System.Drawing.Point(13, 13);
            this.cbRemoveBrackets.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbRemoveBrackets.Name = "cbRemoveBrackets";
            this.cbRemoveBrackets.Size = new System.Drawing.Size(248, 22);
            this.cbRemoveBrackets.TabIndex = 0;
            this.cbRemoveBrackets.Text = "Remove empty brackets () [] {}";
            this.cbRemoveBrackets.UseVisualStyleBackColor = true;
            // 
            // cbRemoveMultipleSpace
            // 
            this.cbRemoveMultipleSpace.AutoSize = true;
            this.cbRemoveMultipleSpace.Location = new System.Drawing.Point(13, 43);
            this.cbRemoveMultipleSpace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbRemoveMultipleSpace.Name = "cbRemoveMultipleSpace";
            this.cbRemoveMultipleSpace.Size = new System.Drawing.Size(298, 22);
            this.cbRemoveMultipleSpace.TabIndex = 1;
            this.cbRemoveMultipleSpace.Text = "Convert multiple spaces into one space";
            this.cbRemoveMultipleSpace.UseVisualStyleBackColor = true;
            // 
            // cbRemoveEndSpace
            // 
            this.cbRemoveEndSpace.AutoSize = true;
            this.cbRemoveEndSpace.Location = new System.Drawing.Point(13, 73);
            this.cbRemoveEndSpace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbRemoveEndSpace.Name = "cbRemoveEndSpace";
            this.cbRemoveEndSpace.Size = new System.Drawing.Size(248, 22);
            this.cbRemoveEndSpace.TabIndex = 2;
            this.cbRemoveEndSpace.Text = "Trim spaces at end of the string";
            this.cbRemoveEndSpace.UseVisualStyleBackColor = true;
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(85, 118);
            this.okayButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(112, 34);
            this.okayButton.TabIndex = 3;
            this.okayButton.Text = "OK";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.okayButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(205, 118);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 34);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 165);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.cbRemoveEndSpace);
            this.Controls.Add(this.cbRemoveMultipleSpace);
            this.Controls.Add(this.cbRemoveBrackets);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionForm";
            this.Text = "Options";
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