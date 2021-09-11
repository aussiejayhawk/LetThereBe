using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class SpinScript : MonoBehaviour
{
    public Rigidbody thisRb;

    public AnimationCurve animCurve;
    
    //delete when done
    public Transform tempPlayer;
    //
    public Transform artwork;
    public Vector3[] faceVectors;
    public float spinDuration = 5f;

    public bool isSpinning;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(Spin(1, 5, tempPlayer));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(Spin(2, 5, tempPlayer));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(Spin(3, 5, tempPlayer));
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            StartCoroutine(Spin(4, 5, tempPlayer));
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            StartCoroutine(Spin(5, 5, tempPlayer));
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            StartCoroutine(Spin(6, 5, tempPlayer));
        }
    }

    public IEnumerator Spin(int endFace, float duration, Transform player)
    {
        isSpinning = true;
        float startRotation = 0;
        float endRotation = startRotation + (360.0f * 5);
        float t = 0.0f;
        Vector3 direction = player.position - artwork.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        RepositionArtwork(endFace);
        transform.rotation = lookRotation;
        while (t < duration)
        {
            t += Time.deltaTime;
            float rotation = Mathf.Lerp(startRotation, endRotation, animCurve.Evaluate(t / duration)) % 360.0f;
            transform.eulerAngles = new Vector3(rotation, -rotation, rotation);
            
            yield return null;
        }

        isSpinning = false;
    }

    private void RepositionArtwork(int face)
    {
        artwork.eulerAngles = faceVectors[face-1];
    }

}
