using UnityEngine;

public class Buttons : MonoBehaviour
{
    public string RightCode;
    public string codeFirst;
    public string codeSecond;
    public string codeLast;
    public int inputAttemptNum;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RightCode = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearCode()
    {
        inputAttemptNum = 0;
        RightCode = "";
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
            gameObject.SetActive(false);
            
        }
        else
        {
            ClearCode();
        }
        
    }


}
