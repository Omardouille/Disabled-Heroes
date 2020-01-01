using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DHHUD : MonoBehaviour
{
    public DHInventory inventory;
    public GameObject messagePanel;

    // Start is called before the first frame update
    void Start()
    {
        inventory.ItemAdded += Inventory_ItemAdded;
        inventory.ItemRemoved += Inventory_ItemRemoved;
    }

    private void Inventory_ItemAdded(object sender, InventoryEventsArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        foreach (Transform slot in inventoryPanel)
        {
            // Border -> Itemimage
            Transform itemImageTransform = slot.GetChild(0).GetChild(0);
            Image image = itemImageTransform.GetComponent<Image>();
            DHItemDragHandler itemDragHandler = itemImageTransform.GetComponent<DHItemDragHandler>();

            // we found the empty slot
            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                // store reference to the item
                Debug.Log("Store reference to item :" + e.Item.Name);
                itemDragHandler.Item = e.Item;
                break;
            }
        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventsArgs e)
    {
        Debug.Log("Inventory - Remove Item");
        Transform inventoryPanel = transform.Find("InventoryPanel");
        foreach (Transform slot in inventoryPanel)
        {
            // Border -> Itemimage
            Transform itemImageTransform = slot.GetChild(0).GetChild(0);
            Image image = itemImageTransform.GetComponent<Image>();
            DHItemDragHandler itemDragHandler = itemImageTransform.GetComponent<DHItemDragHandler>();

            // we found the item in the ui
            if (itemDragHandler.Item.Equals(e.Item))
            {
                Debug.Log("To drop");
                image.enabled = false;
                image.sprite = null;
                itemDragHandler.Item = null;
                break;
            }
        }
    }

    public void OpenMessagePanel(string text)
    {
        Text txt = messagePanel.gameObject.transform.GetComponentInChildren<Text>();
        txt.text = text;
        messagePanel.SetActive(true);
    }

    public void CloseMessagePanel()
    {
        messagePanel.SetActive(false);
    }
}
