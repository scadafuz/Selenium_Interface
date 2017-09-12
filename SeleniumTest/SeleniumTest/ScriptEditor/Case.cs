/*
 * Created by SharpDevelop.
 * User: blopes
 * Date: 22/08/2017
 * Time: 14:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SeleniumTest
{
	/// <summary>
	/// Description of Case.
	/// </summary>
	public class Case
	{   
		public string Project{get;set;}
		public string NameCase{ get; set; }
		public string Purpose{ get; set; }
		public string PreCondition{ get; set; }
		public string PosCondition{ get; set; }
		[XmlIgnore]
        [Browsable(false)]
		public string LastSumary{ get; set; }
        [XmlIgnore]
        [Browsable(false)]
		public Run LastRun{ get; set; }
		
		[Browsable(false)]
		public List<Step> Steps{ get; set; }

		public Case(string nameCase,string posCondition,string purpose,string preCondition )
		{
			this.NameCase=nameCase;
			this.PosCondition=posCondition;
			this.Purpose=purpose;
			this.PreCondition=preCondition;
			Steps=new List<Step>();
		}
		
		public Case(){
		}
        public void createRun() {
            LastRun = new Run(this);
        }
		public void execute(){
           if(ReferenceEquals(LastRun,null)) LastRun = new Run(this);

            LastRun.execute();
			LastSumary=LastRun.Reporter.report.htmlPath;	
		
		}
		
	
	}
}
