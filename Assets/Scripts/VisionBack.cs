using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionBack : MonoBehaviour
{

	private GameObject finLvl;
    // Start is called before the first frame update
    void Start()
    {
        finLvl = GameObject.Find("Sortie");
		finLvl.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void OnTriggerEnter2D(Collider2D c) {
		if(c.gameObject.tag == "Player"){
			// On autorise la porte
			GameObject.Find("Main Camera").GetComponents<ColorBlindFilter>()[0].mode = ColorBlindMode.Normal;
			finLvl.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}
