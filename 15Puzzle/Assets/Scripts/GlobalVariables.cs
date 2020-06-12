using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables 
{
    
    public static string v_UserDifficultyLevel = "Beginner";
    //False by default (Initial start of game), controls the clearing of the game board
    public static bool v_NewGame;
    public static int v_NumberOfTilesToLoad=1;
    public static int[] v_TileNumberGenerated = new int[50];
   // public static int[] v_TileNumber = new int[15];
    public static int v_emptyTileNum = (int)UnityEngine.Random.Range(1, GlobalVariables.v_NumberOfTilesToLoad * 16 + 1);


}
