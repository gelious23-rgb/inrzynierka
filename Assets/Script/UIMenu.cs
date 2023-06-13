using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
  

public class UIMenu : MonoBehaviour
{
    
    
   // [SerializeField] private Button[] yesNo; //всплывающее окно на будущее
    [SerializeField]  private GameObject NowOpened; 
     
    void Start()
    {
     

    }

 public  void Open(GameObject what)
    {
        Close(NowOpened);
        NowOpened = what;
        what.SetActive(true);
       
    }

    public void Close(GameObject _this)
    {
        if (_this == null)
        {
            return;
        }
        _this.SetActive(false);
        _this = null; 
       
    }

   

    public void ActExitGame()
    {
        Application.Quit();
    }

    public void Mmenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }

    private void Update()
    {
       if(Input.GetKeyDown(KeyCode.Escape))
       {
          Close(NowOpened);
          
       }
    }
}
