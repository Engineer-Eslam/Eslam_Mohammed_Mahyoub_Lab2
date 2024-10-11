using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace إسلام_محمد_مهيوب_المليكي_محاضره2
{
    public partial class lect2_in_form : Form
    {
        public lect2_in_form()
        {
            InitializeComponent();
            txtn3.ReadOnly = true;
            this.Text = " الة حاسبة بسيطة ";
            txtn3.BackColor = Color.Aqua;
            enabled(false);

            // ربط معالج واحد للحدث KeyUp لكل من txtn1 و txtn2
            txtn1.KeyUp += new KeyEventHandler(Handle_KeyUp);
            txtn2.KeyUp += new KeyEventHandler(Handle_KeyUp);

            // ربط معالج واحد للحدث MouseClick لكل من txtn1 و txtn2
            txtn1.MouseClick += new MouseEventHandler(Handle_MouseClick);
            txtn2.MouseClick += new MouseEventHandler(Handle_MouseClick);
        }

        private void lect2_in_form_Load(object sender, EventArgs e)
        {
            txtn2.TextChanged +=txtn1_TextChanged;
            txtn2.KeyPress += txtn1_KeyPress;
        }

        public void enabled(bool f)
        {  
            btndiv.Enabled = btnmul.Enabled = btnsub.Enabled =btnadd.Enabled = f;
        }

        public void operation(double n1, double n2, string op)
        {
            switch (op)
            {
                case "+":
                    txtn3.Text = (n1 + n2).ToString();
                    txtn3.BackColor = Color.White;
                    break;
                case "-":
                    txtn3.Text = (n1 - n2).ToString(); txtn3.BackColor = Color.White;
                    break;
                case "*":
                    txtn3.Text = (n1 * n2).ToString(); txtn3.BackColor = Color.White;
                    break;
                case "/":
                    if (n2 != 0)
                    {
                        txtn3.Text = (n1 / n2).ToString(); txtn3.BackColor = Color.White;
                    }
                    else
                    {
                        MessageBox.Show("لا يمكن القسمه على صفر", "تحذير ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                        txtn2.Text = "";
                        txtn2.Focus();
                    }
                    break;
                default:
                    txtn3.BackColor = Color.Black;
                    MessageBox.Show(" العمليه المدخله غلط", "تحذير ", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3);
                    break;
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            label5.Text = "+";
            operation(double.Parse(txtn1.Text), double.Parse(txtn2.Text), label5.Text);
        }

        private void btnsub_Click(object sender, EventArgs e)
        {
            label5.Text = "-";
            operation(double.Parse(txtn1.Text), double.Parse(txtn2.Text), label5.Text);
        }

        private void btnmul_Click(object sender, EventArgs e)
        {
            label5.Text = "*";
            operation(double.Parse(txtn1.Text), double.Parse(txtn2.Text), label5.Text);
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            label5.Text = "/";
            operation(double.Parse(txtn1.Text), double.Parse(txtn2.Text), label5.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtn2.Clear();
            txtn1.Clear();
            txtn3.Clear();
            txtn3.BackColor = Color.Aqua;
            label5.Text = "";
            txtn1.Focus();
        }

        private void txtn1_TextChanged(object sender, EventArgs e)
        {
            bool f = (txtn1.Text.Trim() != "" && txtn2.Text.Trim() != "");
            enabled(f);
        }

        private void txtn2_TextChanged(object sender, EventArgs e)
        {
            //تم تضعيفة مع الحدث التابع لصندوق الادخال الأول 
            //bool f = (txtn1.Text.Trim() != "" && txtn2.Text.Trim() != "");
            // enabled(f);
        }

        private void Handle_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.StartsWith("-") && textBox.SelectionStart == 0)
            {
                textBox.SelectionStart = 1;
            }
        }

        private void Handle_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.StartsWith("-") && textBox.SelectionStart == 0)
            {
                textBox.SelectionStart = 1;
            }
        }

        public void isnumber( KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46) && (e.KeyChar != 45))
            {
                e.Handled = true; // منع إدخال أي حرف غير رقمي
            }
        }

        public void isnumber(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox; // الحصول على مربع النص الذي أثار الحدث
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46) && (e.KeyChar != 45))
            {
                e.Handled = true; // منع إدخال أي حرف غير رقمي
            }

            if (e.KeyChar == 45) // السماح بإدخال السالب فقط إذا لم يكن موجودًا وفي البداية
            {
                if (textBox.Text.Contains("-") || textBox.SelectionStart != 0)
                {
                    e.Handled = true;
                }
            }

            if (e.KeyChar == 46) // السماح بإدخال النقطة العشرية فقط لمرة واحدة
            {
                if (textBox.Text.Contains("."))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtn1_KeyPress(object sender, KeyPressEventArgs e)
        {
            isnumber(sender, e);
        }

        private void txtn2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //تم تضعيفة مع الحدث التابع لصندوق الادخال الأول 
            //isnumber(sender,e);
        }
    }
}
