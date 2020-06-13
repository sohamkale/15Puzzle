using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideScript : MonoBehaviour
{
    public GameObject slot;
    public float xtemp, ytemp;
    // Start is called before the first frame update
    void Start()
    {
        
        var list = GameObject.FindGameObjectsWithTag("Tile");
        for (int i = 0; i < list.Length; i++)
        {
   //         if(list[i].v_TileID == GlobalVariables.v_emptyTileNum)
			//{
                
   //         }
            //Debug.Log(list[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseUp()
    {
        //If theDistance==1 between tiles then swap tiles
        if (Vector3.Distance(transform.localPosition, slot.transform.position) == 1)
        {

            xtemp = transform.localPosition.x;
            ytemp = transform.localPosition.y;
            transform.localPosition = new Vector3(slot.transform.position.x, slot.transform.position.y, 0);
            slot.transform.position = new Vector3(xtemp, ytemp, 0);

        }

    }
}
