using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VaultScript : MonoBehaviour
{
    public GameObject leftKnob;
    public GameObject midKnob;
    public GameObject rightKnob;
    public int leftCode;
    public int rightCode;
    public int midCode;

    public bool leftCodeBool;
    public bool rightCodeBool;
    public bool midCodeBool;


    public int leftNum;
    public int midNum;
    public int rightNum;

    public TMP_Text leftText;
    public TMP_Text midText;
    public TMP_Text rightText;

    public Quaternion DoorOpen;
    public GameObject DoorClose;
    public float openDuration;
    [SerializeField]
    private Slider rightSlider, leftSlider, midSlider;

    public bool unopened;
    
    public bool test;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip openClip;


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
        //leftNum = (int)leftKnob.transform.localEulerAngles.z / 36;
        //Debug.Log("" + leftNum + "|" + (int)leftKnob.transform.localEulerAngles.z / 36);
        //midNum = (int)midKnob.transform.localEulerAngles.z / 36;
        //rightNum = (int)rightKnob.transform.localEulerAngles.z / 36;
        leftNum = (int)(leftSlider.value/0.1f);
        rightNum = (int)(rightSlider.value/0.1f);
        midNum = (int)(midSlider.value/0.1f);
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
            
        } else { leftCodeBool = false; }

        if (midNum == midCode)
        {
            midCodeBool = true;
        } else {  midCodeBool = false; }

        if (rightNum == rightCode)
        {
            rightCodeBool = true;
        } else {  rightCodeBool = false; }

        if (midCodeBool && leftCodeBool && rightCodeBool && unopened)
        {
            unopened = false;
            Debug.Log("Opening Vault");
            StartCoroutine(OpenDoor());
        }

        if (test)
        {
            Debug.Log("Test");
            StartCoroutine(OpenDoor());
            audioSource.PlayOneShot(openClip);
        }
    }

    IEnumerator OpenDoor()
    {
        Debug.Log("Opening Vault");
        float timer = 0;
        while (timer < openDuration)
        {
            timer += Time.deltaTime;
            float fracComplete = timer / openDuration;
            DoorClose.transform.rotation = Quaternion.Slerp(DoorClose.transform.rotation, DoorOpen, fracComplete);
            yield return null;
        }
        Debug.Log("Opened Vault");
    }
}
