using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallMove : MonoBehaviour
{
    public GameObject thisCup;

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
            thisCup.SetActive(false);
        }
    }

}
