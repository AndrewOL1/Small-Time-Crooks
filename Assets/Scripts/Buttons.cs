using System;
using System.Collections;
using PurrNet;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Events;

public class Buttons : NetworkBehaviour
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

    
    public UnityEvent ClearCodeEvent;
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
        ClearCodeEvent.Invoke();
        inputAttemptNum = 0;
        RightCode = "Kellan";
        codeFirst = "";
        codeSecond = "";
        codeLast = "";
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("button"))
        {
            var codeFragment=other.gameObject.GetComponent<CodeNum>().codeString;
            if (codeFragment == "ClearCode")
            {
                ClearCode();return;
            }
            switch (inputAttemptNum)
            {
                case 0:
                    codeFirst = codeFragment;
                    inputAttemptNum++;
                    break;
                case 1:
                    codeSecond = codeFragment;
                    inputAttemptNum++;
                    break;
                case 2:
                    codeLast = codeFragment;
                    inputAttemptNum++;
                    CheckCode();
                    break;
                default:
                    ClearCode();
                    break;
            }
            
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
