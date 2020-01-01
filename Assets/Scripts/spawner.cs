using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] ennemies;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            foreach (GameObject ennemy in ennemies)
            {
                ennemy.SetActive(true);
            }
            gameObject.SetActive(false);
        }

    }
}
