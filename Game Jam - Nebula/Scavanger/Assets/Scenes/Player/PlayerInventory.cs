using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [Header("Start")]

    [Header("CurrentInv")]
    public int CurrentAmmo;
    public int CurrentResources;

    [Header("InvLimits")]
    public int MaxAmmo;
    public int MaxInventory;

    [Header("StatLvls")]
    public float SpeedLvl;
    public float AttackLvl;
    public float AttackSpeedLvl;
    public float InventoryLvl;
    public float HealthLvl;

    // Update is called once per frame
    void Update()
    {
        
    }

    bool CheckIfInventoryIsFull()
    {
        if (CurrentResources >= MaxInventory * InventoryLvl)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
