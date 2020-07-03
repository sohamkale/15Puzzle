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

    public void buttonPressed()
    {
        //Debug.LogError("Button Pressed");
        //Debug.LogError(GlobalVariables.v_escapeCount);
        //newGameButton.SetActive(true);
        //quitGameButton.SetActive(true);
        //entryDoorText.GetComponent<UnityEngine.UI.Text>().text = "PAUSED!!!";
        //GlobalVariables.v_entryDoor.SetActive(true);
        //GlobalVariables.v_solvableboard = false;
        GlobalVariables.v_shouldTimePause = true;
        GlobalVariables.v_MainMenuText.GetComponent<TMPro.TextMeshProUGUI>().text = "PAUSED!!";
        GlobalVariables.v_BackToMainMenuButton.SetActive(true);
        GlobalVariables.v_QuitGameButton.SetActive(false);
        GlobalVariables.v_MainMenuContinueButton.SetActive(true);
        GlobalVariables.v_MainMenuPlayButton.SetActive(false);
        //GameObject MainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        GlobalVariables.v_MainMenu.SetActive(true);


    }

    public void backToMainMenuPressed()
    {
        //Debug.LogError(GlobalVariables.v_escapeCount);
        //newGameButton.SetActive(false);
        //quitGameButton.SetActive(false);
        //entryDoorText.GetComponent<UnityEngine.UI.Text>().text = "PAUSED!!!";
        //GlobalVariables.v_entryDoor.SetActive(false);
        //GlobalVariables.v_solvableboard = true;
        GlobalVariables.v_shouldTimePause = true;
        
        GlobalVariables.v_MainMenuText.GetComponent<TMPro.TextMeshProUGUI>().text = "15 PUZZLE";
        GlobalVariables.v_MainMenuContinueButton.SetActive(false);
        GlobalVariables.v_MainMenuPlayButton.SetActive(true);
        //GameObject MainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        //MainMenu.SetActive(false);
        //GlobalVariables.v_NewGame = true;
        GlobalVariables.v_MainMenu.SetActive(true);
        GlobalVariables.v_shouldEntryDoorBeInActive = false;
    }
}
