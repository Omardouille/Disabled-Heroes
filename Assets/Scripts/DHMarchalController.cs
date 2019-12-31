using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DHMarchalController : MonoBehaviour
{
    public float moveSpeed = 4f;
    private Animator animator;
    private Rigidbody2D m_rb;
    private Vector2 m_movement;
    public  DHInventory inventory;
    public DHHUD Hud;
    private IInventoryItem m_item_to_pickup = null;
    private bool m_lock_pickup = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        m_rb = gameObject.GetComponent<Rigidbody2D>();
        m_movement = new Vector2(0, 0);
        inventory.ItemUsed += Inventory_ItemUsed;
        m_item_to_pickup = null;
    }

    private void Inventory_ItemUsed(object sender, InventoryEventsArgs e)
    {
        IInventoryItem item = e.Item;

        // Do something with the item
        Debug.Log("Marchal Use Item : " + item.Name);
    }


    // Update is called once per frame
    void Update()
    {
        if (m_item_to_pickup != null && Input.GetKeyDown(KeyCode.F))
        {
            inventory.AddItem(m_item_to_pickup);
            Hud.CloseMessagePanel();
            m_item_to_pickup = null;
        }

        m_movement.x = Input.GetAxisRaw("Horizontal");
        m_movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("speed", m_movement.sqrMagnitude);
        animator.SetFloat("horizontal", m_movement.x);
        animator.SetFloat("vertical", m_movement.y);
        Debug.Log(m_movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        m_rb.MovePosition(m_rb.position + m_movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInventoryItem item = collision.gameObject.GetComponent<IInventoryItem>();
        if (item != null)
        {
            if (m_lock_pickup)
                return;

            m_item_to_pickup = item;

            Hud.OpenMessagePanel("");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IInventoryItem item = collision.gameObject.GetComponent<IInventoryItem>();
        if (item != null)
        {
            Hud.CloseMessagePanel();
            m_item_to_pickup = null;
        }
    }
}
