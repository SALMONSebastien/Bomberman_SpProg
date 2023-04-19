using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedObject : MonoBehaviour //Script réutilisable pour tous nos objets animés/animables
{
    [SerializeField]
    private SpriteRenderer sr;
    public Sprite[] objectSprites;

    public Sprite objectIdleSprite;
    public bool isIdle = true;


    public float animationDuration = 1f;
    private int currentFrame;

    //True, car la plupart des animations seront des loops
    public bool isAnimationLooping = true;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        InvokeRepeating(nameof(GoToNextAnimationFrame), animationDuration, animationDuration);
    }

    private void OnEnable()
    {
        sr.enabled = true;
    }

    private void OnDisable()
    {
        sr.enabled = false;
    }

    private void GoToNextAnimationFrame()
    {
        currentFrame++;

        if(isAnimationLooping && currentFrame >= objectSprites.Length)
        {
            currentFrame = 0;
        }

        if (isIdle)
        {
            sr.sprite = objectIdleSprite;
        }

        else if (currentFrame >= 0 && currentFrame < objectSprites.Length)
        {
            sr.sprite = objectSprites[currentFrame];

        }

    }

    
}
