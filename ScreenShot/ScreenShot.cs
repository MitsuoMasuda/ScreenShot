using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenShot
{
	class ScreenShot
	{
		private string _saveFolder = "";

		public string SaveFolder { set { this._saveFolder = value; } }

		public ScreenShot(string saveFolder)
		{
			this._saveFolder = saveFolder;
		}

		public void Shot()
		{
			if (!this._saveFolder.EndsWith(@"\"))
			{
				this._saveFolder += @"\";
			}

			// 保存場所が存在する場合はスクリーンショットを撮る
			if (Directory.Exists(this._saveFolder))
			{
				Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
				Graphics graphics = Graphics.FromImage(bitmap);
				//画面全体をコピーする
				graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), bitmap.Size);
				//解放
				graphics.Dispose();
				bitmap.Save(@"C:\temp\" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".gif", System.Drawing.Imaging.ImageFormat.Gif);

				bitmap.Dispose();
			}
		}
	}
}
