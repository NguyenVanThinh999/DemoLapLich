using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Calendar
{
    public partial class Calendar : Form
    {
        #region properties

        private List<List<Button>> matrix;

        public List<List<Button>> Matrix
        {
            get { return matrix; }
            set { matrix = value; }
        }

        private List<string> dateOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        private PlanData job;
        public PlanData Job
        {
            get { return job; }
            set { job = value; }
        }

        private PlanItem ajob;

        public PlanItem Ajob
        {
            get { return ajob; }
            set { ajob = value; }
        }

        private int appTime;
        public int AppTime
        {
            get { return appTime; }
            set { appTime = value; }
        }

        public string filePath = "data.xml";

        #endregion
        
        public Calendar()
        {
            InitializeComponent();
           
            tmNotify.Start();
            appTime = 0;
            LoadMatrix();

            try 
            {
                Job = DeserializeFromXML(filePath) as PlanData;
            }
            catch 
            { 
                SetDefaultJob();
            }
            
        }

        void SetDefaultJob()
        {
            /*Job = new PlanData();
            Job.Job = new List<PlanItem>();*/
            
        }

        void LoadMatrix()
        {
            Matrix = new List<List<Button>>();

            Button oldbtn = new Button()
                { Width = 63, Height = 40, Location = new Point(-40,0) };

            for(int i=0; i<6; i++)
            {
                Matrix.Add(new List<Button>());

                for(int j=0; j<7; j++)
                {
                    Button btn = new Button()
                    { Width = 63, Height = 40 };
                    btn.Location = new Point(oldbtn.Location.X + oldbtn.Width + 6, oldbtn.Location.Y);

                    pnlMatrix.Controls.Add(btn);
                    btn.Click += btn_Click;

                    Matrix[i].Add(btn);
                    oldbtn = btn;

                }
                oldbtn = new Button()
                { Width = 63, Height = 40, Location = new Point(-40, oldbtn.Location.Y + 40 + 7) };
            }
            SetDefaultDate();
        }

        public void btn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((sender as Button).Text))
                return;
            DailyPaln daily = new DailyPaln(new DateTime(dtpkDate.Value.Year, dtpkDate.Value.Month, Convert.ToInt32((sender as Button).Text)), Job);
            daily.ShowDialog();
        }

        int DayOfMonth(DateTime date)
        {
            switch(date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
               
                case 2:
                    if (date.Year % 4 == 0 && date.Year % 100 == 0 || date.Year % 400 == 0)
                        return 29;
                    else 
                        return 28;

                default:
                    return 30;
            }
        }
        void SetDefaultDate()
        {
            dtpkDate.Value = DateTime.Now;
        }

        bool isEqualdate(DateTime dateA, DateTime DateB)
        {
            return dateA.Year == DateB.Year && dateA.Month == DateB.Month && dateA.Day == DateB.Day;
        }

        List<PlanItem> JobByDay(DateTime date)
        {
            return Job.Job.Where(p => p.Date.Year == date.Year && p.Date.Month == date.Month && p.Date.Day == date.Day).ToList();
        }

        void AddNumberIntoMatrixByDate( DateTime date)
        {
            ClearMatrix();
            DateTime useDate = new DateTime(date.Year, date.Month, 1);
            
            int line = 0;

            for(int i=1; i <= DayOfMonth(useDate); i++)
            {
                int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
                Button btn = Matrix[line][column];
                btn.Text = i.ToString();

                if(isEqualdate(useDate, DateTime.Now))
                {
                    btn.BackColor = Color.Yellow;
                }

                if (isEqualdate(useDate, date))
                {
                    btn.BackColor = Color.Aqua;
                }

                if (column >= 6)
                    line++;

                useDate = useDate.AddDays(1);
            }
        }

        void ClearMatrix()
        {
            for(int i=0; i<Matrix.Count; i++)
            {
                for(int j=0; j<Matrix[i].Count; j++)
                {
                    Button btn = Matrix[i][j];
                    btn.Text = "";
                    btn.BackColor = Color.White;
                }
            }
        }

        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            AddNumberIntoMatrixByDate((sender as DateTimePicker).Value);
        }

        private void Today_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = DateTime.Now;
            //SetDefaultDate();
        }

        private void BtBefore_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(-1);
        }

        private void BtNext_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(1);
        }

        

        public void SerializeToXML(object data, string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            XmlSerializer sr = new XmlSerializer(typeof(PlanData));

            sr.Serialize(fs, data);
            fs.Close();
        }

        private object DeserializeFromXML(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            
            try
            {
                XmlSerializer sr = new XmlSerializer(typeof(PlanData));
                object result = sr.Deserialize(fs);
                fs.Close();
                return result;
            }
            catch //(Exception ex)
            {
                fs.Close();
                throw new NotImplementedException();
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SerializeToXML(Job, filePath);
        }

        public void tmNotify_Tick(object sender, EventArgs e, NotifyIcon notifyIcon)
        {

            AppTime++;
            if (!checkBoxNotify.Checked)
                 return;


             if(AppTime < Cons.notifyTime)
             {
                 return;
             }

             if (Job == null || Job.Job == null)
             {
                 return;
             }

             DateTime currentDate = DateTime.Now;
             List<PlanItem> todayJobs = Job.Job.Where(p=>p.Date.Year == currentDate.Year && p.Date.Month == currentDate.Month && p.Date.Day == currentDate.Day ).ToList();
             Notify.ShowBalloonTip(Cons.notifyTimeOut, "Lịch công việc", string.Format("Bạn có {0} việc trong ngay hôm nay", todayJobs.Count), ToolTipIcon.Info);

             AppTime = 0; 
            /*
            if (!checkBoxNotify.Checked)
                return;
            AppTime++;
            if (AppTime < Cons.notifyTime)
                return;
            if (Job == null || Job.Job == null || Job.Job.Count == 0)
                return;
            DateTime current = DateTime.Now;
            DateTime tomorrow = DateTime.Now.AddDays(1);
            //MessageBox.Show(current.Minute.ToString());
            if (dtpkDate.Value.Year != current.Year || dtpkDate.Value.Month != current.Month || dtpkDate.Value.Day != current.Day)
                return;
            for (int i = 0; i < Job.Job.Count; i++)
            {
                //if (  current.Hour >= Job.ListJob[i].ToTime.X && current.Minute >= Job.ListJob[i].ToTime.Y)
                if (Job.Job[i].ToTime.X * 3600 + Job.Job[i].ToTime.Y * 60 < current.Hour * 3600 + current.Minute * 60
                    && Job.Job[i].Status != "Done" && Job.Job[i].Date.Year == current.Year
                    && Job.Job[i].Date.Month == current.Month && Job.Job[i].Date.Day == current.Day
                    && Job.Job[i].Job != null)
                {
                    Job.Job[i].Status = "Missed";


                }
            }

            int dem = 0;
            for (int i = 0; i < Job.Job.Count; i++)
            {
                if (Job.Job[i].Status == "Doing")
                {
                    dem++;
                }

            }
            if (dem == 0)
            {
                return;
            }


            /* List<PlanItem> listTodayDone = Job.ListJob.Where
             (p => p.Date.Year == current.Year && p.Date.Month == current.Month
             && p.Date.Day == current.Day && PlanItem.list.IndexOf(p.Status) == (int)ePlanItem.Done).ToList();

             List<PlanItem> listTodayMissed = Job.ListJob.Where
             (p => p.Date.Year == current.Year && p.Date.Month == current.Month
             && p.Date.Day == current.Day && PlanItem.list.IndexOf(p.Status) == (int)ePlanItem.Missed).ToList();

             List<PlanItem> listTomorrow = Job.ListJob.Where
             (p => p.Date.Year == tomorrow.Year && p.Date.Month == tomorrow.Month
             && p.Date.Day == tomorrow.Day).ToList();*/

            //List<PlanItem> listTen = Job.ListJob.Where(p=>p.Date.Year)

            //////////////////////////////////////////////////////////////////////////////////
            //
            /*
            List<PlanItem> listTodayDoing = Job.Job.Where
            (p => p.Date.Year == current.Year && p.Date.Month == current.Month
            && p.Date.Day == current.Day && PlanItem.ListStatus.IndexOf(p.Status) == (int)EPlanItem.Doing
            && p.FromTime.X * 3600 + p.FromTime.Y * 60 <= current.Hour * 3600 + current.Minute * 60
            && p.ToTime.X * 3600 + p.ToTime.Y * 60 >= current.Hour * 3600 + current.Minute * 60).ToList();

            string tam = "";
            for (int i = 0; i < listTodayDoing.Count; i++)
            {
                tam += "- " + listTodayDoing[i].Job + "\n";
            }

            Notify.ShowBalloonTip(Cons.notifyTimeOut, "Lịch công việc",
           string.Format("Bạn đang có {0} công việc cần làm: \n", listTodayDoing.Count) + tam, ToolTipIcon.Info);

            */

            /* notifyIcon1.ShowBalloonTip
             (Cons.timeOut, "Lịch công việc",
             string.Format("Bạn có {0} công việc đang làm, {1} đã hoàn thành," +
             " {2} bỏ lỡ trong ngày hôm nay \n" +
             "Ngày mai bạn có {3} công việc cần làm", 
             listTodayDoing.Count,listTodayDone.Count,listTodayMissed.Count,listTomorrow.Count),
             ToolTipIcon.Info);*/
        }

        public void numNotify_ValueChanged(object sender, EventArgs e)
        {
            Cons.notifyTime = (int)numNotify.Value;
        }

        public void checkBoxNotify_CheckedChanged(object sender, EventArgs e)
        {
            numNotify.Enabled = checkBoxNotify.Checked;
        }

        private void Calender_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            ContextMenuStrip.Show(MousePosition, ToolStripDropDownDirection.AboveRight);
        }

        private void tsmnJob_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            DailyPaln plan = new DailyPaln(dtpkDate.Value, Job);
            plan.Show();

        }

        private void tsmnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            DailyPaln plan = new DailyPaln(dtpkDate.Value, Job);
            plan.Show();
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            DailyPaln plan = new DailyPaln(dtpkDate.Value, Job);
            plan.Show();
        }
        List<PlanItem> JobByMonth(DateTime date)
        {
            return Job.Job.Where(p => p.Date.Year == date.Year && p.Date.Month == date.Month).ToList();
        }
        List<PlanItem> JobByMonthDone(DateTime date)
        {
            return Job.Job.Where(p => p.Date.Year == date.Year && p.Date.Month == date.Month && PlanItem.ListStatus.IndexOf(p.Status) == (int)EPlanItem.Done).ToList();
        }
        List<PlanItem> JobByMonthMissed(DateTime date)
        {
            return Job.Job.Where(p => p.Date.Year == date.Year && p.Date.Month == date.Month && PlanItem.ListStatus.IndexOf(p.Status) == (int)EPlanItem.Missed).ToList();
        }

        private void Calender_Load(object sender, EventArgs e)
        {

        }
    }
}
