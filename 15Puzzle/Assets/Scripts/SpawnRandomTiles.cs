using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomTiles : MonoBehaviour
{
    public GameObject v_OriginalTile;
    public bool v_onlyOnce = false;
    public int v_NumberOfTilesToSpawn=0;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateTiles();
        v_onlyOnce = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.v_NewGame)
        {
            //If a new game is requestion, then spawn new tiles to start game
            InstantiateTiles();

            

        }
        
        if (!v_onlyOnce && GlobalVariables.v_grid.Count == 16)
        {
            List<int> v_newGrid = new List<int>();
            for(int b = 0; b < GlobalVariables.v_grid.Count; b++)
            {
                if(GlobalVariables.v_grid[b] != -1)
                {
                    v_newGrid.Add(GlobalVariables.v_grid[b]);
                }
                
            }
            Debug.Log(v_newGrid.Count);
            for (int a = 0; a < GlobalVariables.v_grid.Count; a++)
            {
                double emptyTileRow;
                if (GlobalVariables.v_grid[a] == -1)
                {
                    Debug.Log("GlobalVariables.v_grid: " + GlobalVariables.v_grid[a]);
                    emptyTileRow = ((double)a) / 4;
                    emptyTileRow = 4 - Math.Floor(emptyTileRow);
                    int inversionCount = 0;
                    if((int)(emptyTileRow % 2) == 0) //even row
                    {
                        Debug.Log("Even Row: " + emptyTileRow);
                        for(int c = 0; c < v_newGrid.Count; c++)
                        {
                            for (int d = c + 1; d < v_newGrid.Count; d++)
                            {
                                if (d < v_newGrid.Count && v_newGrid[c] > v_newGrid[d])
                                {
                                    inversionCount++;
                                }

                            }
                            Debug.Log("InversionCount for : " + v_newGrid[c] + " : " + inversionCount);
                        }
                        if (inversionCount % 2 == 1) //If inversions are odd then solvable
                        {
                            Debug.Log("InversionCount: " + inversionCount);
                        }
                        else
                        {
                            Debug.Log("unsolvable: " + inversionCount);
                            for (int i = 0; i < v_NumberOfTilesToSpawn; i++)
                            {
                                Destroy(gameObject);
                            }
                            //InstantiateTiles();
                        }
                        

                    }else if((int)(emptyTileRow % 2) == 1) //odd row
                    {
                        Debug.Log("Odd Row: " + emptyTileRow);
                        for (int c = 0; c < v_newGrid.Count; c++)
                        {
                            for(int d = c + 1; d < v_newGrid.Count; d++)
                            {
                                if (d < v_newGrid.Count && v_newGrid[c] > v_newGrid[d])
                                {
                                    inversionCount++;
                                }

                            }
                            Debug.Log("InversionCount for : " + v_newGrid[c] + " : " + inversionCount);


                        }
                        if(inversionCount % 2 == 0) //If inversions are even then solvable
                        {
                            Debug.Log("Total InversionCount: " + inversionCount);
                        }
                        else
                        {
                            Debug.Log("unsolvable: " + inversionCount);
                            
                            //InstantiateTiles();
                        }
                        Debug.Log("InversionCount: " + inversionCount);
                    }else
                    {
                        Debug.Log("In else block: " + emptyTileRow + " " + emptyTileRow % 2);
                    }
           
                }
                
            }
            v_onlyOnce = true;

        }
    }

    private void InstantiateTiles()
    {
        int v_xPosition = 1, v_yPosition=0;
        bool v_NotFirstEntrance = false;
        
        for (int i=0;i<v_NumberOfTilesToSpawn;i++)//Iterates through the desired number of tiles and spawns it.
        {
             
            if (GlobalVariables.v_UserDifficultyLevel == "Beginner")//If the user is Intermediate level, we spawn 16 tile games (Including empty tile)
            {
                GlobalVariables.v_NumberOfTilesToLoad = 16;

                
                //Checks every 4th number, and makes the  5th number the new row
                if (i % 4== 0)
                {
                    v_xPosition = 0;
                    if (v_NotFirstEntrance)
                    {
                        v_yPosition = v_yPosition - 1;
                    }
                    v_NotFirstEntrance = true;
                }
                //Changes X and Y position of the tile to make it spawn to theright or on a new roww
                Vector3 v_tempPosition = new Vector3(v_OriginalTile.transform.position.x+ v_xPosition, v_OriginalTile.transform.position.y+v_yPosition, v_OriginalTile.transform.position.z);
                //Do not spawn first tile, since our master/original tile will always be on the board
                if (i!=0)
                {
                    Instantiate(v_OriginalTile, v_tempPosition, Quaternion.identity);

                }
                //Increase position so we know where to spawn the next tile horizontally.
                v_xPosition++;
            }
            
        }

        //Debug.Log(GlobalVariables.v_grid.Count);
        //for (int a = 0; a < GlobalVariables.v_grid.Count; a++)
        //{
        //    Debug.Log(GlobalVariables.v_grid[a]);
        //}

    }
}
