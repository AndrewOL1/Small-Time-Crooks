using System.Collections;
using UnityEngine;
using TMPro;

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

    public TMP_Text leftText;
    public TMP_Text midText;
    public TMP_Text rightText;

    public Quaternion DoorOpen;
    public GameObject DoorClose;
    public float openDuration;

    public bool unopened;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftCodeBool = false;
        rightCodeBool = false;
        midCodeBool = false;
        unopened = true;
    }

    // Update is called once per frame
    void Update()
    {
        leftNum = (int)leftKnob.transform.localEulerAngles.z / 36;
        //Debug.Log("" + leftNum + "|" + (int)leftKnob.transform.localEulerAngles.z / 36);
        midNum = (int)midKnob.transform.localEulerAngles.z / 36;
        rightNum = (int)rightKnob.transform.localEulerAngles.z / 36;
        rightText.text = ("" + rightNum);
        leftText.text = ("" + leftNum);
        midText.text = ("" + midNum);
        Combination();
    }

    void Combination()
    {
        if (leftNum == leftCode)
        {
            leftCodeBool = true;
            
        }

        if (midNum == midCode)
        {
            midCodeBool = true;
        }

        if (rightNum == rightCode)
        {
            rightCodeBool = true;
        }

        if (midCodeBool &&  leftCodeBool && rightCodeBool && unopened)
        {
            //Debug.Log("Opening Vault");
            StartCoroutine(OpenDoor());
            unopened = false;
        }
    }

    IEnumerator OpenDoor()
    {
        Debug.Log("Opening Vault");
        float startTime = Time.time;
        while (startTime < openDuration)
        {
            float fracComplete = (Time.time - startTime) / openDuration;
            DoorClose.transform.rotation = Quaternion.Slerp(DoorClose.transform.rotation, DoorOpen, fracComplete);
            yield return null;
        }
    }
}
