using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<FMODUnity.StudioEventEmitter>().Play();
        GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("Silence", 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("Silence", 0);
                break;
            default: break;
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                GetComponent<FMODUnity.StudioEventEmitter>().SetParameter("Silence", 1);
                break;
            default: break;
        }


    }
}
