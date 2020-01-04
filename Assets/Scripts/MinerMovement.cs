using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinerMovement : MonoBehaviour
{
    public float moveSpeed;

    private bool isReadyToWalk;
    private Rigidbody2D rb;
    private int state;
    private int direction;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        isReadyToWalk = true;
        direction = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReadyToWalk)
        {
            if (direction > 0)
                animator.SetFloat("moveDirection", 1.0f);

            if (direction < 0)
                animator.SetFloat("moveDirection", 0.0f);

            rb.velocity = new Vector2(direction * moveSpeed, 0);

            // Start movement
            StartCoroutine("walking");
        }
    }

    IEnumerator walking()
    {
        isReadyToWalk = false;
        yield return new WaitForSeconds(2.0f);
        isReadyToWalk = true;
        direction *= -1;
    }
}
