/*
 * Created by SharpDevelop.
 * User: blopes
 * Date: 01/06/2017
 * Time: 14:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
	/// <summary>
	/// Description of Field.
	/// </summary>
	public class Field

	{
		[Browsable(false)]
		public Element Element{get;set;}
		public string xpath{get;set;}
		[Browsable(false)]
		[DllImport("user32.dll")]
		internal static extern bool OpenClipboard(IntPtr hWndNewOwner);
		[Browsable(false)]
		[DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();
		[Browsable(false)]
		[DllImport("user32.dll")]
		internal static extern bool CloseClipboard();
		[Browsable(false)]
		[DllImport("user32.dll")]
		internal static extern bool SetClipboardData(uint uFormat, IntPtr data);
		[Browsable(false)]
		public string TypeField_;
		[Browsable(false)]
		private int Maxlenght_;
		[Browsable(false)]
		public string DefaultValue;
		//[Browsable(false)]
		//[NonSerialized()]
		//private IWebDriver driver;
		[Browsable(false)]
		public int Maxlenght{
			
			get{
				return this.Maxlenght_;
			}

			set{
				
				if(value>999){
					this.Maxlenght_=999;
				}
				else{
					this.Maxlenght_=value;
				}
				
			}
			
		}
		public Field()
		{
		}
		public Field(Element Campo)
		{
			
			this.Element=Campo;
			
			this.xpath=Campo.xpath_;
			
			//	this.driver=Campo.Elemento.WrappedDriver;
			
			
			int value_=0;
			try{
				int.TryParse((string)getAttr(this.Element.getElemento(),"maxLength"),out value_);
				
				this.Maxlenght=value_;
			}
			catch(Exception){
				this.Maxlenght=0;
			}
			
			try{
				this.DefaultValue=(string)getAttr(this.Element.getElemento(),"value");
			}
			catch(Exception){
				this.DefaultValue=null;
			}
			
			//this.WindowHandle=Util.StartWebDriver.getDriver().CurrentWindowHandle;
			
			this.TypeField_=this.Element.getElemento().GetAttribute("type");

		}
		
		public void RefreshObject(){
			//	IWebDriver u=(this.Element.getContext(Util.StartWebDriver.getDriver()));
			//	IWebElement e=u.FindElement(By.XPath(xpath));
			this.Element.getElemento();

		}
		public Util.status FieldClear(){
			try{
				RefreshObject();
				this.Element.getElemento().Clear();
				return Util.status.pass;
			}
			catch(Exception){
				return Util.status.fail;
			}
			

		}
		public Util.status FieldSet(string massa,MetodoOptions.Metodo Metodo,bool validaSize=false){
			try{
				if(FieldExist()){
					if(Metodo==MetodoOptions.Metodo.SendKey){
						
						if ("^~¨´`".Contains(massa)){
							if (StartWebDriver.handle==GetForegroundWindow()){
								
								if(massa=="^"){
									TranferAreaCopy(massa);
									if (StartWebDriver.handle==GetForegroundWindow()){
										SendKeys.SendWait("^v");
									}
									else{
										
										return Util.status.warning;
									}
									
								}
								else{
									
									SendKeys.SendWait("{"+massa+" 2}");
									if(this.Element.getElemento().GetAttribute("value").Length>1){
										this.Element.getElemento().SendKeys(OpenQA.Selenium.Keys.Backspace);
										
									}
									this.Element.getElemento().SendKeys("");
								}
							}
							else{
								
								return Util.status.warning;
							}

						}
						else
							this.Element.getElemento().SendKeys(massa);
						
					}
					
					else if (Metodo==MetodoOptions.Metodo.Insert){
						this.Element.Elemento.SendKeys("");
						TranferAreaCopy(massa);
						
						if (StartWebDriver.handle==GetForegroundWindow()){
							SendKeys.SendWait("+{INS}");
						}
						else{
							
							return Util.status.warning;
						}
						
					}

					else if(Metodo==MetodoOptions.Metodo.CopiarEColar){
						
						this.Element.getElemento().SendKeys("");
						TranferAreaCopy(massa);
						if (StartWebDriver.handle==GetForegroundWindow()){
							SendKeys.SendWait("^v");
						}
						else{
							
							return Util.status.warning;
						}
						
					}
					
					return Util.status.pass;
					//	return ValidaCampo(massa);
				}
				
				else return Util.status.warning;
			}
			catch(Exception){
				return Util.status.fail;
				
			}
		}
		public bool FieldExist(){
		

			try{
				RefreshObject();
				return (this.Element.Elemento.Displayed && this.Element.Elemento.Enabled);
			}
			catch(Exception ee){
				
				foreach(string x in	Util.StartWebDriver.driver.WindowHandles){
					try{
						Util.StartWebDriver.driver.SwitchTo().Window(x);
						RefreshObject();
					    return (this.Element.Elemento.Displayed && this.Element.Elemento.Enabled);
					}
					catch(Exception eee){
					
					
					}
				}
	
				
				return false;
			}

		}
		
		public Util.status FieldExist(int millsec){
			Thread.Sleep(millsec);
			try{
				RefreshObject();
				if(this.Element.getElemento().Displayed)
					return Util.status.pass;
				else
					return Util.status.fail;
			}
			catch(Exception){
				return Util.status.fail;
			}
		}
		
		
		
		
		
		public Util.status CampoDeveriaAceitarEssaMassa(string massa){
			if (string.Join("",TypeField.GetArrayType(this.TypeField_)).Contains(massa))
				return  Util.status.pass;
			else
				return  Util.status.fail;
			
		}
		private void TranferAreaCopy(string massa){
			OpenClipboard(IntPtr.Zero);
			var ptr = Marshal.StringToHGlobalUni(massa);
			SetClipboardData(13,ptr);
			CloseClipboard();
			Marshal.FreeHGlobal(ptr);
			
			
		}
		public string fieldType(){

			RefreshObject();
			return this.Element.getElemento().GetAttribute("type");
		}
		public object getAttr(IWebElement element,string attr){

			return (object) ((IJavaScriptExecutor) Util.StartWebDriver.getDriver()).ExecuteScript("return arguments[0]."+attr,element);
		}
		
		public Util.status Wait(string Segundo){
			
			try{
				Thread.Sleep((Convert.ToInt32(Segundo))*1000);
				return Util.status.pass;
			}
			catch(Exception){
				return Util.status.fail;
			}
			
		}
		
		public  Util.status Click(){
			
			try{
		//		FieldExist();
				this.Element.getElemento().Click();
				return Util.status.pass;
			}
			catch(Exception){
				return Util.status.fail;
			}
			
			
		}
		
		
		public  Util.status Select(string SelectText){
			
			try{
				FieldExist();
				SelectElement dropdown = new SelectElement(this.Element.getElemento());
				dropdown.SelectByText(SelectText);
				return Util.status.pass;
				
			}
			catch(Exception){	
				try{
					FieldExist();
					Actions sendKeyAction= new Actions(Util.StartWebDriver.driver);
					this.Element.getElemento().Click();
					this.Element.getElemento().SendKeys(SelectText);
				
					
					return Util.status.pass;
				
				}catch(Exception ee){
				
				    return Util.status.fail;
				}

			}
		}
		public  Util.status CheckBox(string SelectText){
			
			try{
				FieldExist();
				
				
				if (SelectText.ToLower()=="on"){
					if (!(this.Element.getElemento().Selected))
						this.Element.getElemento().Click();
				}
				else{
					if ((this.Element.getElemento().Selected))
						this.Element.getElemento().Click();
				}
				return Util.status.pass;
			}
			catch(Exception){
				return Util.status.fail;
			}
			
			
		}
		
		
		public  Util.status MouseOver(){
			
			try{

				FieldExist();
				Actions action  = new Actions(Util.StartWebDriver.getDriver());
				action.MoveToElement(this.Element.getElemento()).Perform();
				return Util.status.pass;
			}
			catch(Exception){
				return Util.status.fail;
			}
		}
		
		
		public  Util.status DoubleClick(){
			
			try{

				FieldExist();
				Actions action  = new Actions(Util.StartWebDriver.getDriver());
				action.MoveToElement(this.Element.getElemento()).DoubleClick();
				
				return Util.status.pass;
			}
			catch(Exception){
				return Util.status.fail;
			}
		}
		
		
		public  Util.status Alert(string namebutton){
			
			try{
				//FieldExist();mapear um elemento para saber qualdriver esse alert esta
				WebDriverWait wait = new WebDriverWait(Util.StartWebDriver.getDriver(), TimeSpan.FromSeconds(10));
				wait.Until(ExpectedConditions.AlertIsPresent());
				IAlert alert = Util.StartWebDriver.getDriver().SwitchTo().Alert();
				if(namebutton.ToLower()=="ok")
					alert.Accept();
				else
					alert.Dismiss();
				return Util.status.pass;
			}
			catch(Exception){
				return Util.status.fail;
			}
		}
		
		public  Util.status URL(string URL){
			
			try{
				var url_=new UriBuilder(URL).Uri.ToString();
				Util.StartWebDriver.getDriver().Url=url_;
				Util.StartWebDriver.driver.Navigate();
				
				return Util.status.pass;
			}
			catch(Exception){
				return Util.status.fail;
			}
		}
		
		public  Util.status Scroll(string scroll){
			
			try{
				
				IJavaScriptExecutor jse = (IJavaScriptExecutor)Util.StartWebDriver.getDriver();
				jse.ExecuteScript("window.scrollBy("+scroll+")", "");
				return Util.status.pass;
			}
			catch(Exception){
				return Util.status.fail;
			}
		}
		
		public  Util.status Auth(string credencial){
			
			try{
				//TODO:certamente mudar isso aki......
				var cred=credencial.Split(',');
				
				WebDriverWait wait = new WebDriverWait(Util.StartWebDriver.getDriver(), TimeSpan.FromSeconds(10));
				IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
				alert.SetAuthenticationCredentials(cred[0], cred[1]);
				return Util.status.pass;
			}
			catch(Exception){
				return Util.status.fail;
			}
		}
		
		
		public  Util.status Maximize(){
			
			try{
				
				Util.StartWebDriver.getDriver().Manage().Window.Maximize();
				return Util.status.pass;
			}
			catch(Exception){
				return Util.status.fail;
			}
		}
		
	}
}
