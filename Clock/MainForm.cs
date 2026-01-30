using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Location = new Point
                (
                Screen.PrimaryScreen.Bounds.Width - this.Width - 50,
                50
                );
            // я не уверен что я сделал правильным способом но зато работает как надо
            // BackgroundColor
            tsmiBackgroundColor_MenuHighlight.Click += 
                ((sender, e) => EventBodyBkColor(tsmiBackgroundColor_MenuHighlight, Color.DodgerBlue));
            tsmiBackgroundColor_YellowGreen.Click += 
                ((sender, e) => EventBodyBkColor(tsmiBackgroundColor_YellowGreen, Color.YellowGreen));
            tsmiBackgroundColor_Orange.Click += 
                ((sender, e) => EventBodyBkColor(tsmiBackgroundColor_Orange, Color.Orange));

            // ForegroundColor
            tsmiForegroundColor_ControlText.Click += 
                ((sender, e) => EventBodyForeColor(tsmiForegroundColor_ControlText , Color.Black));
            tsmiForegroundColor_Crimson.Click += 
                ((sender, e) => EventBodyForeColor(tsmiForegroundColor_Crimson, Color.Crimson));
            tsmiForegroundColor_DarkKhaki.Click += 
                ((sender, e) => EventBodyForeColor(tsmiForegroundColor_DarkKhaki, Color.DarkKhaki));
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString
                (
                "hh:mm:ss tt",
                System.Globalization.CultureInfo.InvariantCulture
                );

            if (checkBoxShowDate.Checked) labelTime.Text += $"\n{DateTime.Now.ToString("yyyy.MM.dd")}";
            if (checkBoxShowWeekDay.Checked) labelTime.Text += $"\n{DateTime.Now.ToString("ddd")}";

            notifyIcon.Text = labelTime.Text;

            
            this.TopMost = tsmiTopmost.Checked;
            setVisibility(tsmiShowControls.Checked); // не уверен что хорошее решение

            checkBoxShowDate.Checked = tsmiShowDate.Checked;
            checkBoxShowWeekDay.Checked = tsmiShowWeekday.Checked;

            if (tsmiExit.Checked) Close();
        }
        private void EventBodyBkColor(ToolStripMenuItem item , Color color) 
        {
            tsmiBackgroundColor_MenuHighlight.Checked = false;
            tsmiBackgroundColor_YellowGreen.Checked = false;
            tsmiBackgroundColor_Orange.Checked = false;

            this.labelTime.BackColor = color;
            item.Checked = true;
        }
        private void EventBodyForeColor(ToolStripMenuItem item , Color color) 
        {
            tsmiForegroundColor_ControlText.Checked = false;
            tsmiForegroundColor_Crimson.Checked = false;
            tsmiForegroundColor_DarkKhaki.Checked = false;

            this.labelTime.ForeColor = color;
            item.Checked = true;
        }
        void setVisibility(bool visible)
        {
            checkBoxShowDate.Visible = visible;               // Делает 'checkBoxShowDate невидимим
            checkBoxShowWeekDay.Visible = visible;            // Делает 'checkBoxShowWeekday' невидимым
            buttonHideControls.Visible = visible;             // Делаем кнопку 'buttonHideControls' невидимой
            this.ShowInTaskbar = visible;                    // Скрываем кнопку приложения в панели задач
            this.FormBorderStyle = visible ? FormBorderStyle.FixedToolWindow : FormBorderStyle.None;    // Полностью убираем границы окна.
            this.TransparencyKey = visible ? Color.Empty : this.BackColor;          // Делаем окно прозначным.
            // Для того чтобы сделать окно прозрачным, его TransperencyKey должен совпадать с BackColor.
        }
        
        private void buttonHideControls_Click(object sender, EventArgs e)
        {
            setVisibility(false);
            tsmiShowControls.Checked = false;
        }

        private void labelTime_DoubleClick(object sender, EventArgs e)
        {
            setVisibility(true);
            tsmiShowControls.Checked = true;
        }

        private void checkBoxShowDate_CheckedChanged(object sender, EventArgs e)
        {
            tsmiShowDate.Checked = checkBoxShowDate.Checked;
        }

        private void checkBoxShowWeekDay_CheckedChanged(object sender, EventArgs e)
        {
            tsmiShowWeekday.Checked = checkBoxShowWeekDay.Checked;
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            tsmiTopmost.Checked = true;
        }
    }
}