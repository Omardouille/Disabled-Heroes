using UnityEngine;


[ExecuteInEditMode]
[RequireComponent(typeof(SpriteRenderer), typeof(CircleCollider2D))]
public class DHCollectableItem : MonoBehaviour
{
    public int count = 1;
    public string itemName;
    private Sprite sprite;

    public Sprite GetSprite()
    {
        return sprite;
    }

    private void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>().sprite;
    }

    void Reset()
    {
        GetComponent<CircleCollider2D>().isTrigger = true;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        gameObject.SetActive(false);
    }
}