﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject canvasMenu;
    public bool paused;
    public TutorialDetector detector;
    public GameObject canvasSure1;
    public GameObject canvasSure2;
    public Win1 win;
    public AudioSource sound;
    public Dialogue dialogue;
    



    public bool dead;

    
    
    // Start is called before the first frame update
    void Start()
    {
        canvasMenu.SetActive(false);
        paused = false;
        dead = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused && !dead)
        {
            if (!canvasSure1.activeSelf && !canvasSure2.activeSelf && !win.win && dialogue.started)
            {
                canvasMenu.SetActive(true);

                foreach (GameObject player in dialogue.scientists)
                {
                    player.SetActive(false);
                }

                Time.timeScale = 0.0f;
                paused = true;
                detector.inMenu = true;
                sound.Play();
            }

            
            
        }

        else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            if (!canvasSure1.activeSelf && !canvasSure2.activeSelf & !win.win && dialogue.started)
            {
                canvasMenu.SetActive(false);

                foreach (GameObject player in dialogue.scientists)
                {
                    player.SetActive(true);
                }

                Time.timeScale = 1.0f;
                paused = false;
                detector.inMenu = false;
                sound.Play();
            }

                
        }
    }
}
