using UnityEngine;

public class FastItem : Item
{
    protected override void TakeItem(GameObject target)
    {
        if(target.TryGetComponent<PlayerFacade>(out var player)){
            player.IncreaseSpeed(3);
        }
    }
}