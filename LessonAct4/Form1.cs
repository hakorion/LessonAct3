using System;
using System.Windows.Forms;

namespace EnrollmentForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            // Step 1: Read fees from left side
            double tuition = TryParse(txtTotalTuition.Text);
            double misc = TryParse(txtMiscFees.Text);
            double other = TryParse(txtOtherFees.Text);
            double comLab = TryParse(txtComLab.Text);
            double sap = TryParse(txtSAP.Text);
            double cisco = TryParse(txtCISCO.Text);
            double exam = TryParse(txtExam.Text);

            double totalOtherFees = misc + other + comLab + sap + cisco + exam;
            txtTotalOtherFees.Text = totalOtherFees.ToString("F2");

            double subtotal = tuition + totalOtherFees;

            // Step 2: Apply Discount if scholar
            double discount = 0;
            if (!string.IsNullOrEmpty(txtScholar.Text) && txtScholar.Text.ToLower() == "yes")
            {
                discount = subtotal * 0.20; // 20% discount for scholars
            }
            txtDiscount.Text = discount.ToString("F2");

            double grandTotal = subtotal - discount;
            txtGrandTotal.Text = grandTotal.ToString("F2");

            // Step 3: Handle Payment Mode
            double downPayment = 0, first = 0, second = 0, third = 0, installmentCharge = 0;
            string mode = cboMode.SelectedItem?.ToString() ?? "Full Payment";

            if (mode.ToLower() == "installment")
            {
                installmentCharge = grandTotal * 0.05; // 5% installment charge
                grandTotal += installmentCharge;

                downPayment = grandTotal * 0.30; // 30% downpayment
                double remaining = grandTotal - downPayment;
                first = remaining / 3;
                second = remaining / 3;
                third = remaining / 3;

                txtInstallmentCharge.Text = installmentCharge.ToString("F2");
                txtDownPayment.Text = downPayment.ToString("F2");
                txt1stInstallment.Text = first.ToString("F2");
                txt2ndInstallment.Text = second.ToString("F2");
                txt3rdInstallment.Text = third.ToString("F2");
            }
            else
            {
                // Full Payment
                txtInstallmentCharge.Text = "0.00";
                txtDownPayment.Text = grandTotal.ToString("F2");
                txt1stInstallment.Text = "0.00";
                txt2ndInstallment.Text = "0.00";
                txt3rdInstallment.Text = "0.00";
            }

            txtAmountDue.Text = grandTotal.ToString("F2");
        }

        private void btnClearStudent_Click(object sender, EventArgs e)
        {
            txtStudentName.Clear();
            txtStudentNo.Clear();
            txtScholar.Clear();
            cboProgram.SelectedIndex = -1;
            cboYearLevel.SelectedIndex = -1;
            cboMode.SelectedIndex = -1;
        }

        private void btnClearSchedule_Click(object sender, EventArgs e)
        {
            dgvSchedule.Rows.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private double TryParse(string value)
        {
            double result;
            if (double.TryParse(value, out result))
                return result;
            return 0;
        }
    }
}