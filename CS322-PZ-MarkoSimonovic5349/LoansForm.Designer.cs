namespace CS322_PZ_MarkoSimonovic5349
{
    partial class LoansForm
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
			this.dgvBooks = new System.Windows.Forms.DataGridView();
			this.BtnReturn = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvBooks
			// 
			this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBooks.Location = new System.Drawing.Point(27, 115);
			this.dgvBooks.Name = "dgvBooks";
			this.dgvBooks.Size = new System.Drawing.Size(568, 297);
			this.dgvBooks.TabIndex = 3;
			// 
			// BtnReturn
			// 
			this.BtnReturn.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnReturn.Location = new System.Drawing.Point(610, 352);
			this.BtnReturn.Name = "BtnReturn";
			this.BtnReturn.Size = new System.Drawing.Size(178, 60);
			this.BtnReturn.TabIndex = 4;
			this.BtnReturn.Text = "Return a book";
			this.BtnReturn.UseVisualStyleBackColor = true;
			this.BtnReturn.Click += new System.EventHandler(this.BtnReturn_Click);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(27, 12);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(179, 46);
			this.button2.TabIndex = 4;
			this.button2.Text = "Back to home";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(22, 83);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(230, 29);
			this.label1.TabIndex = 5;
			this.label1.Text = "Your borrowed books...";
			// 
			// LoansForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.BtnReturn);
			this.Controls.Add(this.dgvBooks);
			this.Name = "LoansForm";
			this.Text = "Loans";
			((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Button BtnReturn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}