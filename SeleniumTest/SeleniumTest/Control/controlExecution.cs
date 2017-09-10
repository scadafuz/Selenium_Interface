/*
 * Created by SharpDevelop.
 * User: bruno
 * Date: 08/09/2017
 * Time: 19:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;
using System.Windows.Forms;

namespace SeleniumTest
{
    /// <summary>
    /// Description of controlExecution.
    /// </summary>
    /// 
    //	public delegate void barDelegate(int valueBar);
    public partial class controlExecution : Form
    {
        private Run run;
        public controlExecution(Run run)
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            this.run = run;
            Thread tm = new Thread(() => MonitorCase(run));
            tm.Start();
            lblInfo.BackColor = System.Drawing.Color.Transparent;
            
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        public void barUpdate(int valueBar)
        {

            if ((this.pgBar.InvokeRequired))
            {
                this.pgBar.Invoke(new Action(() => barUpdate(valueBar)));
            }
            else
            {
                
                this.pgBar.Value = valueBar;
                lblInfo.Text = run.statusExecution;
                this.pgBar.Refresh();
            }

        }
        private void MonitorCase(Run run)
        {
            int barValue = 0;
      

            while (true)
            {
                
                if (!ReferenceEquals(run, null)){
                    barValue = Convert.ToInt32(Math.Round((run.actualStepCont + 1) * ((100.0 / run.totalStep))));

                    
                    barUpdate(barValue);
                    if (run.stopExecution == true)
                    {
                        barUpdate(100);
                        break;
                    }
                }
                Thread.Sleep(1000);

            }
        }
        void BtnStopClick(object sender, EventArgs e)
        {
            lock (run)
            {
                run.stopExecution = true;
            }
        }
        void BtnPlayPauseClick(object sender, EventArgs e)
        {
            lock (run)
            {
                if (run.pauseExecution)
                    run.pauseExecution = false;
                else
                    run.pauseExecution = true;

            }
        }




    }
}
