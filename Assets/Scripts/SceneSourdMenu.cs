using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSourdMenu : MonoBehaviour
{
    public string nextLevelName;
    public Button nextLevelButton;
    public Button exitButton;
    public Button mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        nextLevelButton.onClick.AddListener(delegate { nextLevel(nextLevelName); });
        exitButton.onClick.AddListener(exit);
        mainMenuButton.onClick.AddListener(switchToMainMenu);
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void nextLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    void exit()
    {
        Application.Quit();
    }

    void switchToMainMenu()
    {
        // TODO
        Debug.Log("Need to develop.");
    }
}
