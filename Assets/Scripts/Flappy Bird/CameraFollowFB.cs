using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowFB : MonoBehaviour
{
    public Transform character;
    float offsetX;
    // Start is called before the first frame update
    void Start()
    {
        if (character == null) return;

        offsetX = transform.position.x - character.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (character == null) return;

        Vector3 pos = transform.position;
        pos.x = character.position.x + offsetX;
        transform.position = pos;
    }
}
