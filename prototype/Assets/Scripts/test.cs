using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    //todo: modifier tout le script pour le mettre sur le npc et non sur le player
    GameObject npc;
    void Start()
    {
        npc = GameObject.FindGameObjectWithTag("npc");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("npc") )//ajouter une condition de réalisation d'une quete
        {
            Vector3 tmp = npc.transform.position;
            tmp.x += 2;

            npc.transform.position = tmp;
        }
    }
}
