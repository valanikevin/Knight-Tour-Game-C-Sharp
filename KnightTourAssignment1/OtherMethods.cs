using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*******************************************
 * Title: Game Supporting Method (Utility Methods) Implementation
 * Page Documentation:
 *      1) Purpose: Implement methods which are essential for entire program to function.
 *      2) Algorithm: No Algorithm Used.
 *****************************************/
namespace KnightTourAssignment1
{

    public partial class Form1 : Form
    {
        //The Main Grid.
        private int[,] grid = new int[9, 9];
        //The Priority Grid For Intelligent Version.
        private int[,] gridWP = new int[9, 9];
        //All Possible Moves.
        static int[] posRows = { -2, -2, -1, -1, +1, +1, +2, +2 };
        static int[] posCols = { -1, +1, -2, +2, -2, +2, -1, +1 };
        private void createTextFile(string fileName, string eContent)
        {
            string content = eContent + " " + tableToString();
            string path = fileName;
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path);
                    TextWriter tw = new StreamWriter(path);
                    tw.WriteLine("Fra nnsmsjwm");
                    tw.Close();
                }
                else if (File.Exists(path))
                {
                    File.Delete(fileName);
                    using (var tw = new StreamWriter(path, true))
                    {
                        tw.WriteLine(content);
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void updateGameStat(int totalRun, int[] runRes)
        {
            double sum = 0;
            for (int i = 0; i < runRes.Length; i++)
            {
                sum = sum + runRes[i];
            }
            sum = Math.Round(sum / totalRun, 2);
            tbTotalRun.Text = "" + totalRun;
            tbAverage.Text = "" + sum;
            double std = calculateSD(runRes, sum, totalRun);
            std = Math.Round(std, 2);
            tbStdDev.Text = "" + std;

        }

        private double calculateSD(int[] runRes, double sum, int totalRun)
        {
            double sd = 0;
            double mean = sum / totalRun;
            for (int i = 0; i < totalRun; i++)
            {
                sd = sd + Math.Pow(runRes[i] - mean, 2);
            }
            return Math.Sqrt(sd / totalRun);
        }

        private void printTable()
        {
            string temp = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (grid[i, j] == -1)
                    {
                        tbTable.AppendText(String.Format("{0, 8}", "N"));
                        temp = String.Format("{0, 8}", "N");
                    }
                    else
                    {
                        tbTable.AppendText(String.Format("{0, 8}", grid[i, j]));
                        temp = String.Format("{0, 8}", grid[i, j]);
                    }
                }
                tbTable.AppendText(Environment.NewLine);
                tbTable.AppendText(Environment.NewLine);
                temp = Environment.NewLine;
                temp = Environment.NewLine;
            }
        }

        private string tableToString()
        {
            string temp = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (grid[i, j] == -1)
                    {
                        temp += String.Format("{0, 8}", "N");
                    }
                    else
                    {
                        temp += String.Format("{0, 8}", grid[i, j]);
                    }
                }
                temp += Environment.NewLine;
                temp += Environment.NewLine;
            }

            return temp;
        }

        private void printPriority()
        {
            string temp = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    tbTable.AppendText(String.Format("{0, 8}", gridWP[i, j]));
                }
                tbTable.AppendText(Environment.NewLine);
                tbTable.AppendText(Environment.NewLine);
            }
        }


        private void fillTable()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    grid[i, j] = -1;
                }
            }
        }
    }
}
