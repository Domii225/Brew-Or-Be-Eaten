using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour
{
    private Vector3 initialPosition;
    private Rigidbody rb;
    private Vector3 farPosition = new Vector3(999, 999, 999);
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandPalm"))
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
        if (other.CompareTag("Mixture"))
        {
            transform.position = farPosition;
            rb.isKinematic = true;
            rb.useGravity = false;
            ResetPosition();
        }
    }

    IEnumerator ResetPosition()
    {
        yield return new WaitForSeconds(3);
        transform.position = initialPosition;
    }
}
