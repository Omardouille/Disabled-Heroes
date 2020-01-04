using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button quitButton;
    public Button levelsButton;
    public Button backButton;

    public GameObject mainPanel;
    public GameObject levelsPanel;

    public List<Button> levelButtons = new List<Button>(4);
    public List<string> levelNames = new List<string>(4);

    // Start is called before the first frame update
    void Start()
    {
        mainPanel.SetActive(true);
        levelsPanel.SetActive(false);

        quitButton.onClick.AddListener(Application.Quit);
        levelsButton.onClick.AddListener(levelsButtonCallback);
        backButton.onClick.AddListener(backButtonCallback);
        for (int i = 0; i < 4; ++i)
        {
            string name = levelNames[i];
            levelButtons[i].onClick.AddListener(delegate { SceneManager.LoadScene(name); });
        }
    }

    void levelsButtonCallback()
    {
        mainPanel.SetActive(false);
        levelsPanel.SetActive(true);
    }

    void backButtonCallback()
    {
        levelsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
