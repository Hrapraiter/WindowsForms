using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public FontDialog(Form parent)
        {
            InitializeComponent();
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
            AllocConsole();
            Console.WriteLine(Directory.GetCurrentDirectory());
            Traverse(Directory.GetCurrentDirectory());
            //LoadFonts(Directory.GetCurrentDirectory(), "*.ttf");
            //LoadFonts(Directory.GetCurrentDirectory() + "\\TrueType", "*.ttf");
            //LoadFonts(Directory.GetCurrentDirectory(), "*.otf");
        }
        void LoadFonts(string path , string extension) 
        {
            
            string[] files = Directory.GetFiles(path , extension);
            files = files.Select(str => str.Split('\\').Last()).ToArray();
            comboBoxFonts.Items.AddRange(files);

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
    }
}
