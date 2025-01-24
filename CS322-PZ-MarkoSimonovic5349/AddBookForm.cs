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
	public partial class AddBookForm : Form
	{
		public event EventHandler BookAdded; // Event triggered after a book is added

		public AddBookForm()
		{
			InitializeComponent();

			// Set the form's background image
			string imagePath = Path.Combine(Application.StartupPath, "..", "..", "Images", "bg.jpg");
			this.BackgroundImage = Image.FromFile(imagePath);
			this.BackgroundImageLayout = ImageLayout.Stretch;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Book book = new Book();

			// Ensure all input fields are not empty
			if (textBoxTitle.Text.Trim() != ""
				&& textBoxAuthor.Text.Trim() != ""
				&& textBoxYear.Text.Trim() != "")
			{
				book.Title = textBoxTitle.Text;
				book.Author = textBoxAuthor.Text;

				// Validate the year input
				if (int.TryParse(textBoxYear.Text, out int year))
				{
					book.Year = year;

					// Add the new book to the database
					BookCrud.AddBook(book);
					BookAdded?.Invoke(this, EventArgs.Empty); // Notify listeners
					MessageBox.Show("Book added successfully.");
					this.Hide();
				}
				else
				{
					MessageBox.Show("Please enter a valid number for the year.");
				}
			}
		}
	}
}
