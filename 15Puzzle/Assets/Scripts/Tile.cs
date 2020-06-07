using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile : MonoBehaviour
{
 ///   private enum TileIdentity
    //{  
    //int v_myID;
   // }
public int v_TileID;
    // Start is called before the first frame update
    void Start()
    {
    v_TileID = (int)UnityEngine.Random.Range(1,GlobalVariables.v_NumberOfTilesToLoad+1);
        Debug.Log(v_TileID);
    }

 
}
