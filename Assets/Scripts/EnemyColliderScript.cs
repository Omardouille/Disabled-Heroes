using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        transform.parent.gameObject.GetComponent<EnemiBehavior>().isNear(collider);
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        transform.parent.gameObject.GetComponent<EnemiBehavior>().isNotNear(collider);
    }
}
