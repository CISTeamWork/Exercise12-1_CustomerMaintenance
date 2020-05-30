using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public partial class frmAddCustomer : Form
    {
        public frmAddCustomer()
        {
            InitializeComponent();
        }
        /******************************************************************************
        * George Gachoki, Jason Thomas, Tonya Martinez, Travis Johnson
        * 6-1-2020
        * "Murach Practice Assignments (Team)"
        * "Exercises 12-1 Create a Customer Maintenance application that uses classes"
        ******************************************************************************/

        private Customer customer = null; // create customer class variable w/ initial null value

        public Customer GetNewCustomer()
        {
            this.ShowDialog(); // display form as dialog box
            return customer; // return customer to calling method
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData()) // check if data is valid
            {
                customer = new Customer(txtFirstName.Text, txtLastName.Text, txtEmail.Text); // create new customer object w/ user entries
                this.Close(); // close form
            }
        }

        private bool IsValidData()
        {
            return Validator.IsPresent(txtFirstName) // check if first name is populated
                && Validator.IsPresent(txtLastName) // check if last name is populated
                && Validator.IsPresent(txtEmail) // check if email is populated
                && Validator.IsValidEmail(txtEmail); // check if email is valid format
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); // close form
        }
    }
}