using PurrNet;
using UnityEngine;

public class SlotMachine : NetworkBehaviour
{
    public SlotRollers leftWheel;
    public SlotRollers midWheel;
    public SlotRollers rightWheel;

    private Quaternion leftRot;
    private Quaternion midRot;
    private Quaternion rightRot;

    public int leftCode;
    public int midCode;
    public int rightCode;


    public bool wasSpun;
    public bool isSpun;
    public float spinTime;
    public float spinDuration;

    public float spinCheckDelay;

    public int correctCode;
    public int currentCode;

    public float rollSpeed;

    public GameObject CasinoKey;
    public GameObject Coin;
    public GameObject dropPoint;

    public bool TestingBool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*leftWheel.transform.Rotate(0, Random.Range(0, 360), 0);
        midWheel.transform.Rotate(0, Random.Range(0, 360), 0);
        rightWheel.transform.Rotate(0, Random.Range(0, 360), 0);*/


        /*leftRot = leftWheel.transform.localRotation;
        midRot = midWheel.transform.localRotation;
        rightRot = rightWheel.transform.localRotation;*/
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpun)
        {
            Spin();
            isSpun = false;
        }

        if (TestingBool != true) return;
        GameObject gameObject = Instantiate(CasinoKey, dropPoint.transform.position, Quaternion.identity);
        gameObject.SetActive(true);
        TestingBool = false;

    }

    public void Spin()
    {
        wasSpun = true;
        spinTime = Time.time;
    }

    public void CheckSlots()
    {
        leftCode = leftWheel.code;
        rightCode = rightWheel.code;
        midCode = midWheel.code;

        currentCode = leftCode + midCode + rightCode;
        if (currentCode == correctCode)
        {
            for (int i = 0; i < 20; i++)
            {
                GameObject gameObjects = Instantiate(Coin, dropPoint.transform.position, Quaternion.identity);
                gameObjects.transform.GetChild(1).GetComponent<Rigidbody>().linearVelocity = new Vector3(1, 0, 0);
            }
            GameObject gameObject = Instantiate(CasinoKey, transform.position, Quaternion.identity);
            gameObject.GetComponent<Rigidbody>().linearVelocity = new Vector3(2, 0, 0);
            
        }
        else if (leftCode == rightCode && midCode == rightCode)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject gameObject = Instantiate(Coin, dropPoint.transform.position, Quaternion.identity);
                gameObject.transform.GetChild(1).GetComponent<Rigidbody>().linearVelocity = new Vector3(1, 0, 0);
            }
        }
        else if (leftCode == rightCode || leftCode == midCode || midCode == rightCode)
        {
            for (int i = 0; i < 1; i++)
            {
                GameObject gameObject = Instantiate(Coin, dropPoint.transform.position, Quaternion.identity);
                gameObject.transform.GetChild(1).GetComponent<Rigidbody>().linearVelocity = new Vector3(1, 0, 0);
            }
        }
    }


}
