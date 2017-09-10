/*
 * Created by SharpDevelop.
 * User: blopes
 * Date: 27/04/2017
 * Time: 13:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;
using System.Timers;
using System.Windows.Forms;





using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;



namespace SeleniumTest
{
	
	static class  Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			
			//startar web driver esconder o web driver
			
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Util.mainForm=new MainForm(new StartWebDriver());
			Application.Run(Util.mainForm);
		}
		

	}
}