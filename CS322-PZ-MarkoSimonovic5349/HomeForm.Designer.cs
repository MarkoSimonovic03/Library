namespace CS322_PZ_MarkoSimonovic5349
{
	partial class HomeForm
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
			this.BtnRent = new System.Windows.Forms.Button();
			this.dgvBooks = new System.Windows.Forms.DataGridView();
			this.BtnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.BtnAdd = new System.Windows.Forms.Button();
			this.BtnLoans = new System.Windows.Forms.Button();
			this.labelHi = new System.Windows.Forms.Label();
			this.BtnLogout = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.Search = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
			this.SuspendLayout();
			// 
			// BtnRent
			// 
			this.BtnRent.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnRent.Location = new System.Drawing.Point(615, 301);
			this.BtnRent.Name = "BtnRent";
			this.BtnRent.Size = new System.Drawing.Size(162, 49);
			this.BtnRent.TabIndex = 1;
			this.BtnRent.Text = "Borrow a Book";
			this.BtnRent.UseVisualStyleBackColor = true;
			this.BtnRent.Click += new System.EventHandler(this.BtnRent_Click);
			// 
			// dgvBooks
			// 
			this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBooks.Location = new System.Drawing.Point(27, 115);
			this.dgvBooks.Name = "dgvBooks";
			this.dgvBooks.Size = new System.Drawing.Size(568, 297);
			this.dgvBooks.TabIndex = 2;
			// 
			// BtnDelete
			// 
			this.BtnDelete.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnDelete.Location = new System.Drawing.Point(615, 239);
			this.BtnDelete.Name = "BtnDelete";
			this.BtnDelete.Size = new System.Drawing.Size(162, 49);
			this.BtnDelete.TabIndex = 3;
			this.BtnDelete.Text = "Delete Book";
			this.BtnDelete.UseVisualStyleBackColor = true;
			this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEdit.Location = new System.Drawing.Point(615, 177);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(162, 49);
			this.btnEdit.TabIndex = 3;
			this.btnEdit.Text = "Edit Boook";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// BtnAdd
			// 
			this.BtnAdd.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnAdd.Location = new System.Drawing.Point(615, 115);
			this.BtnAdd.Name = "BtnAdd";
			this.BtnAdd.Size = new System.Drawing.Size(162, 49);
			this.BtnAdd.TabIndex = 3;
			this.BtnAdd.Text = "New Book";
			this.BtnAdd.UseVisualStyleBackColor = true;
			this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
			// 
			// BtnLoans
			// 
			this.BtnLoans.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnLoans.Location = new System.Drawing.Point(615, 363);
			this.BtnLoans.Name = "BtnLoans";
			this.BtnLoans.Size = new System.Drawing.Size(162, 49);
			this.BtnLoans.TabIndex = 3;
			this.BtnLoans.Text = "Your Loans";
			this.BtnLoans.UseVisualStyleBackColor = true;
			this.BtnLoans.Click += new System.EventHandler(this.BtnLoans_Click);
			// 
			// labelHi
			// 
			this.labelHi.AutoSize = true;
			this.labelHi.BackColor = System.Drawing.Color.Transparent;
			this.labelHi.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelHi.Location = new System.Drawing.Point(20, 13);
			this.labelHi.Name = "labelHi";
			this.labelHi.Size = new System.Drawing.Size(138, 38);
			this.labelHi.TabIndex = 4;
			this.labelHi.Text = "Hi, Name!";
			// 
			// BtnLogout
			// 
			this.BtnLogout.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.BtnLogout.Location = new System.Drawing.Point(679, 12);
			this.BtnLogout.Name = "BtnLogout";
			this.BtnLogout.Size = new System.Drawing.Size(98, 39);
			this.BtnLogout.TabIndex = 5;
			this.BtnLogout.Text = "Logout";
			this.BtnLogout.UseVisualStyleBackColor = true;
			this.BtnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(22, 83);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 29);
			this.label1.TabIndex = 4;
			this.label1.Text = "All books...";
			// 
			// Search
			// 
			this.Search.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Search.Location = new System.Drawing.Point(442, 72);
			this.Search.Name = "Search";
			this.Search.Size = new System.Drawing.Size(153, 37);
			this.Search.TabIndex = 6;
			this.Search.TextChanged += new System.EventHandler(this.Search_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(361, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 29);
			this.label2.TabIndex = 4;
			this.label2.Text = "Search:";
			// 
			// HomeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.Search);
			this.Controls.Add(this.BtnLogout);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.labelHi);
			this.Controls.Add(this.BtnLoans);
			this.Controls.Add(this.BtnAdd);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.BtnDelete);
			this.Controls.Add(this.dgvBooks);
			this.Controls.Add(this.BtnRent);
			this.Name = "HomeForm";
			this.Text = "HomeForm";
			((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion
        private System.Windows.Forms.Button BtnRent;
        private System.Windows.Forms.DataGridView dgvBooks;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button BtnLoans;
        private System.Windows.Forms.Label labelHi;
        private System.Windows.Forms.Button BtnLogout;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox Search;
		private System.Windows.Forms.Label label2;
	}
}