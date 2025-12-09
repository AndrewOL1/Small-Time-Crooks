using PurrNet;
using UnityEngine;

public class SlotRollers : NetworkBehaviour, Iinteractable
{
    public SlotMachine slotMachine;

    public bool stopped; // if the pc player has stopped the roll

    public bool wasSpun;
    public bool isSpun;
    public float spinTime;
    public float spinDuration;

    public int code;
    public float endDelay;
    
    private float _rollSpeed;
    private float _tempSpeed;

    public bool isJammed;
    public bool isLastWheel;

    public bool CanInteract()
    {
        return true;
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Jammed " + gameObject.name);
        isJammed=!isJammed;
        Stop();
        return true;

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stopped = false;
        gameObject.transform.Rotate(0, 0, Random.Range(0, 360));
        _rollSpeed=transform.GetComponentInParent<SlotMachine>().rollSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isSpun)
        {
            Spin();
            isSpun = false;
        }

        if (wasSpun && Time.time - spinTime < spinDuration + endDelay && !stopped)
        {
            if (!isJammed)
            {
                gameObject.transform.Rotate(0, 0, _tempSpeed);
                if (_tempSpeed > 1.0f)
                    _tempSpeed -= 0.08f;
            }
        }
        else if (wasSpun)
        {
            wasSpun = false;
            Stop();
            if (isLastWheel)
                slotMachine.CheckSlots();
        }

        if (stopped)
        {
            Stop();
        }
    }

    private void Stop()
    {
        code = ((int)gameObject.transform.localEulerAngles.z / 72);
    }

    

    public void Spin()
    {
        wasSpun = true;
        spinTime = Time.time;
        _tempSpeed = _rollSpeed;
    }
}
