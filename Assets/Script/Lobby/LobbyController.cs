using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyController : MonoBehaviour
{

    [SerializeField] private GameObject LobbyPanel;
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private Button SettingsButton;
    [SerializeField] private Button BackButton;
    [SerializeField] private Button LeaveButton;

    // Start is called before the first frame update
    void Start()
    {
        Button settings = SettingsButton.GetComponent<Button>();
        Button back = BackButton.GetComponent<Button>();
        Button leave = LeaveButton.GetComponent<Button>();
        settings.onClick.AddListener(Settings);
        back.onClick.AddListener(Back);
        leave.onClick.AddListener(Leave);
    }

    private void Settings()
    {
        LobbyPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }
    private void Back()
    {
        SettingsPanel.SetActive(false);
        LobbyPanel.SetActive(true);
    }
    private void Leave()
    {
        SceneManager.LoadScene(0);
    }
}
