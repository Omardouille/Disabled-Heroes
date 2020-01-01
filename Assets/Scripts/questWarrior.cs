using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questWarrior : MonoBehaviour
{
    GameObject player;
    public bool questComplete;
    void Start()
    {
        questComplete = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin")){
            collision.gameObject.SetActive(false);
            questComplete = true;
        }

        if (collision.CompareTag("Player") && questComplete)
        {
            Vector3 tmp = transform.position;
            tmp.x += 3;
            transform.position = tmp;
        }
    }
}
