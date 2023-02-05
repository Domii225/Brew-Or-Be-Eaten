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
                Debug.Log("Success");
                BrewMixture();
            }
            else
            {
                Debug.Log("Success");
                BrewFailure();
            }
        }
    }
    void BrewMixture ()
    {
        GameObject obj = Instantiate(objToSpawn, SpawnPoint.position, SpawnPoint.rotation);
        obj.name = "Success";
        Debug.Log(obj.name);
    }
    void BrewFailure ()
    {
        GameObject obj = Instantiate(objToSpawn, SpawnPoint.position, SpawnPoint.rotation);
        obj.name = GameManager.GetFeedback();
        Debug.Log(obj.name);
    }
    

}
