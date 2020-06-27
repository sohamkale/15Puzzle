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
        if (GlobalVariables.v_solvableboard && !v_doOnce)
        {
            int temp = gameObject.GetComponent<Tile>().v_TileID;
           v_MaterialToLoad =  Resources.Load("Numbers/Materials/"+temp.ToString(), typeof(Material)) as Material;
           
            v_doOnce = true;
            Renderer rend = GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material = v_MaterialToLoad;
            }
             
        }
    }
}
