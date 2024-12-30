using UnityEngine;
using SUPERCharacter;

public class PlayerCanMoveStateController : MonoBehaviour
{
    [SerializeField] private SUPERCharacterAIO _character;

    private float _sensitivity;

    public void FreezePlayer()
    {
        _character.PausePlayer(PauseModes.FreezeInPlace);      
    }

    public void UnfreezePlayer()
    {
        _character.UnpausePlayer();
    }
}
