using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFunctions : MonoBehaviour
{

    public void Start()
    {
        GlobalVariables.v_MainMenuContinueButton = GameObject.FindGameObjectWithTag("ContinueButton");
        GlobalVariables.v_MainMenuContinueButton.SetActive(false);

        GlobalVariables.v_ClassicLayout = GameObject.FindGameObjectWithTag("ClassicLayout");
        //GlobalVariables.v_ClassicLayout.SetActive(false);

        GlobalVariables.v_UpsideDownLayout = GameObject.FindGameObjectWithTag("UpsideDownLayout");
        //GlobalVariables.v_UpsideDownLayout.SetActive(false);

        GlobalVariables.v_ColumnsLayout = GameObject.FindGameObjectWithTag("ColumnsLayout");
        //GlobalVariables.v_ColumnsLayout.SetActive(false);
    }

    public void continuePressed()
    {
        GlobalVariables.v_continuePressed = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
