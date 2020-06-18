using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SlideTile : MonoBehaviour
{

	//float v_xtemp;
	//float v_ytemp;
	public GameObject v_slot;
	public GameObject emptyTile;
	float v_xtemp;
    float v_ytemp;
	bool onlyOnce = false;
	//Use this for initialization

	void Start()
	{
		//for (int i = 0; i < GlobalVariables.v_TileNumberGenerated.Length; i++)
		//{


	//	if (gameObject.GetComponent<Tile>().v_TileID == GlobalVariables.v_emptyTileNum)
	//	{

	//		v_slot = gameObject;
	//		break;
	//	}
	//}
	}

	//Update is called once per frame
	void Update()
	{
		Debug.LogError(GlobalVariables.v_solvableboard);

		
		{
            emptyTile = GameObject.FindWithTag("emptyTile");
			Debug.LogError("EmptyTile: " + emptyTile.GetComponent<Tile>().name);
			Debug.LogError("v_emptyTile: " + GlobalVariables.v_emptyTileNum);

			v_slot = emptyTile;
			onlyOnce = true;
			//for (int i = 0; i < GlobalVariables.v_TileNumberGenerated.Length; i++)
			//{
			//	Debug.LogError("v_Id: " + gameObject.GetComponent<Tile>().v_TileID);
			//	//Debug.LogError("v_emptyTile: " + GlobalVariables.v_emptyTileNum);

			//	if (gameObject.GetComponent<Tile>().v_TileID == 16)
			//	{

			//		Debug.LogError("v_Id inside if statement: " + gameObject.GetComponent<Tile>().v_TileID);
			//		Debug.LogError("v_emptyTile inside if statement: " + GlobalVariables.v_emptyTileNum);
			//		Debug.LogError(gameObject);
			//		//Console.log(gameObject.GetComponent<Tile>().v_iAmEmpty);
			//		v_slot = gameObject;
			//		Debug.LogError(v_slot);
			//		onlyOnce = true;
			//		break;
			//	}
			//}
		}


	}


	void OnMouseUp()
	{
		if (v_slot)
		{
			if (Vector3.Distance(transform.position, v_slot.transform.position) == 1)
			{
				v_xtemp = transform.position.x;
				v_ytemp = transform.position.y;
				transform.position = new Vector3(v_slot.transform.position.x, v_slot.transform.position.y, 0f);
				v_slot.transform.position = new Vector3(v_xtemp, v_ytemp, 0f);
			}
		}
		
	}

}