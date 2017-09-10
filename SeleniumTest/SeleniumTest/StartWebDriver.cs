/*
 * Created by SharpDevelop.
 * User: blopes
 * Date: 01/06/2017
 * Time: 16:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

using System.Timers;
using System.Windows.Forms;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
	/// <summary>
	/// Description of StartWebDriver.
	/// </summary>
	public class StartWebDriver
	{
		[DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();
		
		public static IntPtr handle;
		public static string PathExec=System.IO.Path.GetDirectoryName(Application.ExecutablePath);
		public IWebDriver driver;
		
		
		
		//public IJavaScriptExecutor javascriptExecutor;
		public StartWebDriver()
		{
			
			
			driver = new ChromeDriver();
			IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
			//colocar pagina de apresentacao
				driver.Navigate().GoToUrl(PathExec+"\\TEST_Page_Fraame.html");
			//	driver.Navigate().GoToUrl(@"C:\Users\blopes\Desktop\Nova pasta\principal.html");
		//	driver.Navigate().GoToUrl("http://www.dsv.bradseg.com.br");
			handle = GetForegroundWindow();
			
			
		}
		public IWebDriver getDriver(bool open=true){
		   try{
				var tst=driver.WindowHandles;
				return driver;
		        }
			catch(Exception){
				if(open){
				 this.driver=new ChromeDriver();
				}
				 return driver;
				
			} 
		}
		public  void MapObjects(){
			
			 getDriver();
			foreach (string handle in driver.WindowHandles)
			{
				
				driver.SwitchTo().Window(handle);
				
				driver.SwitchTo().DefaultContent();
				
				
				
				List<Element>listaElements=new List<Element>();
				listaElements=Util.RecursiveElementUIframe(driver,listaElements,"//html[1]",null,true);

				//listaElements=listaElements.GroupBy(x=>x.Elemento.GetHashCode()).Select(grp=>grp.First()).ToList();
			//	listaElements.Add(new Element(new ArrayList(),driver.CurrentWindowHandle));
				//em todos esses elementos eu volto ao contexto dele e coloco eentos para circundar o campo

				foreach(Element e in listaElements ){
					

					e.getContext(driver);

					((IJavaScriptExecutor)e.getContext(driver)).ExecuteScript("if (typeof mapearOver!='function') {mapearOver= function () {  if( typeof(event.target.getAttribute('executiondomain'))=='object'){ event.target.style.outline='5px outset #000000';}  }} ");
					((IJavaScriptExecutor)e.getContext(driver)).ExecuteScript("if (typeof mapearOut!='function') {mapearOut= function () {  if( typeof(event.target.getAttribute('executiondomain'))=='object'){event.target.style.outline='0px outset #000000'; } }}");
					((IJavaScriptExecutor)e.getContext(driver)).ExecuteScript("if (typeof mapearClick!='function') {mapearClick = function()  {  event.preventDefault(); event.stopPropagation();  var ExecutionDomain = document.createAttribute('executiondomain');    ExecutionDomain.value = 'true';   event.toElement.setAttributeNode(ExecutionDomain); event.target.style.outline='4px solid #FF0000'; }  }");
					
					((IJavaScriptExecutor)e.getContext(driver)).ExecuteScript("window.addEventListener('click', mapearClick);");
					((IJavaScriptExecutor)e.getContext(driver)).ExecuteScript("window.addEventListener('mouseover', mapearOver);");
					((IJavaScriptExecutor)e.getContext(driver)).ExecuteScript("window.addEventListener('mouseout', mapearOut);");


				}
				
			}

		}
		public bool highLight(Element e){
			bool saida=false;
			getDriver();
			foreach(string handle in driver.WindowHandles){
			    driver.SwitchTo().Window(handle);
				driver.SwitchTo().DefaultContent();
				try{
					((IJavaScriptExecutor)e.getContext(driver)).ExecuteScript("var highlightElement=arguments[0];  highlight=function(a){ count = 1; a.style.outline='0px outset #FF0000';    var intervalId = setInterval(function() {        if (a.style.outline.includes('0px')) {            a.style.outline = '5px outset #FF0000';            if (count++ === 5) {                clearInterval(intervalId);   a.style.outline = '0px outset #FF0000';         }        } else {            a.style.outline = '0px outset #FF0000';        }        }, 200)};highlight(highlightElement);  ",(IWebElement)e.getElemento());
			//((IJavaScriptExecutor)e.getContext(driver)).ExecuteScript("highlight=function(){ count = 1; a=arguments[0]; a.style.outline='0px outset #FF0000';    var intervalId = setInterval(function() {        if (a.style.outline.includes('0px')) {            clearInterval(intervalId);               }        }, 200)};highlight();",(IWebElement)e.Elemento);
						saida=true;	
						break;
					}
				catch(Exception){
				}
			}
		   return saida;
		}
		public List<Field> StopMap(){
			
			
			List<Field>listaField=new List<Field>();
			try{
			foreach (string handle in driver.WindowHandles)
			{
				
				driver.SwitchTo().Window(handle);
				driver.SwitchTo().DefaultContent();
				List<Element>listaElements=new List<Element>();
				listaElements=Util.RecursiveElementUIframe(driver,listaElements,"//html[1]",null,true);
				//listaElements=listaElements.GroupBy(x=>x.Elemento.GetHashCode()).Select(grp=>grp.First()).ToList();
				
				//em todos esses elementos eu volto ao contexto dele e coloco eventos para circundar o campo
				
				foreach(Element e in listaElements ){
					
					
					
					e.getContext(driver);
					((IJavaScriptExecutor)e.getContext(driver)).ExecuteScript("if (typeof mapearClick=='function') {window.removeEventListener('click', mapearClick);}");
					((IJavaScriptExecutor)e.getContext(driver)).ExecuteScript("if (typeof mapearOver=='function') {window.removeEventListener('mouseover',mapearOver);}");
					((IJavaScriptExecutor)e.getContext(driver)).ExecuteScript("if (typeof mapearOut=='function') {window.removeEventListener('mouseout',mapearOut);}");
					
					
				}
				
				
				//pegar objetos da marcacao
				
				listaElements=new List<Element>();
				listaElements=Util.RecursiveElementUIframe(driver,listaElements,"*[executiondomain=true]",null,false);
				foreach(Element e in listaElements ){
					
					listaField.Add(new Field(e));
				}
				
				//retirar a marcacao
				listaElements=new List<Element>();
				listaElements=Util.RecursiveElementUIframe(driver,listaElements,"*[executiondomain=true]",null,false);
				
				foreach(Element e in listaElements ){
					e.getContext(driver);
					((IJavaScriptExecutor)e.getContext(driver)).ExecuteScript("arguments[0].removeAttribute('executiondomain'); arguments[0].style.outline='0px outset #000000';    ", (IWebElement)e.getElemento());
				}
				
				
				
				
				
			}
			}
			catch(Exception ee){
				var ees=ee.Message;
			
			}
			return listaField;
		}
		
		
		

	}



}
