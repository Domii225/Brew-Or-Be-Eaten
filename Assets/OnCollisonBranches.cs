using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisonBranches : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("HandPalm"))
        {
            Debug.Log("test");
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        if (other.CompareTag("Mixture"))
        {
            GameManager.AddToInventory(Constants.Ingredient.RedRoot);
            Debug.Log(GameManager.inventory[Constants.Ingredient.RedRoot]);
        }
    }
}
