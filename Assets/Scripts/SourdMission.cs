using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourdMission : MonoBehaviour
{
    private List<bool> m_condition_mission_chat;
    private List<bool> m_condition_mission_renard;
    private List<bool> m_condition_mission_panda;
    private List<bool> m_condition_mission_fille;
    private bool m_is_sourd;

    // Est-ce qu'il a envoye completeMission a Score
    private bool m_is_mission_chat_sent;
    private bool m_is_mission_renard_sent;
    private bool m_is_mission_panda_sent;
    private bool m_is_mission_fille_sent;

    // Start is called before the first frame update
    void Start()
    {
        m_is_sourd = false;
        m_condition_mission_chat = new List<bool>();
        m_condition_mission_renard = new List<bool>();
        m_condition_mission_panda = new List<bool>();
        m_condition_mission_fille = new List<bool>();

        m_is_mission_chat_sent = false;
        m_is_mission_fille_sent = false;
        m_is_mission_panda_sent = false;
        m_is_mission_renard_sent = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_condition_mission_chat.Count == 3)
        {
            if (!m_is_mission_chat_sent)
            {
                Debug.Log("Flower Mission Complete!");
                GameObject.FindGameObjectWithTag("Score").GetComponent<StarScoreUpdate>().completeMission("Mission-Chat");
                m_is_mission_chat_sent = true;
            }
        }

        if (m_condition_mission_renard.Count == 2)
        {
            if (!m_is_mission_renard_sent)
            {
                GameObject.FindGameObjectWithTag("Score").GetComponent<StarScoreUpdate>().completeMission("Mission-Renard");
                m_is_mission_renard_sent = true;
            }
        }

        if (m_condition_mission_panda.Count == 2)
        {
            if (!m_is_mission_panda_sent)
            {
                GameObject.FindGameObjectWithTag("Score").GetComponent<StarScoreUpdate>().completeMission("Mission-Panda");
                m_is_mission_panda_sent = true;
            }
        }

        if (m_condition_mission_fille.Count == 1)
        {
            if (!m_is_mission_fille_sent)
            {
                GameObject.FindGameObjectWithTag("Score").GetComponent<StarScoreUpdate>().completeMission("Mission-Fille");
                m_is_mission_fille_sent = true;
            }
        }
    }

    public void DeliverOneFlower()
    {
        m_condition_mission_chat.Add(true);
    }

    public void RemoveOneFlower()
    {
        m_condition_mission_chat.RemoveAt(m_condition_mission_chat.Count - 1);
    }

    public void DeliverOneEpice()
    {
        m_condition_mission_renard.Add(true);
    }

    public void RemoveOneEpice()
    {
        m_condition_mission_renard.RemoveAt(m_condition_mission_renard.Count - 1);
    }

    public void DeliverCactus()
    {
        m_condition_mission_panda.Add(true);
    }

    public void DeliverMiel()
    {
        m_condition_mission_panda.Add(true);
    }

    public void RemoveCactus()
    {
        m_condition_mission_panda.RemoveAt(m_condition_mission_panda.Count - 1);
    }

    public void RemoveMiel()
    {
        m_condition_mission_panda.RemoveAt(m_condition_mission_panda.Count - 1);
    }

    public void SetSourd(bool state)
    {
        m_is_sourd = state;
		GameObject.Find("Player").GetComponent<HeartBeat>().isSourd = state;
    }

    public bool isSourd()
    {
        return m_is_sourd;
    }

    public void DeliverSaphire()
    {
        m_condition_mission_fille.Add(true);
    }
}
