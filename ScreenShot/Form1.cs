using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenShot
{
	public partial class Form1 : Form
	{
		System.Timers.Timer _timer = new System.Timers.Timer();
		ScreenShot _screenShot = new ScreenShot(@"C:\temp\");

		public Form1()
		{
			InitializeComponent();

			this._timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
		}

		void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
		{
			this._screenShot.Shot();
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			this._timer.Interval = 5000;
			this._timer.Start();
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			this._timer.Stop();
		}
	}
}
