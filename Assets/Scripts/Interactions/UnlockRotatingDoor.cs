using Common;

namespace Interactions
{
    public class UnlockRotatingDoor : UnlockDoor
    {
        public override void Interact()
        {
            var door = _target.GetComponent<RotatingDoor>();
            SoundController.Instance.PlaySFX(SoundController.SFXType.Open, _clip);
            door.OpenDoor();
        }
    }
}