/*
 * Created by SharpDevelop.
 * User: blopes
 * Date: 22/08/2017
 * Time: 11:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Threading;

namespace SeleniumTest
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	///

	public delegate void DelAddStep(Field F);
	public partial class MainForm : Form
	{
		public List<Case> caso=new List<Case>();
		
		public Form ControlForm;
		
		public MainForm(StartWebDriver StartWebDriver)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//setar o driver
			Util.StartWebDriver=StartWebDriver;
			
			
			//inserir a primeira linha da grid referente ao caso de teste
			
			CriarLinha();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		
		
		public void CriarLinha(){
			
			caso.Add(new Case("","","",""));
			BindingSource bcase = new BindingSource();
			bcase.DataSource=caso;
			dataGridCase.DataSource=bcase;
			//associar os passos aos casos de teste
			BindingSource bsteps = new BindingSource();
			bsteps.DataSource=caso[0].Steps;
			dataGridSteps.DataSource=bsteps;
			
			//	############# NAO TIRA DAQUI PQ O SHARODEVELOP ESTA APAGANDO NO DESIGNER
			this.dataGridSteps.Columns["Order"].DefaultCellStyle.ForeColor = Color.Gray;
			this.dataGridSteps.Columns["PathObject"].DefaultCellStyle.ForeColor = Color.Gray;
			this.dataGridSteps.Columns["Order"].HeaderCell.Style.ForeColor = Color.Gray;
			this.dataGridSteps.Columns["PathObject"].HeaderCell.Style.ForeColor = Color.Gray;
			this.dataGridSteps.EnableHeadersVisualStyles = false;
			this.dataGridSteps.EditingControlShowing +=dataGridStepChanged;
			this.dataGridSteps.RowsAdded+=new DataGridViewRowsAddedEventHandler(DataGridAddCellEvent);
			this.dataGridSteps.UserDeletedRow+=DataGridRemoveCell;
			this.dataGridCase.AllowDrop = true;
			this.dataGridCase.DragDrop+= new DragEventHandler(dataGridCase_DragDrop);
			this.dataGridCase.DragEnter += new DragEventHandler(dataGridCase_DragEnter);
			
		}
		private StartWebDriver StartWebDriverHandle(){
			try{
				if(Util.StartWebDriver.getDriver().WindowHandles.Count>0)
					return Util.StartWebDriver;
				else
					throw new Exception();
			}
			catch(Exception){
				return new StartWebDriver();
			}
		}
		
		
		void dataGridStepChanged(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			if (e.Control is ComboBox){
				ComboBox comboBox = e.Control as ComboBox;
				comboBox.SelectedIndexChanged -= StepChanged;
				comboBox.SelectedIndexChanged += StepChanged;
			}
			
			
		}
		

		
		void StepChanged(object sender, System.EventArgs e){
			
			if(caso.Count>0 && caso[0].Steps.Count>0 && dataGridSteps.Rows.Count>0){
				ComboBox cmbDataGridView =(ComboBox)sender;
				
				var cellEvent=dataGridSteps.CurrentCell;
				
				if (dataGridSteps.Columns[cellEvent.ColumnIndex].Name=="Expected")
					caso[0].Steps[cellEvent.RowIndex].Expected=cmbDataGridView.SelectedItem.ToString();
				else if (dataGridSteps.Columns[cellEvent.ColumnIndex].Name=="Action")
					caso[0].Steps[cellEvent.RowIndex].Action=cmbDataGridView.SelectedItem.ToString();
				
				
			}

		}

		void MapObjectToolStripMenuItemClick(object sender, EventArgs e)
		{
			
			SearchObject sO=new SearchObject(this.StartWebDriverHandle());
			
			sO.ShowDialog(this);
			
		}
		void refreshStepView(){
			
			BindingSource bsteps = new BindingSource();
			bsteps.DataSource=caso[0].Steps;
			dataGridSteps.DataSource=bsteps;
			dataGridSteps.Update();
			dataGridSteps.Refresh();
			//	dataGridSteps.CurrentCell = dataGridSteps.Rows[dataGridSteps.Rows.Count - 1].Cells[1];
			//	dataGridSteps.Rows[dataGridSteps.Rows.Count-1].Selected=true;
			
			var row=dataGridSteps.Rows;
			for(int a=0;a<=dataGridSteps.Rows.Count-2;a++){
				
				
				row[a].Cells["Expected"].Value=caso[0].Steps[a].Expected;
				row[a].Cells["Action"].Value=caso[0].Steps[a].Action;
				caso[0].Steps[row[a].Index].Order=(a+1).ToString();
				row[a].Cells["Order"].Value=a+1;
				
				
				
			}
		}
		
		void refreshCaseView(){
			
			BindingSource bcase = new BindingSource();
			bcase.DataSource=caso[0];
			dataGridCase.DataSource=bcase;
			dataGridCase.Update();
			dataGridCase.Refresh();
			
		}
		
		
		public void DataGridAddCellEvent(object sender, DataGridViewRowsAddedEventArgs e)
		{
			int contagem=caso[0].Steps.Count;
			if(contagem>0){
				
				caso[0].Steps[caso[0].Steps.Count-1].Order=contagem.ToString();
			}
		}
		
		
		public void AddStepField(Field Field_){

			
			
			if (ReferenceEquals(dataGridSteps.CurrentRow,null) || ReferenceEquals(dataGridSteps.CurrentRow.DataBoundItem,null) ){
				
				Step s=new Step();
				s.Field=Field_;
				
				caso[0].Steps.Add(s);
			}
			
			else{
				//StepChanged();
				((Step)(dataGridSteps.CurrentRow.DataBoundItem)).Field=Field_;
			}
			refreshStepView();
			
			
		}
		
		
		void HighLightToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(ReferenceEquals(dataGridSteps.CurrentRow,null) || ReferenceEquals(dataGridSteps.CurrentRow.DataBoundItem,null) )){
				Field elem=((Step)(dataGridSteps.CurrentRow.DataBoundItem)).Field;
				bool achou=Util.StartWebDriver.highLight(elem.Element);
				if(!achou){
					
					MessageBox.Show("Objeto não encontrado","Atenção",MessageBoxButtons.OK);
				}
				
				
			}
			
			
		}
		
		void SalvarToolStripMenuItemClick(object sender, EventArgs e)
		{
			
			
			//cria o xml
			XmlSerializer xsSubmit = new XmlSerializer(typeof(Case));
			var subReq = caso[0];
			var xml = "";
			
			using(var sww = new StringWriter())
			{
				using(XmlWriter writer = XmlWriter.Create(sww))
				{
					xsSubmit.Serialize(writer, subReq);
					xml = sww.ToString(); // Your XML
				}
			}
			
			

			
			string NameFile="unknown";
			if(!(ReferenceEquals(subReq.NameCase,null)||subReq.NameCase.Length==0)){
				//tira os caracteres ilegais
				NameFile=subReq.NameCase;
				string invalid = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
				foreach (char c in invalid)
				{
					NameFile = NameFile.Replace(c.ToString(), "");
				}
				
				
			}
			
			
			//salva o xml
			SaveFileDialog savefile = new SaveFileDialog();
			// set a default file name
			savefile.FileName = NameFile  +".xml";
			// set filters - this can be done in properties as well
			savefile.Filter = "Text files (*.xml)|*.xml|All files (*.*)|*.*";
			
			if (savefile.ShowDialog() == DialogResult.OK)
			{
				using (StreamWriter sw = new StreamWriter(savefile.FileName))
					sw.WriteLine (xml);
				
				MessageBox.Show("Salvo com sucesso!","Information",MessageBoxButtons.OK);
			}
			
			

		}
		
		void OpenToolStripMenuItemClick(object sender, EventArgs e)
		{
			try{
				string xml;
				OpenFileDialog ofd = new OpenFileDialog();
				ofd.Filter = "All Files (*.xml)|*.xml";
				ofd.FilterIndex = 1;
				
				
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					string sFileName = ofd.FileName;
					xml=File.ReadAllText(sFileName);
					
					OpenFile(xml);
					
				}

			}
			catch(Exception){
				
				
				
			}
		}
		
		void OpenFile(string xml){
			
			try{
				XmlSerializer serializer  = new XmlSerializer(typeof(Case));
				
				using (TextReader reader = new StringReader(xml))
				{
					clearCase();
					Case caso_ofd= (Case)serializer.Deserialize(reader);
					
					caso[0]=caso_ofd;
					refreshStepView();
					refreshCaseView();
				}

			}
			catch(Exception){
				
				MessageBox.Show("Corrupted File!","Warning",MessageBoxButtons.OK);
				
			}
			
		}
		
		void NewCaseToolStripMenuItemClick(object sender, EventArgs e)
		{

			DialogResult dialogResult = MessageBox.Show("Would you like to create a new test case?", "Question", MessageBoxButtons.YesNo);
			if(dialogResult == DialogResult.Yes)
			{
				clearCase();
				
			}
			
		}
		void clearCase(){
			
			caso[0]=new Case("","","","");
			refreshStepView();
			refreshCaseView();
		}
		
		void DataGridRemoveCell(object sender, EventArgs e){
			refreshStepView();
		}
		
		
		void ExecutarToolStripMenuItemClick(object sender, EventArgs e)
		{

			if (caso[0].Steps.Count > 0)
			{
				EnableDisabledVisibleFormMain(false);
				caso[0].createRun();
				controlExecution controlfrm = new controlExecution(caso[0].LastRun);
				controlfrm.MdiParent = this;
				controlfrm.Show();
				ControlForm = controlfrm;
				Thread t = new Thread(new ThreadStart(this.executeThread));
				t.Start();

			}
			
		}
		
		
		private  void executeThread(){


			
			caso[0].execute();
			showSumary();
			//chamo um objeto da form para fazer o invoke....gambiarraa purinha
			dataGridCase.Invoke(new Action(() =>EnableDisabledVisibleFormMain(true)));
		}
		
		void dataGridCase_DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
		}

		void dataGridCase_DragDrop(object sender, DragEventArgs e) {
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			OpenFile(File.ReadAllText(files[0].ToString()));
		}
		
		
		void EnableDisabledVisibleFormMain(bool Show){
			
			if(!Show){
				panelMdi.Visible=false;
				panelMdi.Enabled=false;
				/*dataGridSteps.Visible=false;
			    dataGridCase.Visible=false;
			    dataGridSteps.Enabled=false;
			    dataGridCase.Enabled=false;*/
			}
			else{
				panelMdi.Visible=true;
				panelMdi.Enabled=true;
				/*dataGridSteps.Visible=true;
			    dataGridCase.Visible=true;
			    dataGridSteps.Enabled=true;
			    dataGridCase.Enabled=true;*/
			}
			
		}

		private void summaryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			showSumary();
		}

		public void showSumary() {
			try{
				if (!ReferenceEquals(caso[0].LastSumary, null))
				{

					OpenQA.Selenium.IJavaScriptExecutor js = (OpenQA.Selenium.IJavaScriptExecutor)Util.StartWebDriver.getDriver();
					js.ExecuteScript("window.open('file:///" + caso[0].LastSumary.Replace("\\", "/") + "');");
					/// 
					
					Util.StartWebDriver.driver.SwitchTo().Window(Util.StartWebDriver.driver.WindowHandles[Util.StartWebDriver.driver.WindowHandles.Count-1]).Navigate().GoToUrl("file:///" + caso[0].LastSumary.Replace("\\", "/"));
				}
				else {
					MessageBox.Show("Summary is empty...", "Warning", MessageBoxButtons.OK);

				}
			}catch(Exception){
				MessageBox.Show("Try Again!", "Warning", MessageBoxButtons.OK);
			}

		}
		
		void MainFormClose(object sender, EventArgs e)
		{
			Util.StartWebDriver.driver.Quit();
			Program.CloseAll();
			
		}
	}
}
