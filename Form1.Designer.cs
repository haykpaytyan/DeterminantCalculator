
namespace DeterminantCalculator
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
            this.sizeLabel = new System.Windows.Forms.Label();
            this.sizeSelector = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // sizeLabel
            // 
            this.sizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sizeLabel.Location = new System.Drawing.Point(12, 15);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(100, 20);
            this.sizeLabel.TabIndex = 2;
            this.sizeLabel.Text = "Select size";
            // 
            // sizeSelector
            // 
            this.sizeSelector.AccessibleName = "";
            this.sizeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sizeSelector.FormattingEnabled = true;
            this.sizeSelector.Location = new System.Drawing.Point(118, 14);
            this.sizeSelector.Name = "sizeSelector";
            this.sizeSelector.Size = new System.Drawing.Size(44, 21);
            this.sizeSelector.TabIndex = 1;
            this.sizeSelector.SelectedIndexChanged += new System.EventHandler(this.SizeSelector_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 200);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.sizeSelector);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label sizeLabel;
        private System.Windows.Forms.ComboBox sizeSelector;
    }
}

