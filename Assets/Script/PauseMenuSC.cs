using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuSC : MonoBehaviour
{
    [SerializeField] private GameObject SettingsPref;
    private GameObject ThisCanvas;
    private bool settingsOn;

    private void Start()
    {
        ThisCanvas = GameObject.FindObjectOfType<Canvas>().gameObject;
    }

    public void ResumePause()
    {
        this.gameObject.SetActive(false);
    }

    public void SettingsPause()
    {
        var settingsMenu = Instantiate(SettingsPref, Vector3.zero, Quaternion.identity, ThisCanvas.transform);
        settingsOn = true; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && settingsOn)
        {
             GameObject.Find("Settings").SetActive(false);
             settingsOn = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !settingsOn)
        {
            ResumePause();
        }
    }
}
