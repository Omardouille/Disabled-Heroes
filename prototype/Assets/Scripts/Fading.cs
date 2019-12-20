using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour
{
    internal SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Color tmp = spriteRenderer.color;
            tmp.a = 0.2f;
            spriteRenderer.color = tmp;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Color tmp = spriteRenderer.color;
            tmp.a = 1f;
            spriteRenderer.color = tmp;
        }
    }
}
