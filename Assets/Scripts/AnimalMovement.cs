using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMovement : MonoBehaviour
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
        // 0 - idle, 1 - walk
        state = 0;
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReadyToWalk)
        {
            state = newState();

            switch (state)
            {
                // idle
                case 0:
                {
                    rb.velocity = new Vector2(0, 0);
                    //animator.SetInteger("state", 0);
                } break;                  

                // move
                case 1:
                {
                    direction = newDirection();
                    switch (direction)
                    {
                            case 0:
                                animator.SetFloat("horizontal", -1.0f);
                                animator.SetFloat("vertical", 0.0f);
                                rb.velocity = new Vector2(-1 * moveSpeed, 0);
                                break;
                            case 1:
                                animator.SetFloat("horizontal", 1.0f);
                                animator.SetFloat("vertical", 0.0f);
                                //animator.SetFloat("moveDirection", 1.0f);
                                rb.velocity = new Vector2(1 * moveSpeed, 0);
                                break;
                            case 2:
                                animator.SetFloat("horizontal", 0.0f);
                                animator.SetFloat("vertical", 1.0f);
                                //animator.SetFloat("moveDirection", 1.0f);
                                rb.velocity = new Vector2(0, -1 * moveSpeed);
                                break;
                            case 3:
                                animator.SetFloat("horizontal", 0.0f);
                                animator.SetFloat("vertical", -1.0f);
                                rb.velocity = new Vector2(0, 1 * moveSpeed);
                                //animator.SetFloat("moveDirection", 1.0f);
                                break;
                            default:
                                break;
                    }
                        // Start movement
                        StartCoroutine("walking");
                        //animator.SetInteger("state", 1);
                    } break;

                default:
                    break;
            }
        }
    }

    IEnumerator walking()
    {
        isReadyToWalk = false;
        yield return new WaitForSeconds(2.0f);
        isReadyToWalk = true;
    }

    int newState()
    {
        return Random.Range(0, 2);
    }

    int newDirection()
    {
        int new_direction = -1;
        do {
            new_direction = Random.Range(0, 4);
        } while (direction == new_direction);
        return new_direction;
    }
}
