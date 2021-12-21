using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMaster : MonoBehaviour
{
    public GameObject Ant;
    public GameObject Food;
    public float scale = 1;
    public int AntCount = 15;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < AntCount; i++)
        {
            GameObject ant = Instantiate(Ant, new Vector3(0, scale / 2, 0), Quaternion.identity);
            ant.transform.localScale = new Vector3(scale, scale, scale);
        }
        for (int i = 0; i < 5; i++)
        {
            float midX = Random.Range(-45f, 45f);
            float midZ = Random.Range(-45f, 45f);
            for (int j = 0; j < 100; j++)
            {
                GameObject food = Instantiate(Food, new Vector3(Random.Range(midX - 5, midX + 5), 0.5f, Random.Range(midZ - 5, midZ + 5)), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
