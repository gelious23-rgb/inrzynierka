using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    [SerializeField] private Button Create;
    [SerializeField] private Button Quit;
    [SerializeField] private Button Find;
    [SerializeField] private Button Join;
    [SerializeField] private Button Back;
    [SerializeField] private GameObject MenuPanel;
    [SerializeField] private GameObject JoinPanel;

    // Start is called before the first frame update
    void Start()
    {
        Button create = Create.GetComponent<Button>();
        Button find = Find.GetComponent<Button>();
        Button quit = Quit.GetComponent<Button>();
        Button join = Join.GetComponent<Button>();
        Button back = Back.GetComponent<Button>();
        create.onClick.AddListener(CreateGame);
        find.onClick.AddListener(FindGame);
        quit.onClick.AddListener(QuitGame);
        join.onClick.AddListener(JoinGame);
        back.onClick.AddListener(BacktoLobby);
    }

    private void CreateGame()
    {
        SceneManager.LoadScene(1);
    }
    private void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    private void FindGame()
    {
        MenuPanel.SetActive(false);
        JoinPanel.SetActive(true);
    }
    private void JoinGame()
    {
        //Join Game script
        Debug.Log("Join game");
    }
    private void BacktoLobby()
    {
        JoinPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }
}
