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
	public partial class HomeForm : Form
	{
		// Currently logged-in user
		private User User;

		public HomeForm(User user)
		{
			InitializeComponent();

			// Set the greeting message for the user
			labelHi.Text = "Hi, " + user.Username + "!";

			// Store the logged-in user for further use
			User = user;

			// Configure DataGridView properties
			dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dgvBooks.MultiSelect = false;
			dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

			// Load all books into the DataGridView
			LoadBooks();

			// Set background image dynamically
			string imagePath = Path.Combine(Application.StartupPath, "..", "..", "Images", "bg.jpg");
			this.BackgroundImage = Image.FromFile(imagePath);
			this.BackgroundImageLayout = ImageLayout.Stretch;
		}

		// Load books into the DataGridView, optionally filtering by a search parameter
		private void LoadBooks(string parametar = "")
		{
			// Retrieve all books
			List<Book> books = BookCrud.GetAllBooks();

			// Filter books if a search parameter is provided
			if (parametar != "")
			{
				parametar = parametar.ToUpper();
				books = books.Where(book =>
						book.Title.ToUpper().Contains(parametar) ||
						book.Author.ToUpper().Contains(parametar) ||
						book.Year.ToString().Contains(parametar)
				).ToList();
			}

			// Bind filtered books data to the DataGridView
			dgvBooks.DataSource = books.Select(book => new
			{
				book.Id,          // Hidden column for internal use
				book.Title,       // Book title
				book.Author,      // Book author
				book.Year,        // Publication year
				book.IsAvailable  // Book availability
			}).ToList();

			// Hide the Id column
			dgvBooks.Columns["Id"].Visible = false;
		}

		private void BtnRent_Click(object sender, EventArgs e)
		{
			// Ensure a book is selected
			if (dgvBooks.SelectedRows.Count > 0)
			{
				// Check if the selected book is available
				bool isAvailable = (bool)dgvBooks.SelectedRows[0].Cells["IsAvailable"].Value;

				if (isAvailable)
				{
					// Retrieve the selected book's Id and create a loan
					int bookId = (int)dgvBooks.SelectedRows[0].Cells["Id"].Value;
					LoanCrud.CreateLoan(this.User.Id, bookId);

					// Reload the book list
					LoadBooks();
					MessageBox.Show("The book has been successfully borrowed!");
				}
				else
				{
					MessageBox.Show("The book is unavailable.");
				}
			}
			else
			{
				MessageBox.Show("Select a book for borrowing.");
			}

			// Clear the search box
			Search.Text = "";
		}

		private void BtnDelete_Click(object sender, EventArgs e)
		{
			// Ensure a book is selected
			if (dgvBooks.SelectedRows.Count > 0)
			{
				// Retrieve the selected book's Id and delete it
				int bookId = (int)dgvBooks.SelectedRows[0].Cells["Id"].Value;
				BookCrud.DeleteBook(bookId);

				// Reload the book list
				LoadBooks();
				MessageBox.Show("The book was successfully deleted.");
			}
			else
			{
				MessageBox.Show("Select a book to delete.");
			}

			// Clear the search box
			Search.Text = "";
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			// Ensure a book is selected
			if (dgvBooks.SelectedRows.Count > 0)
			{
				// Retrieve the selected book's Id
				int bookId = (int)dgvBooks.SelectedRows[0].Cells["Id"].Value;

				// Fetch the book details and open the edit form
				Book selectedBook = BookCrud.GetBookByBookId(bookId);
				EditBookForm editForm = new EditBookForm(selectedBook);

				// Reload books when the edit form is closed and updates are saved
				editForm.BookUpdated += (sender2, args) => LoadBooks();

				editForm.ShowDialog();
			}
			else
			{
				MessageBox.Show("Select a book for editing.");
			}

			// Clear the search box
			Search.Text = "";
		}

		private void BtnAdd_Click(object sender, EventArgs e)
		{
			// Open the add book form
			AddBookForm addForm = new AddBookForm();

			// Reload books when a new book is added
			addForm.BookAdded += (sender2, args) => LoadBooks();

			addForm.ShowDialog();

			// Clear the search box
			Search.Text = "";
		}

		private void BtnLoans_Click(object sender, EventArgs e)
		{
			// Open the loans form
			LoansForm loansForm = new LoansForm(User);

			// Reload books when a book is returned
			loansForm.BookReturned += (sender2, args) => LoadBooks();

			loansForm.ShowDialog();

			// Clear the search box
			Search.Text = "";
		}

		private void BtnLogout_Click(object sender, EventArgs e)
		{
			// Open the login form and close the current form
			LoginRegisterForm loginForm = new LoginRegisterForm();
			this.Hide();
			loginForm.Show();

			// Clear the search box
			Search.Text = "";
		}

		private void Search_TextChanged(object sender, EventArgs e)
		{
			// Reload books whenever the search text changes
			LoadBooks(Search.Text);
		}
	}
}
