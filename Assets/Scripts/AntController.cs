using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntController : MonoBehaviour
{
    public float maxSpeed = 2;
    public float steerStrength = 2;
    public float wanderStrength = 1;

    public Collider VisualField;

    Vector3 position = new Vector3(0, 0.5f, 0);
    Vector3 velocity;
    Vector3 desiredDirection;

    Vector3 foodPos;
    bool foundFood;

    Vector3 homePos;
    bool foundHome;

    float[] searchPh = new float[3];
    float[] returnPh = new float[3];

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "AntSearching")
        {
            if (foundFood)
            {
                desiredDirection = (foodPos - position).normalized;
            }
            else
            {
                // want to find where ants are returning from
                if (returnPh[0] > Mathf.Max(returnPh[1], returnPh[2]))
                {
                    desiredDirection = Vector3.left;
                }
                else if (returnPh[1] > Mathf.Max(returnPh[0], returnPh[2]))
                {
                    desiredDirection = Vector3.forward;
                }
                else if (returnPh[2] > Mathf.Max(returnPh[0], returnPh[1]))
                {
                    desiredDirection = Vector3.right;
                }
                // if none of the above, no changes
            }
        }
        else
        {
            if (foundHome)
            {
                desiredDirection = (homePos - position).normalized;
            }
            else
            {
                if (searchPh[0] > Mathf.Max(searchPh[1], searchPh[2]))
                {
                    desiredDirection = Vector3.left;
                }
                else if (searchPh[1] > Mathf.Max(searchPh[0], searchPh[2]))
                {
                    desiredDirection = Vector3.forward;
                }
                else if (searchPh[2] > Mathf.Max(searchPh[0], searchPh[1]))
                {
                    desiredDirection = Vector3.right;
                }
            }
            // when ant gets home
            if (Vector3.Distance(position, Vector3.zero) < 5)
            {
                foundFood = false;
                foundHome = false;
                gameObject.tag = "AntSearching";
            }
        }

        Vector2 push = Random.insideUnitCircle * wanderStrength;
        desiredDirection = (desiredDirection + new Vector3(push.x, 0, push.y)).normalized;
        Vector3 desiredVelocity = new Vector3(desiredDirection.x, 0, desiredDirection.z) * maxSpeed;
        Vector3 desiredSteeringForce = (desiredVelocity - velocity) * steerStrength;
        Vector3 acceleration = Vector3.ClampMagnitude(desiredSteeringForce, steerStrength) / 1;

        velocity = Vector3.ClampMagnitude(velocity + acceleration * Time.deltaTime, maxSpeed);
        position += new Vector3(velocity.x * Time.deltaTime, 0, velocity.z * Time.deltaTime);

        float angle = Mathf.Atan2(velocity.z, velocity.x) * Mathf.Rad2Deg;
        transform.SetPositionAndRotation(position, Quaternion.Euler(90, 0, angle + 90));
    }


    // TODO: Fix potential problem where an Ant's food gets taken before it gets there
    void FoodFoundBroadcast(Vector3 pos)
    {
        if (!foundFood)
        {
            foodPos = new Vector3(pos.x, 0, pos.z);
            foundFood = true;
        }
    }

    void HomeFoundBroadcast(Vector3 pos)
    {
        if (gameObject.tag == "AntReturning" && !foundHome)
        {
            homePos = new Vector3(pos.x, 0, pos.z);
            foundHome = true;
        }
    }

    void PheromoneFoundBroadcast(object[] values)
    {
        int loc = (int)values[0];
        float searchIntensity = (float)values[1];
        float returnIntensity = (float)values[2];
        searchPh[loc] = searchIntensity;
        returnPh[loc] = returnIntensity;
    }
}
