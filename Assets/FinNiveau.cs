using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinNiveau : MonoBehaviour
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
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Fin du niveau");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

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
}
