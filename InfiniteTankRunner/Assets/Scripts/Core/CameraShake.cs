using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;

        float elapased = 0.0f;

        // as long as the time that we aree shaking is less than the duration then keep shaking
        while (elapased < duration)
        {
            // offset the camera in all direction to simulate shaking
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapased += Time.deltaTime;

            // wait unitl the next fram is drawn to return the next while loop iteration, works with update function
            yield return null;
        }

        transform.localPosition = originalPos;
    }

}