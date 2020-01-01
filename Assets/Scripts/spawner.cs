using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] ennemies;

    private void OnTriggerStay2D(Collider2D collision)
    {
        foreach(GameObject ennemy in ennemies){
            ennemy.SetActive(true);
        }

    }
}
