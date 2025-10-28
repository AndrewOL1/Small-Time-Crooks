using UnityEngine;

public class VaultScript : MonoBehaviour
{
    public GameObject leftKnob;
    public GameObject midKnob;
    public GameObject rightKnob;
    public float leftCode;
    public float rightCode;
    public float midCode;

    public bool leftCodeBool;
    public bool rightCodeBool;
    public bool midCodeBool;


    public float leftNum;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftCodeBool = false;
        rightCodeBool = false;
        midCodeBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        leftNum = leftKnob.transform.localEulerAngles.x;
        Combination();
    }

    void Combination()
    {
        if ((int)leftKnob.transform.localEulerAngles.x / 6 == leftCode)
        {
            leftCodeBool = true;
            
        }

        if ((int)midKnob.transform.localEulerAngles.x / 6 == midCode)
        {
            midCodeBool = true;
        }

        if ((int)rightKnob.transform.localEulerAngles.x / 6 == rightCode)
        {
            rightCodeBool = true;
        }

        if (midCodeBool &&  leftCodeBool && rightCodeBool)
        {
            Debug.Log("Opening Vault");
        }
    }
}
