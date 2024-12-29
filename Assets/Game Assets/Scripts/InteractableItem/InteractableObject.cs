using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] private string _objectInteractNameEn;
    [SerializeField] private string _objectInteractNameRu;
    
    public virtual void Interact()
    {

    }

    public string GetInteractObjectName(string language)
    {
        if(language == "ru")
            return _objectInteractNameRu;
        else
            return _objectInteractNameEn;
    }
}
