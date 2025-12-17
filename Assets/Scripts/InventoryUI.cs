using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Image itemIcon;

    void Start()
    {
        itemIcon.gameObject.SetActive(false);
    }

    public void AddItem(Sprite itemSprite)
    {
        itemIcon.sprite = itemSprite;
        itemIcon.gameObject.SetActive(true);
    }

    public void RemoveItem()
    {
        itemIcon.sprite = null;
        itemIcon.gameObject.SetActive(false);
    }
}
