using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntVisionController : MonoBehaviour
{
    // For some weird reason, Sorted Sets don't treat the Ant Clones as unique
    // items :(
    private SortedSet<GameObject> sortedAnts;
    private HashSet<GameObject> ants;

    void Start() {
        ants = new HashSet<GameObject>();
        sortedAnts = new SortedSet<GameObject>(
            Comparer<GameObject>.Create((a, b) =>
                Vector3.Distance(transform.position, a.transform.position)
                    .CompareTo(
                        Vector3.Distance(
                            transform.position, b.transform.position)
                    )
        ));
    }

    public SortedSet<GameObject> getSortedAnts() { return sortedAnts; }
    public HashSet<GameObject> getAnts() { return ants; }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collided = collision.gameObject;
        if (collided.name == "Ant(Clone)") {
            // if (sortedAnts.Contains(collided)) return;
            // Debug.Log("Enter");
            ants.Add(collided);
            sortedAnts.Add(collided);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject collided = collision.gameObject;
        if (sortedAnts.Contains(collided)) {
            // Debug.Log("Exit");
            ants.Remove(collided);
            sortedAnts.Remove(collided);
        }
    }
}
