using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GirlBavardeur : MonoBehaviour
{
    public List<string> rumers;
    public List<string> rumersAvecSpahire;
    public GameObject msgBox;
    public Vector2 offset;

    private bool isPlayerEnter;
    private TextMeshProUGUI textMesh;
    private Transform owner;
    public bool doSpeakAnimalLang;
    public bool isAcceptObject;
    public string acceptableObjectTag;
    public string remerciement;

    private List<string> m_rumers;

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
        m_rumers = rumers;
    }

    void Update()
    {
        if (msgBox)
        {
            msgBox.transform.position = Camera.main.WorldToScreenPoint(owner.position) + new Vector3(offset.x, offset.y, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            msgBox.SetActive(true);
            if (collision.gameObject.GetComponent<SourdMission>().isSourd())
            {
                if (gameObject.tag == "Animal")
                {
                    SpeakInHumanLanguage();
                }
                else
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
                textMesh.SetText(m_rumers[1]);
            }
            else
            {
                textMesh.SetText(m_rumers[0]);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAcceptObject)
        {
            if (collision.gameObject.CompareTag(acceptableObjectTag))
            {
                Destroy(collision.gameObject);
                textMesh.SetText(remerciement);
                m_rumers = rumersAvecSpahire;
                GameObject.FindGameObjectWithTag("Player").GetComponent<SourdMission>().DeliverSaphire();
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
