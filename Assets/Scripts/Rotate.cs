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
	float distance = (float)0;
	public float maxDistance = (float)5;
	
	void Fire() {
		if(isAttached)
			GetComponent<FMODUnity.StudioEventEmitter>().Play();
		isAttached = !isAttached;
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
			GetComponent<FMODUnity.StudioEventEmitter>().Stop();
			this.transform.position = attached.transform.position;
			rotation += speed_rotate*Time.fixedDeltaTime;
			this.transform.Rotate(0,0,rotation);
			this.transform.Translate(0, 1, 0);
			this.transform.Rotate(0,0,-rotation); // on annule la rotation
			distance = (float)0;

		} else {
			this.transform.Rotate(0,0,rotation);
			this.transform.Translate(0, speed*Time.fixedDeltaTime, 0);
			this.transform.Rotate(0,0,-rotation);
			distance += speed * Time.fixedDeltaTime;
		}

		if(distance > maxDistance) {
			isAttached = true;
        }
		
		if (Input.GetKeyDown("space")) {
            Fire();
        }
    }


	private void OnTriggerEnter2D(Collider2D other) {
		if(isAttached)
			return;

        switch(other.gameObject.tag) {
			case "Enemy": other.gameObject.GetComponent<EnemiBehavior>().isTouched();  break;
			case "Wall": isAttached = true; break;
			default: break;
		}


    }
	
	
	
}
