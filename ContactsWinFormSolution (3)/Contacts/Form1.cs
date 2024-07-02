using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
           
        }
       
        private void _RefreshContactsList()
        {
            dataGridView1.DataSource = clsContact.GetAllContacts();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.DataSource=clsContact.GetAllContacts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsContact.GetAllContacts();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(-1);
            form2.ShowDialog();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            _RefreshContactsList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2((int)dataGridView1.CurrentRow.Cells[0].Value);
            form2.ShowDialog();
            _RefreshContactsList();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2((int)dataGridView1.CurrentRow.Cells[0].Value);
            form2.ShowDialog();
            _RefreshContactsList();

        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            clsContact.DeleteContact((int)dataGridView1.CurrentRow.Cells[0].Value);
            _RefreshContactsList();
        }
    }
}
