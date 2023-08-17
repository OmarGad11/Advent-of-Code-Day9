# Advent-of-Code-Day9

This project contains a C# solution for solving the LavaTube puzzle, which involves processing a height map and finding various properties of basins and risk levels.

## Getting Started

Follow these instructions to build, run, and test the LavaTube puzzle solution.

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 5.0 or higher) must be installed.

## Clone this repository

Open a terminal and navigate to the directory where you want to clone the repository. Then, run the following command to clone the repository:
```bash
git clone https://github.com/OmarGad11/Advent-of-Code-Day9.git
````
## Building the Project

Open a terminal and navigate to the root directory of the project (`Advent-of-Code-Day9`). To build the project, execute the following commands:
```bash
cd Advent-of-Code-Day9
dotnet clean
dotnet build
````
## Running the Project
To display the algorithm output, execute the following command:
```bash
dotnet run HeightMap.txt (or any other file path contains the desired input)
````
##Expected output
Risk level sum: ...
Largest basins product: ...

##Running Unit test 
To run the unit tests for the LavaTube puzzle solver, navigate to the LavaTube.Tests directory to run the tests. To do that execute the following commands:
```Bash
cd LavaTube.Tests
dotnet test
````
##Important Code Functions
###Here are some important code functions and classes in the project:

##PuzzleSolution
The PuzzleSolution class is responsible for solving the LavaTube puzzle. It processes the height map, finds low points, calculates risk levels, and determines the largest basins.

##FindBasins()
This method in the PuzzleSolution class uses a breadth-first search (BFS) approach to find basins and their sizes. It starts from each low point and explores adjacent cells with heights greater than or equal to the current cell's height.

##GetRiskLevelSum()
This method calculates the risk level sum by iterating through the low points and adding the current cell's value plus one to the sum.

##GetNeighbors(int row, int col)
This method returns a list of neighboring cell values for a given row and column. It is used to calculate the neighbors' values for each cell.
