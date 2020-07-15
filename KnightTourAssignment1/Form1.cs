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

namespace KnightTourAssignment1
{
    public partial class Form1 : Form
    {
        //This Partial Class is acting as a router.
        //All other methods are located in appropriate partial classes.


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tbTable.Text = "Thank you for coming here."+Environment.NewLine+"Let me introduce myself"+Environment.NewLine+"" +
                "Name: Kevin Valani"+Environment.NewLine+"Sheridan ID: 991545215"+Environment.NewLine+"Food I Love: Gulab Jamun"+Environment.NewLine+"Okay, that's all, let's " +
                "run the code."+Environment.NewLine+"Choose Game Mode From Left Side Dock and Hit Button."+Environment.NewLine;
                
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbTable.Text = "Thank you for coming here." + Environment.NewLine + "Let me introduce myself" + Environment.NewLine + "" +
                 "Name: Kevin Valani" + Environment.NewLine + "Sheridan ID: 991545215" + Environment.NewLine + "Food I Love: Gulab Jamun" + Environment.NewLine + "Okay, that's all, let's " +
                 "run the code." + Environment.NewLine + "Choose Game Mode From Left Side Dock and Hit Button." + Environment.NewLine;
            tbGameResult.Text = "";
            tbTotalRun.Text = "0";
            tbAverage.Text = "0";
            tbStdDev.Text = "0";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tbGameResult.Text = "";
            tbTable.Text = "";
            gameNonIntel();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            tbGameResult.Text = "";
            tbTable.Text = "";

            startGameIntel(Convert.ToInt32(numStartRow.Value), Convert.ToInt32(numStartCol.Value));
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }

    
}
