using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Mission
{
    public string name;
    public bool isComplete;
}

public class StarScoreUpdate : MonoBehaviour
{
    private Mission[] m_missions;
    private int m_mision_complete_num;


    // Start is called before the first frame update
    void Start()
    {
        // Initialization
        m_missions = new Mission[4];
        m_missions[0].name = "Mission-Fille";
        m_missions[0].isComplete = false;
        m_missions[1].name = "Mission-Chat";
        m_missions[1].isComplete = false;
        m_missions[2].name = "Mission-Panda";
        m_missions[2].isComplete = false;
        m_missions[3].name = "Mission-Renard";
        m_missions[3].isComplete = false;

        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(28, 28, 100));
        countCompleteMission();

        for (int i = 0; i < m_mision_complete_num; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }

        if (m_mision_complete_num == 4)
        {
            Time.timeScale = 0;
            GameObject[] inGameUIObjs = GameObject.FindGameObjectsWithTag("InGameUI");
            if (inGameUIObjs.Length >= 0)
            {
                foreach (GameObject obj in inGameUIObjs)
                {
                    obj.SetActive(false);
                }
            }

            GameObject successMenu = GameObject.FindGameObjectWithTag("GameStopUI");
            if (successMenu)
            {
                for (int i = 0; i < successMenu.transform.childCount; ++i)
                {
                    successMenu.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
        }
    }

    public void completeMission(string name)
    {
        for (int i = 0; i < 4; ++i)
        {
            if (name == m_missions[i].name)
            {
                m_missions[i].isComplete = true;
            }
        }
    }

    private void countCompleteMission()
    {
        int num = 0;
        for (int i = 0; i < 4; ++i)
        {
            if (m_missions[i].isComplete)
            {
                num += 1;
            }
        }
        m_mision_complete_num = num;
    }
}
