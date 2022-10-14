using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform followTarget;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(followTarget.position.x, -32.65772f, 60.85696f),
            transform.position.y,
            transform.position.z);
    }
}
