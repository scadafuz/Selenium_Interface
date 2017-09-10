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
		public Element(RemoteWebElement Elemento, ArrayList frameSequence,string WindowHandle)
		{
			this.frameSequence=frameSequence;
			this.Elemento=Elemento;
			xpath_=GetElementXPath(Elemento);
			CSSSelector_=GetElementCSSSelector(Elemento);
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
			driver.SwitchTo().DefaultContent();
			foreach(int i in frameSequence){
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
					" getCSSPath = function(el) {"+
					"        if (!(el instanceof Element)) "+
					"            return;"+
					"        var path = [];"+
					"        while (el.nodeType === Node.ELEMENT_NODE) {"+
					"            var selector = el.nodeName.toLowerCase();"+
					"            if (el.id) {"+
					"                selector += '#' + el.id;"+
					"                path.unshift(selector);"+
					"                break;"+
					"            } else {"+
					"                var sib = el, nth = 1;"+
					"                while (sib = sib.previousElementSibling) {"+
					"                    if (sib.nodeName.toLowerCase() == selector)"+
					"                       nth++;"+
					"                }"+
					"                if (nth != 1)"+
					"                    selector += ':nth-of-type('+nth+')';"+
					"            }"+
					"            path.unshift(selector);"+
					"            el = el.parentNode;"+
					"        }"+
					"        return path.join(' > ');"+
					"     };"+

					"return getCSSPath(arguments[0]);", element);
				
			}
			catch(Exception ){
				
			}
			return saida;
		}
		public String GetElementXPath(IWebElement element)
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
		
		public RemoteWebElement getElemento(){
			
			IWebDriver driveru=(getContext(Util.StartWebDriver.getDriver()));
			var els=driveru.FindElements(By.XPath(xpath_));
			if(els.Count==0){
				els=driveru.FindElements(By.CssSelector(CSSSelector_));
				if(els.Count!=0){
					this.Elemento= (RemoteWebElement)els[0];
				}
			}
			else{
				this.Elemento= (RemoteWebElement)els[0];
			}
			
			return this.Elemento;
		}
		
	}
}
