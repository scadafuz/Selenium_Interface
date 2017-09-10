/*
 * Created by SharpDevelop.
 * User: blopes
 * Date: 26/06/2017
 * Time: 13:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace SeleniumTest
{
	/// <summary>
	/// Description of Util.
	/// </summary>
	public static class Util
	{
		public enum status{ pass,fail,warning};
        public static Case casoTop;
		public static MainForm mainForm;
		public static StartWebDriver StartWebDriver;
		public static  List<Element> RecursiveElementUIframe(IWebDriver driver,List<Element> listaElements,string xpath_tagElement=null,ArrayList arrayFrame=null,bool xpath=false){
			if(object.ReferenceEquals(null,arrayFrame)){
				driver.SwitchTo().DefaultContent();
				arrayFrame=new ArrayList();
				
			}
			
			var framesNormal=driver.FindElements(By.TagName("frame"));
			var iframe=driver.FindElements(By.TagName("iframe"));
			var frames=framesNormal.Concat(iframe).ToList();
			
			ReadOnlyCollection<IWebElement> listEleTagName;
			IWebDriver drive=driver;
			if (!xpath){
				listEleTagName=driver.FindElements(By.CssSelector(xpath_tagElement));
			}
			else{
				listEleTagName=driver.FindElements(By.XPath(xpath_tagElement));
			}
			foreach(RemoteWebElement e in listEleTagName){
				listaElements.Add(new Element(e,(ArrayList)arrayFrame.Clone(),driver.CurrentWindowHandle));
			}
			for(int i=0;i<frames.Count;i++){
				
				arrayFrame.Add(i);
				try{
					driver.SwitchTo().Frame(i);
					RecursiveElementUIframe(driver,listaElements,xpath_tagElement,arrayFrame,xpath);
				}
				catch(Exception){}
				arrayFrame.RemoveAt(arrayFrame.Count-1);
				driver.SwitchTo().ParentFrame();
			}
			return 	listaElements;
		}
		
		
		
	}
}
