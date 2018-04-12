using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Financial_Calcs
{
    public partial class CompInterest : Form
    {
        public CompInterest()
        {
            InitializeComponent();
        }

        public void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void btnCalculate_Click(object sender, EventArgs e)
        {   
            // declaring variables
            double Principle, AnnualRate, FutureValue, RateperPeriod, Deposit, Amount ;
            int NumberofPeriods, Compoundtype;

            
                // Telling certain variables witch textbox to pull information from
                try
                {
                    Principle = Double.Parse(txtPrincipal.Text);
                    errorProvider1.SetError(txtPrincipal, "");
                    AnnualRate = Double.Parse(txtInterest.Text) / 100;
                    errorProvider1.SetError(txtInterest, "");
                    Deposit = Double.Parse(txtDeposits.Text);
                    errorProvider1.SetError(txtDeposits, "");
                    NumberofPeriods = Int32.Parse(txtPeriods.Text);
                    errorProvider1.SetError(txtPeriods, "");
                
                
                //Checking radio buttons for the compound interest times a year
                if (rdoMonthly.Checked)
                    Compoundtype = 12;
                else if (rdoQuarterly.Checked)
                    Compoundtype = 4;
                else if (rdoSemiAnnually.Checked)
                    Compoundtype = 2;
                else
                    Compoundtype = 1;

                // making calculations for the interest rate and the interest bumps * the number of years 
                double i = AnnualRate / Compoundtype;
                int n = Compoundtype * NumberofPeriods;
                
            
            
                // Making calculation to show the deposit addition amount and the pricipal + interest amount.
                double d = (Deposit * AnnualRate) * Compoundtype;
                Amount = Principle * (Math.Pow((1 + AnnualRate), NumberofPeriods) - 1);
                FutureValue = Amount + (d * NumberofPeriods);
                
                // amount goes to specific textbox
                txtAmountEarned.Text = FutureValue.ToString();
            
                }
                catch(Exception)
                {
                    MessageBox.Show("Cannot have alphabetical characters in textbox. Please replace with numbers.");    
                    errorProvider1.SetError(txtPrincipal, "Not a number value.");
                    errorProvider1.SetError(txtInterest, "Not a number value.");
                    errorProvider1.SetError(txtDeposits, "Not a number value.");
                    errorProvider1.SetError(txtPeriods, "Not a number value.");
                }

           
        }

        public void motgageCalcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Menu item have the ability to switch to the mortgage calc form

            Mortgage_Calc.Mortgage f1 = new Mortgage_Calc.Mortgage();
            f1.Show();
        }
    }
}
