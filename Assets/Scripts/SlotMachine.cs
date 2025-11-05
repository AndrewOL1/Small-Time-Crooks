using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    public GameObject leftWheel;
    public GameObject midWheel;
    public GameObject rightWheel;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftWheel.transform.Rotate(0, Random.Range(0, 360), 0);
        midWheel.transform.Rotate(0, Random.Range(0, 360), 0);
        rightWheel.transform.Rotate(0, Random.Range(0, 360), 0);


        leftRot = leftWheel.transform.localRotation;
        midRot = midWheel.transform.localRotation;
        rightRot = rightWheel.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpun)
        {
            Spin();
            isSpun = false;
        }


       if (wasSpun && Time.time - spinTime < spinDuration)
        {
            leftWheel.transform.Rotate(0, -1, 0);
            

        }

       if (wasSpun && Time.time - spinTime < spinDuration+1)
        {
            midWheel.transform.Rotate(0, -1, 0);
        }

        if (wasSpun && Time.time - spinTime < spinDuration + 2)
        {
            rightWheel.transform.Rotate(0, -1, 0);
        }

        if (Time.time - spinTime >= spinDuration)
        {
            CheckSlots();
        }
        
    }

    public void Spin()
    {
        wasSpun = true;
        spinTime = Time.time;
    }

    public void CheckSlots()
    {
        leftCode = (int)leftWheel.transform.localEulerAngles.x/36;
        rightCode = (int)rightWheel.transform.localEulerAngles.x / 36;
        midCode = (int)midWheel.transform.localEulerAngles.x / 36;
    }


}
