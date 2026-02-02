using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
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
            tsmiAutorun.Checked = Registry.GetValue(
                @"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Run",
                "Clock",
                null) == null ? false : true;

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
            
            //FontFamily font = new FontFamily(new Uri(pack://aplication:,,,/fonts/) , "./#Digital-7 Mono);
            //неполучилось потратил не мало нервных клеток и пока без успешно
            
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
        static bool while_end = true; 
        
        private void labelTime_MouseDown(object sender, MouseEventArgs e)
        {
            if (tsmiShowControls.Checked || e.Button != MouseButtons.Left) return;
            Thread thread = new Thread
            (
                (() =>
                {
                    while_end = true;
                    while (while_end)
                    {
                        this.Left = Cursor.Position.X - labelTime.Width / 2;
                        this.Top = Cursor.Position.Y - labelTime.Height / 2;
                    }
                })
            );
            thread.Start();
            
        }

        private void labelTime_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                while_end = false;
        }

        private void tsmiAutorun_CheckedChanged(object sender, EventArgs e)
        {
            const string RegAutorunDirect = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            string value = '\"' + Directory.GetCurrentDirectory() + "\\Clock.exe\"";

            object RegValue = Registry.GetValue
                (
                @"HKEY_CURRENT_USER\"+ RegAutorunDirect,
                "Clock",
                null
                );
            if (RegValue != null)
            {
                if (tsmiAutorun.Checked) return;
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegAutorunDirect, true))
                    if (key != null)
                        key.DeleteValue("Clock");
                
            }
            else if(tsmiAutorun.Checked)
                    Registry.SetValue
                        (
                        @"HKEY_CURRENT_USER\" + RegAutorunDirect,
                        "Clock",
                        value
                        );
            
                
        }
    }
}