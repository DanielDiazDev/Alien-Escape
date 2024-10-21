using Common;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Interactions
{
    public class UnlockDoorButton : UnlockDoor
    {
        public override void Interact()
        {
            var door = _target.GetComponent<SlidingDoor>();
            SoundController.Instance.PlaySFX(SoundController.SFXType.Open, _clip);
            door.OpenDoor();
        }
    }

}