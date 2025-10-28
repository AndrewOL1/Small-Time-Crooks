using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Buttons : MonoBehaviour
{
    public string RightCode;
    public string codeFirst;
    public string codeSecond;
    public string codeLast;
    public int inputAttemptNum;

    [Header("DoorVars")]
    public Quaternion DoorOpen;
    public GameObject DoorClose;
    public float openDuration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openDuration *= 100;
        inputAttemptNum = 0;
        RightCode = "Kellan";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearCode()
    {
        inputAttemptNum = 0;
        RightCode = "Kellan";
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("button"))
        {
            if (inputAttemptNum == 0)
            {
                codeFirst = other.gameObject.GetComponent<CodeNum>().codeString;
                inputAttemptNum++;
            } else if (inputAttemptNum == 1)
            {
                codeSecond = other.gameObject.GetComponent<CodeNum>().codeString;
                inputAttemptNum++;
            } else if (inputAttemptNum == 2)
            {
                codeLast = other.gameObject.GetComponent<CodeNum>().codeString;
                inputAttemptNum++;
                CheckCode();
            }
            else
            {
                ClearCode();
            }
            
        }

        if (other.gameObject.CompareTag("clearButton"))
        {
            ClearCode();
        }
    }

    public void CheckCode()
    {
        if (RightCode == (codeFirst + codeSecond + codeLast))
        {
            StartCoroutine(OpenDoor());
            
        }
        else
        {
            ClearCode();
        }
        
    }

    IEnumerator OpenDoor()
    {
        float startTime = Time.time;
        while (startTime < openDuration)
        {
            float fracComplete = (Time.time - startTime) / openDuration;
            DoorClose.transform.rotation = Quaternion.Slerp(DoorClose.transform.rotation, DoorOpen, fracComplete);
            yield return null;
        }
    }

    


}
