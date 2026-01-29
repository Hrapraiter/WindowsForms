using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToString
                (
                "hh:mm:ss tt",
                System.Globalization.CultureInfo.InvariantCulture
                );
            if (checkBoxShowDate.Checked)    labelTime.Text += $"\n{DateTime.Now.ToString("yyyy.MM.dd")}";
            if (checkBoxShowWeekDay.Checked) labelTime.Text += $"\n{DateTime.Now.ToString("ddd")}";

            notifyIcon.Text = labelTime.Text;
            
            
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
        }

        private void labelTime_DoubleClick(object sender, EventArgs e)
        {
            setVisibility(true);
        }
    }
}