using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Business
{
    public static class MesajKutusu
    {
        // messageBox kullanımı için ortak metot kullanıyorum.
        public static void warning(string message)
        {
            MessageBox.Show(message, "---UYARI!---", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult Question(string message)
        {
          return  MessageBox.Show(message, "---DİKKAT!---", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        public static void information(string message)
        {
            MessageBox.Show(message, "---BİLGİLENDİRME---", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void error(string message)
        {
            MessageBox.Show(message, "---HATA---", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
