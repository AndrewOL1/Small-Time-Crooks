using UnityEngine;

public class PillarPuzzle : MonoBehaviour
{
    public GameObject pillar1;
    public GameObject pillar2;
    public GameObject pillar3;

    public bool wasRight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wasRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkPillars();
    }

    public void checkPillars()
    {
        if (!wasRight && pillar1.GetComponent<PillarScript>().correctPlacement == true)
        {
            Debug.Log("OpeningPuzzle");
            wasRight = true;
        }
    }
}
