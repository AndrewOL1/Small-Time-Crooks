using UnityEngine;

public class CodeNum : MonoBehaviour
{
    public string codeString;
    public Transform originalPOS;
    public Transform endPOS;
    public float duration;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalPOS = gameObject.transform;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnColliderEnter(Collision other)
    {
        if (other.gameObject.CompareTag("VR Hand"))
        {
            //StartCoroutine(pressButton());
        }
    }


   /* IEnumerator pressButton()
    {
        float startTime = Time.time;
        while (startTime < duration)
        {
            float fracComplete = (Time.time - startTime) / duration;
            gameobject.transform.position = Vector3.Lerp(originalPOS, endPOS, fracComplete);
            yield return null;
        }
    }*/


}
