using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public bool shake = false;
    public static bool shakeStatic = false;

    public AnimationCurve curve;
    public float duration = 1f;
    public static float shakeAmount = 1f;

    public FallingRocks script;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shake || shakeStatic)
        {
            shake = false;
            shakeStatic = false;
            StartCoroutine(ShakeCamera());
        }
    }

    IEnumerator ShakeCamera() 
    {
        Vector3 startPosition = transform.position;
        float time = 0f;
        script.SpawnFallingRocks();

        while (time < duration)
        {
            time += Time.deltaTime;
            float strength = curve.Evaluate(time / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }
        transform.position = startPosition;
    }
}
