﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    public bool selected;
    public GameObject panelSelected;
    public GameObject toolBar;
    public GameObject tool;
    public Exit exitScript;

    private float toolBarThreshold;
    private float menuThreshold;


    // Start is called before the first frame update
    void Start()
    {
        selected = false;
        panelSelected.SetActive(false);
        toolBarThreshold = -2.5f;
        menuThreshold = 5.5f;

    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            panelSelected.transform.position = transform.position;
            panelSelected.SetActive(true);
 
        }

        if (selected && Input.GetMouseButtonDown(0))
        {
            Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (cursorPos.y > toolBarThreshold && !exitScript.paused && cursorPos.y < menuThreshold)
            {
                Vector3 updatedPos = new Vector3(cursorPos.x, cursorPos.y, transform.position.z);

                //print(cursorPos.y);

                GameObject clone;
                clone = Instantiate(tool, updatedPos, transform.rotation);

                //ClickAndDrag clickAndDrag;

                //clickAndDrag = clone.GetComponent<ClickAndDrag>();
                //clickAndDrag.enabled = false;

                selected = false;
                panelSelected.SetActive(false);
            }
            
        }
    }

    void OnMouseDown()
    {
        foreach (ClickAndDrag cd in FindObjectsOfType<ClickAndDrag>())
        {
            cd.selected = false;
        }

        selected = true;
        

    }
}
