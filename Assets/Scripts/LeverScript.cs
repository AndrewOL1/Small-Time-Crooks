using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject SlotMachineReal;
    HingeJoint hinge;
    public float leverOutput;
    public float minValue, maxValue;
    public bool canSpin;
    public GameObject Wheel1;
    public GameObject Wheel2;
    public GameObject Wheel3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canSpin = true;
        hinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        float betweenZeroAndOne = (hinge.angle - hinge.limits.min) / (hinge.limits.max - hinge.limits.min);

        leverOutput = minValue +(maxValue - minValue) * betweenZeroAndOne;


        if (transform.rotation.z < 0 && canSpin == true)
        {
            canSpin = false;
            SlotMachineReal.GetComponent<SlotMachine>().isSpun = true;
            Wheel1.GetComponent<SlotRollers>().isSpun = true;
            Wheel2.GetComponent<SlotRollers>().isSpun = true;
            Wheel3.GetComponent<SlotRollers>().isSpun = true;
            Debug.Log("Spin the wheels");
            //gameObject.transform.eulerAngles = new Vector3(0,0,1);
            
        }
        else if (canSpin == false && transform.rotation.z >= 0)
        {
            canSpin = true;
        }
    }
}
