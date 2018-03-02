namespace XMLConfigCreator.CustomExceptions
{
    partial class DlgException
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
            this.dgvValidationException = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValidationException)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvValidationException
            // 
            this.dgvValidationException.AllowUserToAddRows = false;
            this.dgvValidationException.AllowUserToDeleteRows = false;
            this.dgvValidationException.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvValidationException.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValidationException.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvValidationException.Location = new System.Drawing.Point(0, 0);
            this.dgvValidationException.Name = "dgvValidationException";
            this.dgvValidationException.ReadOnly = true;
            this.dgvValidationException.Size = new System.Drawing.Size(649, 217);
            this.dgvValidationException.TabIndex = 0;
            // 
            // DlgException
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 217);
            this.Controls.Add(this.dgvValidationException);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DlgException";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Validación Fallida";
            ((System.ComponentModel.ISupportInitialize)(this.dgvValidationException)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvValidationException;
    }
}