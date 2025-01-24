using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CS322_PZ_MarkoSimonovic5349.DB;

namespace CS322_PZ_MarkoSimonovic5349
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
            DBUtil.EnsureDatabaseExists();

            Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new LoginRegisterForm());
		}
	}
}
