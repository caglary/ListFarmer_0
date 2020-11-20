using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ListFarmer
{
    public partial class Sorgular : Form
    {
        Business.BusinessLogicService.FksService fksBll;
        Business.BusinessLogicService.MgdService mgdBll;
        Business.EF.EfDilekce2018Service _efDilekce2018Service;
        List<Entities.Fks> _fks2018;
        List<Entities.Fks> _fks2017;
        List<Entities.Mgd> _mgd2018;
        List<Entities.Mgd> _mgd2017;
        string fks2018Text = "2018 yılı FKS listesi";
        string fks2017Text = "2017 yılı FKS listesi";
        string mgd2018Text = "2018 yılı MGD listesi";
        string mgd2017Text = "2017 yılı MGD listesi";
        Entities.Ciftci _ciftci;
        public Sorgular(Entities.Ciftci ciftci)
        {
            InitializeComponent();
            fksBll = new Business.BusinessLogicService.FksService();
            mgdBll = new Business.BusinessLogicService.MgdService();
            _efDilekce2018Service = new Business.EF.EfDilekce2018Service();
            //_fks2018 = bll.GetAllFks("FKS2018");
            _fks2018 = fksBll.GetAll("FKS2018");
            //_fks2017 = bll.GetAllFks("FKS2017");
            _fks2017 = fksBll.GetAll("FKS2017");
            _mgd2017 = mgdBll.GetAll("MGD2017");
            _mgd2018 = mgdBll.GetAll("MGD2018");
            _ciftci = ciftci;
        }
        private void Sorgular_Load(object sender, EventArgs e)
        {
            foreach (var item in _fks2018)
            {
                item.isletmeAdi = item.isletmeAdi.ToLower();
            }
            FKS(dgwListe, _fks2018, "2018 yılı FKS listesi", BtnFks2018);
            txtTc.Text = (_ciftci == null) ? "" : _ciftci.tc;
        }
        private void MGD(DataGridView dgw, List<Entities.Mgd> mgds, string groupboxName, Button button)
        {
            dgw.DataSource = mgds;
            grpbxDataGridView.Text = groupboxName;
            lblListeIsmi.Text = groupboxName;
            lblToplamKayitSayisi.Text = mgds.Count.ToString();
            dgw.Columns["id"].Visible = false;
            dgw.Columns["siraNo"].Visible = false;
            dgw.Columns["il"].Visible = false;
            dgw.Columns["ilce"].Visible = false;
            dgw.Columns["dogumTarihi"].Visible = false;
            dgw.Columns["tc"].Visible = false;
            dgw.Columns["siraNo"].Visible = false;
            txtTc.Focus();
            ButtonBackcolor(button);
        }
        private void FKS(DataGridView dgw, List<Entities.Fks> fkss, string groupboxName, Button button)
        {
            dgw.DataSource = fkss;
            grpbxDataGridView.Text = groupboxName;
            lblListeIsmi.Text = groupboxName;
            lblToplamKayitSayisi.Text = fkss.Count.ToString();
            dgw.Columns["id"].Visible = false;
            dgw.Columns["siraNo"].Visible = false;
            dgw.Columns["il"].Visible = false;
            dgw.Columns["ilce"].Visible = false;
            dgw.Columns["dogumTarihi"].Visible = false;
            dgw.Columns["isletmeNo"].Visible = false;
            txtTc.Focus();
            ButtonBackcolor(button);
        }
        private void ButtonBackcolor(Button btnSender)
        {
            GroupBox grpbxListeler = this.Controls["grpbxListeler"] as GroupBox;
            foreach (var item in grpbxListeler.Controls)
            {
                if (item is Button)
                {
                    Button btnItem = item as Button;
                    if (btnItem.Name == btnSender.Name)
                    {
                        btnItem.BackColor = Color.DarkGray;
                    }
                    else if (btnItem.Name != btnSender.Name)
                    {
                        btnItem.BackColor = Color.AliceBlue;
                    }
                }
            }
            string tc = txtTc.Text;
            txtTc.Text = string.Empty;
            txtTc.Text = tc;
            txtIsim.Text = string.Empty;
        }
        private void BtnMgd2018_Click(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            MGD(dgwListe, _mgd2018, mgd2018Text, btnSender);
        }
        private void BtnFks2017_Click(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            FKS(dgwListe, _fks2017, fks2017Text, btnSender);
        }
        private void BtnMgd2017_Click(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            MGD(dgwListe, _mgd2017, mgd2017Text, btnSender);
        }
        private void BtnFks2018_Click(object sender, EventArgs e)
        {
            Button btnSender = sender as Button;
            FKS(dgwListe, _fks2018, fks2018Text, btnSender);
        }
        private void TxtTc_TextChanged(object sender, EventArgs e)
        {
            if (grpbxDataGridView.Text == fks2018Text)
            {
                dgwListe.DataSource = _fks2018.Where(p => p.isletmeNo.Contains(txtTc.Text)).ToList();
            }
            else if (grpbxDataGridView.Text == fks2017Text)
            {
                dgwListe.DataSource = _fks2017.Where(p => p.isletmeNo.Contains(txtTc.Text)).ToList();
            }
            else if (grpbxDataGridView.Text == mgd2017Text)
            {
                dgwListe.DataSource = _mgd2017.Where(p => p.tc.Contains(txtTc.Text)).ToList();
            }
            else if (grpbxDataGridView.Text == mgd2018Text)
            {
                dgwListe.DataSource = _mgd2018.Where(p => p.tc.Contains(txtTc.Text)).ToList();
            }
        }
        private void TxtIsim_TextChanged(object sender, EventArgs e)
        {
            if (grpbxDataGridView.Text == fks2018Text)
            {
                foreach (var item in _fks2018)
                {
                    item.isletmeAdi = item.isletmeAdi.ToLower();
                }
                dgwListe.DataSource = _fks2018.Where(p => p.isletmeAdi.Contains(txtIsim.Text.ToLower())).ToList();
            }
            else if (grpbxDataGridView.Text == fks2017Text)
            {
                foreach (var item in _fks2017)
                {
                    item.isletmeAdi = item.isletmeAdi.ToLower();
                }
                dgwListe.DataSource = _fks2017.Where(p => p.isletmeAdi.Contains(txtIsim.Text.ToLower())).ToList();
            }
            else if (grpbxDataGridView.Text == mgd2017Text)
            {
                foreach (var item in _mgd2017)
                {
                    item.isletmeAdi = item.isletmeAdi.ToLower();
                }
                dgwListe.DataSource = _mgd2017.Where(p => p.isletmeAdi.Contains(txtIsim.Text.ToLower())).ToList();
            }
            else if (grpbxDataGridView.Text == mgd2018Text)
            {
                foreach (var item in _mgd2018)
                {
                    item.isletmeAdi = item.isletmeAdi.ToLower();
                }
                dgwListe.DataSource = _mgd2018.Where(p => p.isletmeAdi.Contains(txtIsim.Text.ToLower())).ToList();
            }
        }
        private void dgwListe_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int dilekceno = 0;
             try
            {
                int secilen = dgwListe.SelectedCells[0].RowIndex;
                dilekceno =Convert.ToInt32( dgwListe.Rows[secilen].Cells["dilekceNo"].Value);
            }
            catch (Exception ex)
            {
                string m = ex.Message;
            }
            if (dilekceno != 0)
            {
                if (grpbxDataGridView.Text == fks2018Text)
                {
                    Entities.EF.DILEKCE2018 ciftci;
                    ciftci = _efDilekce2018Service.GetByDilekceNo(dilekceno);
                    string ciftciTc = ciftci.tc;
                    Form form = Application.OpenForms["Form1"];
                    if (form!=null)
                    {
                        //codingggg
                    }
                    string dur = "dur";
                }
                else if (grpbxDataGridView.Text == fks2017Text)
                {
                }
                else if (grpbxDataGridView.Text == mgd2017Text)
                {
                }
                else if (grpbxDataGridView.Text == mgd2018Text)
                {
                }
            }
            
        }
    }
}
