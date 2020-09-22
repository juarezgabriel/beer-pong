using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCheck : MonoBehaviour
{
    public static int s_BallsMade = 0;

    [SerializeField] 
    private AudioSource m_OnMakeSound;

    [SerializeField]
    private AudioSource m_OnWinSound;

    [SerializeField] 
    private GameObject thisCup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball")
        {
            Debug.Log("in!");

            if(Trigger.s_BlurScale <= 2.5f) {
                Trigger.s_BlurScale = 0.0f;
            } else {
                Trigger.s_BlurScale -= 2.5f;
            }

            s_BallsMade++;

            m_OnMakeSound.PlayOneShot(m_OnMakeSound.clip);

            thisCup.SetActive(false);
            Destroy(other.gameObject);
        }
    }



}
