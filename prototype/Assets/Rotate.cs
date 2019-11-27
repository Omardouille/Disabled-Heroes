using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

	public GameObject attached;
	public Rigidbody2D rb;
	public float speed = (float)2;
	public float speed_rotate = (float)50;
	bool isAttached;
	float rotation = (float)0;
	
	void Fire() {
		isAttached = false;
	}

    void Start()
    {
		this.transform.position = attached.transform.position;
		isAttached = true;
		rb = GetComponent<Rigidbody2D>();

		//rb.useFullKinematicContacts = true;
    }

    // Update is called once per frame
    void Update()
    {

		if(isAttached) {
			this.transform.position = attached.transform.position;
			rotation += speed_rotate*Time.fixedDeltaTime;
			this.transform.Rotate(0,0,rotation);
			this.transform.Translate(0, 1, 0);
			this.transform.Rotate(0,0,-rotation); // on annule la rotation

		} else {
			this.transform.Rotate(0,0,rotation);
			this.transform.Translate(0, speed*Time.fixedDeltaTime, 0);
			this.transform.Rotate(0,0,-rotation);
		}
		
		if (Input.GetKeyDown("space")) {
            Fire();
        }
    }
	
	private void OnTriggerEnter2D(Collider2D other) {
		if(isAttached)
			return;
		
        switch(other.gameObject.tag) {
			case "Enemy": break;
			case "Wall": isAttached = true; break;
			default: break;
		}


    }
	
	
	
}
