using UnityEngine;

public class increaseFireRate : Item
{
    protected override void TakeItem(GameObject target)
    {
        PlayerFire playerFire = target.GetComponent<PlayerFire>();

        playerFire.ModifyFireRate(0.1f);
    }
}