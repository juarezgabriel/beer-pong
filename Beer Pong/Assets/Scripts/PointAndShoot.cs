using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float speed;

    public int ballsMade;

    //[SerializeField]
    //private AudioSource m_OnWinSound;
    //public GameObject ambientSound;


    // Start is called before the first frame update
    void Start()
    {
        ballsMade = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ballPrefab == null)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            GameObject newGameObject = (GameObject)Instantiate(ballPrefab, mouseRay.origin, Quaternion.identity);
            Rigidbody rb = newGameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.velocity = mouseRay.direction * speed;
            }
        }
    }
}
