namespace _23521696_Calculator
{
    public partial class Form1 : Form
    {
        Double Value = 0;
        String Operation = "";
        bool Operation_pressed = false;
        bool ErrorOccurred = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (Double.TryParse(textBox.Text, out double number))
            //{
            //    textBox.TextChanged -= textBox1_TextChanged; // Tạm thời loại bỏ sự kiện để tránh vòng lặp
            //    textBox.Text = number.ToString("N0");
            //    textBox.TextChanged += textBox1_TextChanged; // Gắn lại sự kiện
            //}
        }

        private void buttonNum_Click(object sender, EventArgs e)
        {
            if (ErrorOccurred) // If an error occurred, prevent further input
            {
                return;
            }

            if ((textBox.Text == "0") || (Operation_pressed))
            {
                textBox.Clear();
            }
            Operation_pressed = false;
            Button b = (Button)sender;
            textBox.Text = this.textBox.Text + b.Text;
        }

        private void buttonCE_Click(object sender, EventArgs e)
        {
            textBox.Text = "0";
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            if (ErrorOccurred) // Prevent operation if in error state
            {
                return;
            }

            Button B = (Button)sender;
            Operation = B.Text;
            Value = Double.Parse(textBox.Text);
            Operation_pressed = true;
            equation.Text = Value + " " + Operation;
        }
        private void Operator2_Click(object sender, EventArgs e)
        {
            if (ErrorOccurred) // Prevent operation if in error state
            {
                return;
            }

            Button B = (Button)sender;
            Operation = B.Text;
            Value = Double.Parse(textBox.Text);
            Operation_pressed = true;
            equation.Text = Value + " " + "mod";
        }
        private void buttonEqual_Click(object sender, EventArgs e)
        {
            if (ErrorOccurred) // Prevent calculation if in error state
            {
                return;
            }

            try
            {
                equation.Text = "";
                double result = 0;

                switch (Operation)
                {
                    case "+":
                        result = Value + Double.Parse(textBox.Text);
                        break;
                    case "–":
                        result = Value - Double.Parse(textBox.Text);
                        break;
                    case "×":
                        result = Value * Double.Parse(textBox.Text);
                        break;
                    case "÷":
                        if (Double.Parse(textBox.Text) == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        result = Value / Double.Parse(textBox.Text);
                        break;
                    case "%\r\nmod":
                        result = Value % Double.Parse(textBox.Text);
                        break;
                    default:
                        break;
                }

                // Check for overflow/underflow
                if (double.IsInfinity(result))
                {
                    throw new OverflowException("Value out of range");
                }

                textBox.Text = result.ToString();
            }
            catch (DivideByZeroException)
            {
                textBox.Text = "Cannot divide by zero";
                SetErrorState();
            }
            catch (OverflowException ex)
            {
                textBox.Text = ex.Message;
                SetErrorState();
            }
            catch (Exception ex)
            {
                textBox.Text = "Error: " + ex.Message;
                SetErrorState();
            }
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            textBox.Clear();
            textBox.Text = "0";
            Value = 0;
            Operation = "";
            Operation_pressed = false;
            ErrorOccurred = false; // Reset error flag
        }
        private void SetErrorState()
        {
            ErrorOccurred = true; // Set error flag
            Value = 0;
            Operation = "";
            Operation_pressed = false;
        }
        private void buttonPoN_Click(object sender, EventArgs e)
        {
            if (Double.Parse(textBox.Text) > 0)
                textBox.Text = "-" + textBox.Text;
            else if (Double.Parse(textBox.Text) < 0)
                textBox.Text = ( - Double.Parse(textBox.Text)).ToString();
        }
    }
}
