using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DHInventoryItemBase : MonoBehaviour, IInventoryItem
{
    public virtual string Name
    {
        get
        {
            return "BaseItem";
        }
    }

    public Sprite _Image;

    public virtual Sprite Image
    {
        get { return _Image; }
    }

    public virtual void OnDrop()
    {
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = 0;
        gameObject.SetActive(true);
        gameObject.transform.position = pz;
    }

    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
    }

    public virtual void OnUse()
    {

    }

}
