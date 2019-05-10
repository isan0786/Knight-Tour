using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnightTour
{
    public partial class Form1 : Form
    {
         string column="";
         string row = "";
         string method = "";
         string noOfTimes = "";
         string name = "";
        string result = "";
        int counter = 0;
        int moves = 0;
        int times = 0;
        int averageMoves = 0;
        List<double> numbers = new List<double>();



       public Form1()
        {
            InitializeComponent();
        }

    

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                 method = "NonIntelligentMethod";
            }
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                 method = "HeuristicsMethod";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
              name = textBox1.Text;
          
          //  Console.ReadKey();
        }


        private void button1_Click(object sender, EventArgs e)
        {
         //   Console.WriteLine("column is " + column + " row is" + row + " method is" + method + " times is" + noOfTimes + " name is" + name);
            if (row != "" && column != "" && noOfTimes != "" && name != "") {
                if ((Convert.ToInt32(row) >= 0 && Convert.ToInt32(row) <= 7) && (Convert.ToInt32(column) >= 0 && Convert.ToInt32(column) <= 7) && (Convert.ToInt32(noOfTimes) > 0))
                {
                  //  textBox3.Text = "1 to " + noOfTimes.ToString();
                    counter = Convert.ToInt32(noOfTimes);

                    if (method == "HeuristicsMethod")
                    {
                        result = "";
                        while (counter > times)
                        {


                            Choices c = new Choices();

                            Choices.saver += "Chess Board " + (times+1).ToString();
                           //  c.intelligent(5, 5); get full score
                           moves = c.intelligent(Convert.ToInt32(row), Convert.ToInt32(column));

                            numbers.Add(moves);

                            averageMoves += moves;

                         //   Console.WriteLine("------------------------------------ intelli");

                            //  c.intelligent(5, 5); get full score

                            times++;

                            result += "Trial " + times.ToString() + ":   The knight was able to successfully touch " + moves + " squares\r\n\r\n";
                        }
                        times = 0;
                        
                    }
                    else
                    {
                        
                        result = "";
                        
                        while (counter > times)
                        {


                            Choices c = new Choices();

                            Choices.saver += "Chess Board " + (times + 1).ToString();
                            //  c.intelligent(5, 5); get full score
                            moves = Choices.nonIntelligent(Convert.ToInt32(row), Convert.ToInt32(column));
                            numbers.Add(moves);
                            averageMoves += moves;
                         //   Console.WriteLine("------------------------------------ non intelli");

                            //  c.intelligent(5, 5); get full score

                            times++;

                           
                            result += "Trial " + times.ToString() +":   The knight was able to successfully touch " + moves + " squares\r\n\r\n";
                        }

                        times = 0;
                    }
                 //   Console.WriteLine(result);
                    using (StreamWriter Writer = new StreamWriter(name + method + ".txt"))
                    {
                        Writer.WriteLine(result);
                    }
                }
                else
                {
                    Console.WriteLine("The values that you gave are not good enough , Please provide the right input");
                }
            }
            else
            {
                Console.WriteLine("You didn't fill one of the text feild, Please provide the right input");
            }

            averageMoves = averageMoves / Convert.ToInt32(noOfTimes);
            richTextBox1.Text = Choices.saver;
            label8.Text = name;

            if (Convert.ToInt32(noOfTimes) ==2) {
                MessageBox.Show("The average is " + averageMoves);
            }
            if (Convert.ToInt32(noOfTimes) > 2)
            {
                MessageBox.Show("The average is " + averageMoves);
                MessageBox.Show("The standard deviation is " + getStandardDeviation(numbers));
            }
            Choices.saver = "";
            averageMoves = 0;
            numbers.Clear();
        }

      

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            row = comboBox3.Text;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            column = comboBox2.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            noOfTimes = textBox2.Text;
        }

        private double getStandardDeviation(List<double> numbers)
        {
            double averageNums = numbers.Average();
            double DerivationSum = 0;
            foreach (double value in numbers)
            {
              //  Console.WriteLine("standard deviation " + value);
                DerivationSum += (value) * (value);
            }
            double sumOfDerivationAverage = DerivationSum / (numbers.Count - 1);
            return Math.Sqrt(sumOfDerivationAverage - (averageNums * averageNums));
        }



        private void button2_Click(object sender, EventArgs e)
        {

        }

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
