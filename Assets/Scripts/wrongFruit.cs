using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrongFruit : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            player.GetComponent<DHMarchalController>().nbvie--;
        }
    }
}
