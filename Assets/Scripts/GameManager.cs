using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    public Text winningText;

    public void Winner()
    {
        int aliveCount = 0;


        foreach (GameObject player in players)
        {
            if(player.activeSelf)
            {
                aliveCount += 1;

            }

        }

        if (aliveCount <= 1)
        {
            winningText.text = "You win !";

        }


    }
}
