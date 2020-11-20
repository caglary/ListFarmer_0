using Entities;
using Microsoft.Office.Interop.Excel;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using CheckBox = System.Windows.Forms.CheckBox;
using GroupBox = System.Windows.Forms.GroupBox;
using TextBox = System.Windows.Forms.TextBox;
namespace ListFarmer
{
    public partial class Form1 : Form
    {
        public string TcNo { get; set; }
        Business.BusinessLogicService.CiftciService ciftciService;
        Business.BusinessLogicService.BackupServise backupService;
        Business.EF.ListeManager listeManager;
        Business.BLLSelenium selenium;
        Form T;
        Kullanici _kullanici;
        Ciftci currentCiftci;
        Thread thread1;
        public Form1(Kullanici kullanici)
        {
            if (kullanici != null)
            {
                InitializeComponent();
                _kullanici = kullanici;
                selenium = new Business.BLLSelenium();
                ciftciService = new Business.BusinessLogicService.CiftciService();
                backupService = new Business.BusinessLogicService.BackupServise();
                listeManager = new Business.EF.ListeManager();
            }
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            lblSaat.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            SqlConnection connection = StaticsClass.StaticsMethods._sqlBaglanti;
            T = (Form)sender;
            T.Text = $"Merhaba {_kullanici.kullaniciadi}, Çiftçi Kayıt Programına hoşgeldin. Data Source of Connection: {connection.DataSource}";
            cmbListeSec.SelectedIndex = 1;
            listegoster(cmbListeSec);
            //DataGridIlkKayitYazdir(dgwListe, "liste2019");
            Temizle();
            pictureBoxYeni.Visible = false;
            if (_kullanici.kullaniciadi != "caglar") sendMailforInfoUser();
        }
        private void sendMailforInfoUser()
        {
            SqlConnection baglanti = StaticsClass.StaticsMethods._sqlBaglanti;
            try
            {
                string baglantiAdresi = baglanti.Database;
                string ProgramAdi = "ÇİFTÇİ KAYIT";
                string datetime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                string Icerik = $"{datetime} tarihinde " + ProgramAdi + $" programına {_kullanici.kullaniciadi} adlı kullanici tarafından giriş yapılmıştır. " + baglantiAdresi + " adresinden bağlantı sağlanmaktadır.";
                StaticsClass.StaticsMethods.emailGonder("caglar.yurdakul60@gmail.com", ProgramAdi + " programına giriş yapıldı.", Icerik);
            }
            catch (Exception)
            {
                MessageBox.Show("Mail işlemi sırasında problem oluştu.İnternet bağlantınızı kontrol ediniz.");
            }
        }
        #region refactoring
        private void CrudIslemiIcinButonlariasifAktifYap(bool pasifAktif = true)
        {
            this.BtnSave.Enabled = pasifAktif;
            this.BtnDelete.Enabled = pasifAktif;
            this.BtnUpdate.Enabled = pasifAktif;
            this.BtnToFks.Enabled = pasifAktif;
            this.btnAktar.Enabled = pasifAktif;
        }
        private void listegoster(ComboBox cmb)
        {
            CrudIslemiIcinButonlariasifAktifYap();
            btnAktar.Visible = false;
            if (cmb.SelectedIndex == 0)// ilk index liste 2018 olacak
            {
                txtTc.Focus();
                //dgwListe.DataSource = bll.GetAll("liste2018");
                dgwListe.DataSource = ciftciService.GetAll("liste2018");
                groupBox3.Text = "Çks 2018 Listesi";
                lblKayitSayisi.Text = $"{groupBox3.Text.ToUpper()} toplam kayıt sayısı : {dgwListe.RowCount.ToString()}";
                BtnStatus("2018");
                this.groupBox2.BackColor = Color.DarkSeaGreen;
                BtnToFks.Text = "Fks 2018 Ekle";
                BtnToFks.Enabled = true;
                btnAktar.Visible = true;
                btnAktar.Enabled = true;
                btnAktar.Text = "2019'a Aktar";
                CrudIslemiIcinButonlariasifAktifYap(false);
            }
            else if (cmb.SelectedIndex == 1) // ikinci index liste 2019 olacak
            {
                txtTc.Focus();
                //dgwListe.DataSource = bll.GetAll();
                dgwListe.DataSource = ciftciService.GetAll("liste2019");
                dgwListe.Columns["KayitDurumu"].Visible = false;
                groupBox3.Text = "Çks 2019 Listesi";
                lblKayitSayisi.Text = $"{groupBox3.Text.ToUpper()} toplam kayıt sayısı : {dgwListe.RowCount.ToString()}";
                BtnStatus("2019");
                this.groupBox2.BackColor = Color.Wheat;
                BtnToFks.Text = "Fks 2019 Ekle";
                BtnToFks.Enabled = true;
                btnAktar.Visible = true;
                btnAktar.Enabled = true;
                btnAktar.Text = "2020'ye Aktar";
            }
            else if (cmb.SelectedIndex == 2) // ikinci index DILEKCE2018 olacak
            {
                txtTc.Focus();
                //dgwListe.DataSource = bll.GetAll("DILEKCE2018");
                dgwListe.DataSource = ciftciService.GetAll("DILEKCE2018");
                groupBox3.Text = "Fks Dilekceler 2018";
                lblKayitSayisi.Text = $"{groupBox3.Text.ToUpper()} toplam kayıt sayısı : {dgwListe.RowCount.ToString()}";
                BtnStatus("FKS 2018");
                this.groupBox2.BackColor = Color.AntiqueWhite;
                BtnToFks.Text = "Fks 2018 Ekle";
                BtnToFks.Enabled = true;
                CrudIslemiIcinButonlariasifAktifYap(false);
            }
            else if (cmb.SelectedIndex == 3) // ikinci index liste 2020 olacak
            {
                txtTc.Focus();
                //dgwListe.DataSource = bll.GetAll("liste2020");
                dgwListe.DataSource = ciftciService.GetAll("liste2020");
                dgwListe.Columns["KayitDurumu"].Visible = false;
                groupBox3.Text = "Çks 2020 Listesi";
                lblKayitSayisi.Text = $"{groupBox3.Text.ToUpper()} toplam kayıt sayısı : {dgwListe.RowCount.ToString()}";
                BtnStatus("2020");
                this.groupBox2.BackColor = Color.LightYellow;
                BtnToFks.Text = "Fks 2020 Ekle";
                BtnToFks.Enabled = false;
                btnAktar.Visible = true;
                btnAktar.Enabled = true;
                btnAktar.Text = "Çks 2019";
            }
            else if (cmb.SelectedIndex == 4) // ikinci index DILEKCE2019 olacak
            {
                txtTc.Focus();
                //dgwListe.DataSource = bll.GetAll("DILEKCE2019");
                dgwListe.DataSource = ciftciService.GetAllFks2019("Dilekce2019");
                dgwListe.Columns["id"].Visible = false;
                groupBox3.Text = "Fks Dilekceler 2019";
                lblKayitSayisi.Text = $"{groupBox3.Text.ToUpper()} toplam kayıt sayısı : {dgwListe.RowCount.ToString()}";
                BtnStatus("FKS 2019");
                this.groupBox2.BackColor = Color.LightSkyBlue;
                BtnToFks.Text = "Fks 2019 Ekle";
                BtnToFks.Enabled = false;
                btnAktar.Visible = true;
                btnAktar.Enabled = true;
                btnAktar.Text = "Çks 2019";
            }
            //dataGridView1.Columns["dilekceno"].Visible = false;
            //Butonlar sadece caglar kullanıcı içerisinde kullanılacak.
            if (_kullanici.kullaniciadi != "caglar")
            {
                foreach (Control item in this.Controls)
                {
                    if (item is GroupBox)
                    {
                        foreach (Control button in item.Controls)
                        {
                            if (button is Button)
                            {
                                if (button.Name != "BtnSorgular" && button.Name != "BtnExit" && button.Name != "BtnAra" && button.Name != "BtnTemizle" && button.Name != "BtnNvi")
                                {
                                    button.Enabled = false;
                                }
                            }
                        }
                    }
                }
            }
            dgwListe.Columns["tarih"].DefaultCellStyle.Format = "dd/MM/yyyy";
            
        }
        private void DataGridIlkKayitYazdir(DataGridView dataGridView1, string listeIsmi)
        {
            Ciftci ciftci = new Ciftci();
            int ilkKayitDilekceNo = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            ciftci = ciftciService.Get(ilkKayitDilekceNo, listeIsmi);
            txtDilekceNo.Text = ciftci.dilekceno.ToString();
            txtTc.Text = ciftci.tc;
            txtIsim.Text = ciftci.isim;
            txtSoyisim.Text = ciftci.soyisim;
            cmbMahalle.Text = ciftci.mahalle;
            txtTarih.Text = ciftci.tarih.ToShortDateString();
            richtxtAciklama.Text = ciftci.aciklama;
            txtTelefon.Text = ciftci.telefon;
            if (ciftci.KayitDurumu == 0)
            {
                checkbxYeniKayit.Checked = false;
                pictureBoxYeni.Visible = false;
            }
            else if (ciftci.KayitDurumu == 1)
            {
                checkbxYeniKayit.Checked = true;
                pictureBoxYeni.Visible = true;
            }
        }
        private void BtnStatus(string listeismi)
        {
            BtnAra.Text = $"{listeismi}\n ARA";
            BtnSave.Text = $"{listeismi}\nEKLE";
            BtnUpdate.Text = $"{listeismi}\nGÜNCELLE";
            BtnDelete.Text = $"{listeismi}\nSİL";
            btnNotlar.Text = $"{listeismi}";
        }
        private Entities.Ciftci saveCreateCiftci()
        {
            Entities.Ciftci ciftci = new Entities.Ciftci();
            ciftci.tc = txtTc.Text;
            ciftci.isim = txtIsim.Text.ToUpper();
            ciftci.soyisim = txtSoyisim.Text.ToUpper();
            ciftci.mahalle = cmbMahalle.Text.ToUpper();
            ciftci.aciklama = richtxtAciklama.Text.ToLower();
            if (checkbxYeniKayit.Checked == true) ciftci.KayitDurumu = 1;
            else if (checkbxYeniKayit.Checked == false) ciftci.KayitDurumu = 0;
            ciftci.telefon = txtTelefon.Text;
            return ciftci;
        }
        private Entities.Ciftci updateCreateCiftci()
        {
            Entities.Ciftci ciftci = new Entities.Ciftci();
            if (!string.IsNullOrEmpty(txtDilekceNo.Text))
            {
                ciftci.dilekceno = Convert.ToInt16(txtDilekceNo.Text);
            }
            ciftci.tc = txtTc.Text;
            ciftci.isim = txtIsim.Text.ToUpper();
            ciftci.soyisim = txtSoyisim.Text.ToUpper();
            ciftci.mahalle = cmbMahalle.Text.ToUpper();
            ciftci.aciklama = richtxtAciklama.Text.ToLower();
            if (checkbxYeniKayit.Checked == true) ciftci.KayitDurumu = 1;
            else if (checkbxYeniKayit.Checked == false) ciftci.KayitDurumu = 0;
            ciftci.telefon = txtTelefon.Text;
            return ciftci;
        }
        private Entities.Ciftci deleteCreateCiftci()
        {
            return updateCreateCiftci();
        }
        private Entities.Ciftci seleniumTbsCreateCiftci()
        {
            Entities.Ciftci ciftci = new Entities.Ciftci();
            ciftci.tc = txtTc.Text;
            return ciftci;
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Business.BLLSelenium.webBrowserKapat();
            System.Windows.Forms.Application.Exit();
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            string listeIsmi = ListeIsmi();
            if (!string.IsNullOrEmpty(listeIsmi))
            {
                ciftciService.Save(saveCreateCiftci(), listeIsmi);
            }
            listegoster(cmbListeSec);
        }
        private string ListeIsmi()
        {
            int secenek = cmbListeSec.SelectedIndex;
            string listeIsmi = string.Empty;
            switch (secenek)
            {
                case 0:
                    listeIsmi = "liste2018";
                    break;
                case 1:
                    listeIsmi = "liste2019";
                    break;
                case 2:
                    listeIsmi = "DILEKCE2018";
                    break;
                case 3:
                    listeIsmi = "liste2020";
                    break;
                case 4:
                    listeIsmi = "DILEKCE2019";
                    break;
                default:
                    break;
            }
            return listeIsmi;
        }
        private void TxtTc_Click(object sender, EventArgs e)
        {
            txtTc.SelectionStart = 0;
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string listeIsmi = ListeIsmi();
            if (!string.IsNullOrEmpty(listeIsmi))
            {
                ciftciService.Update(updateCreateCiftci(), listeIsmi);
            }
            listegoster(cmbListeSec);
        }
        private void Btndelete_Click(object sender, EventArgs e)
        {
            string listeIsmi = ListeIsmi();
            if (!string.IsNullOrEmpty(listeIsmi))
            {
                ciftciService.Delete(deleteCreateCiftci(), listeIsmi);
            }
            listegoster(cmbListeSec);
            Temizle();
        }
        private void Temizle()
        {
            //Temizle metodunu form controllerini yakalayarak kodladım. refactoring yapılabilir....
            System.Windows.Forms.GroupBox T = (System.Windows.Forms.GroupBox)this.Controls["grpBxBilgiler"];
            foreach (Control item in T.Controls)
            {
                if (item is System.Windows.Forms.TextBox)
                {
                    TextBox yakalananTextbox = (TextBox)item;
                    yakalananTextbox.Text = string.Empty;
                    if (yakalananTextbox.Name == "txtTarih")
                    {
                        yakalananTextbox.Text = DateTime.Now.ToShortDateString().ToString();
                    }
                }
                else if (item is MaskedTextBox)
                {
                    MaskedTextBox maskedTextBox = (MaskedTextBox)item;
                    if (maskedTextBox.Name == "txtTelefon") item.Text = string.Empty;
                    if (maskedTextBox.Name == "txtTc") item.Text = string.Empty;
                }
                else if (item is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)item;
                    if (comboBox.Name == "cmbMahalle") item.Text = "Mahalle Seçiniz.";
                }
                else if (item is RichTextBox)
                {
                    RichTextBox richTextBox = (RichTextBox)item;
                    if (richTextBox.Name == "richtxtAciklama") item.Text = string.Empty;
                }
                else if (item is System.Windows.Forms.CheckBox)
                {
                    System.Windows.Forms.CheckBox checkBox = (System.Windows.Forms.CheckBox)item;
                    if (checkBox.Name == "checkbxYeniKayit") checkBox.Checked = false;
                }
            }
        }
        private void BtnExcel_Click(object sender, EventArgs e)
        {
            ExceleAktar();
        }
        private void ExceleAktar()
        {
            DialogResult soru = new DialogResult();
            soru = MessageBox.Show("Tablodaki veriler EXCEL'e aktarılacak . Devam etmek istiyor musunuz.", "---Soru---", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (soru == DialogResult.Yes)
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                object Missing = Type.Missing;
                Workbook workbook = excel.Workbooks.Add(Missing);
                Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
                int StartCol = 1;
                int StartRow = 1;
                for (int j = 0; j < dgwListe.Columns.Count; j++)
                {
                    Range myRange = (Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dgwListe.Columns[j].HeaderText;
                }
                StartRow++;
                for (int i = 0; i < dgwListe.Rows.Count; i++)
                {
                    for (int j = 0; j < dgwListe.Columns.Count; j++)
                    {
                        Range myRange = (Range)sheet1.Cells[StartRow + i, StartCol + j];
                        myRange.Value2 = dgwListe[j, i].Value == null ? "" : dgwListe[j, i].Value;
                        myRange.Select();
                    }
                }
            }
        }
        #endregion
        private void BtnTbs_Click(object sender, EventArgs e)
        {
            if (Business.BLLSelenium.driver != null)
            {
                DialogResult soru = MessageBox.Show("Devam etmek istiyor musunuz?", "Bilgilendirme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (soru == DialogResult.No)
                {
                    Business.BLLSelenium.webBrowserKapat();
                    Business.BLLSelenium.driver = null;
                }
                else
                {
                    Business.BLLSelenium.webBrowserKapat();
                    Business.BLLSelenium.driver = null;
                    selenium.ClickTbs(seleniumTbsCreateCiftci());
                }
            }
            else
            {
                selenium.ClickTbs(seleniumTbsCreateCiftci());
            }
        }
        private void CmbListeSec_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string Tcnumarasi = txtTc.Text;
            listegoster(cmbListeSec);
            Temizle();
            txtTc.Text = Tcnumarasi;
        }
        private void BtnNvi_Click(object sender, EventArgs e)
        {
            try
            {
                Ciftci ciftci = selenium.IsletmeBilgileriGetir(seleniumTbsCreateCiftci(), _kullanici);
                txtIsim.Text = ciftci.isim;
                txtSoyisim.Text = ciftci.soyisim;
                cmbMahalle.Text = ciftci.mahalle;
                txtTelefon.Text = "";
                richtxtAciklama.Text = "";
                txtDilekceNo.Text = string.Empty;
                txtTarih.Text = DateTime.Today.ToShortDateString();
                checkbxYeniKayit.Checked = false;
            }
            catch (Exception exception)
            {
                Logger.LogTryCatch.TryCatch(exception, "selenium");
            }
        }
        private void BtnRestore_Click(object sender, EventArgs e)
        {
            Business.BusinessLogicService.BackupServise bs = new Business.BusinessLogicService.BackupServise();
            bs.RestoreDBFromSQL();
        }
        private void TxtTelefon_Click(object sender, EventArgs e)
        {
            txtTelefon.SelectionStart = 0;
        }
        private void BtnAra_Click(object sender, EventArgs e)
        {
            int secenek = cmbListeSec.SelectedIndex;
            string listeIsmi = "";
            switch (secenek)
            {
                case 0:
                    listeIsmi = "liste2018";
                    break;
                case 1:
                    listeIsmi = "liste2019";
                    break;
                case 2:
                    listeIsmi = "DILEKCE2018";
                    break;
                case 3:
                    listeIsmi = "liste2020";
                    break;
                case 4:
                    listeIsmi = "DILEKCE2019";
                    break;
                default:
                    break;
            }
            string tc = txtTc.Text;
            //dgwListe.DataSource = bll.Search(seleniumTbsCreateCiftci(), listeIsmi);
            Ciftci c = seleniumTbsCreateCiftci();
            dgwListe.DataSource = ciftciService.Search(c.tc, listeIsmi);
            Temizle();
            txtTc.Text = tc;
        }
        private void BtnSorgular_Click(object sender, EventArgs e)
        {
            T = System.Windows.Forms.Application.OpenForms["Sorgular"];
            if (T == null)
            {
                Sorgular sorgular = new Sorgular(currentCiftci);
                // forma gönderilecek çiftciyi seçmek için coding...
                sorgular.StartPosition = FormStartPosition.CenterScreen;
                sorgular.Show();
            }
            else
            {
                T.Focus();
            }
        }
        private void Btn_temizle_Click(object sender, EventArgs e)
        {
            Temizle();
            listegoster(cmbListeSec);
        }
        private void BtnToFks_Click(object sender, EventArgs e)
        {
            Ciftci ciftci = updateCreateCiftci();
            if (_kullanici.kullaniciadi != "caglar")
            {
                if (cmbListeSec.SelectedIndex == 1)
                {
                    string mesaj = "2019 yılı FKS kayıtları başlamamıştır.";
                    Business.MesajKutusu.warning(mesaj);
                }
                else if (cmbListeSec.SelectedIndex == 0)
                {
                    string mesaj = "Yetkili değilsiniz.";
                    Business.MesajKutusu.warning(mesaj);
                }
            }
            else
            {
                if (cmbListeSec.SelectedIndex == 0)
                {
                    ciftciService.Save(ciftci, "DILEKCE2018");
                    //bll.Save(updateCreateCiftci(), "DILEKCE2018");
                    cmbListeSec.SelectedIndex = 2;
                }
                else if (cmbListeSec.SelectedIndex == 1)//liste2019 seçili iken
                {
                    ciftci.dilekceno = listeManager.Fks2019EnSonNumara();
                    ciftci.aciklama = string.Empty;
                    ciftciService.SaveFks2019(ciftci);
                    //bll.Save(updateCreateCiftci(), "DILEKCE2019");
                    cmbListeSec.SelectedIndex = 4;
                }
                else if (cmbListeSec.SelectedIndex == 2)
                {
                    string mesaj = "Ekleme ÇKS 2018 listesi üzerinden yapınız.";
                    cmbListeSec.SelectedIndex = 0;
                    Business.MesajKutusu.warning(mesaj);
                }
            }
        }
        #region Form için Yeni GÖRSEL metotlar :)
        private void TxtTc_Enter(object sender, EventArgs e)
        {
            ((MaskedTextBox)sender).BackColor = Color.Azure;
        }
        private void TxtTc_Leave(object sender, EventArgs e)
        {
            ((MaskedTextBox)sender).BackColor = Color.White;
        }
        private void TxtIsim_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.Azure;
        }
        private void TxtIsim_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = Color.White;
        }
        private void RichtxtAciklama_Enter(object sender, EventArgs e)
        {
            ((RichTextBox)sender).BackColor = Color.Azure;
        }
        private void RichtxtAciklama_Leave(object sender, EventArgs e)
        {
            ((RichTextBox)sender).BackColor = Color.White;
        }
        #endregion
        private void BtnJsonBackup_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog _folder = new FolderBrowserDialog();
            DialogResult result = _folder.ShowDialog();
            if (result == DialogResult.OK)
            {
                thread1 = new Thread(new ThreadStart(islem));
                this.Hide();
                thread1.Start();
                bool returnValue = backupService.BackupDbJsonFormat(_folder);
                thread1.Abort();
                this.Show();
                if (returnValue)
                {
                    string mesaj = "Yedeklenen dosyalar json formatında kayıtlı gmail adresine gönderildi.";
                    Business.MesajKutusu.information(mesaj);
                }
                else if (!returnValue)
                {
                    string mesaj = "Yedekleme işlemi yapılırken sorunla karşılaşıldı.İnternet bağlantınızı kontrol edip işlemi tekrarlayınız.Aynı hatayı almanız durumunda sistem yöneticisi ile irtibata geçiniz.";
                    Business.MesajKutusu.error(mesaj);
                }
            }
        }
        private void islem()
        {
            try
            {
                waitingForm wf = new waitingForm();
                wf.ShowDialog();
            }
            catch (Exception exception)
            {
                Logger.LogTryCatch.TryCatch(exception, "Form1");
            }
        }
        private string WhatIsNameOfListInComboBox()
        {
            //combo Box içerisinde seçili olan listenin ismi dönderen metot.
            string listeIsmi = string.Empty;
            switch (cmbListeSec.SelectedIndex)
            {
                case 0:
                    listeIsmi = "liste2018";
                    break;
                case 1:
                    listeIsmi = "liste2019";
                    break;
                case 2:
                    listeIsmi = "DILEKCE2018";
                    break;
                case 3:
                    listeIsmi = "liste2020";
                    break;
                case 4:
                    listeIsmi = "DILEKCE2019";
                    break;
                default:
                    MessageBox.Show("Herhangi bir liste seçimi yapılmadı.");
                    break;
            }
            return listeIsmi;
        }
        private void BtnJsonRestore_Click(object sender, EventArgs e)
        {
            string listeIsmi = WhatIsNameOfListInComboBox();
            backupService.RestoreDbFromJson(listeIsmi);
            listegoster(cmbListeSec);
        }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Form T = System.Windows.Forms.Application.OpenForms["Sorgular"];
            bool formkontrol = T == null ? true : false;
            if (!formkontrol) T.Close();
            BtnSorgular_Click(sender, e);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Business.BLLSelenium.webBrowserKapat();
        }
        private void CheckbxYeniKayit_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbox = sender as CheckBox;
            if (cbox.Checked == true)
            {
                pictureBoxYeni.Visible = true;
            }
            else if (cbox.Checked == false)
            {
                pictureBoxYeni.Visible = false;
            }
        }
        private void DgwListe_Click(object sender, EventArgs e)
        {
            DataGridView dgw = sender as DataGridView;
            int secilen = dgw.SelectedCells[0].RowIndex;
            txtDilekceNo.Text = dgw.Rows[secilen].Cells["dilekceno"].Value.ToString();
            txtTc.Text = dgw.Rows[secilen].Cells["tc"].Value.ToString();
            txtIsim.Text = dgw.Rows[secilen].Cells["isim"].Value.ToString();
            txtSoyisim.Text = dgw.Rows[secilen].Cells["soyisim"].Value.ToString();
            cmbMahalle.Text = dgw.Rows[secilen].Cells["mahalle"].Value.ToString();
            DateTime tarih = (DateTime)dgw.Rows[secilen].Cells["tarih"].Value;
            txtTarih.Text = tarih.ToShortDateString();
            richtxtAciklama.Text = dgw.Rows[secilen].Cells["aciklama"].Value.ToString();
            txtTelefon.Text = dgw.Rows[secilen].Cells["telefon"].Value.ToString();
            string kayitDurumu = dgw.Rows[secilen].Cells["kayitdurumu"].Value.ToString();
            int KayitDurumuInt = Convert.ToInt16(kayitDurumu);
            if (KayitDurumuInt == 1) checkbxYeniKayit.Checked = true;
            else checkbxYeniKayit.Checked = false;
            currentCiftci = new Ciftci();
            //currentCiftci.dilekceno =Convert.ToInt16( txtDilekceNo.Text);
            currentCiftci.isim = txtIsim.Text;
            currentCiftci.soyisim = txtSoyisim.Text;
            currentCiftci.tc = txtTc.Text;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            lblSaat.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }
        private void BtnAktar_Click(object sender, EventArgs e)
        {
            int caseSwitch = cmbListeSec.SelectedIndex;
            switch (caseSwitch)
            {
                case 0://çks 2018
                    //ciftciService.Save(saveCreateCiftci(), "liste2019");
                    ciftciService.Save2019(saveCreateCiftci());
                    cmbListeSec.SelectedIndex = 1;
                    break;
                case 1://çks 2019
                    Entities.Ciftci ciftci = new Entities.Ciftci();
                    ciftci.tc = txtTc.Text;
                    ciftci.isim = txtIsim.Text.ToUpper();
                    ciftci.soyisim = txtSoyisim.Text.ToUpper();
                    ciftci.mahalle = cmbMahalle.Text.ToUpper();
                    ciftci.aciklama = string.Empty;
                    ciftci.KayitDurumu = 0;
                    if (txtTelefon.Text == "" || txtTelefon.Text == "(   )    -")
                    {
                        MessageBox.Show("Telefon Numarası Girilmeli");
                    }
                    ciftci.telefon = txtTelefon.Text;
                    ciftciService.Save(ciftci, "liste2020");
                    cmbListeSec.SelectedIndex = 3;
                    break;
                //case 2://fks dilekce 2018
                //    break;
                case 3://çks 2020
                    cmbListeSec.SelectedIndex = 1;
                    break;
                case 4://fks dilekce 2019
                    cmbListeSec.SelectedIndex = 1;
                    break;
                default:
                    break;
            }
            listegoster(cmbListeSec);
        }
        private void BtnNotlar_Click(object sender, EventArgs e)
        {
            int caseSwitch = cmbListeSec.SelectedIndex;
            switch (caseSwitch)
            {
                case 0://çks 2018
                    dgwListe.DataSource = listeManager.Notlar2018();
                    dgwListe.Columns["id"].Visible = false;
                    break;
                case 1://çks 2019
                    dgwListe.DataSource = listeManager.Notlar2019();
                    dgwListe.Columns["id"].Visible = false;
                    break;
                //case 2://fks dilekce 2018
                //    break;
                //case 3://çks 2020
                //    break;
                case 4://fks dilekce 2019
                    dgwListe.DataSource = listeManager.NotlarFks2019();
                    dgwListe.Columns["id"].Visible = false;
                    break;
                default:
                    MessageBox.Show("Seçili liste için kodlama yapılmadı");
                    break;
            }
        }
        public void TcYaz(string tcNo )
        {
            txtTc.Text = "";
            txtTc.Text = TcNo;
        }
    }
}
