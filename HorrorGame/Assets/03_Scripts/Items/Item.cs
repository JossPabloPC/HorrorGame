using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    //public int amount = 0;
    public bool isKey;
    public bool isFAK;
    public bool isBullet;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
        if (isFAK)
        {
            PlayerManager.instance.TakeFAK();
        }
        else if (isBullet)
        {
            Gun.instance.ReloadAmmo();
        }
    }
}
