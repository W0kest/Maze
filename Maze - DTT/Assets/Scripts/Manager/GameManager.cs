using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MazeConstructor))]

public class GameManager : MonoBehaviour
{
    private MazeConstructor generator;
    private StickyCamera stickyCam;
    private GameObject generatedMaze;

    public static int sizeRows = 15;    //This value is the length of the maze.
    public static int sizeCols = 15;    //This value is the width of the maze.

    // Start is called before the first frame update
    void Start()
    {
        generator = GetComponent<MazeConstructor>();    //Gets the script component that generates the maze
        stickyCam = GetComponent<StickyCamera>();
        BeginMaze();
    }

    private void BeginMaze()
    {
        generator.GenerateNewMaze(sizeRows, sizeCols);  //Generates the entire maze
        stickyCam.Sticky();                             //The Sticky function makes sure that the camera is centered above the maze.
    }

    public void RegenerateMaze()
    {
        generatedMaze = GameObject.FindGameObjectWithTag("Generated");  //Gets the generated maze.

        Destroy(generatedMaze.gameObject);                              //Destroys the generated maze.
        BeginMaze();                                                    //And the cycle starts over.
    }

    //Increases the size of the maze by an extra row and colum.
    public void IncreaseSize()
    {
        sizeRows++;
        sizeCols++;
        RegenerateMaze();
    }

    //Decreases the size of the maze by an extra row and colum.
    public void DecreaseSize()
    {
        sizeRows--;
        sizeCols--;
        RegenerateMaze();
    }
}
