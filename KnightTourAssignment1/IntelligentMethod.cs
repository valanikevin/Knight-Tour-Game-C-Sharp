using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*******************************************
 * Title: Intelligent Version Implementation.
 * Page Documentation:
    1) Purpose: This page is responsible for implementation of intelligent version of game.
        1.1) Non-Intelligent Version followed 'First Come, First Serve' technique which means, if program found empty location, the knight will move there.
        1.2) Intelligent Version follows 'Find Best, Then Serve' technique which means, program will find best location among the empty and at end, 
             the knight will move at that particular location.
        1.3) We will find best location for knight based on the priority. We will try to move knights in corners and less reachable areas on high priority.
        1.4) We do this in order to make knight reach as many squares as possible.
        1.5) In non-intelligent version, the average was 50/64 squares, but in intelligent game, we will target average between 59-64 each time.
    2) Methods:
        2.1) startGameIntel(int, int) -> Input parameters is user-defined start row and col.
            2.1.1) Sets everything to default before starting game. Such as counter will be defaulted to 0;
        2.2) makeMove() -> Will find the best move and make move.
        2.3) fillPriority() - > We have array of 8*8 which is meant to store priority of the grid. This method is actually setting priority inside the array.
    3) Notes: 
        3.1) As this is partial class, some of the functionality and business login maybe located at another partial class.
 
 *******************************************/

namespace KnightTourAssignment1
{
    public partial class Form1 : Form
    {
        //>>>Global Variables
        int intMvCount = 0;
        int liveRow = 0;
        int liveCol = 0;
        string extContent = "";


        private void startGameIntel(int row, int col)
        {
            int[] runRes = new int[Convert.ToInt32(numGameCount.Value)]; // Run Result.
            fillTable(); //Fill Table With Default Value -1
            fillPriority(); //Fill Priority Table With Default Values. 
            liveRow = row;  //liveRow Is Now User Defined Start Row.
            liveCol = col;  //liveCol Is Now USer Defined Start Col.
            grid[liveRow, liveCol] = 0; //User-Defined Row & Col is now set to 0 in Table. 

            for (int rTime = 0; rTime < numGameCount.Value; rTime++) 
            {
                tbGameResult.AppendText("-----------------------" + Environment.NewLine); //tbGameResult is placeholder on GUI for displaying game Results.
                for (int i = 0; i < 64; i++)
                {
                    makeMove(); //We are making moves 64 times in the table because 64 is the maximum times knight can move. 

                }

                //Below is just printing results and outputing result to text file that is to be generated and stored locally.
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
            //Game stat method will calculate avg, total move, std. deviation.
            updateGameStat(Convert.ToInt32(numGameCount.Value), runRes);
            //Generating text file.
            createTextFile("valanikevinHeuristicsMethod.txt", extContent);

        }

        private void makeMove()
        {
            int[] pNo = { 99, 99, 99, 99, 99, 99, 99, 99 };
            int[] tempArray = { 99, 99, 99, 99, 99, 99, 99, 99 };

            //Trying to store 8 possible outcomes into an array at given position.
            for (int i = 0; i < 8; i++)
            {
                //Try-Catch to ignore out of bound moves.
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
            //Finding smallest number.
            for (int i = 1; i < 8; i++)
            {
                if (tempArray[i] < smallestNum)
                {
                    smallestNum = tempArray[i];
                    smallestID = i;
                }
            }

            //Making actual move.
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
