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

        // Reference Sites https://www.mortgagecalculator.org/ and https://usmortgagecalculator.org/
        public void btnCalculate_Click(object sender, EventArgs e)
        {
            int intMortgageAmount;// House Price
            double dblAnnualRate;// Annual interest rate
            double dblMonthlyrate;
            double downPayment;
            double decPayment; // Monthly payment amount
            int Years = 1; // Years for the mortgage to fill the list box
            int Months;
            double totInterest;
            double totLoan;

            try
            {
                // Setting values coming from specific text boxes

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
                  "Years\tMonthly Payment\tTotal Interest\tTotal Loan");
         
            while (Years <= 30)
            {
                    // convert years to months for the calculation

                    Months = Years * 12;

                    // perform calc

                    decPayment = (double)
                    ((intMortgageAmount - downPayment) * dblMonthlyrate *
                    Math.Pow(1 + dblMonthlyrate, Months) /
                    (Math.Pow(1 + dblMonthlyrate, Months) - 1));
                    totInterest = decPayment * Months - (intMortgageAmount - downPayment);
                    totLoan = decPayment * Months + (intMortgageAmount - downPayment);

                    // Creating the format for the listbox and making the correct format for numerical results
                    lbResult.Items.Add(Years + "\t" +
                    String.Format("{0:C}", decPayment) + "\t" +
                    String.Format("{0:C}", totInterest) + "\t" +
                    String.Format("{0:C}", totLoan));
                Years += 1;
            }
            }
            catch(Exception)
            {   
                // To create the error buttons with a error message 

                errorProvider1.SetError(txtPurchasePrice, "Not a number value.");
                errorProvider1.SetError(txtInterest, "Not a number value.");
                errorProvider1.SetError(txtDownPayment, "Not a number value.");
                MessageBox.Show("Cannot have alphabetical characters in textbox. Please replace with numbers.");
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Closes this form only
            this.Close();
        }
    }
}
