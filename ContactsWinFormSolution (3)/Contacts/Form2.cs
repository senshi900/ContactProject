using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactsBusinessLayer;
namespace Contacts
{
    public partial class Form2 : Form
    {
      public enum enMode { AddNew = 0, Update = 1 };
        private enMode _mode;
        int _contactid=2;
        clsContact contact;
        public Form2(int id)
        {
            InitializeComponent();
            if (id != -1)
            {
                _mode = enMode.Update;
            }
            else
            {
                _mode = enMode.AddNew;
            }
            _contactid = id;
           
        }
        private void _FillCountriesInComoboBox()
        {
           
            DataTable dtCountries= clsCountry.GetAllCountries();

            foreach(DataRow row in dtCountries.Rows)
            {

                comboBox1.Items.Add(row["CountryName"]);
            }
        }
        private void _LoadData()
        {
            _FillCountriesInComoboBox();
            comboBox1.SelectedIndex = 0;
            switch (_mode)
            {
                case enMode.Update:
                    
                     contact =  clsContact.Find(_contactid);
                   
                    break;
                case enMode.AddNew:
                   
                    contact = new clsContact();
                    break;
            }
            if(contact.ID != -1)
            {
                lbid.Text = contact.ID.ToString();
            }
            else
            {
                lbid.Text = "???";
            }
            
            
            textBox1.Text = contact.FirstName.ToString();
            textBox2.Text = contact.LastName.ToString();
            textBox3.Text=contact.Email.ToString();
            textBox4.Text=contact.Phone.ToString();
            dateTimePicker1.Value = contact.DateOfBirth;
            contact.CountryID = 1;
            contact.ImagePath = "";

        }
        private void label1_Click(object sender, EventArgs e)
        {
           
        }
        private void Form2_Load_1(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

      
        private void save()
        {
            contact.FirstName = textBox1.Text;
            contact.LastName = textBox2.Text;
           contact.Email =      textBox3.Text;
           contact.Phone =      textBox4.Text;
            contact.Address = "";
           contact.DateOfBirth = dateTimePicker1.Value;
            contact.CountryID = 1;
            contact.ImagePath = "";
            if (contact.Save())
                MessageBox.Show("Data Saved Successfully.");
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");
            _mode = enMode.Update;
            lbid.Text = contact.ID.ToString();

        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            save();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
