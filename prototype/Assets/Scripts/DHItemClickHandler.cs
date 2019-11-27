using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DHItemClickHandler : MonoBehaviour
{
    public DHInventory _Inventory;

    public void OnItemClicked()
    {
        DHItemDragHandler dragHandler = gameObject.transform.Find("ItemImage").GetComponent<DHItemDragHandler>();

        IInventoryItem item = dragHandler.Item;

        if (item != null)
        {
            Debug.Log(item.Name);
            _Inventory.UseItem(item);
            item.OnUse();
        }
    }
}
