using UnityEngine;

public class ItemPickup : Interactable
{
    [SerializeField]
    private Item item;
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        Inventory.instance.Add(item);
        Destroy(gameObject);
    }
}
