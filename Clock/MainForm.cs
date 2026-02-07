using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;      //Input/Output
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Drawing.Text;
using System.Data.SqlTypes;

namespace Clock
{
    public partial class MainForm : Form
    {
        //PrivateFontCollection pfc_label = new PrivateFontCollection(); // test 0

        FontDialog fontDialog;
        ColorDialog backgroundDialog;
        ColorDialog foregroundDialog;
        [DllImport("kernel32.dll")]
        private static extern void AllocConsole();
        public MainForm()
        {
            InitializeComponent();
            this.Location = new Point
                (
                Screen.PrimaryScreen.Bounds.Width - this.Width - 50,
                50
                );
            fontDialog = new FontDialog(this);
            backgroundDialog = new ColorDialog();
            foregroundDialog = new ColorDialog();
            LoadSettings();
            
        }
        void SaveSettings() 
        {
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..");
            string filename = "Settings.ini";
            StreamWriter writer = new StreamWriter(filename);

            writer.WriteLine($"{this.Location.X}x{this.Location.Y}");
            writer.WriteLine(tsmiTopmost.Checked);
            writer.WriteLine(tsmiShowControls.Checked);
            writer.WriteLine(tsmiShowDate.Checked);
            writer.WriteLine(tsmiShowWeekday.Checked);
            writer.WriteLine(tsmiAutorun.Checked);
            writer.WriteLine(labelTime.BackColor.ToArgb());
            writer.WriteLine(labelTime.ForeColor.ToArgb());
            writer.WriteLine(fontDialog.FontFile);
            writer.WriteLine(fontDialog.FontSize);
            

            writer.Close();

            Process.Start("notepad", filename);
        }
        void LoadSettings() 
        {
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..");
            string filename = "Settings.ini";
            try
            {
                StreamReader reader = new StreamReader(filename);
                string[] pos_values = reader.ReadLine().Split('x');
                this.Location = new Point(int.Parse(pos_values.First()), int.Parse(pos_values.Last()));

                tsmiTopmost.Checked         = bool.Parse(reader.ReadLine());
                tsmiShowControls.Checked    = bool.Parse(reader.ReadLine());
                tsmiShowDate.Checked        = bool.Parse(reader.ReadLine());
                tsmiShowWeekday.Checked     = bool.Parse(reader.ReadLine());
                tsmiAutorun.Checked         = bool.Parse(reader.ReadLine());
                labelTime.BackColor         = backgroundDialog.Color = Color.FromArgb(int.Parse(reader.ReadLine()));
                labelTime.ForeColor         = foregroundDialog.Color = Color.FromArgb(int.Parse(reader.ReadLine()));
                fontDialog.FontFile         = reader.ReadLine();

                if (!string.IsNullOrWhiteSpace(fontDialog.FontFile))
                {
                    fontDialog.SelectItem_form_fonts(fontDialog.FontFile.Split('\\').Last());
                    fontDialog.FontSize = float.Parse(reader.ReadLine());
                    fontDialog.ApplyFontExample(fontDialog.FontFile);
                    labelTime.Font = fontDialog.Font;
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(this , ex.Message);
            }
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
            backgroundBox.Visible = visible;
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
            {
                labelTime.Font = fontDialog.Font;
                //{
                //  this.pfc_label = fontDialog.pfc;
                //  labelTime.Font = fontDialog.Font;
                //
                //} test 0
                // при закрытии окна fontDialog он не обнуляется
                // после чего fontDialog подхватывается заного и т.к. Font это параметр шрифта на всём окне то и его
                // Width и Height автоматчески меняется как auto scalling ( Звучит абсурдно но простестированно )

                //labelTime.Font = new Font(fontDialog.pfc.Families[0], (float)fontDialog.Value); // test 1
                // уже лучше Font напрямую создаётся в объекте labelTime из копий переменных fontDialog

                
            }
        }

        private void tsmiAutorun_CheckedChanged(object sender, EventArgs e)
        {
            string key_name = "Clock_PV_522";
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            
            if (tsmiAutorun.Checked) key.SetValue(key_name, Application.ExecutablePath);
            else key.DeleteValue(key_name, false);
            
            key.Dispose();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }
        static bool isPressedLabel = false;
        private void labelTime_MouseMove(object sender, MouseEventArgs e)
        {
            
             if(isPressedLabel && !tsmiShowControls.Checked)
                this.Location = new Point
                    (Cursor.Position.X - this.labelTime.Width/2 ,
                    Cursor.Position.Y - this.labelTime.Height/2);
            
        }

        private void labelTime_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isPressedLabel = true;
        }

        private void labelTime_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                isPressedLabel = false;
        }
    }
}