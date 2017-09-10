/*
 * Created by SharpDevelop.
 * User: blopes
 * Date: 20/06/2017
 * Time: 10:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

using OpenQA.Selenium;
using SeleniumTest.Properties;

namespace SeleniumTest
{
	/// <summary>
	/// Description of CoreExecucao.
	/// </summary>
	/// 
	
	public class Run
	{
		
		public DateTime DataHoraInicio;
		public DateTime DataHoraFim;
		private Case caso;
		public Util.status status;
		public Report Reporter;
		public bool pauseExecution=false;
		public bool stopExecution=false;
        public string statusExecution = "";
		public int actualStepCont=0;
        public int totalStep = 0;
        public Run(Case caso)
		{
			
			this.caso=caso;
            this.totalStep = this.caso.Steps.Count;


        }
		public Run(){
		}
		public void execute(){
			
			this.stopExecution=false;
			actualStepCont=0;
			this.DataHoraInicio=DateTime.Now;
			
			Reporter=new Report();
			
			
			for(int i=0;i<caso.Steps.Count;i++){
                if (stopExecution) { break; statusExecution = "End"; }
                actualStepCont =i;
                totalStep = caso.Steps.Count;
                caso.LastRun = this;
            
                if (caso.Steps[i].Action!="CallTestCase"){
					caso.Steps[i].execute();
					Reporter.addEvidencia(new Evidencia(caso.Steps[i]));
					
				}
				else{
					
					
					caso.Steps.InsertRange(i+1,CallTestSet(caso.Steps[i].DataTest));
					
				}
                statusExecution = "( "+ (actualStepCont +1)+ "/"+ totalStep + " )"+caso.Steps[i].StepName;
                while (pauseExecution && stopExecution == false)
                    statusExecution = "Pause";
					Thread.Sleep(1000);
			}
			

			stopExecution=true;
			this.DataHoraFim=DateTime.Now;
			Reporter.FinalizaReporterReport(DataHoraInicio,DataHoraFim,caso);
		}
		
		
		public List<Step> CallTestSet(string pathCall){
			
			try{
				
				string xml=File.ReadAllText(pathCall);
				XmlSerializer serializer  = new XmlSerializer(typeof(Case));
				TextReader reader = new StringReader(xml);
				
				Case caso_ofd= (Case)serializer.Deserialize(reader);
				
				return caso_ofd.Steps;
				
				
				
			}
			catch(Exception){
				return new List<Step>();
			}
		}

		
	}
}
