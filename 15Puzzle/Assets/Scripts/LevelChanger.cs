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
        GlobalVariables.v_gridWidth = 3;
        GameObject v_gameBoard = GameObject.FindGameObjectWithTag("GameBoard");
        GlobalVariables.v_emptyTileNum = (int)UnityEngine.Random.Range(1, GlobalVariables.v_NumberOfTilesToLoad);
        v_gameBoard.transform.GetChild(0).GetComponent<SpawnRandomTiles>().v_NumberOfTilesToSpawn = 9;
        v_gameBoard.transform.GetChild(0).gameObject.SetActive(true);
        GlobalVariables.v_NewGame = true;
        GlobalVariables.v_solvableboard = false;
        GlobalVariables.v_entryDoor.SetActive(true);
        GlobalVariables.v_solvableboard = true;

    }
    public void hardMode()
    {
        GlobalVariables.v_UserDifficultyLevel = "Hard";
        GlobalVariables.v_NumberOfTilesToLoad = 16;
        GlobalVariables.v_StartGame = true;
        GlobalVariables.v_gridWidth = 4;
        GameObject v_gameBoard = GameObject.FindGameObjectWithTag("GameBoard");
        GlobalVariables.v_emptyTileNum = (int)UnityEngine.Random.Range(1, GlobalVariables.v_NumberOfTilesToLoad);
        v_gameBoard.transform.GetChild(0).GetComponent<SpawnRandomTiles>().v_NumberOfTilesToSpawn = 16;
        v_gameBoard.transform.GetChild(0).gameObject.SetActive(true);
        GlobalVariables.v_NewGame = true;
        GlobalVariables.v_solvableboard = false;
        GlobalVariables.v_entryDoor.SetActive(true);
        GlobalVariables.v_solvableboard = true;

    }

    public void classicMode()
    {
        GlobalVariables.v_layout= "Classic";
        GlobalVariables.v_shouldEntryDoorBeInActive = true;
        GlobalVariables.v_shouldTimePause = false;

    }

    public void upsideDownMode()
    {
        GlobalVariables.v_layout = "UpsideDown";
        GlobalVariables.v_shouldEntryDoorBeInActive = true;
        GlobalVariables.v_shouldTimePause = false;

    }

    public void columnsMode()
    {
        GlobalVariables.v_layout = "Columns";
        GlobalVariables.v_shouldEntryDoorBeInActive = true;
        GlobalVariables.v_shouldTimePause = false;

    }


}
