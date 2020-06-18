using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjectDraggable : MonoBehaviour
{
    private Vector3 v_Offset;
    private float v_zCoordinate;
    public int v_clickedTileId = 0;
    public GameObject emptyTile;
    int i, j;
    private void OnMouseDown()
    {
        //v_zCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        //v_Offset = gameObject.transform.position - GetMouseWorldPos();
        emptyTile = GlobalVariables.v_emptyTileObject;

        v_clickedTileId = gameObject.GetComponent<Tile>().v_TileID;
        Debug.LogError("Inside MouseDown method - Tile clicked: " + v_clickedTileId + " Empty Tile ID: " + emptyTile.GetComponent<Tile>().v_TileID);
        for(int a = 0; a < GlobalVariables.v_gridWidth; a++)
        {
            for(int b = 0; b < GlobalVariables.v_gridWidth; b++)
            {
                if(GlobalVariables.v_2Dlist[a, b] == v_clickedTileId)
                {
                    i = a;
                    j = b;
                    break;
                }
            }
        }




        if ((j - 1) >= 0 && (j - 1) < GlobalVariables.v_gridWidth && GlobalVariables.v_2Dlist[i, j - 1] == -1)
        {
            Debug.LogError("Match Found (Left): " + i + "," + (j - 1));
            //Swap2DListVars(i, j, i, (j - 1));

            //make a function for this
            Vector3 pos1 = gameObject.transform.position;
            Vector3 emptyTilePos1 = pos1;
            pos1.x = pos1.x - 1;
            gameObject.transform.position = pos1;
            emptyTile.transform.position = emptyTilePos1;



            int v_temp = GlobalVariables.v_2Dlist[i, (j - 1)];
            GlobalVariables.v_2Dlist[i, (j - 1)] = GlobalVariables.v_2Dlist[i, j];
            GlobalVariables.v_2Dlist[i, j] = v_temp;

            GlobalVariables.display();
            //break;

        }
        else if ((j + 1) >= 0 && (j + 1) < GlobalVariables.v_gridWidth && GlobalVariables.v_2Dlist[i, j + 1] == -1)
        {
            //Swap2DListVars(i, j, i, (j + 1));


            Debug.LogError("Match Found (right): " + i + "," + (j + 1));
            Vector3 pos2 = gameObject.transform.position;
            Vector3 emptyTilePos2 = pos2;
            pos2.x = pos2.x + 1;
            gameObject.transform.position = pos2;
            emptyTile.transform.position = emptyTilePos2;


            int v_temp = GlobalVariables.v_2Dlist[i, (j + 1)];
            GlobalVariables.v_2Dlist[i, (j + 1)] = GlobalVariables.v_2Dlist[i, j];
            GlobalVariables.v_2Dlist[i, j] = v_temp;
            //break;
        }
        else if ((i - 1) >= 0 && (i - 1) < GlobalVariables.v_gridWidth && GlobalVariables.v_2Dlist[i - 1, j] == -1)
        {
            Debug.LogError("Match Found (up): " + (i - 1) + "," + (j));
            //Swap2DListVars(i, j, (i - 1), j);
            Vector3 pos3 = gameObject.transform.position;
            Vector3 emptyTilePos3 = pos3;
            pos3.y = pos3.y + 1;
            gameObject.transform.position = pos3;
            emptyTile.transform.position = emptyTilePos3;

            int v_temp = GlobalVariables.v_2Dlist[(i - 1), j];
            GlobalVariables.v_2Dlist[(i - 1), j] = GlobalVariables.v_2Dlist[i, j];
            GlobalVariables.v_2Dlist[i, j] = v_temp;
        }
        else if ((i + 1) >= 0 && (i + 1) < GlobalVariables.v_gridWidth && GlobalVariables.v_2Dlist[i + 1, j] == -1)
        {
            Debug.LogError("Match Found (down): " + (i + 1) + "," + (j));
            //Swap2DListVars(i, j, (i + 1), j);
            Vector3 pos4 = gameObject.transform.position;
            Vector3 emptyTilePos4 = pos4;
            pos4.y = pos4.y - 1;
            gameObject.transform.position = pos4;
            emptyTile.transform.position = emptyTilePos4;

            Debug.LogError("EmptyTile: " + GlobalVariables.v_2Dlist[(i + 1), j]);
            Debug.LogError("Tile: " + GlobalVariables.v_2Dlist[(i), j]);
            int v_temp = GlobalVariables.v_2Dlist[(i + 1), j];
            GlobalVariables.v_2Dlist[(i + 1), j] = GlobalVariables.v_2Dlist[i, j];
            GlobalVariables.v_2Dlist[i, j] = v_temp;
            GlobalVariables.displayAll();
            //break;
        }
        else
        {
            Debug.LogError("Match Not Found: " + v_clickedTileId + "Tile x: " + i + " Tile y: " + j);
            GlobalVariables.display();
        }
    }
    private Vector3 GetMouseWorldPos()
    {
        //Gets x,y coordinates
        Vector3 v_MousePointer = Input.mousePosition;
        //Gets only the z coordinate
        v_MousePointer.z = v_zCoordinate;
        return Camera.main.ScreenToWorldPoint(v_MousePointer);
    }
   

    private void Swap2DListVars(int currTileXIndex, int currTileYIndex, int emptyTileXIndex, int emptyTileYIndex)
    {
        int v_temp = GlobalVariables.v_2Dlist[emptyTileXIndex, emptyTileYIndex];
        GlobalVariables.v_2Dlist[emptyTileXIndex, emptyTileYIndex] = GlobalVariables.v_2Dlist[currTileXIndex, currTileYIndex];
        GlobalVariables.v_2Dlist[currTileXIndex, currTileYIndex] = v_temp;
    }



}
