using System.Windows.Forms;

namespace EnrollmentForm
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Panel mainPanel;
        private GroupBox grpStudent, grpSchedule, grpFeesLeft, grpFeesRight;
        private DataGridView dgvSchedule;

        private Button btnCompute, btnClearStudent, btnClearSchedule, btnExit;

        private TextBox txtStudentName, txtStudentNo, txtScholar;
        private ComboBox cboProgram, cboYearLevel, cboMode;

        // Left Fees
        private TextBox txtTotalTuition, txtMiscFees, txtOtherFees, txtComLab, txtSAP, txtCISCO, txtExam, txtTotalOtherFees;

        // Right Fees
        private TextBox txtModePayment, txtInstallmentCharge, txtDownPayment, txt1stInstallment, txt2ndInstallment, txt3rdInstallment;

        // Totals
        private TextBox txtAmountDue, txtGrandTotal, txtDiscount;

        private void InitializeComponent()
        {
            this.mainPanel = new Panel();
            this.grpStudent = new GroupBox();
            this.grpSchedule = new GroupBox();
            this.grpFeesLeft = new GroupBox();
            this.grpFeesRight = new GroupBox();
            this.dgvSchedule = new DataGridView();

            this.btnCompute = new Button();
            this.btnClearStudent = new Button();
            this.btnClearSchedule = new Button();
            this.btnExit = new Button();

            this.txtStudentName = new TextBox();
            this.txtStudentNo = new TextBox();
            this.txtScholar = new TextBox();

            this.cboProgram = new ComboBox();
            this.cboYearLevel = new ComboBox();
            this.cboMode = new ComboBox();

            // Left fees textboxes
            txtTotalTuition = new TextBox();
            txtMiscFees = new TextBox();
            txtOtherFees = new TextBox();
            txtComLab = new TextBox();
            txtSAP = new TextBox();
            txtCISCO = new TextBox();
            txtExam = new TextBox();
            txtTotalOtherFees = new TextBox();

            // Right fees textboxes
            txtModePayment = new TextBox();
            txtInstallmentCharge = new TextBox();
            txtDownPayment = new TextBox();
            txt1stInstallment = new TextBox();
            txt2ndInstallment = new TextBox();
            txt3rdInstallment = new TextBox();

            // Totals
            txtAmountDue = new TextBox();
            txtGrandTotal = new TextBox();
            txtDiscount = new TextBox();

            this.SuspendLayout();

            // MAIN PANEL
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.AutoScroll = true;
            this.Controls.Add(mainPanel);

            // ================= STUDENT INFO =================
            grpStudent.SetBounds(20, 20, 1100, 120);

            Label lblName = new Label() { Text = "Student Name:", Left = 20, Top = 20 };
            txtStudentName.SetBounds(130, 15, 300, 25);

            Label lblNo = new Label() { Text = "Student No.:", Left = 460, Top = 20 };
            txtStudentNo.SetBounds(550, 15, 200, 25);

            Label lblScholar = new Label() { Text = "Scholar:", Left = 780, Top = 20 };
            txtScholar.SetBounds(850, 15, 200, 25);

            Label lblProgram = new Label() { Text = "Program:", Left = 20, Top = 60 };
            cboProgram.SetBounds(130, 55, 300, 25);

            Label lblYear = new Label() { Text = "Year Level:", Left = 460, Top = 60 };
            cboYearLevel.SetBounds(550, 55, 200, 25);

            Label lblMode = new Label() { Text = "Mode:", Left = 780, Top = 60 };
            cboMode.SetBounds(850, 55, 200, 25);

            grpStudent.Controls.AddRange(new Control[]
            {
                lblName, txtStudentName,
                lblNo, txtStudentNo,
                lblScholar, txtScholar,
                lblProgram, cboProgram,
                lblYear, cboYearLevel,
                lblMode, cboMode
            });

            mainPanel.Controls.Add(grpStudent);

            // ================= SCHEDULE =================
            grpSchedule.Text = "Schedule of Course(s)";
            grpSchedule.SetBounds(20, 160, 1100, 300);

            dgvSchedule.Dock = DockStyle.Fill;
            dgvSchedule.ColumnCount = 9;
            dgvSchedule.Columns[0].Name = "Course Code";
            dgvSchedule.Columns[1].Name = "Section";
            dgvSchedule.Columns[2].Name = "Description";
            dgvSchedule.Columns[3].Name = "Lec Units";
            dgvSchedule.Columns[4].Name = "Lab Units";
            dgvSchedule.Columns[5].Name = "Cred Units";
            dgvSchedule.Columns[6].Name = "Time";
            dgvSchedule.Columns[7].Name = "Day";
            dgvSchedule.Columns[8].Name = "Room";
            dgvSchedule.Rows.Add(7);

            grpSchedule.Controls.Add(dgvSchedule);
            mainPanel.Controls.Add(grpSchedule);

            // ================= LEFT FEES =================
            grpFeesLeft.SetBounds(20, 480, 520, 240);

            string[] leftLabels =
            {
                "Total Tuition Fee:",
                "Miscellaneous Fees:",
                "Other School Fees",
                "Com Lab Fee:",
                "SAP Fee:",
                "CISCO Lab Fee:",
                "Exam Booklet Fee:",
                "Total Oth. Fee:"
            };

            TextBox[] leftTextBoxes =
            {
                txtTotalTuition, txtMiscFees, txtOtherFees,
                txtComLab, txtSAP, txtCISCO, txtExam, txtTotalOtherFees
            };

            int y = 20;
            for (int i = 0; i < leftLabels.Length; i++)
            {
                Label lbl = new Label() { Text = leftLabels[i], Left = 20, Top = y };
                leftTextBoxes[i].SetBounds(200, y - 5, 250, 25);
                grpFeesLeft.Controls.Add(lbl);
                grpFeesLeft.Controls.Add(leftTextBoxes[i]);
                y += 28;
            }

            mainPanel.Controls.Add(grpFeesLeft);

            // ================= RIGHT FEES (INSTALLMENT ONLY) =================
            grpFeesRight.Text = "TOTAL TUITION AND FEES";
            grpFeesRight.SetBounds(600, 480, 520, 240);

            string[] rightLabels =
            {
                "Mode of Payment:",
                "Installment Charge:",
                "Downpayment:",
                "1st Installment:",
                "2nd Installment:",
                "3rd Installment:"
            };

            TextBox[] rightTextBoxes =
            {
                txtModePayment, txtInstallmentCharge, txtDownPayment,
                txt1stInstallment, txt2ndInstallment, txt3rdInstallment
            };

            y = 25;
            for (int i = 0; i < rightLabels.Length; i++)
            {
                Label lbl = new Label() { Text = rightLabels[i], Left = 20, Top = y };
                rightTextBoxes[i].SetBounds(200, y - 5, 250, 25);
                grpFeesRight.Controls.Add(lbl);
                grpFeesRight.Controls.Add(rightTextBoxes[i]);
                y += 28;
            }

            mainPanel.Controls.Add(grpFeesRight);

            // ================= BUTTONS =================
            btnCompute.Text = "COMPUTE FEES";
            btnCompute.SetBounds(20, 740, 200, 40);
            btnCompute.Click += btnCompute_Click;

            btnClearStudent.Text = "CLEAR STUDENT INFORMATION";
            btnClearStudent.SetBounds(230, 740, 260, 40);
            btnClearStudent.Click += btnClearStudent_Click;

            btnExit.Text = "EXIT";
            btnExit.SetBounds(20, 790, 200, 40);
            btnExit.Click += btnExit_Click;

            btnClearSchedule.Text = "CLEAR SCHEDULE OF COURSES";
            btnClearSchedule.SetBounds(230, 790, 260, 40);
            btnClearSchedule.Click += btnClearSchedule_Click;

            mainPanel.Controls.AddRange(new Control[]
            {
                btnCompute, btnClearStudent,
                btnExit, btnClearSchedule
            });

            // ================= RIGHT TOTALS (ALIGNED WITH BUTTONS) =================
            Label lblAmountDue = new Label()
            {
                Text = "AMOUNT DUE:",
                Left = 650,
                Top = 750
            };

            txtAmountDue.SetBounds(800, 745, 250, 25);

            Label lblGrandTotal = new Label()
            {
                Text = "GRAND TOTAL:",
                Left = 650,
                Top = 790
            };

            txtGrandTotal.SetBounds(800, 785, 250, 25);

            Label lblDiscount = new Label()
            {
                Text = "Discount:",
                Left = 650,
                Top = 830
            };

            txtDiscount.SetBounds(800, 825, 250, 25);

            mainPanel.Controls.Add(lblAmountDue);
            mainPanel.Controls.Add(txtAmountDue);
            mainPanel.Controls.Add(lblGrandTotal);
            mainPanel.Controls.Add(txtGrandTotal);
            mainPanel.Controls.Add(lblDiscount);
            mainPanel.Controls.Add(txtDiscount);

            // FORM SETTINGS
            this.Text = "Enrollment Form";
            this.Width = 1200;
            this.Height = 950;
            this.ResumeLayout(false);
        }
    }
}