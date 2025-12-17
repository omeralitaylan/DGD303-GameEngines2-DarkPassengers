using UnityEngine;
using UnityEngine.InputSystem;

public class ItemPickup : MonoBehaviour
{
    public GameObject collectEIcon;
    public Sprite itemSprite;
    
    bool playerNear;

    void Start()
    {
        collectEIcon.SetActive(false);
    }

    void Update()
    {
        if(playerNear && Keyboard.current.eKey.wasPressedThisFrame)
        {
            PickupItem();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerNear = true;
            collectEIcon.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerNear = false;
            collectEIcon.SetActive(false);
        }
    }

    void PickupItem()
    {
        InventoryUI inventory = FindObjectOfType<InventoryUI>();
        inventory.AddItem(itemSprite);
        Destroy(gameObject);
    }
}
