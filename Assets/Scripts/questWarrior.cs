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

    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Coin") != null)
        {
            GameObject coin = GameObject.FindGameObjectWithTag("Coin");
            BoxCollider2D[] c = gameObject.GetComponents<BoxCollider2D>();
            BoxCollider2D c2 = c[1];
            BoxCollider2D c3 = coin.GetComponent<BoxCollider2D>();
            if (c3.IsTouching(c2))
            {
                coin.gameObject.SetActive(false);
                questComplete = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && questComplete)
        {
            Vector3 tmp = transform.position;
            tmp.x += 3;
            transform.position = tmp;
        }
    }
}
