using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public AnimatedObject content;


    public void DestructionDelay(float seconds)
    {
        Destroy(gameObject, seconds);
    }


}
