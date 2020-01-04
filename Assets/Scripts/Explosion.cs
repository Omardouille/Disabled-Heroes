using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionForce;
    public GameObject[] toBeRemoved;
    private Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.CompareTag("Player"))
        {
            IEnumerator e = wait(obj);
            StartCoroutine(e);
        }
    }

    IEnumerator wait(GameObject obj)
    {
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -1 * explosionForce));
        m_animator.Play("Explosion");
        Destroy(GetComponent<CircleCollider2D>());
        yield return new WaitForSeconds(0.5f);
        if (toBeRemoved.Length > 0)
        {
            for (int i = 0; i < toBeRemoved.Length; ++i)
            {
                Destroy(toBeRemoved[i]);
            }
        }
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        obj.GetComponent<SourdMission>().SetSourd(true);
    }
}
