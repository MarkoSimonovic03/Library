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
	public partial class EditBookForm : Form
	{
		private Book Book; // The book being edited
		public event EventHandler BookUpdated; // Event triggered after the book is updated

		public EditBookForm(Book book)
		{
			InitializeComponent();

			Book = book;
			textBoxTitle.Text = book.Title;
			textBoxAuthor.Text = book.Author;
			textBoxYear.Text = book.Year.ToString();

			// Set the form's background image
			string imagePath = Path.Combine(Application.StartupPath, "..", "..", "Images", "bg.jpg");
			this.BackgroundImage = Image.FromFile(imagePath);
			this.BackgroundImageLayout = ImageLayout.Stretch;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			// Ensure all input fields are not empty
			if (textBoxTitle.Text.Trim() != ""
				&& textBoxAuthor.Text.Trim() != ""
				&& textBoxYear.Text.Trim() != "")
			{
				Book.Title = textBoxTitle.Text;
				Book.Author = textBoxAuthor.Text;

				// Validate the year input
				if (int.TryParse(textBoxYear.Text, out int year))
				{
					Book.Year = year;

					BookCrud.UpdateBook(Book); // Save changes to the database
					BookUpdated?.Invoke(this, EventArgs.Empty); // Notify listeners
					MessageBox.Show("Successfully edited book.");
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
