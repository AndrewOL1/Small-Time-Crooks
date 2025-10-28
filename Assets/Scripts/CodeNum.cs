using UnityEngine;
using System.Collections;

public class CodeNum : MonoBehaviour
{
    public string codeString;
    public Transform originalPOS;
    public Transform endPOS;
    public float duration;

    public bool buttonPressed; // a test bool
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonPressed = false;
        originalPOS = gameObject.transform;
        //StartCoroutine(pressButton());
        
    }

    // Update is called once per frame
    void Update()
    {
        posCorrecter();
        if (buttonPressed)
        {
            StartCoroutine(pressButton());
        }
    }

    private void OnColliderEnter(Collision other)
    {
        if (other.gameObject.CompareTag("VR Hand"))
        {
            //StartCoroutine(pressButton());
        }
    }


    IEnumerator pressButton()
    {
        float startTime = Time.time;
        while (startTime < duration)
        {
            float fracComplete = (Time.time - startTime) / duration;
            gameObject.transform.position = Vector3.Lerp(originalPOS.position, endPOS.position, fracComplete);
            yield return null;
        }
    }

    IEnumerator unpressButton()
    {
        float startTime = Time.time;
        while (startTime < duration)
        {
            float fracComplete = (Time.time - startTime) / duration;
            gameObject.transform.position = Vector3.Lerp(endPOS.position, originalPOS.position, fracComplete);
            yield return null;
        }
    }

    public void posCorrecter()
    {
        if (gameObject.transform.position.x > originalPOS.position.x)
        {
            gameObject.transform.position = originalPOS.position;
        }

        if (gameObject.transform.position.x < endPOS.position.x)
        {
            gameObject.transform.position = endPOS.position;
        }
    }

}
