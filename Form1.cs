using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// 27 - Feb - 2024
// Johann Mauricio Gaciria Rodriguez
// este programa crea una experiencia interactiva donde el botón btnNo se mueve
// aleatoriamente por el formulario cuando el ratón se acerca a él, y al hacer clic en
// el botón btnSi, se revela un mensaje, como una broma para el usuario.


namespace aplicacionBroma
{
    public partial class frmBroma : Form
    {
        private Random random = new Random();

        public frmBroma()
        {
            InitializeComponent();
        }

        private void MoveButtonToRandomLocation()
        {
            int x = random.Next(0, ClientSize.Width - btnNo.Width);
            int y = random.Next(0, ClientSize.Height - btnNo.Height);
            btnNo.Location = new Point(x, y);
        }

        private void frmBroma_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseNearButton(e.Location, btnNo))
            {
                MoveButtonToRandomLocation();
            }
        }

        private bool IsMouseNearButton(Point mouseLocation, Control control)
        {
            Point controlCenter = new Point(control.Left + control.Width / 2, control.Top + control.Height / 2);
            double distance = Math.Sqrt(Math.Pow(mouseLocation.X - controlCenter.X, 2) + Math.Pow(mouseLocation.Y - controlCenter.Y, 2));

            double threshold = 100;

            return distance < threshold;
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            lblFormateando.Visible = true;
        }

    }
}
