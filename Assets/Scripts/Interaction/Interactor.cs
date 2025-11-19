using PurrNet;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : NetworkBehaviour
{
    public float _castDistance = 5f;
    public Vector3 _raycastOffset = new Vector3(0, 1f, 0);

    public bool hasItem;
    public GameObject heldItem;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && hasItem == false)
        {
            

            if (DoInteractionTest(out Iinteractable interactable))
            {
                if (interactable.CanInteract())
                {
                    interactable.Interact(this);
                }
            }
        } else if (Keyboard.current.eKey.wasPressedThisFrame && hasItem == true)
        {
            DropItem();
            
        }
    }

    private bool DoInteractionTest(out Iinteractable interactable)
    {
        interactable = null;

        Ray ray = new Ray(transform.position + _raycastOffset, transform.forward);

        Debug.DrawRay(ray.origin, ray.direction, Color.red, 3f);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _castDistance))
        {
            interactable = hitInfo.collider.GetComponent<Iinteractable>();

            if (interactable != null)
            {
                return true;
            }

            return false;
        }

        return false;
    }

    /*public void OnInteract(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            Debug.Log("Interacting");
        }
    }*/

    public void DropItem()
    {
        Instantiate(heldItem, transform.position, Quaternion.identity);
        hasItem = false;
    }
}
