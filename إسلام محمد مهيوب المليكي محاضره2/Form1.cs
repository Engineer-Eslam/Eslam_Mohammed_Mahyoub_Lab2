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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // ربط معالج واحد للحدث KeyPress لكل من textBox1 و textBox2
            textBox1.KeyPress += new KeyPressEventHandler(Handle_KeyPress);
            textBox2.KeyPress += new KeyPressEventHandler(Handle_KeyPress);

            // ربط معالج واحد للحدث TextChanged لكل من textBox1 و textBox2
            textBox1.TextChanged += new EventHandler(Handle_TextChanged);
            textBox2.TextChanged += new EventHandler(Handle_TextChanged);

            // ربط معالج واحد للحدث KeyUp لكل من textBox1 و textBox2
            textBox1.KeyUp += new KeyEventHandler(Handle_KeyUp);
            textBox2.KeyUp += new KeyEventHandler(Handle_KeyUp);

            // ربط معالج واحد للحدث MouseClick لكل من textBox1 و textBox2
            textBox1.MouseClick += new MouseEventHandler(Handle_MouseClick);
            textBox2.MouseClick += new MouseEventHandler(Handle_MouseClick);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            button1.Enabled = false;
            textBox3.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = (Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text)).ToString();
            textBox1.Text = textBox2.Text = "";
            textBox3.BackColor = Color.DeepSkyBlue;
        }

        //private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    textBox3.Text = "";
        //    if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46) && (e.KeyChar != 45))
        //        e.Handled = true;
        //    // السماح بإدخال إشارة السالب فقط إذا كانت غير موجودة وفي البداية
        //    if (e.KeyChar == 45)
        //    {
        //        if (textBox1.Text.Contains("-") || textBox1.SelectionStart != 0)
        //        {
        //            e.Handled = true; // منع إدخال إشارة السالب إذا كانت موجودة بالفعل أو إذا لم يكن المؤشر في البداية
        //        }
        //    }
        //    // السماح بإدخال النقطة العشرية فقط إذا لم تكن موجودة بالفعل
        //    if (e.KeyChar == 46)
        //    {
        //        if (textBox1.Text.Contains("."))
        //        {
        //            e.Handled = true; // منع إدخال نقطة إضافية إذا كانت النقطة موجودة بالفعل
        //        }
        //    }
        //}

        //private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    textBox3.Text = "";
        //    if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 8) && (e.KeyChar != 46) && (e.KeyChar != 45))
        //        e.Handled = true;
        //    // السماح بإدخال إشارة السالب فقط إذا كانت غير موجودة وفي البداية
        //    if (e.KeyChar == 45)
        //    {
        //        if (textBox2.Text.Contains("-") || textBox2.SelectionStart != 0)
        //        {
        //            e.Handled = true; // منع إدخال إشارة السالب إذا كانت موجودة بالفعل أو إذا لم يكن المؤشر في البداية
        //        }
        //    }
        //    // السماح بإدخال النقطة العشرية فقط إذا لم تكن موجودة بالفعل
        //    if (e.KeyChar == 46)
        //    {
        //        if (textBox2.Text.Contains("."))
        //        {
        //            e.Handled = true; // منع إدخال نقطة إضافية إذا كانت النقطة موجودة بالفعل
        //        }
        //    }
        //}

        // معالج واحد للحدث KeyPress لكل من textBox1 و textBox2
        //هذه الداله تغني على الدالتين السابقتين 
        private void Handle_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox; // الحصول على مربع النص الذي أثار الحدث
            textBox3.Text = "";

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
        
        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    button1.Enabled = (textBox1.Text.Trim() != "") && (textBox2.Text.Trim() != "");
        //}

        //private void textBox2_TextChanged(object sender, EventArgs e)
        //{
        //    button1.Enabled = (textBox1.Text.Trim() != "") && (textBox2.Text.Trim() != "");
        //}

        // معالج واحد للحدث TextChanged لكل من textBox1 و textBox2
        //هذه الداله تغني على الدالتين السابقتين 
        private void Handle_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = (textBox1.Text.Trim() != "") && (textBox2.Text.Trim() != "");
        }

        //private void textBox1_KeyUp(object sender, KeyEventArgs e)
        //{
        //    // منع نقل المؤشر إلى ما قبل إشارة السالب بعد كتابة أي نص
        //    if (textBox1.Text.StartsWith("-") && textBox1.SelectionStart == 0)
        //    {
        //        textBox1.SelectionStart = 1; // نقل المؤشر تلقائيًا إلى بعد السالب
        //    }
        //}

        //private void textBox2_KeyUp(object sender, KeyEventArgs e)
        //{
        //    // منع نقل المؤشر إلى ما قبل إشارة السالب بعد كتابة أي نص
        //    if (textBox2.Text.StartsWith("-") && textBox2.SelectionStart == 0)
        //    {
        //        textBox2.SelectionStart = 1; // نقل المؤشر تلقائيًا إلى بعد السالب
        //    }
        //}

        // معالج واحد للحدث KeyUp لكل من textBox1 و textBox2
        //هذه الداله تغني على الدالتين السابقتين 
        private void Handle_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.StartsWith("-") && textBox.SelectionStart == 0)
            {
                textBox.SelectionStart = 1;
            }
        }

        //private void textBox1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    // منع النقر ووضع المؤشر قبل إشارة السالب
        //    if (textBox1.Text.StartsWith("-") && textBox1.SelectionStart == 0)
        //    {
        //        textBox1.SelectionStart = 1; // نقل المؤشر تلقائيًا إلى بعد السالب
        //    }
        //}

        //private void textBox2_MouseClick(object sender, MouseEventArgs e)
        //{
        //    // منع النقر ووضع المؤشر قبل إشارة السالب
        //    if (textBox2.Text.StartsWith("-") && textBox2.SelectionStart == 0)
        //    {
        //        textBox2.SelectionStart = 1; // نقل المؤشر تلقائيًا إلى بعد السالب
        //    }
        //}


        // معالج واحد للحدث MouseClick لكل من textBox1 و textBox2
        //هذه الداله تغني على الدالتين السابقتين 
        private void Handle_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text.StartsWith("-") && textBox.SelectionStart == 0)
            {
                textBox.SelectionStart = 1;
            }
        }
    }
}