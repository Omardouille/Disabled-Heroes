using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DHInventory : MonoBehaviour
{
    private const int maxItemCount = 8;

    private List<IInventoryItem> m_items = new List<IInventoryItem>();

    public event EventHandler<InventoryEventsArgs> ItemAdded;

    public event EventHandler<InventoryEventsArgs> ItemRemoved;

    public event EventHandler<InventoryEventsArgs> ItemUsed;


    public void AddItem(IInventoryItem item)
    {
        // si on a encore de place pour le ramasser
        if (m_items.Count < maxItemCount)
        {
            Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();
            if (collider.enabled)
            {
                collider.enabled = false;
                m_items.Add(item);
                item.OnPickup();
                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventsArgs(item));
                }
            }
        }
    }

    internal void UseItem(IInventoryItem item)
    {
        if (ItemUsed != null)
        {
            ItemUsed(this, new InventoryEventsArgs(item));
        }
    }

    public void RemoveItem(IInventoryItem item)
    {
        if (m_items.Contains(item))
        {
            m_items.Remove(item);
            item.OnDrop();

            Collider2D collider = (item as MonoBehaviour).GetComponent<Collider2D>();
            if (collider != null)
            {
                collider.enabled = true;
            }

            if (ItemRemoved != null && item != null)
            {
                ItemRemoved(this, new InventoryEventsArgs(item));
            }
        }
        
    }
}
