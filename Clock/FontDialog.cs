using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class FontDialog : Form
    {
        Form parent;
        Dictionary<string, string> fonts;
        //public decimal Value { get { return numericUpDownFontSize.Value; } set { numericUpDownFontSize.Value = value; } }//test 1 
        public PrivateFontCollection pfc { get; private set; }// test 0 & 1
        public string FontFile { get; set; }
        public Font Font { get; private set; }
        public FontDialog(Form parent)
        {
            InitializeComponent();
            this.pfc = null;
            this.fonts = new Dictionary<string, string>();
            this.StartPosition = FormStartPosition.Manual;
            this.parent = parent;
        }
        [DllImport("kernel32.dll")]
        public static extern void AllocConsole();
        [DllImport("kernel32.dll")]
        public static extern bool FreeConsole();
        void LoadFonts()
        {
            // папка каталог или директория это особый тип файла
            // который хранит в себе другие файлы

            // абсолютно в любой файловой системе в любом каталоге
            // есть 2 служебные ссылки 
            Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..\\Fonts");
            //AllocConsole();
            Console.WriteLine(Directory.GetCurrentDirectory());
            Traverse(Directory.GetCurrentDirectory());
            //LoadFonts(Directory.GetCurrentDirectory(), "*.ttf");
            //LoadFonts(Directory.GetCurrentDirectory() + "\\TrueType", "*.ttf");
            //LoadFonts(Directory.GetCurrentDirectory(), "*.otf");
        }
        void LoadFonts(string path , string extension) 
        {
            string[] files = Directory.GetFiles(path , extension);
            for(int i = 0; i < files.Length; i++) 
            {
                if (fonts.ContainsKey(files[i].Split('\\').Last())) continue;
                fonts.Add(files[i].Split('\\').Last(), files[i]);
            }
            comboBoxFonts.Items.AddRange(fonts.Keys.ToArray());
        }
        void Traverse(string path)
        {
            LoadFonts(path, "*.ttf");
            LoadFonts(path, "*.otf");
            string[] directories = Directory.GetDirectories(path);
            for(int i = 0; i < directories.Length; ++i) 
            {
                Traverse(directories[i]);
            }
        }
        private void FontDialog_Load(object sender, EventArgs e)
        {
            this.Location = new Point
                (
                    this.parent.Location.X - this.Width / 2,
                    this.parent.Location.Y + 100
                );
            LoadFonts();
        }
        public void ApplyFontExample(string filename , float size)
        {
            //PrivateFontCollection pfc = new PrivateFontCollection();
            if (pfc != null) pfc.Dispose();
            pfc = new PrivateFontCollection();// test 0 & 1
            pfc.AddFontFile(filename);
            labelExample.Font = new Font(pfc.Families[0], size);
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Font = labelExample.Font;
            this.FontFile = fonts[comboBoxFonts.SelectedItem.ToString()];
        }
        private void comboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFontExample(fonts[comboBoxFonts.SelectedItem.ToString()] , (float)numericUpDownFontSize.Value);   
        }
        private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
        {
            ApplyFontExample(fonts[comboBoxFonts.SelectedItem.ToString()] , (float)numericUpDownFontSize.Value);
        }
    }
}
