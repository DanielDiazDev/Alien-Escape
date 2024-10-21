using Common;
using Player;

namespace Interactions
{
    public class UnlockFinalDoorButton : UnlockDoor
    {
        public override void Interact()
        {
            if(PlayerInventory.Instance.HasAllCards())
            {
                var door = _target.GetComponent<SlidingDoor>();
                SoundController.Instance.PlaySFX(SoundController.SFXType.Open, _clip);
                door.OpenDoor();
            }
        }
    }
}