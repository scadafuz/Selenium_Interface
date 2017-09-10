/*
 * Created by SharpDevelop.
 * User: blopes
 * Date: 31/08/2017
 * Time: 08:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace SeleniumTest
{
	partial class SearchObject
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
			this.btnSearch = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.lstXPath = new System.Windows.Forms.DataGridView();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnHighlight = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.lstXPath)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(12, 23);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(59, 32);
			this.btnSearch.TabIndex = 0;
			this.btnSearch.Text = "Map";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.BtnSearchClick);
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(77, 23);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(57, 32);
			this.btnStop.TabIndex = 1;
			this.btnStop.Text = "GetMap";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.BtnStopClick);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(162, 177);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(57, 32);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.BtnOkClick);
			// 
			// lstXPath
			// 
			this.lstXPath.AllowUserToAddRows = false;
			this.lstXPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.lstXPath.Location = new System.Drawing.Point(12, 61);
			this.lstXPath.MultiSelect = false;
			this.lstXPath.Name = "lstXPath";
			this.lstXPath.Size = new System.Drawing.Size(354, 110);
			this.lstXPath.TabIndex = 4;
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(140, 23);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(57, 32);
			this.btnClear.TabIndex = 5;
			this.btnClear.Text = "Clear";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
			// 
			// btnHighlight
			// 
			this.btnHighlight.Location = new System.Drawing.Point(203, 23);
			this.btnHighlight.Name = "btnHighlight";
			this.btnHighlight.Size = new System.Drawing.Size(57, 32);
			this.btnHighlight.TabIndex = 6;
			this.btnHighlight.Text = "Highlight";
			this.btnHighlight.UseVisualStyleBackColor = true;
			this.btnHighlight.Click += new System.EventHandler(this.BtnHighlightClick);
			// 
			// SearchObject
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(378, 214);
			this.Controls.Add(this.btnHighlight);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.lstXPath);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnSearch);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "SearchObject";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Search Objects";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchObjectClosing);
			((System.ComponentModel.ISupportInitialize)(this.lstXPath)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btnHighlight;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.DataGridView lstXPath;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button btnSearch;
		
	
		
		
	}
}
