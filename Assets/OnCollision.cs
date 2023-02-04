using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject objToSpawn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spoon"))
        {
            BrewMixture();
        }
    }
    void BrewMixture ()
    {
        Instantiate(objToSpawn, SpawnPoint.position, SpawnPoint.rotation);
    }
}
