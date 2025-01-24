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
	public partial class LoginRegisterForm : Form
	{
		public LoginRegisterForm()
		{
			InitializeComponent();

			// Set the background image for the form dynamically
			string imagePath = Path.Combine(Application.StartupPath, "..", "..", "Images", "bg.jpg");
			this.BackgroundImage = Image.FromFile(imagePath);
			this.BackgroundImageLayout = ImageLayout.Stretch;
		}

		private void Register_Click(object sender, EventArgs e)
		{
			try
			{
				// Validate registration fields
				if (RegPassword.Text == RegRePassword.Text
					&& RegUsername.Text.Trim() != ""
					&& RegEmail.Text.Trim() != ""
					&& RegPassword.Text.Trim() != "")
				{
					// Create a new user in the database
					User user = UserCrud.CreateUser(RegUsername.Text, RegPassword.Text, RegEmail.Text);

					// Open the home form and pass the registered user
					HomeForm homeForm = new HomeForm(user);
					homeForm.Show();
					this.Hide();
				}
				else
				{
					// Show an error message if the input data is invalid
					MessageBox.Show("The entered data is invalid.");
				}
			}
			catch (Exception ex)
			{
				// Handle and display any unexpected errors during registration
				MessageBox.Show("An error occurred during registration: " + ex.Message);
			}
		}

		private void Login_Click(object sender, EventArgs e)
		{
			try
			{
				// Validate login fields
				if (LogUsername.Text.Trim() != "" && LogPassword.Text.Trim() != "")
				{
					// Attempt to find the user by username and password
					User user = UserCrud.GetUserByUsernameAndPassword(LogUsername.Text, LogPassword.Text);

					if (user != null)
					{
						// If the user exists, open the home form
						HomeForm homeForm = new HomeForm(user);
						homeForm.Show();
						this.Hide();
					}
					else
					{
						// Show an error message if login data is invalid
						MessageBox.Show("The entered data is invalid.");
					}
				}
			}
			catch (Exception ex)
			{
				// Handle and display any unexpected errors during login
				MessageBox.Show("An error occurred while logging in: " + ex.Message);
			}
		}
	}
}
