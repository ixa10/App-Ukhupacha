﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Sprite hold;
    public Sprite notHold;

    private SpriteRenderer buttonSprite;
    private BoxCollider2D col;
    
    // Start is called before the first frame update
    void Start()
    {
        buttonSprite = GetComponent<SpriteRenderer>();
        buttonSprite.sprite = notHold;
        col = GetComponent<BoxCollider2D>();
        col.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDrag()
    {
        buttonSprite.sprite = hold;
    }

    void OnMouseUp()
    {
        buttonSprite.sprite = notHold;
    }

    void OnMouseUpAsButton()
    {
        SceneManager.LoadScene("Play");
        Time.timeScale = 1.0f;
    }
}
