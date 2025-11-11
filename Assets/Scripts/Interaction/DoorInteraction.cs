using UnityEngine;
//using DG.Tweening;

public class DoorInteraction : MonoBehaviour, Iinteractable
{
    //This was purely for testing purposes



    //[SerializedField]
    public Vector3 _targetRotation = new Vector3(0, -100f, 0f);
    //SerializedField]
    public float _rotationSpeed = 3f;

    private bool _isOpen = false;

    public bool CanInteract()
    {
        return true;
    }

    public bool Interact(Interactor interactor)
    {
        if (_isOpen)
        {
            Debug.Log("Closing");
            //transform.DORotate(-_targetRotation, _rotationSpeed, RotateMode.WorldAxisAdd);
        }
        else
        {
            //transform.DORotate(_targetRotation, _rotationSpeed, RotateMode.WorldAxisAdd);
            Debug.Log("Opening");
        }

        _isOpen = !_isOpen;

        return true;

    }


}
