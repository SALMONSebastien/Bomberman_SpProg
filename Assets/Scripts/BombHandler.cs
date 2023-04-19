using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombHandler : MonoBehaviour
{
    [Header("Bomb Object")]
    public GameObject bomb;
    public KeyCode bombKey = KeyCode.E;
    public float bombDestructionTime = 4f;
    public int playerBombAmount = 1;

    private int currentBombsLeft;

    [Header("Power-Up")]

    [Range(0, 100)]
    public int powerUpSpawnOdds = 20;
    public GameObject[] powerUpList;



    [Header("Bomb Explosion")]
    public BombExplosion explosionPrefab;
    public float explosionDuration = 1f;
    public int explosionRadius = 1;
    public LayerMask explosionLayerMask;

    [Header("Destructible Tiles")]
    public Tilemap destructibleTiles;


    private void OnEnable()
    {
        currentBombsLeft = playerBombAmount;
    }

    private void Update()
    {
        if (Input.GetKeyDown(bombKey) && currentBombsLeft > 0)
        {

            StartCoroutine(SpawnBomb());
        }

    }

    private IEnumerator SpawnBomb()
    {
        Vector2 position = transform.position;
        GameObject bombLocal = Instantiate(bomb, position, Quaternion.identity);
        playerBombAmount -= 1;


        yield return new WaitForSeconds(bombDestructionTime);

        position = bombLocal.transform.position;
        
        BombExplosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);


        explosion.DestructionDelay(explosionDuration);

        Exploding(position, Vector2.up);
        Exploding(position, Vector2.down);
        Exploding(position, Vector2.left);
        Exploding(position, Vector2.right);

        //On lance la fonction des 4 côtés pour détecter les éléments destructibles

        Destroy(bombLocal);

        playerBombAmount += 1;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Bombs"))
        {
            other.isTrigger = false;
        }

    }


    private void DestroyDestructible(Vector2 position)
    {
        Vector3Int cell = destructibleTiles.WorldToCell(position);
        TileBase tile = destructibleTiles.GetTile(cell);

        if (tile != null)
        {
            destructibleTiles.SetTile(cell, null); //On détruit la tile
            OnBombExploded(cell);
        }

        else
        {
            Debug.Log("Y a rien ici");
        }

    }

    private void Exploding(Vector2 position, Vector2 direction)
    {

        position += direction;

        if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, explosionLayerMask))
        {
            DestroyDestructible(position);
            
            return;
        }
    }


    private void OnBombExploded(Vector3 target)
    {
        if (powerUpList.Length > 0 && UnityEngine.Random.value < powerUpSpawnOdds)
        {
            int randomNb = UnityEngine.Random.Range(0, powerUpList.Length);
            Instantiate(powerUpList[randomNb], target , Quaternion.identity);
            Debug.Log("Oh, un objet");

        }

        else
        {
            Debug.Log("Y a rien là-dedans");

        }
    }

}
