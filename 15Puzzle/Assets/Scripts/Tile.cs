using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class Tile : MonoBehaviour
{
    ///   private enum TileIdentity
    //{  
    //int v_myID;
    // }
    public int v_TileID = 0;
    public bool v_continueLoop = true, v_matchFound = false, v_shouldBeEmpty = false;
    public bool v_iAmEmpty = false;
    // Start is called before the first frame update
    void Start()
    {
        //Generates random ID between 1 -MaxNumOFTiles
        //v_TileID = (int)UnityEngine.Random.Range(1, GlobalVariables.v_NumberOfTilesToLoad + 1);
        //gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = v_TileID.ToString();
        v_continueLoop = true;
        v_matchFound = false;
        v_shouldBeEmpty = false;
    }
    private void Update()
    {
        UpdateTileNumber();

    }

    public void UpdateTileNumber()
    {
        //Debug.Log("EmptyTile is  " + GlobalVariables.v_emptyTileNum + " " + v_TileID);
        //Debug.Log("Update ID is " + v_TileID + " " + v_continueLoop);
        while (v_continueLoop)
        {
            v_matchFound = false;
            if (v_TileID == 0)
            {
                int v_tempTileID = GlobalVariables.v_emptyTileNum;
                while (v_tempTileID == GlobalVariables.v_emptyTileNum)
                {
                    v_tempTileID = (int)UnityEngine.Random.Range(1, GlobalVariables.v_NumberOfTilesToLoad + 1);
                }

                v_TileID = v_tempTileID;
            }
            else
            {
                v_TileID = (int)UnityEngine.Random.Range(1, GlobalVariables.v_NumberOfTilesToLoad + 1);
            }
            //Debug.Log("Update ID is " + v_TileID);

            for (int i = 0; i < GlobalVariables.v_TileNumberGenerated.Length; i++)
            {


                if (v_TileID == GlobalVariables.v_TileNumberGenerated[i])
                {
                    v_matchFound = true;
                    //Debug.Log("Match Found inside If: " + v_matchFound);
                    //Debug.Log(GlobalVariables.v_TileNumberGenerated[i] + " " + v_TileID);

                    break;
                }
            }

            if (!v_matchFound)
            {


                for (int i = 0; i < GlobalVariables.v_TileNumberGenerated.Length; i++)
                {

                    if (GlobalVariables.v_TileNumberGenerated[i] == 0)
                    {

                        //Debug.Log("Adding: " + v_TileID);
                        GlobalVariables.v_TileNumberGenerated[i] = v_TileID;
                        break;
                    }

                }

                v_continueLoop = false;

                if (v_TileID == GlobalVariables.v_emptyTileNum)
                {   //Debug.Log("EMPTY TILE: " + v_TileID + " " + GlobalVariables.v_UserDifficultyLevel);
                    if (GlobalVariables.v_UserDifficultyLevel == "Easy")
                    {
                        //Debug.Log("EMPTY TILE: " + v_TileID);
                        //DESTROY
                        // Debug.LogError("Deleting tile number: " + GlobalVariables.v_emptyTileNum);
                        
                        gameObject.SetActive(false);
                        gameObject.GetComponent<Tile>().v_TileID = 9;         //CHANGED
                        gameObject.GetComponent<Tile>().v_iAmEmpty = true;
                        gameObject.GetComponent<Tile>().tag = "EmptyTile";
                        GlobalVariables.v_emptyTileObject = gameObject;
                        Debug.Log(GlobalVariables.v_emptyTileObject.tag);
                        //Destroy(gameObject);
                        //gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
                        GlobalVariables.v_grid.Add(-1);
                    }
                    else
                    {
                        //Debug.Log("EMPTY TILE: " + v_TileID);
                        //DESTROY
                        // Debug.LogError("Deleting tile number: " + GlobalVariables.v_emptyTileNum);
                        GlobalVariables.v_emptyTileObject = gameObject;
                        gameObject.SetActive(false);
                        gameObject.GetComponent<Tile>().v_TileID = 16;         //CHANGED
                        gameObject.GetComponent<Tile>().v_iAmEmpty = true;
                        gameObject.GetComponent<Tile>().tag = "EmptyTile";
                        //Destroy(gameObject);
                        //gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
                        GlobalVariables.v_grid.Add(-1);
                    }
                    
                }
                else
                {
                    //Debug.Log("EMPTY TILE: " + v_TileID + " " + GlobalVariables.v_UserDifficultyLevel);
                    if (GlobalVariables.v_UserDifficultyLevel == "Easy")
                    {
                        if (v_TileID == 9)
                        {
                            gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = GlobalVariables.v_emptyTileNum.ToString();
                            gameObject.GetComponent<Tile>().v_TileID = GlobalVariables.v_emptyTileNum;
                            GlobalVariables.v_grid.Add(gameObject.GetComponent<Tile>().v_TileID);

                        }
                        else
                        {
                            gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = v_TileID.ToString();
                            GlobalVariables.v_grid.Add(v_TileID);

                        }
                    }
                    else
                    {
                        if (v_TileID == 16)
                        {
                            gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = GlobalVariables.v_emptyTileNum.ToString();
                            gameObject.GetComponent<Tile>().v_TileID = GlobalVariables.v_emptyTileNum;
                            GlobalVariables.v_grid.Add(gameObject.GetComponent<Tile>().v_TileID);

                        }
                        else
                        {
                            gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = v_TileID.ToString();
                            GlobalVariables.v_grid.Add(v_TileID);

                        }
                    }
                    
                    //for (int a = 0; a < GlobalVariables.v_grid.Count; a++)
                    //{
                    //    Debug.Log(GlobalVariables.v_grid[a]);
                    //}

                }
            }
        }
    }

    public void resetVariables()
    {
        v_TileID = 0;
        v_continueLoop = true;
        v_matchFound = false;
        v_shouldBeEmpty = false;
    }


}
