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
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
        }
        /*****************************************************************************
        * George Gachoki, Jason Thomas, Tonya Martinez, Travis Johnson
        * 6-1-2020
        * "Murach Practice Assignments (Team)"
        * "Exercises 12-1 Create a Customer Maintenance application that uses classes"
        ******************************************************************************/

        private List<Customer> customers = null; // create class variable list for customer

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            customers = CustomerDB.GetCustomers(); // get list of customers
            FillCustomerListBox(); // call method to fill customer list box
        }

        private void FillCustomerListBox()
        {
            lstCustomers.Items.Clear(); // clear current list of customers
            foreach (Customer c in customers) // loop through each customer
            {
                lstCustomers.Items.Add(c.GetDisplayText); // add current customer to list
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddCustomer newAddCustomerForm = new frmAddCustomer(); // create new instance of AddCustomer form
            Customer customer = newAddCustomerForm.GetNewCustomer(); // get data for new customer
            if (customer != null) // check if customer object is null
            {
                customers.Add(customer); // add new customer
                CustomerDB.SaveCustomers(customers); // save customers list
                FillCustomerListBox(); // call method to refresh customer list box
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstCustomers.SelectedIndex; // create & set variable to selected customer in list
            if (i != -1) // check if a customer has been selected
            {
                Customer customer = customers[i]; // create & set variable for selected customer
                string message = "Are you sure you want to delete "
                    + customer.FirstName + " " + customer.LastName + "?"; // create delete confirmation message
                DialogResult button = MessageBox.Show(message, "Confirm Delete", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2); // display confirmation to delete
                if (button == DialogResult.Yes) // check if user confirmed deletion
                {
                    customers.Remove(customer); // remove selected customer from list
                    CustomerDB.SaveCustomers(customers); // save updated customers list
                    FillCustomerListBox(); // call method to refresh customer list box
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quit Customer Application?", "Confirm Exit", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes) // display confirmation to Exit
            {
                this.Close(); // close form
            }
            lstCustomers.Focus();
        }
    }
}