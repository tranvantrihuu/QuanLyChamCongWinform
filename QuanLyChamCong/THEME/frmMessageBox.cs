using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QuanLyChamCong.THEME
{
    public partial class FrmMessageBox : Form
    {
        public DialogResult Result =
            DialogResult.OK;
        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(
            IntPtr hwnd,
            int attr,
            ref int attrValue,
            int attrSize
        );

        [DllImport("dwmapi.dll")]
        private static extern int DwmExtendFrameIntoClientArea(
            IntPtr hWnd,
            ref MARGINS pMarInset
        );

        private struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public FrmMessageBox(
            string message,
            string title
        )
        {
            InitializeComponent();

            lblTitle.Text = title;
            lblMessage.Text = message;

            SetButtons(
                MessageBoxButtons.OK
            );

            this.Region =
                Region.FromHrgn(
                    CreateRoundRectRgn(
                        0,
                        0,
                        Width,
                        Height,
                        25,
                        25
                    )
                );
        }

        public void SetButtons(
            MessageBoxButtons buttons
        )
        {
            if (buttons == MessageBoxButtons.OK)
            {
                btnCancel.Visible = false;

                btnOK.Text = "OK";

                btnOK.Location =
                    new Point(
                        (this.ClientSize.Width - btnOK.Width) / 2,
                        175
                    );
            }

            else if (
                buttons == MessageBoxButtons.OKCancel
                ||
                buttons == MessageBoxButtons.YesNo
            )
            {
                btnCancel.Visible = true;

                btnOK.Location =
                    new Point(90, 175);

                btnCancel.Location =
                    new Point(220, 175);

                if (buttons == MessageBoxButtons.YesNo)
                {
                    btnOK.Text = "OK";
                    btnCancel.Text = "Cancel";
                }
                else
                {
                    btnOK.Text = "OK";
                    btnCancel.Text = "Cancel";
                }
            }
        }
        protected override void OnHandleCreated(
            EventArgs e
        )
        {
            base.OnHandleCreated(e);

            int attrValue = 2;

            DwmSetWindowAttribute(
                this.Handle,
                2,
                ref attrValue,
                4
            );

            MARGINS margins = new MARGINS()
            {
                leftWidth = 1,
                rightWidth = 1,
                topHeight = 1,
                bottomHeight = 1
            };

            DwmExtendFrameIntoClientArea(
                this.Handle,
                ref margins
            );
        }
        public void SetIcon(
            MessageBoxIcon icon
        )
        {

        }

        private void btnOK_Click(
            object sender,
            EventArgs e
        )
        {
            Result = DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(
            object sender,
            EventArgs e
        )
        {
            Result = DialogResult.Cancel;

            this.Close();
        }
        
    }
}