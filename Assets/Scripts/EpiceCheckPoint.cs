using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EpiceCheckPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Epice"))
        {
            collision.gameObject.transform.position = gameObject.transform.position;
            collision.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player)
            {
                player.GetComponent<SourdMission>().DeliverOneEpice();
            }
        }
    }
}
