using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Livros
{
    public partial class FrmSplashScreen : Form
    {
        public FrmSplashScreen()
        {
            InitializeComponent();
        }

        public int timeLeft { get; set; }

        private void FrmSplashScreen_Load(object sender, EventArgs e)
        {
            timeLeft = 50;
            tmrSplash.Start();
        }

        private void tmrSplash_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
            }

            else
            {
                tmrSplash.Stop();
                new Frm_Login().Show();
                this.Hide();
            }
        }
    }
}
