using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSniff : MonoBehaviour
{
    public int location;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pheromone")
        {
            object[] values = new object[3];
            values[0] = location;
            values[1] = other.gameObject.GetComponent<PheremoneZone>().getSearchIntensity();
            values[2] = other.gameObject.GetComponent<PheremoneZone>().getSearchIntensity();
            SendMessageUpwards("PheromoneFoundBroadcast", values);
            
        }
        else if (other.gameObject.tag == "Obstacles")
        {
            Debug.Log("WALLLLl");

            object[] values = new object[3];
            values[0] = location;
            values[1] = -1f;
            values[2] = -1f;
            SendMessageUpwards("PheromoneFoundBroadcast", values);
        }
    }
}
