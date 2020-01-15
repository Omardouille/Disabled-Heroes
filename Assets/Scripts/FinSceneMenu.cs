using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinSceneMenu : MonoBehaviour
{
    public string nextLevelName;
    public Button nextLevelButton;
    public Button exitButton;
    public Button mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        nextLevelButton.onClick.AddListener(delegate { SceneManager.LoadScene(nextLevelName);  });
        exitButton.onClick.AddListener(exit);
        mainMenuButton.onClick.AddListener(delegate { SceneManager.LoadScene("Menu"); });
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    void exit()
    {
        Application.Quit();
    }
}
