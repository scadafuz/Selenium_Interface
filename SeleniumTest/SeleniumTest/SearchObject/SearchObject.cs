/*
 * Created by SharpDevelop.
 * User: blopes
 * Date: 31/08/2017
 * Time: 08:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using OpenQA.Selenium;

namespace SeleniumTest
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class SearchObject : Form
	{
		
		
		public SearchObject(StartWebDriver StartWebDriver)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			Util.StartWebDriver=StartWebDriver;
			
			
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		

		
		void BtnSearchClick(object sender, EventArgs e)
		{
			Util.StartWebDriver.MapObjects();
		}
		
		void BtnStopClick(object sender, EventArgs e)
		{
			List<Field> lF=Util.StartWebDriver.StopMap();
			BindingSource bs = new BindingSource();
			bs.DataSource=lF;
			lstXPath.DataSource=bs;
			lstXPath.Update();
			lstXPath.Refresh();
			
		}
		void SearchObjectClosing(object sender, System.EventArgs e)
		{
			List<Field> lF=Util.StartWebDriver.StopMap();
		}
		
		void BtnHighlightClick(object sender, EventArgs e)
		{
			//TODO:ELEMENTO NAO VISIVEL < FALAR QUE EXISTE MAS e.Displayed or hidden
			try{
				object field_=lstXPath.CurrentRow.DataBoundItem;
				if (!Util.StartWebDriver.highLight(((Field)field_).Element)){
					
					MessageBox.Show("Não foi possivel encontrar o objeto na tela","Warning",MessageBoxButtons.OK);
				}
			}
			catch(Exception){
				MessageBox.Show("Selecione um objeto(xpath)","Warning",MessageBoxButtons.OK);
			}
		}
		void BtnClearClick(object sender, System.EventArgs e)
		{
			
			
			lstXPath.Rows.Clear();
		}
		void BtnOkClick(object sender, EventArgs e)
		{
			if(!ReferenceEquals(lstXPath.CurrentRow,null)){
				object field_=lstXPath.CurrentRow.DataBoundItem;
				Util.mainForm.AddStepField((Field)field_);
			}
			this.Close();
			
		}
	}
}
