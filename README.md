# Knight Tour Game in C#

One of the more interesting puzzles for chess buffs is the Knight's Tour problem, originally proposed by the mathematician Euler. The question is this: Can the chess piece called the knight move around an empty chessboard and touch each of the 64 squares once and only once? The knight makes L-shaped moves (over two in on direction and then over one in perpendicular direction). Thus, from a square in the middle of an empty chessboard, the knight can make eight different moved (numbered 0 through 7) as shown below.

![KnightTourGamePuzzle1](https://user-images.githubusercontent.com/36758614/88225812-1e31be00-cc39-11ea-9141-ff55356be937.PNG)

One way is to use first-come-first-serve method, which is non-intelligent method and moves knight whenever the box is empty.

One other way to improve success is to use a heuristic (strategy) for moving the knight. Heuristics do not guarantee success, but a carefully developed heuristic generally improves the chance of success. In this method, knight moves to the corners first and based on the priority. The priority grid is shown below. 

![KnightTourGamePuzzle2](https://user-images.githubusercontent.com/36758614/88226150-a912b880-cc39-11ea-96c9-f77e71136d49.PNG)

### This program will illustrate both the methods.

## Program Explanation
1. GUI will be used for the illustration of working of both the algorithms.
2. Program will prompt for number of time game should run.
3. Program will prompt for number of start row and col.
4. Press Intelligent or Non-Intelligent button to run respective version of game.

## Screenshots
![KnightTourGameScreenshot](https://user-images.githubusercontent.com/36758614/88226484-21797980-cc3a-11ea-85fb-9a2916d8531e.PNG)


## Requirements
1. Windows Computer.
2. Visual Studio Community/Professional.
3. Brain.

## Installation

1. Clone project or download zip.
2. Open .sln file. (Solution File)
3. Build project.
4. Run Project.

## Common Visual Studio Errors
###  1) .csproj file has been moved or deleted: 
This sometimes happens when you have cloned project that was built on another Visual Studio Version with different user.
- Solution: 
1. Completely Close Visual Studio. (Very Important)
2. On the main project directory, look for .vs hidden folder, navigate inside and find .suo file.
3. Delete .suo file.
4. Load .sln file again.
5. If error is still present.
6. Open .csproj file inside Project Directory.


