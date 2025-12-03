using PurrNet;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyInteractable : NetworkBehaviour, Iinteractable
{
    [SerializeField]
    private NetworkIdentity prefab;


    public bool CanInteract()
    {
        return true;
    }
    
    public bool Interact(Interactor interactor)
    {
        SetVal(interactor);
        interactor.hasItem = true;
        interactor.heldItem = prefab;
        Debug.Log( interactor.heldItem);
        Debug.Log("You have grabbed the key!");
        Destroy(gameObject);

        return true;
    }
    [ServerRpc]
    private void SetVal(Interactor interactor)
    {
        interactor.hasItem = true;
        interactor.heldItem = prefab;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
