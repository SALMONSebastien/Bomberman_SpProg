using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControlledState : IPlayerState
{
    public void EnterState(PlayerController player)
    {

        player.playerUp = KeyCode.None;
        player.playerDown = KeyCode.None;
        player.playerLeft = KeyCode.None;
        player.playerRight = KeyCode.None;

        Debug.Log("Je suis contrôlé par l'IA !");

    }

}
