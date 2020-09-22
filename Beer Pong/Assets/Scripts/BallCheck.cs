using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallCheck : MonoBehaviour
{
    public static int s_BallsMade = 0;

    [SerializeField] 
    private AudioSource m_OnMakeSound;

    [SerializeField]
    private AudioSource m_OnWinSound;

    [SerializeField] 
    private GameObject thisCup;

    public GameObject ambientSound;

    public PointAndShoot pointAndShoot;

    public Text youWinText;

    private void Start()
    {
        youWinText.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball")
        {
            pointAndShoot.ballsMade++;

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

        if (pointAndShoot.ballsMade == 15)
        {
            ambientSound.GetComponent<AudioSource>().Stop();
            m_OnWinSound.PlayOneShot(m_OnWinSound.clip);
            youWinText.enabled = true;
            pointAndShoot.enabled = false;


        }

    }
}
