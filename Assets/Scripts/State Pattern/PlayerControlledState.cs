using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlledState : IPlayerState
{
    private bool connectedGameController = false;


    public void EnterState(PlayerController player)
    {
        if (!connectedGameController)
        {

            player.playerUp = KeyCode.Z;
            player.playerDown = KeyCode.S;
            player.playerLeft = KeyCode.Q;
            player.playerRight = KeyCode.D;

            Debug.Log("Je suis contrôlé par un.e joueur.se au clavier !");

        }


    }

}