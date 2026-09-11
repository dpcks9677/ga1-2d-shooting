using UnityEngine;

public class HealItem : Item
{
    protected override void TakeItem(GameObject target)
    {
        if (target.TryGetComponent<PlayerFacade>(out var player))
        {
            player.Heal(1);
        }
    }
}