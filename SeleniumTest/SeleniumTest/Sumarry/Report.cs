/*
 * Created by SharpDevelop.
 * User: blopes
 * Date: 01/06/2017
 * Time: 15:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using OpenQA.Selenium;
using SeleniumTest.Properties;

namespace SeleniumTest
{
	/// <summary>
	/// Description of Report.
	/// </summary>
	public class Report
	{
		private List<Evidencia> Evidencias=new List<Evidencia>();
		public HtmlReport report;
      
		public Report()
		{
			//ao intanciar ja cria o arquivo
			this.report=new HtmlReport(); 
			

		}
		public string FinalizaReporterReport(DateTime inicio,DateTime fim,Case caso){
		
			return report.GerarReport(inicio,fim,Evidencias,caso);
		
		}
		public void addEvidencia(Evidencia evi){
				//Ao adcionar ao reporter o print e descarregado
			    report.addEvidencia(evi,Evidencias.Count);
				Evidencias.Add(evi);	
				
		}
		
		
		
	}
}
