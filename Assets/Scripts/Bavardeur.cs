using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bavardeur : MonoBehaviour
{
    public List<string> rumers;
    //public List<string> narrations;
    public GameObject msgBox;
    public Vector2 offset;

    private bool isPlayerEnter;
    private TextMeshProUGUI textMesh;
    private Transform owner;
    public bool doSpeakAnimalLang;
    public bool isAcceptObject;
    public string acceptableObjectTag;
    public string remerciement;

    void Start()
    {
        owner = gameObject.GetComponentInParent<Transform>();
        textMesh = msgBox.GetComponentInChildren<TextMeshProUGUI>();
        if (gameObject.CompareTag("Animal"))
        {
            SpeakInAnimalLanguage();
        }
        else
        {
            SpeakInHumanLanguage();
        }
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
            if (collision.gameObject.GetComponent<SourdMission>().isSourd())
            {
                if (gameObject.tag == "Animal") {
                    SpeakInHumanLanguage();
                } else
                {
                    SpeakInAnimalLanguage();
                }
            } 
            else
            {
                if (gameObject.tag == "Animal")
                {
                    SpeakInAnimalLanguage();
                }
                else
                {
                    SpeakInHumanLanguage();
                }
            }
            //StartCoroutine(narrate());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            msgBox.SetActive(true);
            isPlayerEnter = true;
            if (doSpeakAnimalLang)
            {
                textMesh.SetText(rumers[1]);
            }
            else
            {
                textMesh.SetText(rumers[0]);
            }
        }

        if (isAcceptObject)
        {
            if (collision.gameObject.CompareTag(acceptableObjectTag))
            {
                Destroy(collision.gameObject);
                textMesh.SetText(remerciement);
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

    public void SpeakInAnimalLanguage()
    {
        doSpeakAnimalLang = true;
    }

    public void SpeakInHumanLanguage()
    {
        doSpeakAnimalLang = false;
    }

    /*
    private IEnumerator narrate()
    {
        textMesh.SetText(narrations[Random.Range(0, narrations.Count)]);
        yield return new WaitForSeconds(1.5f);
    }
    */
}
