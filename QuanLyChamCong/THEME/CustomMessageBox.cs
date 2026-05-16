using System.Windows.Forms;

namespace QuanLyChamCong.THEME
{
    public static class CustomMessageBox
    {
        public static DialogResult Show(
            string text
        )
        {
            FrmMessageBox frm =
                new FrmMessageBox(
                    text,
                    "THÔNG BÁO"
                );

            frm.ShowDialog();

            return frm.Result;
        }

        public static DialogResult Show(
            string text,
            string caption
        )
        {
            FrmMessageBox frm =
                new FrmMessageBox(
                    text,
                    caption
                );

            frm.ShowDialog();

            return frm.Result;
        }

        public static DialogResult Show(
            string text,
            string caption,
            MessageBoxButtons buttons
        )
        {
            FrmMessageBox frm =
                new FrmMessageBox(
                    text,
                    caption
                );

            frm.SetButtons(buttons);

            frm.ShowDialog();

            return frm.Result;
        }

        public static DialogResult Show(
            string text,
            string caption,
            MessageBoxButtons buttons,
            MessageBoxIcon icon
        )
        {
            FrmMessageBox frm =
                new FrmMessageBox(
                    text,
                    caption
                );

            frm.SetButtons(buttons);

            frm.SetIcon(icon);

            frm.ShowDialog();

            return frm.Result;
        }
    }
}