using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveUpStep = 1.0f;

    private void OnEnable()
    {
        Block.OnBlockLanded += MoveCameraUp;
    }

    private void OnDisable()
    {
        Block.OnBlockLanded -= MoveCameraUp;
    }

    private void MoveCameraUp()
    {
        StartCoroutine(MoveCameraSmoothly());
    }

    private IEnumerator MoveCameraSmoothly()
    {
        Vector3 targetPosition = transform.position + new Vector3(0, moveUpStep, 0);
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPosition, t);
            yield return null;
        }
    }
}
