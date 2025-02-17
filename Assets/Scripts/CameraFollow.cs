using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector2 minBounds;
    public Vector2 maxBounds;

    // Start is called before the first frame update
    void LateUpdate()
    {
        if (character == null) return;

        // 목표 위치 설정
        Vector3 desiredPosition = character.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 맵 영역 내에서만 이동 가능하도록 Clamp
        float clampedX = Mathf.Clamp(smoothedPosition.x, minBounds.x, maxBounds.x);
        float clampedY = Mathf.Clamp(smoothedPosition.y, minBounds.y, maxBounds.y);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
