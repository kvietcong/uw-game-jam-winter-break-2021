using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PheremoneZone : MonoBehaviour
{
    float searchIntensity; // pheremone value 0 to 1
    float returnIntensity; // pheremone value 0 to 1

    public TextMesh searchText;
    public TextMesh returnText;

    // Start is called before the first frame update
    void Start()
    {
        searchIntensity = 0;
        returnIntensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (searchIntensity > 0)
        {
            searchIntensity -= 0.03f * Time.deltaTime;
            if (searchIntensity <= 0)
            {
                searchIntensity = 0;
            }
        }
        if (returnIntensity > 0)
        {
            returnIntensity -= 0.03f * Time.deltaTime;
            if (returnIntensity <= 0)
            {
                returnIntensity = 0;
            }
        }
        searchText.text = "" + Mathf.Round(searchIntensity * 100);
        returnText.text = "" + Mathf.Round(returnIntensity * 100);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "AntSearching")
        {
            searchIntensity += 0.015f;
        }
        else if (other.gameObject.tag == "AntReturning")
        {
            returnIntensity += 0.015f;
        }
    }

    public float getSearchIntensity()
    {
        return searchIntensity;
    }
    public float getReturnIntensity()
    {
        return returnIntensity;
    }
}
