using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCheck : MonoBehaviour
{
    public static int s_BallsMade = 0;

    [SerializeField] private GameObject thisCup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball")
        {
            Debug.Log("in!");

            if(Trigger.s_BlurScale <= 0.5f) {
                Trigger.s_BlurScale = 0.0f;
            } else {
                Trigger.s_BlurScale -= 0.5f;
            }

            thisCup.SetActive(false);
            Destroy(other.gameObject);
        }
    }



}
