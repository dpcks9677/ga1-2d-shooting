using UnityEngine;

public class FastItem : Item
{
    protected override void TakeItem(GameObject target)
    {
        PlayerMove playerHealth = target.GetComponent<PlayerMove>();
        playerHealth.ModifySpeed(3);
    }
}