using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomTiles : MonoBehaviour
{
    public GameObject v_OriginalTile;
    public int v_NumberOfTilesToSpawn=0;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateTiles();
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.v_NewGame)
        {
            //If a new game is requestion, then spawn new tiles to start game
            InstantiateTiles();
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
    }
}
