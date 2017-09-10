/*
 * Created by SharpDevelop.
 * User: blopes
 * Date: 22/08/2017
 * Time: 15:21
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.ComponentModel;
namespace SeleniumTest
{
	/// <summary>
	/// Description of Step.
	/// </summary>
	public class Step
	{
		
		[ReadOnly(true)]
		public string Order{get;set;}
		public string StepName{get;set;}
		[Browsable(false)]
		public string Action{get;set;}
		[Browsable(false)]
		public string Expected{get;set;}
		public string DataTest{get;set;}
		[ReadOnly(true)]
		public string PathObject{get;set;}
		[Browsable(false)]
		[ReadOnly(true)]
		public Util.status Status{get;set;}
		[Browsable(false)]
		private Field field_=new Field();
		[Browsable(false)]
		public Field Field{get{
				return this.field_;
			}set{
				
				this.PathObject=value.xpath;
				this.field_=value;
			}}
		
		public Step()
		{
		}
		
		public bool isNull(){
			
			if(ReferenceEquals(this.Order,null) && ReferenceEquals(this.StepName,null) && ReferenceEquals(this.Action,null)  && ReferenceEquals(this.DataTest,null) && ReferenceEquals(this.Expected,null) && ReferenceEquals(this.PathObject,null) ){
				return true;
			}
			else{return false;}
		}
		public void execute(){
		   
			switch(this.Action){
				case  "Click"://
					Status=this.Field.Click();
			    	break;
			    case  "Clear"://
					Status=this.Field.FieldClear();
			    	break;
				case "Select in Drop"://colocar no datatest o texto da combo
			    	Status=this.Field.Select(DataTest);
					break;
				case "Check/Uncheck"://colocar no datatest 'on' ou 'off'
					Status=this.Field.CheckBox(DataTest);
					break;
				case "MouseOver":
					Status=this.Field.MouseOver();
					break;
				case "Wait"://colocar no datatest segundos
					Status=this.Field.Wait(this.DataTest);
					break;
				case "DoubleClick"	:		     	
					Status=this.Field.DoubleClick();
					break;
				case  "Set": 
					Status=this.Field.FieldSet(DataTest,MetodoOptions.Metodo.SendKey);
			    	break;
				case  "Verify":   
			    	Status=this.Field.FieldExist(2000);
					break;
			    case  "Scroll" ://colocar no datatest 0, 250  
					Status=this.Field.Scroll(DataTest);
			    	break;
				case  "URL"  :
					Status=this.Field.URL(DataTest);			    	
			    	break;
			 
				case  "SendKey"  : 
			    	Status=this.Field.FieldSet(DataTest,MetodoOptions.Metodo.SendKey);
			    	break;
				case  "Alert"   ://colocar no datatest  ok 
			    	Status=this.Field.Alert(DataTest);
			    	break;
			    case  "Auth"   :// colocar no datatest  username, password
			    	Status=this.Field.Auth(DataTest);
			    	break;
			    case  "Maximize"   :// colocar no datatest  username, password
			    	Status=this.Field.Maximize();
			    	break;	
				default:
                    Status = Util.status.fail;
                    break;
		
			}
		}
		
	}
}
