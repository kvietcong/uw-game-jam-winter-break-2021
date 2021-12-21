using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntFindFood : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Food")
        {
            SendMessageUpwards("FoodFoundBroadcast", other.gameObject.transform.position);
        }
        else if (other.gameObject.tag == "Home")
        {
            SendMessageUpwards("HomeFoundBroadcast", other.gameObject.transform.position);
        }
    }
}
