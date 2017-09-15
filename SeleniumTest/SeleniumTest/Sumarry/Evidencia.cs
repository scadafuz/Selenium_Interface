/*
 * Created by SharpDevelop.
 * User: blopes
 * Date: 21/06/2017
 * Time: 08:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

using OpenQA.Selenium;

namespace SeleniumTest.Properties
{
	/// <summary>
	/// Description of Evidencia.
	/// </summary>
	public class Evidencia
	{

		public string ScreenBase64;
		public Step step;
		public Evidencia(Step step)
		{
			
			this.ScreenBase64=TakeScreenshot();
			
			
			
			this.step=step;
		}
		//sempre lembrar de limpar pq  c nao vai abarrotar memoria
		public void ClearScreenBase64(){
			
			ScreenBase64=string.Empty;
			
		}
		private string TakeScreenshot(){
			
			try{
				return ((ITakesScreenshot)Util.StartWebDriver.getDriver()).GetScreenshot().AsBase64EncodedString;

			}
			catch(Exception){
				try{
					Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
					                           Screen.PrimaryScreen.Bounds.Height);
					Graphics graphics = Graphics.FromImage(bitmap as Image);
					graphics.CopyFromScreen(0, 0, 0, 0, bitmap.Size);
					graphics.Dispose();
					Image img = (Image)bitmap;
					return Convert.ToBase64String(ImageToByteArray(img));
				}
				catch(Exception){
					return "";
				}
			}
			
			
		}
		internal static byte[] ImageToByteArray(Image img)
		{
			byte[] byteArray = new byte[0];
			MemoryStream stream = new MemoryStream();
			img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
			stream.Close();
			byteArray = stream.ToArray();
			return byteArray;
		}
	}
}
