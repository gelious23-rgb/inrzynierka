using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown Resolution;
    [SerializeField] private Toggle Fullscreen;
    private Resolution[] resolutions;
    private List<Resolution> ResolutionList;
    private float currentRefreshrate;
    private int resolutionIndex = 0;
    

    private void Start()
    {
      
        resolutions = Screen.resolutions;
        ResolutionList = new List<Resolution>();
        Resolution.ClearOptions();
        currentRefreshrate = Screen.currentResolution.refreshRate; 
        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshrate)
            {
                ResolutionList.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for(int i = 0; i < ResolutionList.Count; i++)
        {
            string resolutionOption = ResolutionList[i].width+"x"+ ResolutionList[i].height+" "+ResolutionList[i].refreshRate+" Hz";
            options.Add(resolutionOption);
            if (ResolutionList[i].width == Screen.width && ResolutionList[i].height == Screen.height)
            {
                resolutionIndex = i;
            }
        }
        Resolution.AddOptions(options);
        Resolution.value = resolutionIndex; 
        Resolution.RefreshShownValue();
    }

    public void FullScreen(bool fsc)
    {
        Screen.fullScreen = fsc;
        Debug.Log("Fullscreen is " + fsc);
    }
    public void SetScreenRes(int resIndex)
    {
        Resolution resolution = ResolutionList[resolutionIndex]; 
        Screen.SetResolution(resolution.width, resolution.height, true);
        
    }
}
