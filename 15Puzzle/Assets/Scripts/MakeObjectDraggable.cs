using System;
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
        //Debug.LogError("Inside MouseDown method - Tile clicked: " + v_clickedTileId + " Empty Tile ID: " + emptyTile.GetComponent<Tile>().v_TileID);
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
            //Debug.LogError("Match Found (Left): " + i + "," + (j - 1));
            

            //make a function for this
            Vector3 pos1 = gameObject.transform.position;
            Vector3 emptyTilePos1 = pos1;
            pos1.x = pos1.x - 1;
            gameObject.transform.position = pos1;
            emptyTile.transform.position = emptyTilePos1;

            Swap2DListVars(i, j, i, (j - 1));
            //break;

        }
        else if ((j + 1) >= 0 && (j + 1) < GlobalVariables.v_gridWidth && GlobalVariables.v_2Dlist[i, j + 1] == -1)
        {
            //Debug.LogError("Match Found (right): " + i + "," + (j + 1));
            Vector3 pos2 = gameObject.transform.position;
            Vector3 emptyTilePos2 = pos2;
            pos2.x = pos2.x + 1;
            gameObject.transform.position = pos2;
            emptyTile.transform.position = emptyTilePos2;

            Swap2DListVars(i, j, i, (j + 1));
            //break;
        }
        else if ((i - 1) >= 0 && (i - 1) < GlobalVariables.v_gridWidth && GlobalVariables.v_2Dlist[i - 1, j] == -1)
        {
            //Debug.LogError("Match Found (up): " + (i - 1) + "," + (j));
            
            Vector3 pos3 = gameObject.transform.position;
            Vector3 emptyTilePos3 = pos3;
            pos3.y = pos3.y + 1;
            gameObject.transform.position = pos3;
            emptyTile.transform.position = emptyTilePos3;

            Swap2DListVars(i, j, (i - 1), j);
        }
        else if ((i + 1) >= 0 && (i + 1) < GlobalVariables.v_gridWidth && GlobalVariables.v_2Dlist[i + 1, j] == -1)
        {
            //Debug.LogError("Match Found (down): " + (i + 1) + "," + (j));
            
            Vector3 pos4 = gameObject.transform.position;
            Vector3 emptyTilePos4 = pos4;
            pos4.y = pos4.y - 1;
            gameObject.transform.position = pos4;
            emptyTile.transform.position = emptyTilePos4;

            Swap2DListVars(i, j, (i + 1), j);
            //break;
        }
        else
        {
            int dist = 0;
            for(int a = 0; a < GlobalVariables.v_gridWidth; a++)
            {
                
                if (GlobalVariables.v_2Dlist[i, a] == -1) //horizontal
                {
                    Debug.Log(GlobalVariables.v_AllTiles2DArray[i, (j)].GetComponent<Tile>().v_TileID + ">>>> " + i + ", " + j );
                    Debug.Log(GlobalVariables.v_AllTiles2DArray[i, a].GetComponent<Tile>().v_TileID + ">>>> " + i + ", " + a);
                    dist = (a - j);
                    if(dist < 0)
                    {
                        int val = Math.Abs(dist);
                        for (int b = 0; b < val; b++)
                        {
                            Vector3 pos5 = GlobalVariables.v_AllTiles2DArray[i, (j - b)].transform.position;
                            Vector3 emptyTilePos5 = emptyTile.transform.position;
                            pos5.x = pos5.x - 1;
                            emptyTilePos5.x = emptyTilePos5.x + 1;
                            GlobalVariables.v_AllTiles2DArray[i, (j - b)].transform.position = pos5;
                            emptyTile.transform.position = emptyTilePos5;
                            //Swap2DListVars(i, (j - b), i, (a + b));
                            //Swap2DListVars(i, (GlobalVariables.v_gridWidth + dist + b), i, (a + b));
                            //Swap2DTilesListVars(i, (GlobalVariables.v_gridWidth + dist + b), i, (a + b));
                            //Debug.Log("i, (j - (b + dist)) " + i + "," + (j - (b + val)) + " :::: " + (GlobalVariables.v_gridWidth + dist + b));
                            //Debug.Log("i, (a + b) " + i + "," + (a + b));
                            //Debug.Log(GlobalVariables.v_AllTiles2DArray[i, (j - b)].GetComponent<Tile>().v_TileID);
                        }
                       
                        for(int b = val - 1; b >= 0; b--)
                        {
                            Debug.Log(GlobalVariables.v_AllTiles2DArray[i, (j - b)].GetComponent<Tile>().v_TileID);
                            Debug.Log("Swap 1: " + i + ", " + (j - b) + " Swap 2: " + i + ", " + (j - b - 1));
                            //Swap2DListVars(i, (GlobalVariables.v_gridWidth + dist + b), i, (a + b)); //THIS IS WRONG CHANGE THIS IF POSSIBLE. THIS IS MESSING EVERYTHING UP
                            Swap2DListVars(i, (j - b), i, (j - b - 1));
                        }
                        GlobalVariables.displayAllTiles();
                        Debug.LogError(":::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                        GlobalVariables.displayAll();
                        break;
                        //GlobalVariables.displayAllTiles();
                        //Debug.LogError("In else dist is -ve: " + i + "," + a + " ::: " + dist );
                    }
                    else if(dist > 0)
                    {
                        int val = Math.Abs(dist);
                        for (int b = 0; b < val; b++)
                        {
                            Vector3 pos6 = GlobalVariables.v_AllTiles2DArray[i, (j + b)].transform.position;
                            Vector3 emptyTilePos6 = emptyTile.transform.position;
                            pos6.x = pos6.x + 1;
                            emptyTilePos6.x = emptyTilePos6.x - 1;
                            GlobalVariables.v_AllTiles2DArray[i, (j + b)].transform.position = pos6;
                            emptyTile.transform.position = emptyTilePos6;

                            //Swap2DListVars(i, (GlobalVariables.v_gridWidth - dist + b + 1), i, (a - b));
                            //Swap2DTilesListVars(i, (GlobalVariables.v_gridWidth - dist + b + 1), i, (a - b));
                            //Swap2DListVars(i, (j + b), i, (a - b));
                            //Swap2DListVars(i, (j + a - (b + 1)), i, (a - b));
                            //Debug.Log("i, (j - (b + dist)) " + i + "," + (j - (b + val)) + " :::: " + (GlobalVariables.v_gridWidth + dist + b));
                            //Debug.Log("i, (a + b) " + i + "," + (a + b));
                            //GlobalVariables.displayAll();
                            Debug.Log(GlobalVariables.v_AllTiles2DArray[i, (j + b)].GetComponent<Tile>().v_TileID);
                        }
                        for (int b = val - 1; b >= 0; b--)
                        {
                            Debug.Log("Swap 1: " + i + ", " + (j + b) + " Swap 2: " + i + ", " + (j + b + 1));
                            //Swap2DListVars(i, (j + a - (b + 1)), i, (a - b)); //THIS IS WRONG CHANGE THIS IF POSSIBLE. THIS IS MESSING EVERYTHING UP
                            Swap2DListVars(i, (j + b), i, (j + b + 1));
                        }
                        GlobalVariables.displayAllTiles();
                        Debug.LogError(":::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                        GlobalVariables.displayAll();
                        break;
                        //GlobalVariables.displayAllTiles();
                        //Debug.LogError("In else dist is +ve: " + i + "," + a + " ::: " + dist);
                    }
                    
                }else if(GlobalVariables.v_2Dlist[a, j] == -1)
                {
                    Debug.Log(GlobalVariables.v_AllTiles2DArray[i, (j)].GetComponent<Tile>().v_TileID + ">>>> " + i + ", " + j);
                    Debug.Log(GlobalVariables.v_AllTiles2DArray[a, j].GetComponent<Tile>().v_TileID + ">>>> " + a + ", " + j);
                    dist = (a - i);
                    if (dist < 0)
                    {
                        int val = Math.Abs(dist);
                        for (int b = 0; b < val; b++)
                        {
                            Vector3 pos6 = GlobalVariables.v_AllTiles2DArray[(i - b), j].transform.position;
                            Vector3 emptyTilePos6 = emptyTile.transform.position;
                            pos6.y = pos6.y + 1;
                            emptyTilePos6.y = emptyTilePos6.y - 1;
                            GlobalVariables.v_AllTiles2DArray[(i - b), j].transform.position = pos6;
                            emptyTile.transform.position = emptyTilePos6;
                            //Swap2DListVars((i - b), j, (a + b), j);
                            //Swap2DListVars((GlobalVariables.v_gridWidth + dist + b),j,(a + b), j);
                            Debug.Log(GlobalVariables.v_AllTiles2DArray[(i - b), j].GetComponent<Tile>().v_TileID);
                        }
                        for (int b = val - 1; b >= 0; b--)
                        {
                            Debug.Log("Swap 1: " + (i - b) + ", " + (j) + " Swap 2: " + (i - b - 1) + ", " + (j));
                            //Swap2DListVars((GlobalVariables.v_gridWidth + dist + b), j, (a + b), j); //THIS IS WRONG CHANGE THIS IF POSSIBLE. THIS IS MESSING EVERYTHING UP
                            Swap2DListVars(((i - b)), j, (i - b - 1), j);
                        }
                        GlobalVariables.displayAllTiles();
                        Debug.LogError(":::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                        GlobalVariables.displayAll();
                        break;
                        //GlobalVariables.displayAll();
                        //Debug.LogError("In else dist is negative: " + a + "," + j + " ::: " + dist);
                    }
                    else if (dist > 0)
                    {
                        int val = Math.Abs(dist);
                        for (int b = 0; b < val; b++)
                        {
                            Vector3 pos6 = GlobalVariables.v_AllTiles2DArray[(i + b), j].transform.position;
                            Vector3 emptyTilePos6 = emptyTile.transform.position;
                            pos6.y = pos6.y - 1;
                            emptyTilePos6.y = emptyTilePos6.y + 1;
                            GlobalVariables.v_AllTiles2DArray[(i + b), j].transform.position = pos6;
                            emptyTile.transform.position = emptyTilePos6;
                            //Swap2DListVars((i + b), j, (a - b), j);
                            //Swap2DListVars((i + a - (b + 1)), j, (a - b), j);
                            //
                            Debug.Log(GlobalVariables.v_AllTiles2DArray[(i + b), j].GetComponent<Tile>().v_TileID);
                        }
                        for (int b = val - 1; b >= 0; b--)
                        {
                            Debug.Log("Swap 1: " + (i + b) + ", " + j + " Swap 2: " + (i + b + 1) + ", " + j);
                            //Swap2DListVars((i + a - (b + 1)), j, (a - b), j); //THIS IS WRONG CHANGE THIS IF POSSIBLE. THIS IS MESSING EVERYTHING UP
                            Swap2DListVars((i + b), j, (i + b + 1), j);
                        }
                        GlobalVariables.displayAllTiles();
                        Debug.LogError(":::::::::::::::::::::::::::::::::::::::::::::::::::::::");
                        GlobalVariables.displayAll();
                        break;
                        
                        //Debug.LogError("In else dist is positive" + a + "," + j + " ::: " + dist);
                    }
                    break;
                    
                }
            }
            
            Debug.LogError("Match Not Found: " + v_clickedTileId + "Tile x: " + i + " Tile y: " + j);
            //GlobalVariables.display();
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
   
    private int c = 0;
    private void Swap2DListVars(int currTileXIndex, int currTileYIndex, int emptyTileXIndex, int emptyTileYIndex)
    {
        Debug.LogError("currTileXIndex: " + currTileXIndex + " currTileYIndex: " + currTileYIndex + " emptyTileXIndex: " + emptyTileXIndex + " emptyTileYIndex: " + emptyTileYIndex);
        
        int v_temp = GlobalVariables.v_2Dlist[emptyTileXIndex, emptyTileYIndex];
        GlobalVariables.v_2Dlist[emptyTileXIndex, emptyTileYIndex] = GlobalVariables.v_2Dlist[currTileXIndex, currTileYIndex];
        GlobalVariables.v_2Dlist[currTileXIndex, currTileYIndex] = v_temp;


        GameObject v_temp1 = GlobalVariables.v_AllTiles2DArray[emptyTileXIndex, emptyTileYIndex];
        GlobalVariables.v_AllTiles2DArray[emptyTileXIndex, emptyTileYIndex] = GlobalVariables.v_AllTiles2DArray[currTileXIndex, currTileYIndex];
        GlobalVariables.v_AllTiles2DArray[currTileXIndex, currTileYIndex] = v_temp1;
        c++;
    }

    private void Swap2DTilesListVars(int currTileXIndex, int currTileYIndex, int emptyTileXIndex, int emptyTileYIndex)
    {
        //Debug.LogError("currTileXIndex: " + currTileXIndex + " currTileYIndex: " + currTileYIndex + " emptyTileXIndex: " + emptyTileXIndex + " emptyTileYIndex: " + emptyTileYIndex);
        
    }



}
