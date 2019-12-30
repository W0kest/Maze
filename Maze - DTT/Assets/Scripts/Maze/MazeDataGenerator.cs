using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeDataGenerator
{
    public float placementThreshold;    //Determines if a space is empty.

    public MazeDataGenerator()
    {
        placementThreshold = 0.1f;
    }

    //Generates the data for the maze.
    public int[,] FromDimensions(int sizeRows, int sizeCols)
    {
        int[,] maze = new int[sizeRows, sizeCols];

        int rMax = maze.GetUpperBound(0);       //Gets the max amount of rows.
        int cMax = maze.GetUpperBound(1);       //Gets the max amount of colums.

        for (int i = 0; i <= rMax; i++)         //This loop goes on as long as there are rows.
        {
            for (int j = 0; j <= cMax; j++)     //This loop goes on as long as there are colums, and the rows didn't run out.
            {
                if (i == 0 || j == 0 || i == rMax || j == cMax) 
                {
                    maze[i, j] = 1;         //This makes a cell on the outer wall.
                }

                else if (i % 2 == 0 && j % 2 == 0)
                {
                    if( Random.value > placementThreshold)
                    {
                        maze[i, j] = 1;     //This makes another wall next to a wall cell, making it a corridor.

                        int a = Random.value < 0.5f ? 0 : (Random.value < 0.5f ? -1 : 1);

                        int b = a != 0 ? 0 : (Random.value < 0.5f ? -1 : 1);
                        maze[i + a, j + b] = 1;
                    }
                }
            }
        }

        return maze;
    }
}
