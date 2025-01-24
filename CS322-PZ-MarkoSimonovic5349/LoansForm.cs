using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS322_PZ_MarkoSimonovic5349.DB;
using CS322_PZ_MarkoSimonovic5349.Entities;

namespace CS322_PZ_MarkoSimonovic5349
{
	public partial class LoansForm : Form
	{
		// Currently logged-in user
		private User User;

		// Event triggered when a book is returned
		public event EventHandler BookReturned;

		public LoansForm(User user)
		{
			InitializeComponent();

			// Assign the logged-in user to a private field
			User = user;

			// Configure DataGridView properties
			dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvBooks.MultiSelect = false;
			dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			// Load loaned books into the DataGridView
			LoadBooks();

			// Set the form's background image dynamically
			string imagePath = Path.Combine(Application.StartupPath, "..", "..", "Images", "bg.jpg");
			this.BackgroundImage = Image.FromFile(imagePath);
			this.BackgroundImageLayout = ImageLayout.Stretch;
		}

		private void LoadBooks()
		{
			// Retrieve loaned books for the current user
			List<Book> books = BookCrud.GetLoanedBooksByUserId(User.Id);

			// Bind books data to the DataGridView
			dgvBooks.DataSource = books.Select(book => new
			{
				book.Id,       // Hidden column for internal use
				book.Title,    // Book title
				book.Author,   // Book author
				book.Year,     // Publication year
			}).ToList();

			// Hide the Id column in the DataGridView
			dgvBooks.Columns["Id"].Visible = false;
		}

		private void BtnReturn_Click(object sender, EventArgs e)
		{
			// Check if a book is selected
			if (dgvBooks.SelectedRows.Count > 0)
			{
				// Retrieve the selected book's Id
				int bookId = (int)dgvBooks.SelectedRows[0].Cells["Id"].Value;

				// Return the loaned book using its Id
				LoanCrud.ReturnLoan(bookId);

				// Reload books to reflect the returned book
				LoadBooks();

				// Trigger the BookReturned event
				BookReturned?.Invoke(this, EventArgs.Empty);

				// Notify the user
				MessageBox.Show("The book was returned.");
			}
			else
			{
				// Notify the user to select a book first
				MessageBox.Show("Select a book to return.");
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			// Hide the current form
			this.Hide();
		}
	}
}
