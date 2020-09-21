using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public int ballsMissed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball")
        {
            ballsMissed += 1;
            Debug.Log("balls missed: " + ballsMissed);
            Destroy(other.gameObject);
        }
    }
}
