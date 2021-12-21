using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PheremoneController : MonoBehaviour
{
    public GameObject PheremoneZone;
    public float minX, minZ, maxX, maxZ;
    public float zoneSize;
    // Start is called before the first frame update
    void Start()
    {
        for (float x = minX + (zoneSize / 2); x <= maxX - (zoneSize / 2); x += zoneSize)
        {
            for (float z = minZ + (zoneSize / 2); z <= maxZ - (zoneSize / 2); z += zoneSize)
            {
                GameObject zone = Instantiate(PheremoneZone, new Vector3(x, zoneSize / 2, z), Quaternion.identity);
                zone.transform.localScale = new Vector3(zoneSize, zoneSize, zoneSize);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
