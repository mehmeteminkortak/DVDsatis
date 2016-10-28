using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVDDUKKAN
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        frmDvdGiris DvdGiris;
        private void btnDvd_Click(object sender, EventArgs e)
        {
            if (DvdGiris == null || DvdGiris.IsDisposed)
                DvdGiris = new frmDvdGiris();
            DvdGiris.Show();
        }
        frmSatis Satis;
        private void btnSatis_Click(object sender, EventArgs e)
        {
            if (Satis == null || Satis.IsDisposed)
                Satis = new frmSatis();
            Satis.Show();
        }
    }
}
