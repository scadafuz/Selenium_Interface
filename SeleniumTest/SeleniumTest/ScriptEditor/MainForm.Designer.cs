using System;
using System.Drawing;
using System.Windows.Forms;

/*
 * Created by SharpDevelop.
 * User: blopes
 * Date: 22/08/2017
 * Time: 11:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SeleniumTest
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.contextMenuCase = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salvarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSteps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.highLightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMdi = new System.Windows.Forms.Panel();
            this.dataGridSteps = new System.Windows.Forms.DataGridView();
            this.Action = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Expected = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridCase = new System.Windows.Forms.DataGridView();
            this.summaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuCase.SuspendLayout();
            this.contextMenuSteps.SuspendLayout();
            this.panelMdi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSteps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCase)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuCase
            // 
            this.contextMenuCase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCaseToolStripMenuItem,
            this.openToolStripMenuItem,
            this.salvarToolStripMenuItem,
            this.executarToolStripMenuItem,
            this.summaryToolStripMenuItem});
            this.contextMenuCase.Name = "contextMenuCase";
            this.contextMenuCase.Size = new System.Drawing.Size(153, 136);
            // 
            // newCaseToolStripMenuItem
            // 
            this.newCaseToolStripMenuItem.Name = "newCaseToolStripMenuItem";
            this.newCaseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newCaseToolStripMenuItem.Text = "NewCase";
            this.newCaseToolStripMenuItem.Click += new System.EventHandler(this.NewCaseToolStripMenuItemClick);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // salvarToolStripMenuItem
            // 
            this.salvarToolStripMenuItem.Name = "salvarToolStripMenuItem";
            this.salvarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salvarToolStripMenuItem.Text = "Save";
            this.salvarToolStripMenuItem.Click += new System.EventHandler(this.SalvarToolStripMenuItemClick);
            // 
            // executarToolStripMenuItem
            // 
            this.executarToolStripMenuItem.Name = "executarToolStripMenuItem";
            this.executarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.executarToolStripMenuItem.Text = "Execute";
            this.executarToolStripMenuItem.Click += new System.EventHandler(this.ExecutarToolStripMenuItemClick);
            // 
            // contextMenuSteps
            // 
            this.contextMenuSteps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highLightToolStripMenuItem,
            this.mapObjectToolStripMenuItem});
            this.contextMenuSteps.Name = "contextMenuSteps";
            this.contextMenuSteps.Size = new System.Drawing.Size(150, 48);
            // 
            // highLightToolStripMenuItem
            // 
            this.highLightToolStripMenuItem.Name = "highLightToolStripMenuItem";
            this.highLightToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.highLightToolStripMenuItem.Text = "HighLight";
            this.highLightToolStripMenuItem.Click += new System.EventHandler(this.HighLightToolStripMenuItemClick);
            // 
            // mapObjectToolStripMenuItem
            // 
            this.mapObjectToolStripMenuItem.Name = "mapObjectToolStripMenuItem";
            this.mapObjectToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.mapObjectToolStripMenuItem.Text = "SearchObjects";
            this.mapObjectToolStripMenuItem.Click += new System.EventHandler(this.MapObjectToolStripMenuItemClick);
            // 
            // panelMdi
            // 
            this.panelMdi.Controls.Add(this.dataGridSteps);
            this.panelMdi.Controls.Add(this.dataGridCase);
            this.panelMdi.Location = new System.Drawing.Point(0, 0);
            this.panelMdi.Name = "panelMdi";
            this.panelMdi.Size = new System.Drawing.Size(794, 574);
            this.panelMdi.TabIndex = 2;
            // 
            // dataGridSteps
            // 
            this.dataGridSteps.AllowUserToOrderColumns = true;
            this.dataGridSteps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSteps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Action,
            this.Expected});
            this.dataGridSteps.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridSteps.Location = new System.Drawing.Point(13, 87);
            this.dataGridSteps.Name = "dataGridSteps";
            this.dataGridSteps.RowTemplate.ContextMenuStrip = this.contextMenuSteps;
            this.dataGridSteps.Size = new System.Drawing.Size(769, 466);
            this.dataGridSteps.TabIndex = 3;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Items.AddRange(new object[] {
            "Alert",
            "Auth",
            "CallTestCase",
            "Clear",
            "Click",
            "Check/Uncheck",
            "DoubleClick",
            "MouseOver",
            "Scroll",
            "Select in Drop",
            "SendKey",
            "Set",
            "URL",
            "Verify",
            "Maximize",
            "Wait"});
            this.Action.Name = "Action";
            this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Expected
            // 
            this.Expected.HeaderText = "Expected";
            this.Expected.Items.AddRange(new object[] {
            "Allow",
            "Dont Allow",
            "Show",
            "Hide"});
            this.Expected.Name = "Expected";
            this.Expected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Expected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridCase
            // 
            this.dataGridCase.AllowUserToAddRows = false;
            this.dataGridCase.AllowUserToOrderColumns = true;
            this.dataGridCase.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCase.ContextMenuStrip = this.contextMenuCase;
            this.dataGridCase.Location = new System.Drawing.Point(13, 13);
            this.dataGridCase.Name = "dataGridCase";
            this.dataGridCase.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridCase.Size = new System.Drawing.Size(769, 56);
            this.dataGridCase.TabIndex = 2;
            // 
            // summaryToolStripMenuItem
            // 
            this.summaryToolStripMenuItem.Name = "summaryToolStripMenuItem";
            this.summaryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.summaryToolStripMenuItem.Text = "Summary";
            this.summaryToolStripMenuItem.Click += new System.EventHandler(this.summaryToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 569);
            this.Controls.Add(this.panelMdi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "ScriptCreator";
            this.contextMenuCase.ResumeLayout(false);
            this.contextMenuSteps.ResumeLayout(false);
            this.panelMdi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSteps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCase)).EndInit();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.ToolStripMenuItem newCaseToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mapObjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem highLightToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuSteps;
		private System.Windows.Forms.ToolStripMenuItem salvarToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem executarToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuCase;
		private System.Windows.Forms.DataGridViewComboBoxColumn Expected;
		private System.Windows.Forms.DataGridViewComboBoxColumn Action;
		private System.Windows.Forms.DataGridView dataGridSteps;
		private System.Windows.Forms.DataGridView dataGridCase;
		private System.Windows.Forms.Panel panelMdi;
        private ToolStripMenuItem summaryToolStripMenuItem;
    }
}
