using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeConstructor : MonoBehaviour
{
    private MazeDataGenerator dataGen;
    private MazeMeshGenerator meshGen;

    public bool showDebug;  //If you switch this one, you'll see the maze layout in string version on the game screen.

    [SerializeField] private Material Floor;
    [SerializeField] private Material Wall;

    public int[,] data
    {
        get; private set;
    }

    private void Awake()
    {
        dataGen = new MazeDataGenerator();
        meshGen = new MazeMeshGenerator();
    }

    //Creates a visual version of the maze.
    private void DisplayMaze()
    {
        GameObject go = new GameObject();
        go.transform.position = Vector3.zero;   //Sets the position of the object to 0, 0, 0.
        go.name = "Procedural Maze";            //Names the instantiated object.
        go.tag = "Generated";                   //Gives the instantiated object a tag.

        MeshFilter mf = go.AddComponent<MeshFilter>();
        mf.mesh = meshGen.FromData(data);

        MeshCollider mc = go.AddComponent<MeshCollider>();
        mc.sharedMesh = mf.mesh;

        MeshRenderer mr = go.AddComponent<MeshRenderer>();
        mr.materials = new Material[2] 
        {
            Floor, Wall
        };
    }

    //Takes the data from the MazeDataGenerator, and uses it to generate a maze. The DisplayMaze function makes it visual.
    public void GenerateNewMaze(int sizeRows, int sizeCols)
    {
        data = dataGen.FromDimensions(sizeRows, sizeCols);
        DisplayMaze();
    }

    //This entire function is to show the maze in a string version.
    private void OnGUI()
    {
        if(!showDebug)
        {
            return;
        }

        int[,] maze = data;
        int rMax = maze.GetUpperBound(0);           //Gets the max amount of rows.
        int cMax = maze.GetUpperBound(1);           //Gets the max amount of colums.

        string msg = "";

        for (int i = rMax; i >= 0; i--)             //Checks to see if there are still some rows.
        {
            for (int j = 0; j <= cMax; j++)         //Checks to see if there are still some colums.
            {
                if (maze[i, j] == 0)
                {
                    msg += "....";                  //This symbolises a floor.
                }

                else
                {
                    msg += "==";                    //This symbolises a wall.
                }
            }
            msg += "\n";                            //If it reaches the edge of a line, it goes to the next.
        }
        GUI.Label(new Rect(20, 20, 500, 500), msg); //Creates a square where the string version of the maze is printed on.
    }
}
