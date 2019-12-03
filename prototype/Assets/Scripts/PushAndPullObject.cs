using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAndPullObject : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E) && transform.parent != null)
        {
            transform.SetParent(null);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            transform.SetParent(player.transform);
        }
    }
}
