using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    // Problème pour définir isAIControlled du Main Menu, mais fonctionne manuellement depuis le Level
    public void SoloMode(PlayerController myPlayerController)

    {
        myPlayerController.isAIControlled = true;
        PlayerPrefs.SetString("isAIControlled", "true");

        SceneManager.LoadScene("Level");
    }

    public void MultiplayerMode(PlayerController myPlayerController)

    {
        myPlayerController.isAIControlled = false;
        PlayerPrefs.SetString("isAIControlled", "false");

        SceneManager.LoadScene("Level");
    }


}
