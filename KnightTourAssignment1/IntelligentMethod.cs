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
        //Intelligent Method.
        int intMvCount = 0;
        int liveRow = 0;
        int liveCol = 0;
        string extContent = "";


        private void startGameIntel(int row, int col)
        {
            int[] runRes = new int[Convert.ToInt32(numGameCount.Value)];
            fillTable();
            fillPriority();
            liveRow = row;
            liveCol = col;
            grid[liveRow, liveCol] = 0;

            for (int rTime = 0; rTime < numGameCount.Value; rTime++)
            {
                tbGameResult.AppendText("-----------------------" + Environment.NewLine);
                for (int i = 0; i < 64; i++)
                {
                    makeMove();

                }

                runRes[rTime] = intMvCount;
                tbGameResult.AppendText("Run : " + (rTime + 1) + " - The knight was able to touch " + intMvCount + " Squares" + Environment.NewLine);
                extContent += "Run : " + (rTime + 1) + " - The knight was able to touch " + intMvCount + " Squares" + Environment.NewLine;
                tbTable.AppendText("-----------------------" + Environment.NewLine);
                tbTable.AppendText("Intelligent Run: " + (rTime + 1) + Environment.NewLine);
                extContent += "Intelligent Run: " + (rTime + 1) + Environment.NewLine;
                tbTable.AppendText("-----------------------" + Environment.NewLine);
                printTable();
                extContent += tableToString();
                fillTable();
                grid[liveRow, liveCol] = 0;
                intMvCount = 0;
            }
            updateGameStat(Convert.ToInt32(numGameCount.Value), runRes);
            createTextFile("valanikevinHeuristicsMethod.txt", extContent);

        }

        private void makeMove()
        {
            int[] pNo = { 99, 99, 99, 99, 99, 99, 99, 99 };
            int[] tempArray = { 99, 99, 99, 99, 99, 99, 99, 99 };

            //Trying to store 8 possible outcomes into an array at given position.
            for (int i = 0; i < 8; i++)
            {
                try
                {
                    if (grid[liveRow + posRows[i], liveCol + posCols[i]] == -1)
                    {
                        tempArray[i] = gridWP[liveRow + posRows[i], liveCol + posCols[i]];
                        pNo[i] = i;
                    }
                }
                catch (System.IndexOutOfRangeException ex)
                {
                    Console.WriteLine("Out Of Bound Exception.");
                }
            }

            int smallestNum = tempArray[0];
            int smallestID = pNo[0];

            for (int i = 1; i < 8; i++)
            {
                if (tempArray[i] < smallestNum)
                {
                    smallestNum = tempArray[i];
                    smallestID = i;
                }
            }

            if (smallestID != 99)
            {
                liveCol = liveCol + posCols[smallestID];
                liveRow = liveRow + posRows[smallestID];
                intMvCount++;
                grid[liveRow, liveCol] = intMvCount;
                //printTable();
            }
        }

        private void fillPriority()
        {
            //All Priorities
            int[] pNum = { 2, 3, 4, 6, 8 };
            for (int i = 0; i < 8; i++)
            {
                if (i == 0 || i == 7)
                {
                    gridWP[i, 0] = pNum[0];
                    gridWP[i, 1] = pNum[1];
                    gridWP[i, 2] = pNum[2];
                    gridWP[i, 3] = pNum[2];
                    gridWP[i, 4] = pNum[2];
                    gridWP[i, 5] = pNum[2];
                    gridWP[i, 6] = pNum[1];
                    gridWP[i, 7] = pNum[0];
                }
                if (i == 1 || i == 6)
                {
                    gridWP[i, 0] = pNum[1];
                    gridWP[i, 1] = pNum[2];
                    gridWP[i, 2] = pNum[3];
                    gridWP[i, 3] = pNum[3];
                    gridWP[i, 4] = pNum[3];
                    gridWP[i, 5] = pNum[3];
                    gridWP[i, 6] = pNum[2];
                    gridWP[i, 7] = pNum[1];
                }
                if (i == 2 || i == 3 || i == 4 || i == 5)
                {
                    gridWP[i, 0] = pNum[2];
                    gridWP[i, 1] = pNum[3];
                    gridWP[i, 2] = pNum[4];
                    gridWP[i, 3] = pNum[4];
                    gridWP[i, 4] = pNum[4];
                    gridWP[i, 5] = pNum[4];
                    gridWP[i, 6] = pNum[3];
                    gridWP[i, 7] = pNum[2];
                }
            }
        }
    }
}
