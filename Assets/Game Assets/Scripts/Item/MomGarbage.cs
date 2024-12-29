using UnityEngine;

public class MomGarbage : InteractableObject, IInteractable
{
    public override void Interact()
    {
        Debug.Log($"Sweetie wha are u doing?");
    }
}
