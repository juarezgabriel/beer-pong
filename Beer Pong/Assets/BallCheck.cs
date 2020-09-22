using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCheck : MonoBehaviour
{
    public GameObject thisCup;
    public Trigger trigger;

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
            Debug.Log("in!");
            trigger.blurScale -= .5f;
            thisCup.SetActive(false);
            Destroy(other.gameObject);
        }
    }



}
