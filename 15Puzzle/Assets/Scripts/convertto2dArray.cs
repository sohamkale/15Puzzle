using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class convertto2dArray : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void convert2DArray(List<int> v_grid)
    {
        List<int> v_tempArray = new List<int>();
        for(int i = 0; i < v_grid.Count; i++)
        {
            v_tempArray.Add(v_grid[i]);
            if (i % 4 == 0)
            {
                GlobalVariables.v_2DArray.Add(v_tempArray);
                v_tempArray.Clear();
            }
        }
    }
}
