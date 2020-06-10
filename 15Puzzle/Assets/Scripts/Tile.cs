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
    public int v_TileID =  0;
    public bool v_continueLoop = true,v_matchFound=false;
    // Start is called before the first frame update
    void Start()
    {
        v_TileID = (int)UnityEngine.Random.Range(1, GlobalVariables.v_NumberOfTilesToLoad + 1);
    
        gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = v_TileID.ToString();
    }
    private void Update()
    {
        UpdateTileNumber();
    }

  public void UpdateTileNumber()
    {
        while (v_continueLoop)
        {
           
            v_TileID = (int)UnityEngine.Random.Range(1, GlobalVariables.v_NumberOfTilesToLoad + 1);
            for (int i = 0; i < GlobalVariables.v_TileNumberGenerated.Length; i++)
            {
                 if (GlobalVariables.v_TileNumberGenerated[i] ==0 && v_TileID == GlobalVariables.v_TileNumberGenerated[i])
                {
                    v_matchFound = true;
                     break;
                }
            }
            Debug.Log("Cont");
            if (v_matchFound)
            {
                v_continueLoop = true;
            }
            else
            {
               
                for (int i = 0; i < GlobalVariables.v_TileNumberGenerated.Length; i++)
                {
                    if (GlobalVariables.v_TileNumberGenerated[i] == 0)
                    {
                        Debug.Log("Adding: " + v_TileID);
                        GlobalVariables.v_TileNumberGenerated[i] = v_TileID;
                        break;
                    }
                  
                }
                v_continueLoop = false;
                gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = v_TileID.ToString();
            }
        }
    }
 
}
