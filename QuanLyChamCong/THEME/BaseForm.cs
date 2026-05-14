using System;
using System.Windows.Forms;

namespace QuanLyChamCong.THEME
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            this.Load +=
                BaseForm_Load;

            this.FormBorderStyle =
                FormBorderStyle.Sizable;

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true
            );

            this.UpdateStyles();

            AppStyles.StyleForm(this);
        }

        private void BaseForm_Load(
            object sender,
            EventArgs e
        )
        {
            ApplyTheme(this);
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
                // BUTTON

                if (
                    c is Button btn
                )
                {
                    AppStyles.StyleButton(btn);
                }

                // TEXTBOX

                else if (
                    c is TextBox txt
                )
                {
                    AppStyles.StyleTextBox(txt);
                }

                // LABEL

                else if (
                    c is Label lbl
                )
                {
                    AppStyles.StyleLabel(lbl);
                }

                // GRID

                else if (
                    c is DataGridView dgv
                )
                {
                    AppStyles.StyleGrid(dgv);
                }

                // COMBOBOX

                else if (
                    c is ComboBox cbo
                )
                {
                    AppStyles.StyleComboBox(cbo);
                }

                // DATE

                else if (
                    c is DateTimePicker dtp
                )
                {
                    AppStyles.StyleDatePicker(dtp);
                }

                // PANEL CARD

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

                // RECURSIVE

                if (
                    c.Controls.Count > 0
                )
                {
                    ApplyTheme(c);
                }
            }
        }
    }
}