using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject objToSpawn;
    private bool isBrewing = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spoon"))
        {
            if (!isBrewing)
            {
                isBrewing = true;
                StartCoroutine(Brewing());
            }
        }
    }

    IEnumerator Brewing()
    {
        yield return new WaitForSeconds(2);
        bool isMixtureSuccessful = GameManager.BrewMixture();
        Debug.Log("is Inventory empty:" + GameManager.isInventoryEmpty());
        if (!GameManager.isInventoryEmpty())
        {
            GameManager.ResetInventory();
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
        isBrewing = false;
    }
    void BrewMixture()
    {
        GameObject obj = Instantiate(objToSpawn, SpawnPoint.position, SpawnPoint.rotation);
        obj.name = "Success";
        Debug.Log(obj.name);
    }
    void BrewFailure()
    {
        GameObject obj = Instantiate(objToSpawn, SpawnPoint.position, SpawnPoint.rotation);
        obj.name = GameManager.GetFeedback();
        Debug.Log(obj.name);
    }
}
