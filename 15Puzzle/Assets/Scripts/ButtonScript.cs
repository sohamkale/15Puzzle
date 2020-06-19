using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void newGame()
    {
        GlobalVariables.v_NewGame = true;
        GlobalVariables.v_solvableboard = false;
        
    }

    public void quitGame()
    {
        Application.Quit();

    }
}
