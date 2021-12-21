using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "AntSearching")
        {
            other.gameObject.tag = "AntReturning";
            Destroy(gameObject);
        }
    }
}
