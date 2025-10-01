using UnityEngine;

public class VaultScript : MonoBehaviour
{
    public GameObject leftKnob;
    public GameObject midKnob;
    public GameObject rightKnob;
    public float leftCode;
    public float rightCode;
    public float midCode;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Combination();
    }

    void Combination()
    {
        if (leftKnob.transform.rotation.x / 6 == leftCode)
        {
            
            Debug.Log("Left unlocked");
        }
    }
}
