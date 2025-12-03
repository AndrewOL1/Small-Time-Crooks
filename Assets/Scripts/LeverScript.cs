using PurrNet;
using UnityEngine;

public class LeverScript : NetworkBehaviour
{
    public GameObject SlotMachineReal;
    HingeJoint hinge;
    public float leverOutput;
    public float minValue, maxValue;
    public bool canSpin;
    public GameObject Wheel1;
    public GameObject Wheel2;
    public GameObject Wheel3;
    public bool leverPulled;
    public bool pullLever;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //canSpin = true;
        //hinge = GetComponent<HingeJoint>();
    }

    protected override void OnSpawned()
    {
        canSpin = true;
        hinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hinge == null)
            hinge = GetComponent<HingeJoint>();
        
        

        if (pullLever && canSpin)//for testing
        {
            PullLever();
        }

        if (transform.rotation.x > -90 && canSpin == true)
        {
            PullLever();
            //gameObject.transform.eulerAngles = new Vector3(0,0,1);
            
        }
        else if (canSpin == false && leverPulled == true)
        {
            transform.eulerAngles = new Vector3(-90, -90, -90);
            canSpin = true;
        }
    }
    [ServerRpc]
    private void PullLever()
    {
        leverPulled = false;
        if(pullLever)
            pullLever = false;
        canSpin = false;
        SlotMachineReal.GetComponent<SlotMachine>().isSpun = true;
        Wheel1.GetComponent<SlotRollers>().isSpun = true;
        Wheel2.GetComponent<SlotRollers>().isSpun = true;
        Wheel3.GetComponent<SlotRollers>().isSpun = true;
        Debug.Log("Spin the wheels");
    }
}
