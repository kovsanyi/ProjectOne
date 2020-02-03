using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileStarter
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        string _fileName;
        public MainPage()
        {
            InitializeComponent();
            init();
        }

        void init()
        {
            _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");
            if (File.Exists(_fileName))
                editor.Text = File.ReadAllText(_fileName);
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, editor.Text);
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
                File.Delete(_fileName);
            editor.Text = string.Empty;
        }

        void OnLoadFormButtonClicked(object sender, EventArgs e)
        {
            var msDll = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(x => x.CodeBase.EndsWith("MobileStarter.dll"));
            var uiDllName = msDll.GetManifestResourceNames().FirstOrDefault(x => x.EndsWith("FwUI.dll"));
            byte[] uiDllBytes;
            using (var stream = msDll.GetManifestResourceStream(uiDllName))
            {
                uiDllBytes = new byte[stream.Length];
                stream.Read(uiDllBytes, 0, uiDllBytes.Length);
            }
            var assembly = Assembly.Load(uiDllBytes);
            var main = assembly.GetType("FwUI.PoUIBase", true, false);
            var method = main.GetMethods(BindingFlags.Public | BindingFlags.Static).FirstOrDefault();
            var res = method.Invoke(null, null);
        }
    }
}
