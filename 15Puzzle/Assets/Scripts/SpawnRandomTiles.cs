using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomTiles : MonoBehaviour
{
    public GameObject v_OriginalTile;
    public bool v_onlyOnce = false;
    public int v_NumberOfTilesToSpawn = 0;
    GameObject quitGameButton, newGameButton, entryDoorText, entryDoorCanvas;
    
    //public GameObject entryDoor;
    // Start is called before the first frame update
    void Start()
    {
         
        InstantiateTiles();
        v_onlyOnce = false;
        GlobalVariables.v_entryDoor = GameObject.FindGameObjectWithTag("entryDoor");
        GameObject entryDoorCanvas = GlobalVariables.v_entryDoor.transform.GetChild(0).gameObject;
        GameObject entryDoorText = entryDoorCanvas.transform.GetChild(0).gameObject;
        GameObject newGameButton = entryDoorCanvas.transform.GetChild(1).gameObject;
        GameObject quitGameButton = entryDoorCanvas.transform.GetChild(2).gameObject;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.v_ClassicLayout != null && GlobalVariables.v_layout == "Classic")
        {
            GlobalVariables.v_ClassicLayout.SetActive(true);
            GlobalVariables.v_UpsideDownLayout.SetActive(false);
            GlobalVariables.v_ColumnsLayout.SetActive(false);

        }
        else if (GlobalVariables.v_UpsideDownLayout != null && GlobalVariables.v_layout == "UpsideDown")
        {
           
            GlobalVariables.v_UpsideDownLayout.SetActive(true);
            GlobalVariables.v_ClassicLayout.SetActive(false);
            GlobalVariables.v_ColumnsLayout.SetActive(false);
        }
        else if (GlobalVariables.v_ColumnsLayout != null && GlobalVariables.v_layout == "Columns")
        {
            GlobalVariables.v_ColumnsLayout.SetActive(true);
            GlobalVariables.v_ClassicLayout.SetActive(false);
            GlobalVariables.v_UpsideDownLayout.SetActive(false);
        }



        if (Input.GetKeyDown("escape"))
        {
            Debug.LogError("Escape Pressed");

            if (GlobalVariables.v_escapeCount == 0)
            {
                Debug.LogError(GlobalVariables.v_escapeCount);
                //newGameButton.SetActive(true);
                //quitGameButton.SetActive(true);
                //entryDoorText.GetComponent<UnityEngine.UI.Text>().text = "PAUSED!!!";
                //GlobalVariables.v_entryDoor.SetActive(true);
                //GlobalVariables.v_solvableboard = false;
                GlobalVariables.v_shouldTimePause = true;
                GlobalVariables.v_escapeCount++;
                GlobalVariables.v_MainMenuText.GetComponent<TMPro.TextMeshProUGUI>().text = "PAUSED!!";
                Debug.LogError(GlobalVariables.v_MainMenuContinueButton.name);
                GlobalVariables.v_MainMenuContinueButton.SetActive(true);
                GlobalVariables.v_MainMenuPlayButton.SetActive(false);
                //GameObject MainMenu = GameObject.FindGameObjectWithTag("MainMenu");
                GlobalVariables.v_MainMenu.SetActive(true);
            }
            else if (GlobalVariables.v_escapeCount == 1)
            {

                Debug.LogError(GlobalVariables.v_escapeCount);
                //newGameButton.SetActive(false);
                //quitGameButton.SetActive(false);
                //entryDoorText.GetComponent<UnityEngine.UI.Text>().text = "PAUSED!!!";
                //GlobalVariables.v_entryDoor.SetActive(false);
                //GlobalVariables.v_solvableboard = true;
                GlobalVariables.v_shouldTimePause = false;
                GlobalVariables.v_escapeCount = 0;
                GlobalVariables.v_MainMenuText.GetComponent<TMPro.TextMeshProUGUI>().text = "15 PUZZLE";
                GlobalVariables.v_MainMenuContinueButton.SetActive(false);
                GlobalVariables.v_MainMenuPlayButton.SetActive(true);
                //GameObject MainMenu = GameObject.FindGameObjectWithTag("MainMenu");
                //MainMenu.SetActive(false);
                GlobalVariables.v_MainMenu.SetActive(false);
            }

            //Application.Quit();
        }

        if (GlobalVariables.v_continuePressed)
        {
            GlobalVariables.v_shouldTimePause = false;
            GlobalVariables.v_escapeCount = 0;
            GlobalVariables.v_MainMenuText.GetComponent<TMPro.TextMeshProUGUI>().text = "15 PUZZLE";
            GlobalVariables.v_MainMenuContinueButton.SetActive(false);
            GlobalVariables.v_MainMenuPlayButton.SetActive(true);
            GlobalVariables.v_continuePressed = false;
            GlobalVariables.v_MainMenu.SetActive(false);
        }

        GlobalVariables.tickerCountDown();
        if (GlobalVariables.v_timeLeft <= 0 && GlobalVariables.v_solvableboard)
        {
            GlobalVariables.v_entryDoor.SetActive(false);
            GlobalVariables.v_MainTextMesh.SetActive(false);
            GlobalVariables.tickerCountUp();
        }

        //GlobalVariables.tickerCountUp();


        if (GlobalVariables.v_NewGame)
        {
            //If a new game is requestion, then spawn new tiles to start game
            Vector3 v_OriginalTilePos = v_OriginalTile.transform.position;
            v_OriginalTilePos.x = -1.49f;
            v_OriginalTilePos.y = 3.91f;
            v_OriginalTilePos.z = 0.43f;
            v_OriginalTile.transform.position = v_OriginalTilePos;
            Debug.LogError("Inside new_game function in update");
            v_onlyOnce = false;
            GlobalVariables.v_solvableboard = false;
            DestroyTiles();
            v_OriginalTile.GetComponent<Tile>().resetVariables();
            InstantiateTiles();
            GlobalVariables.v_entryDoor = GameObject.FindGameObjectWithTag("entryDoor");
            GameObject entryDoorCanvas = GlobalVariables.v_entryDoor.transform.GetChild(0).gameObject;
            GameObject entryDoorText = entryDoorCanvas.transform.GetChild(0).gameObject;
            GameObject newGameButton = entryDoorCanvas.transform.GetChild(1).gameObject;
            GameObject quitGameButton = entryDoorCanvas.transform.GetChild(2).gameObject;
            //GameObject textMesh = entryDoorCanvas.transform.GetChild(3).gameObject;
            //textMesh.GetComponent<TMPro.TextMeshProUGUI>().text = "Please Wait while the game loads!!";
            entryDoorText.GetComponent<UnityEngine.UI.Text>().text = "Please Wait while the game loads!!";
            GlobalVariables.v_MainTextMesh.GetComponent<TMPro.TextMeshProUGUI>().text = "Please Wait while the game loads!!";
            newGameButton.SetActive(false);
            quitGameButton.SetActive(false);
            GlobalVariables.v_entryDoor.SetActive(true);
            GlobalVariables.v_MainTextMesh.SetActive(true);
            GlobalVariables.v_timeElapsed = 0;
            GlobalVariables.v_NewGame = false;
            GlobalVariables.v_StartGame = true;
            GlobalVariables.v_timeLeft = 1.0f;

        }
        //Debug.Log("V_GRID::::: " + GlobalVariables.v_grid.Count);
        //Debug.Log("V_ONLYONCE:::::::  " + v_onlyOnce);
        if ((!v_onlyOnce && GlobalVariables.v_NumberOfTilesToLoad == 16))
        {
       


            List<int> v_newGrid = new List<int>();
            for (int b = 0; b < GlobalVariables.v_grid.Count; b++)
            {
                if (GlobalVariables.v_grid[b] != -1)
                {
                    v_newGrid.Add(GlobalVariables.v_grid[b]);
                }

            }
            
            for (int a = 0; a < GlobalVariables.v_grid.Count; a++)
            {
                double emptyTileRow;
                if (GlobalVariables.v_grid[a] == -1)
                {
                    Debug.Log("GlobalVariables.v_grid: " + GlobalVariables.v_grid[a]);
                    emptyTileRow = ((double)a) / Math.Sqrt(GlobalVariables.v_NumberOfTilesToLoad);
                    emptyTileRow = Math.Sqrt(GlobalVariables.v_NumberOfTilesToLoad) - Math.Floor(emptyTileRow);
                    int inversionCount = 0;
                    if ((int)(emptyTileRow % 2) == 0) //even row
                    {
                        Debug.Log("Even Row: " + emptyTileRow);
                        for (int c = 0; c < v_newGrid.Count; c++)
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
                            v_onlyOnce = true;
                            Debug.Log("solvable: " + inversionCount);
                            GlobalVariables.v_solvableboard = true;
                            GlobalVariables.convert2DArray(GlobalVariables.v_grid);
                            GlobalVariables.convert2DTilesArray(GlobalVariables.v_AllTiles1DList);
                            //entryDoor = GameObject.FindGameObjectWithTag("entryDoor");
                            //if(GlobalVariables.v_timeLeft <= 0 && GlobalVariables.v_solvableboard)
                            //{
                            //    entryDoor.SetActive(false);
                            //}
                        }
                        else
                        {
                            Debug.Log("unsolvable: " + inversionCount);
                            
                            v_onlyOnce = false;
                            GlobalVariables.v_solvableboard = false;
                            GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
                            //for (int i = 0; i < tiles.Length; i++)//Iterates through the desired number of tiles and deletes it.
                            //{
                            //    //Debug.Log(gameObject);
                            //    Destroy(tiles[i]);
                            //}
                            //Debug.Log("CLONED TILES ARAY B4 DELETION: " + GlobalVariables.v_clonedTiles.Count + " TILe NUMebR geneRATES: " + GlobalVariables.v_TileNumberGenerated.Length);
                            DestroyTiles();
                            //Debug.Log("CLONED TILES AFTER ARAY: " + GlobalVariables.v_clonedTiles.Count + " TILe NUMebR geneRATES: " + GlobalVariables.v_TileNumberGenerated.Length);
                            //Reset ORiginal  Tile variables

                            v_OriginalTile.GetComponent<Tile>().resetVariables();
                            InstantiateTiles();
                            Debug.Log("I am in the if statement...HERE I WAS?" + GlobalVariables.v_clonedTiles[5].name);
                        }


                    }
                    else if ((int)(emptyTileRow % 2) == 1) //odd row
                    {
                        Debug.Log("Odd Row: " + emptyTileRow);
                        for (int c = 0; c < v_newGrid.Count; c++)
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
                        if (inversionCount % 2 == 0) //If inversions are even then solvable
                        {
                            Debug.Log("Total InversionCount: " + inversionCount);
                            v_onlyOnce = true;
                            Debug.Log("solvable: " + inversionCount);
                            GlobalVariables.v_solvableboard = true;
                            GlobalVariables.convert2DArray(GlobalVariables.v_grid);
                            GlobalVariables.convert2DTilesArray(GlobalVariables.v_AllTiles1DList);
                         
                        }
                        else
                        {
                            Debug.Log("unsolvable: " + inversionCount);
                            v_onlyOnce = false;
                            GlobalVariables.v_solvableboard = false;
                            GameObject[] tiles = GameObject.FindGameObjectsWithTag("Tile");
                            //for (int i = 0; i < tiles.Length; i++)//Iterates through the desired number of tiles and deletes it.
                            //{
                            //    //Debug.Log(gameObject);
                            //    Destroy(tiles[i]);
                            //}
                            //Debug.Log("CLONED TILES ARAY b4 DELETION: " + GlobalVariables.v_clonedTiles.Count + " TILe NUMebR geneRATES: " + GlobalVariables.v_TileNumberGenerated.Length);
                            DestroyTiles();
                            v_OriginalTile.GetComponent<Tile>().resetVariables();
                            //Debug.Log("CLONED TILES ARAY AFTER DELETION: " + GlobalVariables.v_clonedTiles.Count + " TILe NUMebR geneRATES: " + GlobalVariables.v_TileNumberGenerated.Length);
                            InstantiateTiles();
                         //   Debug.Log("I am in the else  statement...Here I am ..." + GlobalVariables.v_clonedTiles[4].name);
                        }
                        //Debug.Log("InversionCount: " + inversionCount);
                    }
                    else
                    {
                        //Debug.Log("In else block: " + emptyTileRow + " " + emptyTileRow % 2);
                    }

                }

            }


        }
        else
        {
           // Debug.Log("Unmet condition? : " + GlobalVariables.v_grid.Count + " ::: " + v_onlyOnce);
        }
    }

    private void InstantiateTiles()
    {
        GlobalVariables.v_AllTiles1DList.Add(v_OriginalTile);
        int v_xPosition = 1, v_yPosition = 0;
        bool v_NotFirstEntrance = false;
        
        for (int i = 0; i < v_NumberOfTilesToSpawn; i++)//Iterates through the desired number of tiles and spawns it.
        {

            if (GlobalVariables.v_UserDifficultyLevel == "Hard")//If the user is Intermediate level, we spawn 16 tile games (Including empty tile)
            {
                
                GlobalVariables.v_NumberOfTilesToLoad = 16;


                //Checks every 4th number, and makes the  5th number the new row
                if (i % 4 == 0)
                {
                    v_xPosition = 0;
                    if (v_NotFirstEntrance)
                    {
                        v_yPosition = v_yPosition - 1;
                    }
                    v_NotFirstEntrance = true;
                }
                //Changes X and Y position of the tile to make it spawn to theright or on a new roww
                Vector3 v_tempPosition = new Vector3(v_OriginalTile.transform.position.x + v_xPosition, v_OriginalTile.transform.position.y + v_yPosition, v_OriginalTile.transform.position.z);
                //Do not spawn first tile, since our master/original tile will always be on the board
                if (i != 0)
                {
                    GameObject v_clonedTile = Instantiate(v_OriginalTile, v_tempPosition, Quaternion.identity);
                    GlobalVariables.v_clonedTiles.Add(v_clonedTile);
                    GlobalVariables.v_AllTiles1DList.Add(v_clonedTile);

                }
                //Increase position so we know where to spawn the next tile horizontally.
                v_xPosition++;
            }
            else// Else it is easy mode
            {
                GlobalVariables.v_NumberOfTilesToLoad = 9;


                //Checks every 4th number, and makes the  5th number the new row
                if (i % 3 == 0)
                {
                    v_xPosition = 0;
                    if (v_NotFirstEntrance)
                    {
                        v_yPosition = v_yPosition - 1;
                    }
                    v_NotFirstEntrance = true;
                }
                //Changes X and Y position of the tile to make it spawn to theright or on a new roww
                Vector3 v_tempPosition = new Vector3(v_OriginalTile.transform.position.x + v_xPosition, v_OriginalTile.transform.position.y + v_yPosition, v_OriginalTile.transform.position.z);
                //Do not spawn first tile, since our master/original tile will always be on the board
                if (i != 0)
                {
                    GameObject v_clonedTile = Instantiate(v_OriginalTile, v_tempPosition, Quaternion.identity);
                    GlobalVariables.v_clonedTiles.Add(v_clonedTile);
                    GlobalVariables.v_AllTiles1DList.Add(v_clonedTile);

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

    private void DestroyTiles()
    {
        for (int i = 0; i < GlobalVariables.v_clonedTiles.Count; i++)//Iterates through the desired number of tiles and deletes it.
        {
            Destroy(GlobalVariables.v_clonedTiles[i]);
        }
        GlobalVariables.v_grid.Clear();
        GlobalVariables.v_clonedTiles.Clear();
        GlobalVariables.v_AllTiles1DList.Clear();
        for (int i = 0; i < GlobalVariables.v_TileNumberGenerated.Length; i++)
        {
            GlobalVariables.v_TileNumberGenerated[i] = 0;
        }
        
    }
}
