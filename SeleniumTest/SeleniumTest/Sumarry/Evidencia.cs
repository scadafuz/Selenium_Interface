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
			this.ScreenBase64=((ITakesScreenshot)Util.StartWebDriver.driver).GetScreenshot().AsBase64EncodedString;
			this.step=step;
		}
		//sempre lembrar de limpar pq  c nao vai abarrotar memoria
		public void ClearScreenBase64(){
		
			ScreenBase64=string.Empty;
		
		}
		
		
	}
}
