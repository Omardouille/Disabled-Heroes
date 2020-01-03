using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bavardeur : MonoBehaviour
{
    public List<string> rumeures;
    public GameObject msgBox;
    public Vector2 offset;

    private Transform owner;

    private void Start()
    {
        owner = gameObject.GetComponentInParent<Transform>();
        Debug.Log("Owner position : " + owner.position);
    }

    private void Update()
    {
        if (msgBox)
        {
            msgBox.transform.position = Camera.main.WorldToScreenPoint(owner.position) + new Vector3(offset.x, offset.y, 0) ;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {            
            Text text = msgBox.GetComponentInChildren<Text>();
            text.text = rumeures[Random.Range(0, rumeures.Count)];
            StartCoroutine("wait");
        }
    }

    IEnumerable wait()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
