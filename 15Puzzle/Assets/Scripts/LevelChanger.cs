using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelChanger : MonoBehaviour
{
  public void easyMode()
    {
        GlobalVariables.v_UserDifficultyLevel = "Easy";
        GlobalVariables.v_NumberOfTilesToLoad = 9;
        GlobalVariables.v_StartGame = true;
        GameObject v_gameBoard = GameObject.FindGameObjectWithTag("GameBoard");
     
        v_gameBoard.transform.GetChild(0).GetComponent<SpawnRandomTiles>().v_NumberOfTilesToSpawn = 9;
        v_gameBoard.transform.GetChild(0).gameObject.SetActive(true);
            
    }
    public void hardMode()
    {
        GlobalVariables.v_UserDifficultyLevel = "Hard";
        GlobalVariables.v_NumberOfTilesToLoad = 16;
        GlobalVariables.v_StartGame = true;
        GameObject v_gameBoard = GameObject.FindGameObjectWithTag("GameBoard");
        v_gameBoard.transform.GetChild(0).GetComponent<SpawnRandomTiles>().v_NumberOfTilesToSpawn = 16;
        v_gameBoard.transform.GetChild(0).gameObject.SetActive(true);

    }
}
