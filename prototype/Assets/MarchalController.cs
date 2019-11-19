using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchalController : MonoBehaviour
{
    public float moveSpeed = 4f;
    private Animator m_animator;
    private Rigidbody2D m_rb;
    private Vector2 m_movement;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
        m_rb = gameObject.GetComponent<Rigidbody2D>();
        m_movement = new Vector2(0, 0);
    }


    // Update is called once per frame
    void Update()
    {
        m_movement.x = Input.GetAxisRaw("Horizontal");
        m_movement.y = Input.GetAxisRaw("Vertical");
        m_animator.SetFloat("speed", m_movement.sqrMagnitude);
        m_animator.SetFloat("horizontal", m_movement.x);
        m_animator.SetFloat("vertical", m_movement.y);
        Debug.Log(m_movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        m_rb.MovePosition(m_rb.position + m_movement * moveSpeed * Time.fixedDeltaTime);
    }
}
