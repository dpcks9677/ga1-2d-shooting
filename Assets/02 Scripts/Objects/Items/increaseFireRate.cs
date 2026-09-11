using UnityEngine;

public class increaseFireRate : Item
{
    protected override void TakeItem(GameObject target)
    {
        if(target.TryGetComponent<PlayerFacade>(out var player))
        {
            player.IncreaseFireRate(0.1f);
        }
    }
}