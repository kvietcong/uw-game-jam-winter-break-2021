using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private GameObject Gun;
    [SerializeField] private GameObject AntVision;
    [SerializeField] private float RotationSpeed = 1;

    private Transform gunT;

    void Start() {
        gunT = Gun.transform;
    }

    void Update() {
        HashSet<GameObject> ants =
            AntVision.GetComponent<AntVisionController>().getAnts();
        // SortedSet<GameObject> sortedAnts =
        //     AntVision.GetComponent<AntVisionController>().getSortedAnts();
        if (ants.Count <= 0) return;

        List<GameObject> antsList = new List<GameObject>(ants);
        antsList.Sort(
            (a, b) =>
                Vector3.Distance(gunT.position, a.transform.position)
                    .CompareTo(
                        Vector3.Distance(
                            gunT.position, b.transform.position)
                    )
        );
        GameObject closestAnt = antsList[0];
        gunT.rotation = Quaternion.Slerp(
            gunT.rotation,
            // How TF does this work LOL
            Quaternion
                .LookRotation(closestAnt.transform.position - gunT.position)
                * Quaternion.Euler(-90, 0, -90),
            RotationSpeed * Time.deltaTime
        );
    }
}
