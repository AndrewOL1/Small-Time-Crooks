using PurrNet;
using UnityEngine;
using UnityEngine.InputSystem;

public class KeyInteractable : NetworkBehaviour, Iinteractable
{
    [SerializeField]
    private GameObject prefab;


    public bool CanInteract()
    {
        return true;
    }

    public bool Interact(Interactor interactor)
    {
        interactor.hasItem = true;
        interactor.heldItem = prefab;
        Debug.Log("You have grabbed the key!");
        Destroy(gameObject);

        return true;
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
