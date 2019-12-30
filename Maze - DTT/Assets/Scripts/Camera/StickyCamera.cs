using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyCamera : MonoBehaviour
{
    public Camera cam;

    float camPosX, camPosY, camPosZ, camSize;

    //This function makes sure that the camera is always centered on top of the maze.
    public void Sticky()
    {
        camPosX = GameManager.sizeRows;     //Sets the X axis of the camera.
        camPosY = 10;
        camPosZ = GameManager.sizeCols;     //Sets the Z axis of the camera.

        //Centers the camera if the rows and colums are of equal length.
        if (GameManager.sizeRows == GameManager.sizeCols)
        {
            cam.transform.rotation = Quaternion.Euler(90, 270, 0);
            camSize = GameManager.sizeRows - 0.5f; 
        }

        //If the rows are bigger then the colums, use the row value for the camera size.
        else if (GameManager.sizeRows > GameManager.sizeCols)
        {
            cam.transform.rotation = Quaternion.Euler(90, 270, 0);
            camSize = GameManager.sizeRows - 0.5f;
        }

        //If the colums are bigger then the rows, use the colum value for the camera size, and rotate it by 90 degrees.
        else if (GameManager.sizeRows < GameManager.sizeCols)
        {
            cam.transform.rotation = Quaternion.Euler(90, 180, 0);
            camSize = GameManager.sizeCols - 0.5f;
        }

        cam.orthographicSize = camSize;                                     //Sets the camera size.

        cam.transform.position = new Vector3(camPosX, camPosY, camPosZ);    //Changes the camera position.
    }
}
