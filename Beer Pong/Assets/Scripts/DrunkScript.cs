using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkScript : MonoBehaviour
{
    private static int s_CurrentDrunknessFactor = 0;

    private const float MAX_POSITIVE_Z_ROTATION = 10.0f;
    private const float MAX_NEGATIVE_Z_ROTATION = 350.0f;
    private const float ANGULAR_ACCELERATION_INCREMENT_PER_MISSED_SHOT = 0.1f;
    private const float ANGULAR_VELOCITY_SCALAR = 50.0f;
    private const float BASE_ANGULAR_VELOCITY = 0.5f;
    private const int MAX_DRUNKNESS_FACTOR = 20;
    private const int BALLS_MADE_TO_MISSED_DRUNK_RATIO = 4;

    private float m_LastNonZeroAngularVelocity = 0.0f;
    private float m_AngularVelocity = 0.0f;
    private bool m_IsSwayingRight = false;

    void Start()
    {
        
    }

    void Update()
    {
        UpdateDrunknessFactor();
        UpdateAngularVelocity();
        ApplyRotationalConstraints();
    }

    private void UpdateDrunknessFactor()
    {
        s_CurrentDrunknessFactor += (-(BallCheck.s_BallsMade * BALLS_MADE_TO_MISSED_DRUNK_RATIO) + Trigger.s_BallsMissed);

        if (s_CurrentDrunknessFactor < 0)
        {
            s_CurrentDrunknessFactor = 0;
        } else if(s_CurrentDrunknessFactor > MAX_DRUNKNESS_FACTOR)
        {
            s_CurrentDrunknessFactor = MAX_DRUNKNESS_FACTOR;
        }

        BallCheck.s_BallsMade = 0; Trigger.s_BallsMissed = 0;
    }

    private void UpdateAngularVelocity()
    {
        Vector3 eulerAngles = gameObject.transform.eulerAngles;

        float zValue = eulerAngles.z;

        if (zValue >= MAX_NEGATIVE_Z_ROTATION)
        {
            zValue = MAX_NEGATIVE_Z_ROTATION - zValue;
        }

        m_AngularVelocity = (BASE_ANGULAR_VELOCITY * s_CurrentDrunknessFactor) + ((Mathf.Abs(zValue) / MAX_POSITIVE_Z_ROTATION) * ANGULAR_VELOCITY_SCALAR * Time.deltaTime);

        if(m_IsSwayingRight)
        {
            m_AngularVelocity *= -1.0f;
        }
    
        eulerAngles.z += m_AngularVelocity * Time.deltaTime;

        gameObject.transform.eulerAngles = eulerAngles;

    }

    private void ApplyRotationalConstraints()
    {
        Vector3 currentEulerAngle = gameObject.transform.eulerAngles;

        if(currentEulerAngle.z <= MAX_NEGATIVE_Z_ROTATION && currentEulerAngle.z > MAX_POSITIVE_Z_ROTATION + 10.0f)
        {
            currentEulerAngle.z = MAX_NEGATIVE_Z_ROTATION;
            m_AngularVelocity *= -1.0f;
            m_IsSwayingRight = false;
        }  else if (currentEulerAngle.z >= MAX_POSITIVE_Z_ROTATION && currentEulerAngle.z < MAX_POSITIVE_Z_ROTATION + 10.0f)
        {
            currentEulerAngle.z = MAX_POSITIVE_Z_ROTATION;
            m_AngularVelocity *= -1.0f;
            m_IsSwayingRight = true;
        }

        gameObject.transform.eulerAngles = currentEulerAngle;
    }
}
