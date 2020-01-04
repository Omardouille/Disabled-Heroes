using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotBehavior : MonoBehaviour
{
    private GameObject m_fleur;
    // Start is called before the first frame update
    void Start()
    {
        m_fleur = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Flower"))
        {
            collision.gameObject.transform.position = gameObject.transform.position;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player)
            {
                player.GetComponent<SourdMission>().DeliverOneFlower();
                m_fleur = collision.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == m_fleur)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player)
            {
                player.GetComponent<SourdMission>().RemoveOneFlower();
                m_fleur = null;
            }
        }
    }
}
