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
    public float midNum;
    public float rightNum;


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
        leftNum = (int)leftKnob.transform.localEulerAngles.x / 36;
        midNum = (int)midKnob.transform.localEulerAngles.x / 36;
        rightNum = (int)rightKnob.transform.localEulerAngles.x / 36;
        Combination();
    }

    void Combination()
    {
        if ((int)leftKnob.transform.localEulerAngles.x / 36 == leftCode)
        {
            leftCodeBool = true;
            
        }

        if ((int)midKnob.transform.localEulerAngles.x / 36 == midCode)
        {
            midCodeBool = true;
        }

        if ((int)rightKnob.transform.localEulerAngles.x / 36 == rightCode)
        {
            rightCodeBool = true;
        }

        if (midCodeBool &&  leftCodeBool && rightCodeBool)
        {
            Debug.Log("Opening Vault");
        }
    }
}
