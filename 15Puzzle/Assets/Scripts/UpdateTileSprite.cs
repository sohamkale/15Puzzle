using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTileSprite : MonoBehaviour
{
    public Material v_MaterialToLoad;
    public GameObject v_thisObject;
    public bool v_doOnce = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogError(v_doOnce);
        if (GlobalVariables.v_solvableboard && !v_doOnce)
        {
            int temp = gameObject.GetComponent<Tile>().v_TileID;

            for(int i = 0; i < GlobalVariables.v_AllTiles1DList.Count; i++)
            {
                int tempTileID = GlobalVariables.v_AllTiles1DList[i].GetComponent<Tile>().v_TileID;
                Debug.Log("Tile " + i + ": " + GlobalVariables.v_AllTiles1DList[i].GetComponent<Tile>().v_TileID);
                v_MaterialToLoad = Resources.Load("Numbers/Materials/" + tempTileID.ToString(), typeof(Material)) as Material;
                Renderer rend = GlobalVariables.v_AllTiles1DList[i].GetComponent<Renderer>();
                if (rend != null)
                {
                    rend.material = v_MaterialToLoad;
                }
                var rotationVector = GlobalVariables.v_AllTiles1DList[i].transform.rotation.eulerAngles;
                rotationVector.z = 180;
                GlobalVariables.v_AllTiles1DList[i].transform.rotation = Quaternion.Euler(rotationVector);

            }
            //v_MaterialToLoad = Resources.Load("Numbers/Materials/" + temp.ToString(), typeof(Material)) as Material;

            //v_doOnce = true;
            //Renderer rend = GetComponent<Renderer>();
            //if (rend != null)
            //{
            //    rend.material = v_MaterialToLoad;
            //}
            Debug.LogError("Game rendering Complete : " + temp);
            v_doOnce = true;
             
        }
        if (GlobalVariables.v_NewGame)
        {
            v_doOnce = false;
        }
    }
}
