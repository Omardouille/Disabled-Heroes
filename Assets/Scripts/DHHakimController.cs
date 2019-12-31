using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DHHakimController : MonoBehaviour
{
    public float satisfactionThreshold = 100;
    private float m_satisfaction;
    private Animator m_animator;
    private RuntimeAnimatorController animatorController;

    // Start is called before the first frame update
    void Start()
    {
        m_satisfaction = 0f;
        m_animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO remove
        m_satisfaction += 0.2f;
        m_animator.SetFloat("satisfaction", m_satisfaction);
    }
}
