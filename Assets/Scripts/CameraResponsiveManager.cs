using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResponsiveManager : MonoBehaviour
{
    public float orthographicSize = 5;
    public float aspect = 16 / 9f;
    void Start()
    {
        Camera.main.projectionMatrix = Matrix4x4.Ortho(
                -orthographicSize * aspect, orthographicSize * aspect,
                -orthographicSize, orthographicSize,
                Camera.main.nearClipPlane, Camera.main.farClipPlane);
    }
}
