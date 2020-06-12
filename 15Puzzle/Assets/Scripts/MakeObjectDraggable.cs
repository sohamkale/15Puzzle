using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeObjectDraggable : MonoBehaviour
{
    private Vector3 v_Offset;
    private float v_zCoordinate;
 
    private void OnMouseDown()
    {
        v_zCoordinate = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        v_Offset = gameObject.transform.position - GetMouseWorldPos();
    }
    private Vector3 GetMouseWorldPos()
    {
        //Gets x,y coordinates
        Vector3 v_MousePointer = Input.mousePosition;
        //Gets only the z coordinate
        v_MousePointer.z = v_zCoordinate;
        return Camera.main.ScreenToWorldPoint(v_MousePointer);
    }
    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + v_Offset;
    }
}
