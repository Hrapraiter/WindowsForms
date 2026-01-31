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
        FontDialog fontDialog;
        ColorDialog backgroundDialog;
        ColorDialog foregroundDialog;
        public MainForm()
        {
            InitializeComponent();
            this.Location = new Point
                (
                Screen.PrimaryScreen.Bounds.Width - this.Width - 50,
                50
                );

            backgroundDialog = new ColorDialog();
            foregroundDialog = new ColorDialog();
            fontDialog = new FontDialog();
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
        private void buttonHideControls_Click(object sender, EventArgs e)=>tsmiShowControls.Checked = false;
        private void labelTime_DoubleClick(object sender, EventArgs e)=>tsmiShowControls.Checked = true;
        private void tsmiTopmost_CheckedChanged(object sender, EventArgs e) =>this.TopMost = (sender as ToolStripMenuItem).Checked;//this.TopMost = tsmiTopmost.Checked;
        private void tsmiShowControls_CheckedChanged(object sender, EventArgs e) =>setVisibility(tsmiShowControls.Checked);
        private void tsmiExit_Click(object sender, EventArgs e) => Close();

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!this.TopMost) 
            {
                this.TopMost = true;
                this.TopMost = false;
            } 
        }

        private void checkBoxShowDate_CheckedChanged(object sender, EventArgs e) => tsmiShowDate.Checked = (sender as CheckBox).Checked;
        private void checkBoxShowWeekDay_CheckedChanged(object sender, EventArgs e) => tsmiShowWeekday.Checked = (sender as CheckBox).Checked;
        private void tsmiShowDate_CheckedChanged(object sender, EventArgs e) => checkBoxShowDate.Checked = (sender as ToolStripMenuItem).Checked;
        private void tsmiShowWeekday_CheckedChanged(object sender, EventArgs e) => checkBoxShowWeekDay.Checked = (sender as ToolStripMenuItem).Checked;

        private void tsmiBackgroundColor_Click(object sender, EventArgs e)
        {
            DialogResult result = backgroundDialog.ShowDialog();
            if (result == DialogResult.OK)
                labelTime.BackColor = backgroundDialog.Color;
        }

        private void tsmiForegraundColor_Click(object sender, EventArgs e)
        {
            if (foregroundDialog.ShowDialog() == DialogResult.OK)
                labelTime.ForeColor = foregroundDialog.Color;
        }

        private void tsmiFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK)
                labelTime.Font = fontDialog.Font;
        }
    }
}