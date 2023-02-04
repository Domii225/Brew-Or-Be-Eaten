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
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }
}
