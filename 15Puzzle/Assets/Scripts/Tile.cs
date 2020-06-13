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
    // Start is called before the first frame update
    void Start()
    {
        //Generates random ID between 1 -MaxNumOFTiles
        // v_TileID = (int)UnityEngine.Random.Range(1, GlobalVariables.v_NumberOfTilesToLoad + 1);
        //gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = v_TileID.ToString();
        
    }
    private void Update()
    {
        UpdateTileNumber();
        
    }

    public void UpdateTileNumber()
    {
        while (v_continueLoop)
        {
            v_matchFound = false;
            v_TileID = (int)UnityEngine.Random.Range(1, GlobalVariables.v_NumberOfTilesToLoad + 1);
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
                {
                    Debug.Log("EMPTY TILE: " + v_TileID);
                    //DESTROY
                    Destroy(gameObject);
                    //gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
                    GlobalVariables.v_grid.Add(-1);
                }
                else
                {
                    if (v_TileID == 16)
                    {
                        gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = GlobalVariables.v_emptyTileNum.ToString();
                        gameObject.GetComponent<Tile>().v_TileID = GlobalVariables.v_emptyTileNum;
                        GlobalVariables.v_grid.Add(v_TileID);
                    }
                    else
                    {
                        gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = v_TileID.ToString();
                        GlobalVariables.v_grid.Add(v_TileID);

                    }
                    //for (int a = 0; a < GlobalVariables.v_grid.Count; a++)
                    //{
                    //    Debug.Log(GlobalVariables.v_grid[a]);
                    //}

                }
            }
        }
    }


}
