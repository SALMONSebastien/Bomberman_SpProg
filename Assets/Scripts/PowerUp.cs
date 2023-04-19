using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
   public enum PowerUpType
    {
        QuickBomb,
        PlayerSpeed,
        HealthBoost,
        StrengthBoost,

    }

    public PowerUpType type;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            OnPowerUpObtained(collider.gameObject);
        }
    }

    private void OnPowerUpObtained(GameObject player)
    {
        switch (type)
        {
            case PowerUpType.HealthBoost:
                player.GetComponent<PlayerController>().currentLife += 0.3f; //augmente la sant� du perso
                player.GetComponent<PlayerController>().playerLife.size += 0.3f; //augmente la sant� du perso

                Debug.Log("Ah, �a va mieux");
                break;

            case PowerUpType.StrengthBoost:
                player.GetComponent<PlayerController>().playerStrength++; //augmente la force du perso
                Debug.Log("Aaaaaaaah");
                break;


            case PowerUpType.QuickBomb:
                player.GetComponent<BombHandler>().bombDestructionTime--; //r�duit le temps d'explosion 
                Debug.Log("Attention, �a va exp.. BOUM");

                break;

            case PowerUpType.PlayerSpeed:
                player.GetComponent<PlayerController>().playerSpeed++; //augmente la vitesse du perso
                Debug.Log("Wow, �a va vite");
                break;
        }

        Destroy(gameObject);

    }
}
