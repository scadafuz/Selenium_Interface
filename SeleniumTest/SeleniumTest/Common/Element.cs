/*
 * Created by SharpDevelop.
 * User: blopes
 * Date: 27/06/2017
 * Time: 16:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
	/// <summary>
	/// Description of Element.
	/// </summary>
	/// 
	[Serializable()]
	public class Element
	{
		//public string WindowHandle;
		public ArrayList frameSequence;
		[XmlIgnore]
		public RemoteWebElement Elemento;
		public string xpath_;
		public string CSSSelector_;
		public string xpath_id;
		public string CSSSelector_id;
		[XmlIgnore]
		public ArrayList frameSequence_otherContext;
		public Element(RemoteWebElement Elemento, ArrayList frameSequence,string WindowHandle)
		{
			this.frameSequence=frameSequence;
			this.Elemento=Elemento;
			xpath_=GetElementXPath(Elemento);
			CSSSelector_=GetElementCSSSelector(Elemento);
			xpath_id=GetElementXPathID(Elemento);
			CSSSelector_id=GetElementCSSSelectorID(Elemento);
		}
		/*	public Element(ArrayList frameSequence,string WindowHandle){
			
			this.frameSequence=frameSequence;
			if(!ReferenceEquals(Elemento,null))
				this.xpath_=GetElementXPath(Elemento,Util.StartWebDriver.getDriver());
		}*/
		public Element(){
			
			
		}

		
		//usado so pra mapear
		public IWebDriver getContext(IWebDriver driver){
			//coloquei esse forwach para verificar em todas as windows nao testei
		
			ArrayList frameSequence_atual;
			if(!(ReferenceEquals(frameSequence_otherContext,null))){
					frameSequence_atual=frameSequence_otherContext;
			}
			else{
					frameSequence_atual=frameSequence;
			}
			
			driver.SwitchTo().DefaultContent();
			foreach(int i in frameSequence_atual){
				try{
					driver.SwitchTo().Frame(i);
				}
				catch(Exception){
					
				}
			}
			return driver;
		}
	
		
		
		
		
		
		public String GetElementCSSSelector(IWebElement element)
		{
			string saida="";
			try{
				saida= (String) ((IJavaScriptExecutor) Util.StartWebDriver.getDriver()).ExecuteScript(
					
					"getCSSPath_=function(el){"+
					"var names = [];"+
					" while (el.parentNode){"+
					"      if (el==el.ownerDocument.documentElement) names.unshift(el.tagName);"+
					"      else{"+
					"        for (var c=1,e=el;e.previousElementSibling;e=e.previousElementSibling,c++);"+
					"        names.unshift(el.tagName+':nth-child('+c+')');"+
					"      }"+
					"      el=el.parentNode;  "+
					"  }"+
					"  return names.join(' > ');"+
					"};"+
					"return getCSSPath_(arguments[0]);", element);
				
			}
			catch(Exception ){
				
			}
			return Regex.Replace(saida,".*> aside[^>]+>|.*> ASIDE[^>]+>","");
		}
		
	

		
		
		public String GetElementCSSSelectorID(IWebElement element)
		{
			string saida="";
			try{
				saida= (String) ((IJavaScriptExecutor) Util.StartWebDriver.getDriver()).ExecuteScript(
					
					"getCSSPath_=function(el){"+
					"var names = [];"+
					" while (el.parentNode){"+
					 "if (el.id){"+
				      "names.unshift('#'+el.id);"+
				      "break;"+
				      "}else{"+
					"      if (el==el.ownerDocument.documentElement) names.unshift(el.tagName);"+
					"      else{"+
					"        for (var c=1,e=el;e.previousElementSibling;e=e.previousElementSibling,c++);"+
					"        names.unshift(el.tagName+':nth-child('+c+')');"+
					"      }"+
					"      el=el.parentNode;  "+
					"  }"+
					"  }"+
					"  return names.join(' > ');"+
					"};"+
					"return getCSSPath_(arguments[0]);", element);
				
			}
			catch(Exception ){
				
			}
			return Regex.Replace(saida,".*> aside[^>]+>|.*> ASIDE[^>]+>","");
		}
		
		
		public String GetElementXPath(IWebElement element)
		{
			
			string saida="";
			try{
				saida= (String) ((IJavaScriptExecutor) Util.StartWebDriver.getDriver()).ExecuteScript(
					"getXPath_=function(node)" +
					"{" +
					//	"if (node.id !== '')" +
					//	"{" +
					//	"return '//' + node.tagName.toLowerCase() + '[@id=\"' + node.id + '\"]'" +
					//	"}" +
					
					"if (node === document.body)" +
					"{" +
					"return node.tagName.toLowerCase()" +
					"}" +
					
					"var nodeCount = 0;" +
					"var childNodes = node.parentNode.childNodes;" +
					
					"for (var i=0; i<childNodes.length; i++)" +
					"{" +
					"var currentNode = childNodes[i];" +
					
					"if (currentNode === node)" +
					"{" +
					"return getXPath(node.parentNode) + '/' + node.tagName.toLowerCase() + '[' + (nodeCount+1) + ']'" +
					"}" +
					
					"if (currentNode.nodeType === 1 && " +
					"currentNode.tagName.toLowerCase() === node.tagName.toLowerCase())" +
					"{" +
					"nodeCount++" +
					"}" +
					"}" +
					"};" +
					
					"return getXPath_(arguments[0]);", element);
				
			}
			catch(Exception ){
				
			}
			return saida;
		}
		
		
		
		public String GetElementXPathID(IWebElement element)
		{
			
			string saida="";
			try{
				saida= (String) ((IJavaScriptExecutor) Util.StartWebDriver.getDriver()).ExecuteScript(
					"getXPath=function(node)" +
					"{" +
					"if (node.id !== '')" +
					"{" +
					"return '//' + node.tagName.toLowerCase() + '[@id=\"' + node.id + '\"]'" +
					"}" +
					
					"if (node === document.body)" +
					"{" +
					"return node.tagName.toLowerCase()" +
					"}" +
					
					"var nodeCount = 0;" +
					"var childNodes = node.parentNode.childNodes;" +
					
					"for (var i=0; i<childNodes.length; i++)" +
					"{" +
					"var currentNode = childNodes[i];" +
					
					"if (currentNode === node)" +
					"{" +
					"return getXPath(node.parentNode) + '/' + node.tagName.toLowerCase() + '[' + (nodeCount+1) + ']'" +
					"}" +
					
					"if (currentNode.nodeType === 1 && " +
					"currentNode.tagName.toLowerCase() === node.tagName.toLowerCase())" +
					"{" +
					"nodeCount++" +
					"}" +
					"}" +
					"};" +
					
					"return getXPath(arguments[0]);", element);
				
			}
			catch(Exception ){
				
			}
			return saida;
		}
		
		
		
		//nao coloca try and catch
		public RemoteWebElement getElemento(){
			
			IWebDriver driveru=(getContext(Util.StartWebDriver.getDriver()));
			var els=driveru.FindElements(By.XPath(xpath_id));
			if(els.Count==0){
				els=driveru.FindElements(By.CssSelector(CSSSelector_id));
				if(els.Count!=0){
					this.Elemento= (RemoteWebElement)els[0];
				}
				else{
					els=driveru.FindElements(By.XPath(xpath_));
					if(els.Count==0){
						els=driveru.FindElements(By.CssSelector(CSSSelector_));
						if(els.Count!=0){
							this.Elemento= (RemoteWebElement)els[0];
						}
						else{
							List<RemoteWebElement> lstElementoQualquerContexto=new List<RemoteWebElement>();
							lstElementoQualquerContexto=FindOtherContext(lstElementoQualquerContexto);
							if(lstElementoQualquerContexto.Count>0){
								return lstElementoQualquerContexto[0];
							}
							else{
								throw new Exception("Elemento não encontrado");
							}
						}
					}
					else{
						this.Elemento= (RemoteWebElement)els[0];
					}
				}
			}
			else{
				this.Elemento= (RemoteWebElement)els[0];
			}
			
			return this.Elemento;
		}
		
		
		
		public List<RemoteWebElement> FindOtherContext(List<RemoteWebElement> saida,ArrayList arrayFrame=null){
			if(saida.Count>0){
				return saida;
			}
			IWebDriver driver=Util.StartWebDriver.driver;
			if(object.ReferenceEquals(null,arrayFrame)){
				driver.SwitchTo().DefaultContent();
				arrayFrame=new ArrayList();
				
			}
			
			var framesNormal=driver.FindElements(By.TagName("frame"));
			var iframe=driver.FindElements(By.TagName("iframe"));
			var frames=framesNormal.Concat(iframe).ToList();
			

			
			var listEleTagName=driver.FindElements(By.CssSelector(this.CSSSelector_));
			
			foreach(RemoteWebElement e in listEleTagName){
				saida.Add(e);
				frameSequence_otherContext=(ArrayList)arrayFrame.Clone();
				return saida;
				break;
			}
			for(int i=0;i<frames.Count;i++){
				
				arrayFrame.Add(i);
				try{
					driver.SwitchTo().Frame(i);
					FindOtherContext(saida,arrayFrame);
				}
				catch(Exception){}
				arrayFrame.RemoveAt(arrayFrame.Count-1);
				driver.SwitchTo().ParentFrame();
			}
			return 	saida;
			
		}
		
	}
}
