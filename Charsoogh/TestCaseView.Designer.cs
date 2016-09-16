namespace Charsoogh
{
    partial class TestCaseView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userCheckBox = new System.Windows.Forms.CheckBox();
            this.expectedCheckbox = new System.Windows.Forms.CheckBox();
            this.resultPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // userCheckBox
            // 
            this.userCheckBox.AutoSize = true;
            this.userCheckBox.Location = new System.Drawing.Point(3, 6);
            this.userCheckBox.Name = "userCheckBox";
            this.userCheckBox.Size = new System.Drawing.Size(90, 17);
            this.userCheckBox.TabIndex = 0;
            this.userCheckBox.Text = "Your decision";
            this.userCheckBox.UseVisualStyleBackColor = true;
            // 
            // expectedCheckbox
            // 
            this.expectedCheckbox.AutoSize = true;
            this.expectedCheckbox.Location = new System.Drawing.Point(3, 29);
            this.expectedCheckbox.Name = "expectedCheckbox";
            this.expectedCheckbox.Size = new System.Drawing.Size(71, 17);
            this.expectedCheckbox.TabIndex = 1;
            this.expectedCheckbox.Text = "Expected";
            this.expectedCheckbox.UseVisualStyleBackColor = true;
            // 
            // resultPanel
            // 
            this.resultPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultPanel.AutoScroll = true;
            this.resultPanel.Location = new System.Drawing.Point(3, 49);
            this.resultPanel.Name = "resultPanel";
            this.resultPanel.Size = new System.Drawing.Size(344, 139);
            this.resultPanel.TabIndex = 2;
            // 
            // TestCaseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.resultPanel);
            this.Controls.Add(this.expectedCheckbox);
            this.Controls.Add(this.userCheckBox);
            this.Name = "TestCaseView";
            this.Size = new System.Drawing.Size(350, 191);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox userCheckBox;
        private System.Windows.Forms.CheckBox expectedCheckbox;
        private System.Windows.Forms.Panel resultPanel;
    }
}
