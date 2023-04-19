using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlledState : IPlayerState
{
    public void EnterState(PlayerController player)
    {
        if (player.name == "Player1")
        {
            player.playerUp = KeyCode.Z;
            player.playerDown = KeyCode.S;
            player.playerLeft = KeyCode.Q;
            player.playerRight = KeyCode.D;

            Debug.Log("Je suis contrôlé par un.e joueur.se au clavier !");

        }

        else 
        {
            player.playerUp = KeyCode.UpArrow;
            player.playerDown = KeyCode.DownArrow;
            player.playerLeft = KeyCode.LeftArrow;
            player.playerRight = KeyCode.RightArrow;

            Debug.Log("Je suis contrôlé par un.e joueur.se au clavier !");

        }


    }

}