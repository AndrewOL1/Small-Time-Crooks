using UnityEngine;

public class PillarScript : MonoBehaviour
{
    public string RightBottle;
    public bool correctPlacement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        correctPlacement = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(RightBottle))
        {
            correctPlacement = true;
            Debug.Log("RightBottle");
        }
        else
        {
            Debug.Log("WrongBottle");
            correctPlacement = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        correctPlacement = false;
    }


}
