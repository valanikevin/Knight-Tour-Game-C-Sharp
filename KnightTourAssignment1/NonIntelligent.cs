using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnightTourAssignment1
{
    public partial class Form1 : Form
    {
        private void gameNonIntel()
        {
            fillTable();
            int curRow = Convert.ToInt32(numStartRow.Value);
            int curCol = Convert.ToInt32(numStartCol.Value);
            int movCounter = 0;
            grid[curRow, curCol] = 0;
            int[] runRes = new int[Convert.ToInt32(numGameCount.Value)];
            string extraContent = "";

            for (int rTimes = 0; rTimes < numGameCount.Value; rTimes++)
            {
                tbTable.AppendText("-----------------------" + Environment.NewLine);
                extraContent += "-----------------------" + Environment.NewLine;
                tbTable.AppendText("Non Intelligent Run: " + (rTimes + 1) + Environment.NewLine);
                extraContent += "Non Intelligent Run: " + (rTimes + 1) + Environment.NewLine;
                tbTable.AppendText("-----------------------" + Environment.NewLine);
                extraContent += "-----------------------" + Environment.NewLine;
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        try
                        {
                            if (grid[curRow + posRows[j], curCol + posCols[j]] == -1)
                            {
                                movCounter++;
                                grid[curRow + posRows[j], curCol + posCols[j]] = movCounter;
                                curRow = curRow + posRows[j];
                                curCol = curCol + posCols[j];
                                
                            }

                        }
                        catch (System.IndexOutOfRangeException e)
                        {
                            //This is my best use of Try-Catch Block in my entire life.
                            //This try-catch saved me from writing so many if-else conditions.
                            Console.WriteLine("Out Of Bound Exception");
                        }
                    }

                }
                extraContent += tableToString();
                tbGameResult.AppendText("Run: " + (rTimes + 1) + " Knight Was Able To Touch: " + movCounter + " Squares." + Environment.NewLine);
                extraContent += "Run: " + (rTimes + 1) + " Knight Was Able To Touch: " + movCounter + " Squares." + Environment.NewLine;
                createTextFile("valanikevinNonIntelligentMethod.txt", extraContent);
                runRes[rTimes] = movCounter;
                movCounter = 0;
                printTable();
                fillTable();
                grid[curRow, curCol] = 0;
            }
            updateGameStat(Convert.ToInt32(numGameCount.Value), runRes);
            createTextFile("valanikevinNonIntelligentMethod.txt", extraContent);

        }

    }
}
