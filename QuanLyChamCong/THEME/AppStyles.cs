using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyChamCong.THEME
{
    public static class AppStyles
    {

        public static void StyleForm(
            Form frm
        )
        {
            frm.Font =
                AppFonts.Default;

            frm.StartPosition =
                FormStartPosition.CenterScreen;

            frm.BackColor =
                AppColors.Background;
        }


        public static void StyleButton(
            Button btn
        )
        {
            btn.FlatStyle =
                FlatStyle.Flat;

            btn.FlatAppearance.BorderSize =
                1;

            btn.FlatAppearance.BorderColor =
                AppColors.Border;

            btn.BackColor =
                AppColors.Primary;

            btn.ForeColor =
                Color.White;

            btn.Font =
                AppFonts.Button;

            btn.Cursor =
                Cursors.Hand;

            btn.Height =
                40;

            btn.UseVisualStyleBackColor =
                false;
        }


        public static void StyleTextBox(
            TextBox txt
        )
        {
            txt.BorderStyle =
                BorderStyle.FixedSingle;

            txt.BackColor =
                Color.White;

            txt.ForeColor =
                AppColors.Text;

            txt.Font =
                AppFonts.Default;
        }

        public static void StyleLabel(
            Label lbl
        )
        {
            lbl.Font =
                AppFonts.Default;

            lbl.ForeColor =
                AppColors.Text;

            lbl.BackColor =
                Color.Transparent;

            lbl.AutoSize =
                true;
        }

        public static void StyleTitle(
            Label lbl
        )
        {
            lbl.Font =
                AppFonts.Title;

            lbl.ForeColor =
                AppColors.Text;

            lbl.BackColor =
                Color.Transparent;

            lbl.AutoSize =
                true;
        }


        public static void StyleComboBox(
            ComboBox cbo
        )
        {
            cbo.FlatStyle =
                FlatStyle.Flat;

            cbo.BackColor =
                Color.White;

            cbo.ForeColor =
                AppColors.Text;

            cbo.Font =
                AppFonts.Default;
        }

        public static void StyleDatePicker(
            DateTimePicker dtp
        )
        {
            dtp.Font =
                AppFonts.Default;

            dtp.CalendarForeColor =
                AppColors.Text;

            dtp.CalendarMonthBackground =
                Color.White;

            dtp.CalendarTitleBackColor =
                AppColors.Primary;

            dtp.CalendarTitleForeColor =
                Color.White;
        }

        public static void StyleGrid(
            DataGridView dgv
        )
        {
            dgv.BorderStyle =
                BorderStyle.None;

            dgv.BackgroundColor =
                Color.White;

            dgv.EnableHeadersVisualStyles =
                false;

            dgv.GridColor =
                AppColors.Border;

            dgv.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.None;

            dgv.CellBorderStyle =
                DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                AppColors.Primary;

            dgv.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Bold
                );

            dgv.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgv.ColumnHeadersHeight =
                42;

            dgv.DefaultCellStyle.BackColor =
                Color.White;

            dgv.DefaultCellStyle.ForeColor =
                AppColors.Text;

            dgv.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(
                    220,
                    235,
                    252
                );

            dgv.DefaultCellStyle.SelectionForeColor =
                AppColors.Text;

            dgv.DefaultCellStyle.Font =
                new Font(
                    "Segoe UI",
                    10F
                );

            dgv.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgv.DefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

            dgv.DefaultCellStyle.Padding =
                new Padding(
                    3,
                    0,
                    3,
                    0
                );

            dgv.RowHeadersVisible =
                false;

            dgv.AllowUserToAddRows =
                false;

            dgv.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgv.RowTemplate.Height =
                36;

            dgv.DataBindingComplete += (
                s,
                e
            ) =>
            {
                foreach (
                    DataGridViewColumn col
                    in dgv.Columns
                )
                {
                    Type type =
                        col.ValueType;

                    if (
                        type == null &&
                        dgv.Rows.Count > 0
                    )
                    {
                        object value =
                            dgv.Rows[0]
                               .Cells[col.Index]
                               .Value;

                        if (value != null)
                        {
                            type =
                                value.GetType();
                        }
                    }

                    bool isNumber =
                        type == typeof(int) ||
                        type == typeof(long) ||
                        type == typeof(float) ||
                        type == typeof(double) ||
                        type == typeof(decimal);

                    col.DefaultCellStyle.Alignment =
                        isNumber
                            ? DataGridViewContentAlignment.MiddleCenter
                            : DataGridViewContentAlignment.MiddleLeft;
                }
            };
        }
        public static void StyleScheduleGrid(
            DataGridView dgv
        )
        {
            StyleGrid(dgv);

            dgv.SelectionMode =
                DataGridViewSelectionMode.CellSelect;

            dgv.MultiSelect =
                true;

            dgv.ReadOnly =
                false;
        }

        public static void StyleCard(
            Panel panel
        )
        {
            panel.BackColor =
                Color.White;

            panel.BorderStyle =
                BorderStyle.FixedSingle;
        }
    }
}