using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           

        }

        public string Vertauschen(String hs)
        {

            int LL = hs.Length;
            string svert = "";
            while (hs.Length >0)
            {
                Random r1 = new Random();
                int index1 = r1.Next(hs.Length);
                if (index1 == 0 && svert.Length <1)
                    continue;
                svert += hs[index1];
                hs = hs.Remove(index1, 1);
            }
               
            return svert;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ErstelleleVertauschteListe();
            
        }

        private void ErstelleleVertauschteListe()
        {
            String UmFileName, hs;
            List<string> Umwortliste;
            int Zae = 0;

            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                UmFileName = fileDialog.FileName;

                Umwortliste = new List<String>();

                if (File.Exists(UmFileName))
                {
                    using (StreamReader sr = File.OpenText(UmFileName))
                    {
                        while (sr.Peek() >= 0)
                        {
                            Umwortliste.Add(sr.ReadLine());
                        }
                    }
                    string fn1 = "c:\\C#\\VertauschteWorte.txt";
                    String fn2 = "c:\\C#\\VertauschteLösung.txt";
                    File.Delete(fn1);
                    File.Delete(fn2);
                    using (StreamWriter sw = File.CreateText(fn1))
                    {
                        for (int ii = 0; ii < Umwortliste.Count; ii++)
                        {
                            hs = Umwortliste[ii];                           
                            hs = Vertauschen(hs);
                            hs = hs.ToUpper();
                            Zae++;
                            hs=Zae.ToString() + ".     " + hs + "\n";
                            sw.WriteLine(hs);
                        }
                    }
                    Zae = 0;
                    using (StreamWriter sw1 = File.CreateText(fn2))
                    {
                        for (int ii = 0; ii < Umwortliste.Count; ii++)
                        {
                            hs = Umwortliste[ii];
                            hs = hs.ToUpper();
                            Zae++;
                            hs = Zae.ToString() + ".     " + hs;
                            sw1.WriteLine(hs);
                        }
                    }
                }
            }


        }

        public void ZweitesWortOhenUmlaute6bis13()
        { 
            /*   var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                Datei.Text = fileDialog.FileName;
                Ausgabe.Text = File.ReadAllText(Datei.Text);
            }
            */
            String UmFileName, hs,fnNeu;
            List<string> Umwortliste;

            var fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)               
            {
                UmFileName = fileDialog.FileName;
                fnNeu = "C:\\C#\\worte\\test\\M1_x.txt";
                Umwortliste = new List<String>();

                if (File.Exists(UmFileName))
                {
                    using (StreamReader sr = File.OpenText(UmFileName))
                    {
                        while (sr.Peek() >= 0)
                        {
                            Umwortliste.Add(sr.ReadLine());
                        }
                    }
                    File.Delete(fnNeu);

                    using (StreamWriter sw = File.CreateText(fnNeu))
                    {
                        for (int ii = 1; ii < Umwortliste.Count + 1; ii++)
                        {
                            hs =Umwortliste[ii - 1];
                            int pos1 = hs.IndexOf("\t");
                            if (pos1 < 1)
                                continue;
                            hs = hs.Substring(pos1+1);
                            hs = hs.TrimStart();
                            pos1 = hs.IndexOf("\t");
                            if (pos1 < 1)
                                continue;
                            hs = hs.Substring(0, pos1);
                            if (hs.Length < 6 || hs.Length > 6)
                                continue;
                            if (hs.IndexOf("ä")>-1|| hs.IndexOf("ö") > -1|| hs.IndexOf("ü") > -1||
                                hs.IndexOf("Ä") > -1 || hs.IndexOf("Ö") > -1 || hs.IndexOf("Ü") > -1)
                                continue;
                            if (hs.IndexOf(".") > -1 || hs.IndexOf("'") > -1 || hs.IndexOf("-") > -1 ||
                                hs.IndexOf(" ") > -1 || hs.IndexOf("ß") > -1 || hs.IndexOf("Ü") > -1)
                                continue;
                           
                            if (!Char.IsUpper(hs[0]))
                                continue;
                            sw.WriteLine(hs);
                        }
                    }
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ZweitesWortOhenUmlaute6bis13();
        }
    }
}
