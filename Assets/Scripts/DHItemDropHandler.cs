using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DHItemDropHandler : MonoBehaviour, IDropHandler
{
    public DHInventory inventory;

    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;
        if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
            IInventoryItem item = eventData.pointerDrag.gameObject.GetComponent<DHItemDragHandler>().Item;
            if (item != null)
            {
                inventory.RemoveItem(item);
            }
        }
    }
}
