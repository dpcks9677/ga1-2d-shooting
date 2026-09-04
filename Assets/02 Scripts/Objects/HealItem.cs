using UnityEngine;

public class HealItem : Item
{
    protected override void TakeItem(GameObject target)
    {
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();

        playerHealth.ModifyHealth(1);
        Debug.Log(playerHealth.returnHealth());
    }
}