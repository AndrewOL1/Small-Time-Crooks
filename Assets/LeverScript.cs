using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public GameObject SlotMachineReal;
    HingeJoint hinge;
    public float leverOutput;
    public float minValue, maxValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        float betweenZeroAndOne = (hinge.angle - hinge.limits.min) / (hinge.limits.max - hinge.limits.min);

        leverOutput = minValue +(maxValue - minValue) * betweenZeroAndOne;


        if (transform.rotation.z != 0)
        {
            SlotMachineReal.GetComponent<SlotMachine>().isSpun = true;
            //gameObject.transform.eulerAngles = new Vector3(0,0,1);
        }
    }
}
