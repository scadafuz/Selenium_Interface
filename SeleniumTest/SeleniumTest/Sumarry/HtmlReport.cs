/*
 * Created by SharpDevelop.
 * User: blopes
 * Date: 22/06/2017
 * Time: 14:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

using SeleniumTest.Properties;

namespace SeleniumTest
{
	/// <summary>
	/// Description of HtmlReport.
	/// </summary>
	public class HtmlReport
	{
		
		public string Html=File.ReadAllText(StartWebDriver.PathExec+"\\relatorioCapado.html");
		public string htmlPath;

		public HtmlReport()
		{
			htmlPath=StartWebDriver.PathExec+"\\Result\\"+DateTime.Now.ToString("yyyyMMddHHmmssfff")+".html";
	
			string  inicioTexto=Regex.Split(Html,"#rowEvidencias#")[0];
			FileStreamWrite(inicioTexto,true);
		}
		public string GerarReport(DateTime DataHoraInicio,DateTime DataHoraFim,List<Evidencia> Evidencias,Case caso){

			string  fimTexto=Regex.Split(Html,"#rowEvidencias#")[1];

			FileStreamWrite(fimTexto+replaceEnd(DataHoraInicio,DataHoraFim,Evidencias,caso),true);

			return htmlPath;
			
		}
		
		public void addEvidencia(Evidencia e,int cont){

			StringBuilder EvidenciaHtml=new StringBuilder();

			EvidenciaHtml.Append(Environment.NewLine+"          <tr class='"+StatusToTextTemplate(e.step.Status).Replace("success","default")+"'>");
			EvidenciaHtml.Append("             <td class='text-center'>"+(cont+1)+"</td>");
			EvidenciaHtml.Append("             <td>"+e.step.Expected+"</td>");
			EvidenciaHtml.Append("             <td>"+e.step.Action+" "+e.step.DataTest+"</td>");
			EvidenciaHtml.Append("             <td>"+e.step.StepName+"</td>");

			EvidenciaHtml.Append("             <td>");
			EvidenciaHtml.Append("                 <span class='label label-"+StatusToTextTemplate(e.step.Status)+"'>"+StatusToTextTemplate(e.step.Status)+"</span>");
			EvidenciaHtml.Append("             </td>");
			EvidenciaHtml.Append("             <td>");
			EvidenciaHtml.Append("                 <a class='thumbnail'>");
			EvidenciaHtml.Append("                     <img style='width:100%' class='img-responsive' data-toggle='modal' data-target='#modalEvidence' title='Clique para ampliar a imagem.' src='data:image/png;base64,"+e.ScreenBase64+"' title='Evidência , clique para ampliar/diminuir a imagem.'>");
			EvidenciaHtml.Append("                 </a>");
			EvidenciaHtml.Append("             </td>");
			EvidenciaHtml.Append("         </tr>");
			
			//writeText(FileStreamWrite));
			FileStreamWrite(EvidenciaHtml.ToString(),true);
			EvidenciaHtml.Clear();
			e.ClearScreenBase64();
			
		}
		
		
		private string replaceEnd(DateTime inicio,DateTime Fim,List<Evidencia> Evidencias,Case caso){
			int warning=Evidencias.Where(x=>x.step.Status==Util.status.warning).ToList().Count();
			string warningString="";
			string statusString="";
			string colorClass="";
			if(warning>0)	warningString=" ("+warning+" Aviso(s))";

			if(Evidencias.Where(x=>x.step.Status==Util.status.fail).ToList().Count()>0){
				statusString="Falhou";
				colorClass="danger";}
			else{
				statusString="Passou";
				colorClass="success";}
			
			string endString="<script>";
			endString=endString+"var ResultExec={ini:'"+inicio.ToString("dd/MM/yyyy hh:mm:ss")+"',end:'"+Fim.ToString("dd/MM/yyyy hh:mm:ss")+"',statusText:'"+statusString+"',warningText:'"+warningString+"',project: '"+caso.Project+"',testCase: '"+caso.NameCase+"',preCondition: '"+caso.PreCondition+"',purpose: '"+caso.Purpose+"',posCondition: '"+caso.PosCondition+"'};";
			endString=endString+"function RunResult(){ ";
			endString=endString+"document.getElementById('preExec4895').innerHTML=ResultExec.preCondition;";
			endString=endString+"document.getElementById('objExec4895').innerHTML=ResultExec.purpose;";
			endString=endString+"document.getElementById('posExec4895').innerHTML=ResultExec.posCondition;";
			endString=endString+"document.getElementById('cnameExec4895').innerHTML=ResultExec.testCase;";
			endString=endString+"document.getElementById('proExec4895').innerHTML=ResultExec.project;";
			endString=endString+"document.getElementById('iniExec4895').innerHTML=ResultExec.ini;";
			endString=endString+"document.getElementById('endExec4895').innerHTML=ResultExec.end;";
			endString=endString+"document.getElementById('changeColor4895span').innerHTML=ResultExec.statusText;";
			endString=endString+"document.getElementById('changeColor4895SpanWarn').innerHTML=ResultExec.warningText;";
			endString=endString+"$(document.getElementById('changeColor4895SpanWarn')).attr('class','text-"+colorClass+"');";
			endString=endString+"$(document.getElementById('changeColor4895span')).attr('class','text-"+colorClass+"');";
			endString=endString+"$(document.getElementById('changeColor4895strong')).attr('class','text-"+colorClass+"');";
			endString=endString+"$(document.getElementById('changeColor4895list')).attr('class','list-group-item list-group-item-"+ colorClass + "');";
			endString=endString+"}";
			endString=endString+"RunResult();";
			endString=endString+"</script>	";
			endString=endString+"</body></html>";
			
			return endString;
			
		}
		
		
		
		private string StatusToTextTemplate(Util.status status){
			
			if(status.ToString().Equals("pass")){
				return "success";
			   }
			else if(status.ToString().Equals("fail")){
				return "danger";
			   }
			else if(status.ToString().Equals("warning")){
				return "warning";
			   }
			else	return "default";		
			
		}
		
		
		private string ReplaceTag(string searchvalue,string newvalue){
			
			return this.Html=Html.Replace(searchvalue,newvalue);

		}
		
		public void FileStreamWrite(String Html,bool EOF){
			
			if(EOF){
				File.AppendAllText(htmlPath,Html);
			}
			else{
				string Temp=File.ReadAllText(htmlPath);
				File.WriteAllText(htmlPath,Html+Temp);
				Temp="";
			}

		}
	}
}
