using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class DailyPaln : Form
    {
        public DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private PlanData job;

        public PlanData Job
        {
            get { return job; }
            set { job = value; }
        }


        FlowLayoutPanel fPanel = new FlowLayoutPanel();
        public DailyPaln(DateTime date, PlanData job)
        {
            InitializeComponent();

            this.Date = date;
            this.Job = job;

            
            fPanel.Width = pnlJob.Width;
            fPanel.Height = pnlJob.Height;

            pnlJob.Controls.Add(fPanel);

            dtpkDate.Value = Date;

        }

        public DailyPaln()
        {
        }

        void ShowJobByDate(DateTime date)
        {
            fPanel.Controls.Clear();
            if (Job != null && Job.Job != null)
            {
                List<PlanItem> todayJob = GetJobByDay(date);
                for (int i = 0; i < GetJobByDay(date).Count; i++)
                {
                    AddJob(todayJob[i]);

                }
            }
        }

        void AddJob(PlanItem job)
        {
            AJob aJob = new AJob(job);
            aJob.Edited += aJob_Edited;
            aJob.Deleted += aJob_Deleted;
            fPanel.Controls.Add(aJob);
        }

        private void aJob_Deleted(object sender, EventArgs e)
        {
            AJob uc = sender as AJob;
            PlanItem job = uc.Job;

            fPanel.Controls.Remove(uc);
            Job.Job.Remove(job);
        }

        private void aJob_Edited(object sender, EventArgs e)
        {
            
        }

        List<PlanItem> GetJobByDay(DateTime date)
        {
            return Job.Job.Where(p => p.Date.Year == date.Year && p.Date.Month == date.Month && p.Date.Day == date.Day).ToList();
        }

        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            ShowJobByDate((sender as DateTimePicker).Value);
        }

        private void btnBeforeDay_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(-1);
        }

        private void btnNextDay_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddDays(1);
        }

        private void mnstAdd_Click(object sender, EventArgs e)
        {
            PlanItem item = new PlanItem() { Date = dtpkDate.Value};
            Job.Job.Add(item);
            AddJob(item);

        }

        private void mnstToday_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = DateTime.Now;

        }

        private void DailyPaln_Load(object sender, EventArgs e)
        {

        }
    }
}
