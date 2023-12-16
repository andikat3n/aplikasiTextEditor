using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace projekTextEditor


{
    public partial class Form1 : Form
    {
        bool Modified, Continue;
        String FileName;
        DialogResult hasil;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Modified = false;
            FileName = "";
            Lblstatus.Text = "";
        }

        private void TXTEDitor_TextChanged(object sender, EventArgs e)
        {
            Modified = true;
            Lblstatus.Text = "Modified";
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TXTEDitor.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TXTEDitor.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TXTEDitor.Paste();
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.Color = TXTEDitor.ForeColor;
            if (colorDialog.ShowDialog() == DialogResult.OK) ;
            TXTEDitor.ForeColor = colorDialog.Color;
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.Color = TXTEDitor.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK) ;
            TXTEDitor.BackColor = colorDialog.Color;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog.Font = TXTEDitor.Font;
            if (fontDialog.ShowDialog() == DialogResult.OK) ;
            TXTEDitor.Font = fontDialog.Font;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (FileName == "")
            {
                saveAS_Click(save, e);
            }
            else
            {
                File.WriteAllText(FileName, TXTEDitor.Text);
                Modified = true;
                Lblstatus.Text = "";
                Continue = true;
            }
        }

        private void saveAS_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = "";
            if (saveFileDialog.ShowDialog()== DialogResult.OK)
            {
                FileName = saveFileDialog.FileName;
                File.WriteAllText(FileName, TXTEDitor.Text);
                Modified = false;
                Lblstatus.Text = "";
                Continue = true;

            }
            else
            {
                Continue = false;
            }

        }
    }
}