using UnityEngine;
using System.Collections;
using PurrNet;

public class CodeNum : NetworkBehaviour
{
    public string codeString;
    public Transform originalPOS;
    public Transform endPOS;
    public Vector3 testPOS;
    public float duration;

    public bool buttonPressed; // a test bool

    private bool _cooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonPressed = false;
        //originalPOS = gameObject.transform;
        //StartCoroutine(pressButton());
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //posCorrecter();
        transform.position = Vector3.Lerp(transform.position, buttonPressed ?
            endPOS.position : originalPOS.position, Time.deltaTime * duration);
    }

    private void OnColliderEnter(Collision other)
    {
        if (other.gameObject.CompareTag("VR Hand"))
        {
            //StartCoroutine(pressButton());
        }
    }

    public void OnClicked()
    {
        if (_cooldown) return;
        buttonPressed = !buttonPressed;
        _cooldown = true;
        StartCoroutine(Delay());
    }

    public void Clear()
    {
        buttonPressed = false;
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(duration);
        _cooldown = false;
    }

    /*IEnumerator pressButton()
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
    }*/

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
