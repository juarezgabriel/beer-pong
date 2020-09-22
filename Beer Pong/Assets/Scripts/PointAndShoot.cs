using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    public GameObject crosshairs;
    public GameObject ballPrefab;
    
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //crosshairs.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15f));

        //if (Input.GetMouseButtonDown(0))
        //{
        //    //fire bullet
        //    GameObject InstBall = Instantiate(ballPrefab, transform.position, Quaternion.identity) as GameObject;
        //    Rigidbody instBallRigidbody = InstBall.GetComponent<Rigidbody>();
        //    instBallRigidbody.AddForce(crosshairs.transform.position * speed);
        //}

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
