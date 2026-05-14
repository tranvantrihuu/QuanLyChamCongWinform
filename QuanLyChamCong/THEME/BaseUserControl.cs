using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyChamCong.THEME
{
    public class BaseUserControl
        : UserControl
    {
        public BaseUserControl()
        {
            this.Load +=
                BaseUserControl_Load;

            this.Resize +=
                BaseUserControl_Resize;

            this.BackColor =
                AppColors.Background;

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true
            );

            this.UpdateStyles();
        }

        private void BaseUserControl_Load(
            object sender,
            EventArgs e
        )
        {
            ApplyTheme(this);

            this.BeginInvoke(
                new Action(() =>
                {
                    CenterPanel();
                })
            );
        }

        private void BaseUserControl_Resize(
            object sender,
            EventArgs e
        )
        {
            CenterPanel();
        }

        private void ApplyTheme(
            Control parent
        )
        {
            foreach (
                Control c
                in parent.Controls
            )
            {
                if (c is Button btn)
                {
                    AppStyles.StyleButton(btn);
                }

                else if (c is TextBox txt)
                {
                    AppStyles.StyleTextBox(txt);
                }

                else if (c is Label lbl)
                {
                    AppStyles.StyleLabel(lbl);
                }

                else if (
                    c is DataGridView dgv
                )
                {
                    AppStyles.StyleGrid(dgv);
                }

                else if (
                    c is ComboBox cbo
                )
                {
                    AppStyles.StyleComboBox(cbo);
                }

                else if (
                    c is DateTimePicker dtp
                )
                {
                    AppStyles.StyleDatePicker(dtp);
                }

                else if (
                    c is Panel pnl
                )
                {
                    if (
                        pnl.Tag != null &&
                        pnl.Tag.ToString() == "CARD"
                    )
                    {
                        AppStyles.StyleCard(
                            pnl
                        );
                    }
                }

                if (
                    c.Controls.Count > 0
                )
                {
                    ApplyTheme(c);
                }
            }
        }

        private void CenterPanel()
        {
            Control panel =
                this.Controls
                .OfType<Panel>()
                .FirstOrDefault(
                    p =>
                        p.Tag != null &&
                        p.Tag.ToString() == "CENTER"
                );

            if (
                panel == null
            )
            {
                return;
            }

            panel.Left =
                (
                    this.ClientSize.Width
                    - panel.Width
                ) / 2;

            panel.Top =
                (
                    this.ClientSize.Height
                    - panel.Height
                ) / 2;
        }
    }
}