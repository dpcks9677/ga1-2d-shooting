using UnityEngine;

public class FastItem : Item
{
    protected override void TakeItem(GameObject target)
    {
        Debug.Log("executed");
        PlayerMove playerHealth = target.GetComponent<PlayerMove>();

        playerHealth.ModifySpeed(3);
    }
}