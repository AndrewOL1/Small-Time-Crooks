using UnityEngine;

public class SlotRollers : MonoBehaviour, Iinteractable
{
    public GameObject SlotMachine;

    public bool stopped; // if the pc player has stopped the roll

    public bool wasSpun;
    public bool isSpun;
    public float spinTime;
    public float spinDuration;

    public float code;
    public float endDelay;

    public bool CanInteract()
    {
        return true;
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Stopping");
        stopped = true;
        SlotMachine.GetComponent<SlotMachine>().currentCode += ((int)gameObject.transform.localEulerAngles.x / 36);

        return true;

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stopped = false;
        gameObject.transform.Rotate(0, Random.Range(0, 360), 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpun)
        {
            Spin();
            isSpun = false;
        }

        if (wasSpun && Time.time - spinTime < spinDuration + endDelay && !stopped)
        {
            gameObject.transform.Rotate(0, -1, 0);


        }

        if (stopped)
        {
            code = ((int)gameObject.transform.localEulerAngles.x / 36);
        }
    }

    

    public void Spin()
    {
        wasSpun = true;
        spinTime = Time.time;
    }
}
