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
            StartCoroutine(Brewing());
        }
    }

    IEnumerator Brewing()
    {
        yield return new WaitForSeconds(1);
        bool isMixtureSuccessful = GameManager.BrewMixture();
        if (!GameManager.isInventoryEmpty())
        {
            if (isMixtureSuccessful)
            {
                BrewMixture();
            }
            else
            {
                BrewFailure();
            }
        }
    }
    void BrewMixture ()
    {
        GameObject obj = Instantiate(objToSpawn, SpawnPoint.position, SpawnPoint.rotation);
        obj.name = "Success";
    }
    void BrewFailure ()
    {
        GameObject obj = Instantiate(objToSpawn, SpawnPoint.position, SpawnPoint.rotation);
        obj.name = GameManager.GetFeedback();
    }
    

}
