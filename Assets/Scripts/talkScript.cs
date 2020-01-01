using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talkScript : MonoBehaviour
{
    public string message;
    public GameObject messagePanel;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Text text = messagePanel.gameObject.transform.GetComponentInChildren<Text>();
            text.text = message;
            messagePanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            messagePanel.SetActive(false);
        }
    }
}
