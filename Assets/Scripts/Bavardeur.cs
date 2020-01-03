using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bavardeur : MonoBehaviour
{
    public List<string> rumeures;
    public GameObject msgBox;
    public Vector2 offset;

    private bool isPlayerEnter;
    private TextMeshProUGUI textMesh;
    private Transform owner;

    void Start()
    {
        owner = gameObject.GetComponentInParent<Transform>();
        textMesh = msgBox.GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
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
            msgBox.SetActive(true);
            isPlayerEnter = true;
            //msgBox.GetComponentInChildren<Text>().text = rumeures[Random.Range(0, rumeures.Count)];
            if (rumeures.Count > 0)
            {
                textMesh.SetText(rumeures[Random.Range(0, rumeures.Count)]);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        msgBox.SetActive(false);
        if (collision.CompareTag("Player"))
        {
            isPlayerEnter = false;
        }
    }
}
