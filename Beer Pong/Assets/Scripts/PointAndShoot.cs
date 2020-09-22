using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndShoot : MonoBehaviour
{
    public GameObject ballPrefab;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
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
