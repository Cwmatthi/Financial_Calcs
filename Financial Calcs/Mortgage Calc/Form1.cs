using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Mortgage_Calc
{
    public partial class Mortgage : Form
    {
        public Mortgage()
        {
            InitializeComponent();
        }

        public void btnCalculate_Click(object sender, EventArgs e)
        {
            int intMortgageAmount;// House Price
            double dblAnnualRate;// Annual interest rate
            double dblMonthlyrate;
            double downPayment;
            double decPayment; // Monthly payment amount
            int Years = 1; // Years for the mortgage to fill the list box
            int Months;

            try
            {
                intMortgageAmount = Int32.Parse(txtPurchasePrice.Text);
                errorProvider1.SetError(txtPurchasePrice, "");
                dblAnnualRate = double.Parse(txtInterest.Text) / 100;
                errorProvider1.SetError(txtInterest, "");
                downPayment = double.Parse(txtDownPayment.Text);
                errorProvider1.SetError(txtDownPayment, "");
                // calculate monthly interest rate
                dblMonthlyrate = dblAnnualRate / 12;
                lbResult.Items.Clear();
                lbResult.Items.Add(
                  "Mortgage Length (Years)\tMonthly Payment");
         
            while (Years <= 30)
            {
                // convert years to months for the calculation
                Months = Years * 12;
                // perform calc
                decPayment = (double)
                    ((intMortgageAmount - downPayment) * dblMonthlyrate *
                    Math.Pow(1 + dblMonthlyrate, Months) /
                    (Math.Pow(1 + dblMonthlyrate, Months) - 1));

                lbResult.Items.Add(Years + "\t\t\t" +
                    String.Format("{0:C}", decPayment));
                Years += 1;
            }
            }
            catch(Exception)
            {
                errorProvider1.SetError(txtPurchasePrice, "Not a number value.");
                errorProvider1.SetError(txtInterest, "Not a number value.");
                errorProvider1.SetError(txtDownPayment, "Not a number value.");
                MessageBox.Show("Cannot have alphabetical characters in textbox. Please replace with numbers.");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
