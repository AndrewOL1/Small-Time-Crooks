using PurrNet;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DoorScript : NetworkIdentity
{
    public GameObject DoorOpen;
    public GameObject DoorClose;
    public float openDuration;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        openDuration *= 100;
        DoorClose.SetActive(true);
        DoorOpen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PrisonKey"))
        {
            //gameObject.SetActive(false);
            //DoorClose.SetActive(false);
            //DoorOpen.SetActive(true);

            //DoorClose.transform.rotation = Quaternion.Slerp(DoorClose.transform.rotation, DoorOpen.transform.rotation, 0.1f * Time.deltaTime);
            StartCoroutine(OpenDoor());
            //Destroy(other);
        }
    }

    IEnumerator OpenDoor()
    {
        float startTime = Time.time;
        while (startTime < openDuration)
        {
            float fracComplete = (Time.time - startTime) / openDuration;
            DoorClose.transform.rotation = Quaternion.Slerp(DoorClose.transform.rotation, DoorOpen.transform.rotation, fracComplete);
            yield return null;
        }
    }
}


/*Vector3 center = (sunrise.position + sunset.position) * 0.5F;
center -= new Vector3(0, 1, 0);
float fracComplete = (Time.time - startTime) / journeyTime;
transform.position = Vector3.Slerp(riseRelCenter, setRelCenter, fracComplete);*/
