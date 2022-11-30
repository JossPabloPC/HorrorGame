using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    Item item;
    public Button removeBtn;
    public Button useBtn;

    [ContextMenu("cola")]
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeBtn.interactable = true;
        if (item.isKey)
        {
            PlayerManager.instance.PickedKey();
        }
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeBtn.interactable = false;
    }

    public void onRemoveBtn()
    {
        Inventory.instance.Remove(item);
    }

    public void onUseBtn()
    {
        item.Use();
        Inventory.instance.Remove(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }
}
