using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    [Header("Basics Player")]

    [SerializeField]
    public Rigidbody2D rgb;

    [SerializeField]
    private Vector2 playerDirection;
    public float playerSpeed = 3f;
    public float playerStrength = 3f;


    public float currentLife = 1f;
    public Scrollbar playerLife;
    

    [Header("Mapping Player")]

    public KeyCode playerUp = KeyCode.Z;
    public KeyCode playerDown = KeyCode.S;
    public KeyCode playerLeft = KeyCode.Q;
    public KeyCode playerRight = KeyCode.D;

    [Header("Animations Player")]

    //Gestion des animations
    public AnimatedObject srUp;
    public AnimatedObject srDown;
    public AnimatedObject srLeft;
    public AnimatedObject srRight;
    private AnimatedObject activeSr;

    private void Awake()
    {
        rgb = GetComponent<Rigidbody2D>();
        activeSr = srDown;

    }

    private void Start()
    {
        playerDirection = Vector2.down;

    }

    private void Update()
    {
        if(Input.GetKey(playerUp))
        {
            SetPlayerDirection(Vector2.up, srUp);
        }

        else if (Input.GetKey(playerDown))
        {
            SetPlayerDirection(Vector2.down, srDown);
        }

        else if (Input.GetKey(playerLeft))
        {
            SetPlayerDirection(Vector2.left, srLeft);
        }

        else if (Input.GetKey(playerRight))
        {
            SetPlayerDirection(Vector2.right, srRight);
        }

        else
        {
            SetPlayerDirection(Vector2.zero, activeSr); // Contrairement aux autres, on garde actif le sprite actuel
        }

    }

    private void FixedUpdate()
    {
        // On utilise FixedUpdate pour éviter de dépendre du framerate

        Vector2 currentPosition = rgb.position;
        Vector2 translation = playerDirection * playerSpeed * Time.fixedDeltaTime;

        rgb.MovePosition(currentPosition + translation);
    }

    private void SetPlayerDirection(Vector2 newPlayerDirection, AnimatedObject sr)
    {
        playerDirection = newPlayerDirection;

        srUp.enabled = sr == srUp;
        srDown.enabled = sr == srDown;
        srLeft.enabled = sr == srLeft;
        srRight.enabled = sr == srRight;

        activeSr = sr;
        activeSr.isIdle = playerDirection == Vector2.zero; // déclare le perso comme Idle si Vector2.zero = pas de touche pressée


    }

    private void OnTriggerEnter2D(Collider2D collider) //Permet la mort du personnage
    {
        if (collider.CompareTag("Bomb")) // Le Tag bomb fait référence à l'explosion de celle-ci, pas à au prefab bomb.
        {
            PlayerLifeDecrease(0.3f);
        }
    }

    public void PlayerLifeDecrease(float nb)
    {
        currentLife -= nb;
        playerLife.size -= nb;

        if (currentLife <= 0)
        {

            PlayerDeath();
        }

    }


    private void PlayerDeath()
    {
        enabled = false;
        GetComponent<BombHandler>().enabled = false;
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().Winner();   
            
     }

}
