using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    [SerializeField] private Button Create;
    [SerializeField] private Button Quit;

    // Start is called before the first frame update
    void Start()
    {
        Button create = Create.GetComponent<Button>();
        Button quit = Quit.GetComponent<Button>();
        create.onClick.AddListener(CreateGame);
        quit.onClick.AddListener(QuitGame);
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
}
