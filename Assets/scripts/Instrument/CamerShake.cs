using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerShake : MonoBehaviour
{
 public IEnumerator Shake (float duration, float force)
    {
        Vector3 defaultPos = transform.position;
        float elapsedTime = 0f;
        while (elapsedTime < duration)

        {
            float x = Random.Range(-0.3f, 0.3f) * force;
            float y = Random.Range(-0.3f, 0.3f) * force;
            transform.position = new Vector3(x, y, defaultPos.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = defaultPos;
    }
    public void ShakeShake(float duration, float force)
    {
        StartCoroutine(Shake(duration, force));
    }
}
