﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class GlobalVariables
{

    public static string v_UserDifficultyLevel = "Hard";
    public static string v_layout = "Classic";
    //False by default (Initial start of game), controls the clearing of the game board
    public static bool v_NewGame;
    public static int v_NumberOfTilesToLoad = 1;
    public static int[] v_TileNumberGenerated = new int[50];
    public static List<int> v_grid = new List<int>();
    public static List<GameObject> v_clonedTiles = new List<GameObject>(); //ONLY CLONED TILES
    public static bool v_solvableboard = false;
    public static List<List<int>> v_2DArray = new List<List<int>>(); //NOT NEEDED
    public static int v_gridWidth = 4;
    public static int[,] v_2Dlist = new int[v_gridWidth, v_gridWidth]; //THE ACTUAL 2D Array
    public static GameObject v_emptyTileObject;

    public static List<GameObject> v_AllTiles1DList = new List<GameObject>(); //THE list of all tiles
    public static GameObject[,] v_AllTiles2DArray = new GameObject[v_gridWidth, v_gridWidth]; //THE 2D Array for TILES
    
    public static int v_emptyTileNum = 0;

    public static float v_timeLeft = 1.0f;
    public static float v_timeElapsed = 0.0f;
    private static int v_timeElapsedHours = 0;
    private static int v_timeElapsedMinutes = 0;
    private static int v_timeElapsedSeconds = 0;
    public static bool v_shouldTimePause = false;
    public static bool v_continuePressed = false;
    public static GameObject v_entryDoor = GameObject.FindGameObjectWithTag("entryDoor");
    public static GameObject v_timeText = GameObject.FindGameObjectWithTag("timeElapsed");
    public static GameObject v_MainMenu = GameObject.FindGameObjectWithTag("Menu");
    public static GameObject v_MainMenuText = GameObject.FindGameObjectWithTag("MainMenuTitleText");
    public static GameObject v_MainTextMesh = GameObject.FindGameObjectWithTag("MainTextMesh");
    public static GameObject v_MainMenuContinueButton;
    public static GameObject v_BackToMainMenuButton;
    public static GameObject v_QuitGameButton = GameObject.FindGameObjectWithTag("QuitGame");
    public static GameObject v_ClassicLayout;
    public static GameObject v_UpsideDownLayout;
    public static GameObject v_ClassicEasyLayout;
    public static GameObject v_UpsideDownEasyLayout;
    public static GameObject v_ColumnsLayout;
    public static bool v_shouldEntryDoorBeInActive = false;
    public static GameObject v_MainMenuPlayButton = GameObject.FindGameObjectWithTag("PlayButton");
    public static int v_escapeCount = 0;
    public static bool v_StartGame=false;
    public static bool v_StartCounter = false;
    public static void tickerCountDown()
    {
        v_timeLeft -= Time.deltaTime;
        
        if (v_timeLeft < 0)
        {
            //Do something useful or Load a new game scene depending on your use-case
        }
    }

    public static void tickerCountUp()
    {
        if (!v_shouldTimePause && v_StartCounter)
        {
            v_timeElapsed += Time.deltaTime;
        }

        v_timeElapsedMinutes = (int) (v_timeElapsed / 60.0f);
        v_timeElapsedSeconds = (int) v_timeElapsed % 60;
        if(v_timeElapsedMinutes < 10)
        {
            if (v_timeElapsedSeconds < 10)
            {
                v_timeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Time: 0" + v_timeElapsedMinutes.ToString("0") + ":0" + (v_timeElapsedSeconds).ToString("0");
            }
            else
            {
                v_timeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Time: 0" + v_timeElapsedMinutes.ToString("0") + ":" + (v_timeElapsedSeconds).ToString("0");
            }
        }else
        {
            if (v_timeElapsedSeconds < 10)
            {
                v_timeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Time: " + v_timeElapsedMinutes.ToString("0") + ":0" + (v_timeElapsedSeconds).ToString("0");
            }
            else
            {
                v_timeText.GetComponent<TMPro.TextMeshProUGUI>().text = "Time: " + v_timeElapsedMinutes.ToString("0") + ":" + (v_timeElapsedSeconds).ToString("0");
            }
        }
        
        //if (v_timeElapsed < 60)
        
    }

    public static void convert2DArray(List<int> v_grid)
    {
        int count = 0;
        List<int> v_tempArray = new List<int>();
        //Debug.LogError("v_gridWidth: " + v_gridWidth);
        for (int i = 0; i < v_grid.Count; i++)
        {
            v_tempArray.Add(v_grid[i]);
            if ((i + 1) % v_gridWidth == 0 && i != 0)
            {
         
                GlobalVariables.v_2DArray.Add(v_tempArray); //DONT NEED THIS ANYMORE
                for (int b = 0; b < v_gridWidth; b++)
                {
                    v_2Dlist[count, b] = v_tempArray[b];
                }
                v_tempArray.Clear();
                count++;
            }
            

        }
    }


    public static void convert2DTilesArray(List<GameObject> v_AllTiles1DList)
    {
        int count = 0;
        List<GameObject> v_tempArray = new List<GameObject>();
        //Debug.LogError("v_gridWidth: " + v_gridWidth);
        for (int i = 0; i < v_AllTiles1DList.Count; i++)
        {
            v_tempArray.Add(v_AllTiles1DList[i]);
            if ((i + 1) % v_gridWidth == 0 && i != 0)
            {

                
                for (int b = 0; b < v_gridWidth; b++)
                {
                    v_AllTiles2DArray[count, b] = v_tempArray[b];
                }
                v_tempArray.Clear();
                count++;
            }


        }
        //FOR DISPLAYING TILES 
        //for (int c = 0; c < v_gridWidth; c++)
        //{
        //    for (int d = 0; d < v_gridWidth; d++)
        //    {
        //        //if (v_2Dlist[c, d] == -1)
        //        //{
        //        //    Debug.LogError("Count [" + c + "," + d + "] : " + v_2Dlist[c, d]);
        //        //}
        //        Debug.LogError("Count [" + c + "," + d + "] : " + v_AllTiles2DArray[c, d].GetComponent<Tile>().v_TileID);
        //    }
        //    Debug.LogError("NEW ROW: " + c);
        //}
    }


    public static void display()
    {
        for (int c = 0; c < v_gridWidth; c++)
        {
            for (int d = 0; d < v_gridWidth; d++)
            {
                if(v_2Dlist[c, d] == -1)
                {
                    //Debug.LogError("Count [" + c + "," + d + "] : " + v_2Dlist[c, d]);
                }
                //Debug.LogError("Count [" + c + "," + d + "] : " + v_2Dlist[c, d]);
            }
            //Debug.LogError("NEW ROW: " + c);
        }
    }

    public static void displayAll()
    {
        for (int c = 0; c < v_gridWidth; c++)
        {
            for (int d = 0; d < v_gridWidth; d++)
            {
                //if (v_2Dlist[c, d] == -1)
                //{
                //    Debug.LogError("Count [" + c + "," + d + "] : " + v_2Dlist[c, d]);
                //}
                //Debug.LogError("Count [" + c + "," + d + "] : " + v_2Dlist[c, d]);
            }
            //Debug.LogError("NEW ROW: " + c);
        }
    }

    public static void displayAllTiles()
    {
        for (int c = 0; c < v_gridWidth; c++)
        {
            for (int d = 0; d < v_gridWidth; d++)
            {
                //if (v_2Dlist[c, d] == -1)
                //{
                //    Debug.LogError("Count [" + c + "," + d + "] : " + v_2Dlist[c, d]);
                //}
                //Debug.LogError("Count [" + c + "," + d + "] : " + v_AllTiles2DArray[c, d].GetComponent<Tile>().v_TileID);
            }
            //Debug.LogError("NEW ROW: " + c);
        }
    }
}