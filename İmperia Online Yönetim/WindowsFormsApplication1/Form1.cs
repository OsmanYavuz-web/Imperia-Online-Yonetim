using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Form1_Kodları
        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey regkey = (RegistryKey)Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            regkey.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToString() + ".exe", 9999, RegistryValueKind.DWord);
        }
        #endregion
        #region SİTE URL ADRESİ
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            textBox3.Text = webBrowser1.Url.ToString();
            Site_Kaynak_Kodları();
        }
        #endregion
        #region GİRİŞ - ÇIKIŞ KODLARI

        private void Giriş_Kodları() 
        
        {
            try
            {
                webBrowser1.Document.GetElementById("login-user").SetAttribute("value", textBox1.Text);
                webBrowser1.Document.GetElementById("login-pass").SetAttribute("value", textBox2.Text);
                webBrowser1.Document.GetElementById("image-submit").InvokeMember("click");
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Giriş_Kodları();
        }
        
        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Giriş_Kodları();
        }

        private void Çıkış_Kodları()
        {
            textBox40 .Text = textBox3.Text.ToString();
            textBox40.Text = textBox40.Text.Replace("village.php", "");
            
            webBrowser1.Navigate(textBox40.Text + "close.php?logout=1");
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
            groupBox5.Enabled = false;
        }

        private void yeniBağlantıAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Çıkış_Kodları();
        } 

        private void yeniBağlantıAçToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Çıkış_Kodları();

        }
        #endregion
        #region GİRİŞ DURUMU
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Contains("Giriş") == true)
            {
                label13.Text = "Durum: Çıkış Yapıldı.";
                label3.ForeColor = Color.DarkBlue;
                groupBox1.Enabled = true;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;

            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox2.Text.Contains("Nüfus") == true)
            {
                label3.Text = "Durum : Giriş yapıldı.";
                label3.ForeColor = Color.Green;
                groupBox1.Enabled = false;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;
                groupBox5.Enabled = true;
            }
            else
            {
                label3.Text = "Durum : Giriş başarısız.";
                label3.ForeColor = Color.DarkRed;
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Text = "";
                richTextBox2.Text = "";
                richTextBox2.Text = webBrowser1.Document.Body.InnerHtml.ToString();
                if (label3.Text.Contains("Durum : Giriş yapıldı.") == true)
                {
                    richTextBox1.Text = webBrowser1.Document.Body.InnerHtml.ToString();
                    timer1.Enabled = false;
                    timer2.Enabled = true;
                }

            }
            catch { }
        }

        #endregion
        #region SİTE KAYNAK KODLARI
        private void Site_Kaynak_Kodları()
        {
            timer1.Enabled = true;
        }
        #endregion
        #region DENEME PANELİ
        private void button2_Click(object sender, EventArgs e)
        {
            HtmlElementCollection col = webBrowser1.Document.GetElementsByTagName(textBox7.Text.ToString());// 1 İlk Parametre
            foreach (HtmlElement doc in col)
            {
                string x = doc.GetAttribute(textBox8.Text.ToString());// 2 Parametre işlevi
                if (x == textBox4.Text.ToString())// 3 Komut
                {
                    doc.InvokeMember(textBox9.Text.ToString()); // 4 Eylem
                }

            }

            string gelen = richTextBox1.Text; //6
            int titleIndexBaslangici = gelen.IndexOf(textBox5.Text) + textBox5.TextLength; //7
            int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf(textBox6.Text); //8
            label6.Text = "Çıktı : " + gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9
            
                
        }
        #endregion
        #region PROFİL KODLARI
        private void Profile_Tikla()
        {
            try
            {
                HtmlElementCollection col = webBrowser1.Document.GetElementsByTagName("a");// 1 İlk Parametre
                foreach (HtmlElement doc in col)
                {
                    string x = doc.GetAttribute("href");// 2 Parametre işlevi
                    if (x == "javascript:void(xajax_viewGameProfiles(container.open({saveName: 'profiles', title: 'Profil'}), { tab: 1 }));")// 3 Komut
                    {
                        doc.InvokeMember("click"); // 4 Eylem
                    }

                }
                Site_Kaynak_Kodları();
            }
            catch { }
        }

        private void Kullanici_Adi ()
        {
            try
            {
                string gelen = richTextBox1.Text; //6
                int titleIndexBaslangici = gelen.IndexOf(textBox18 .Text ) + textBox18 .TextLength  ; //7
                int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf("</DIV>"); //8
                textBox10.Text = gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9
            }
            catch { }
        }

        private void Diyar() 
        {
            try
            {
                string gelen = richTextBox1.Text; //6
                int titleIndexBaslangici = gelen.IndexOf(textBox19.Text) + textBox19.TextLength; //7
                int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf("</DIV>"); //8
                textBox11.Text = gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9
            }
            catch { }
        }

        private void Puan()
        {
            try
            {
                string gelen = richTextBox1.Text; //6
                int titleIndexBaslangici = gelen.IndexOf(textBox20.Text) + textBox20.TextLength; //7
                int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf("</TD></TR>"); //8
                textBox12.Text = gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9
                textBox12.Text = textBox12.Text.Replace("&nbsp;", "");
            }
            catch { }
        }

        private void Sıralama()
        {
            try
            {
                string gelen = richTextBox1.Text; //6
                int titleIndexBaslangici = gelen.IndexOf(textBox21.Text) + textBox21.TextLength; //7
                int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf("</TD></TR>"); //8
                textBox13.Text = gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9
                textBox13.Text = textBox13.Text.Replace("&nbsp;", "");
            }
            catch { }
        }

        private void Onur()
        {
            try
            {
                string gelen = richTextBox1.Text; //6
                int titleIndexBaslangici = gelen.IndexOf(textBox22.Text) + textBox22.TextLength; //7
                int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf("</TD></TR>"); //8
                textBox14.Text = gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9
            }
            catch { }
        }

        private void İttifak()
        {
            try
            {
                string gelen = richTextBox1.Text; //6
                int titleIndexBaslangici = gelen.IndexOf(textBox23.Text) + textBox23.TextLength; //7
                int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf(" </A></DIV>"); //8
                textBox15.Text = gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9
            }
            catch { }
        }

        private void AskeriPuan()
        {
            try
            {
                string gelen = richTextBox1.Text; //6
                int titleIndexBaslangici = gelen.IndexOf(textBox24.Text) + textBox24.TextLength; //7
                int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf("</TD></TR>"); //8
                textBox16.Text = gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9
                textBox16.Text = textBox16.Text.Replace("<TD class=num>", "");
                textBox16.Text = textBox16.Text.Replace("&nbsp;", "");
                textBox16 .Text = textBox16 .Text .Replace (" ","");
                textBox16.Text = textBox16.Text.Remove(0,1);
            }
            catch { }
        }

        private void Rütbe()
        {
            try
            {
                string gelen = richTextBox1.Text; //6
                int titleIndexBaslangici = gelen.IndexOf(textBox25.Text) + textBox25.TextLength; //7
                int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf("</TD></TR>"); //8
                textBox17.Text = gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9
                textBox17.Text = textBox17.Text.Replace("<TD class=num>", "");
                textBox17.Text = textBox17.Text.Remove(0, 1);
            }
            catch { }
        }
        #endregion
        #region KAYNAK KODLARI
        private void TümEyaletKaynakları_Tıkla() 
        {

            HtmlElementCollection col = webBrowser1.Document.GetElementsByTagName("a");// 1 İlk Parametre
            foreach (HtmlElement doc in col)
            {
                string x = doc.GetAttribute("href");// 2 Parametre işlevi
                if (x == "javascript:void(xajax_viewResourcesInfo(container.open({saveName:'show_res_info', title:'Kaynaklar hakkında bilgi'})))")// 3 Komut
                {
                    doc.InvokeMember("click"); // 4 Eylem
                }

            }
            Site_Kaynak_Kodları();
        }
        private void Mutluluk() 
        {
            try
            {
                string gelen = richTextBox1.Text; //6
                int titleIndexBaslangici = gelen.IndexOf(textBox33.Text) + textBox33.TextLength; //7
                int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf("<SPAN class="); //8
                textBox26.Text = gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9

            }
            catch { }
        }
        private void Nüfus() 
        {
            try
            {
                string gelen = richTextBox1.Text; //6
                int titleIndexBaslangici = gelen.IndexOf(textBox34.Text) + textBox34.TextLength; //7
                int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf("</TD></TR>"); //8
                textBox27.Text = gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9
                textBox27.Text = textBox27.Text.Replace("&nbsp;", "");
            }
            catch { }
        
        }
        private void Odun() 
        {
            try
            {
                string gelen = richTextBox1.Text; //6
                int titleIndexBaslangici = gelen.IndexOf(textBox35.Text) + textBox35.TextLength; //7
                int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf("</TD></TR>"); //8
                textBox28.Text = gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9
                textBox28.Text = textBox28.Text.Replace("&nbsp;", "");
                textBox28.Text = textBox28.Text.Replace ("<TD style=\"WIDTH: 20%\" class=numeral>","");
                textBox28.Text = textBox28.Text.Remove(0, 1);
            }
            catch { }
        }
        private void Demir() 
        {

            try
            {
                string gelen = richTextBox1.Text; //6
                int titleIndexBaslangici = gelen.IndexOf(textBox36.Text) + textBox36.TextLength; //7
                int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf("</TD></TR>"); //8
                textBox29.Text = gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9
                textBox29.Text = textBox29.Text.Replace("&nbsp;", "");
                textBox29.Text = textBox29.Text.Replace("<TD style=\"WIDTH: 20%\" class=numeral>", "");
                textBox29.Text = textBox29.Text.Remove(0, 1);
            }
            catch { }

        }
        private void Taş()
        {

            try
            {
                string gelen = richTextBox1.Text; //6
                int titleIndexBaslangici = gelen.IndexOf(textBox37.Text) + textBox37.TextLength; //7
                int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf("</TD></TR>"); //8
                textBox30.Text = gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9
                textBox30.Text = textBox30.Text.Replace("&nbsp;", "");
                textBox30.Text = textBox30.Text.Replace("<TD style=\"WIDTH: 20%\" class=numeral>", "");
                textBox30.Text = textBox30.Text.Remove(0, 1);
            }
            catch { }

        }
        private void Altın() 
        {

            try
            {
                string gelen = richTextBox1.Text; //6
                int titleIndexBaslangici = gelen.IndexOf(textBox38.Text) + textBox38.TextLength; //7
                int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf("<SPAN class=ui-icon></"); //8
                textBox31.Text = gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9
                textBox31.Text = textBox31.Text.Replace("&nbsp;", "");
            }
            catch { }

        }
        private void Elmas() 
        {
            try
            {
                string gelen = richTextBox1.Text; //6
                int titleIndexBaslangici = gelen.IndexOf(textBox39.Text) + textBox39.TextLength; //7
                int titleIndexBitisi = gelen.Substring(titleIndexBaslangici).IndexOf("<SPAN class=ui-icon>"); //8
                textBox32.Text = gelen.Substring(titleIndexBaslangici, titleIndexBitisi);//9
            }
            catch { }
        }
        #endregion
        #region PROGRAM MOTORU
        private void Program_Motoru()
        {
            #region Kaynak Bilgileri
            TümEyaletKaynakları_Tıkla();
            Mutluluk();
            Nüfus();
            Odun();
            Demir();
            Taş();
            Altın();
            Elmas();
            #endregion

            #region Profil_Bilgileri
            Profile_Tikla();
            Kullanici_Adi();
            Diyar();
            Puan();
            Sıralama();
            Onur();
            İttifak();
            AskeriPuan();
            Rütbe();
            #endregion


            AskerHareketeGeçir();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Çalışma();
            timer2.Interval = 5000;
        } 

        private void  Çalışma()
        {
            try
            {
                Program_Motoru();

                if (checkBox1.Checked == true)
                {TümAskerleriHareketeGeçir();}

            }
            catch { }

        }
        #endregion

        #region DİGER SEKMESİ
        #region Eğitimdeki Askerleri Otomatik Harekete Geçir
        private void AskerHareketeGeçir() 
        {
            HtmlElementCollection col = webBrowser1.Document.GetElementsByTagName("a");// 1 İlk Parametre
            foreach (HtmlElement doc in col)
            {
                string x = doc.GetAttribute("href");// 2 Parametre işlevi
                if (x == "javascript:void(xajax_viewEmpireTrainingList(container.open({saveName:'trainings', title:'Eğitimdeki askerler'})))")// 3 Komut
                {
                    doc.InvokeMember("click"); // 4 Eylem
                }

            }
            Site_Kaynak_Kodları();
        }
        private void TümAskerleriHareketeGeçir() 
        {
            try
            {
                webBrowser1.Document.GetElementById("do-mobilize-all").InvokeMember("click");
            }
            catch { }
        }
        #endregion

        #region Optimal Üretim

        private void Optimal_Üretim_Aç()

        {
            HtmlElementCollection col = webBrowser1.Document.GetElementsByTagName("a");// 1 İlk Parametre
            foreach (HtmlElement doc in col)
            {
                string x = doc.GetAttribute("href");// 2 Parametre işlevi
                if (x == "javascript:void(xajax_viewHireWorkersAllProvinces(container.open({'saveName': 'fast_hire', 'position': 'center;center', 'title': 'Tüm arazilerde işçileri işe al'})))")// 3 Komut
                {
                    doc.InvokeMember("click"); // 4 Eylem
                }

            }
            Site_Kaynak_Kodları();
        }
        private void Optimal_Üretim()
        {
            HtmlElementCollection col = webBrowser1.Document.GetElementsByTagName("a");// 1 İlk Parametre
            foreach (HtmlElement doc in col)
            {
                string x = doc.GetAttribute("href");// 2 Parametre işlevi
                if (x == "xajax_doHireWorkersAllProvinces('fast_hire', {'workers': {'optimal': true}});return false;")// 3 Komut
                {
                    doc.InvokeMember("click"); // 4 Eylem
                }

            }
        }

        #endregion




        #endregion



        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser2.Navigate(textBox3.Text );
        }

        








    }
}
