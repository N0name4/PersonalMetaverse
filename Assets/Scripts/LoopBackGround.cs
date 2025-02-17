using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LoopBackGround : MonoBehaviour
{
    public GameObject backGround; // 타일맵을 포함하는 부모 오브젝트
    public Transform player; // 플레이어 참조
    public float repeatOffset = 10f; // 맵이 반복될 거리

    private Vector3 startPos;
    private float mapWidth;

    void Start()
    {
        // `Background` 안의 모든 Tilemap들의 크기를 합산하여 mapWidth 결정
        mapWidth = GetBackgroundWidth();
        startPos = backGround.transform.position;
    }

    void Update()
    {
        if (player == null) return;

        // 플레이어가 맵의 오른쪽 끝을 넘어가면 배경을 오른쪽으로 이동
        if (player.position.x > startPos.x + mapWidth - repeatOffset)
        {
            backGround.transform.position += new Vector3(mapWidth, 0, 0);
            startPos = backGround.transform.position;
        }
        // 플레이어가 맵의 왼쪽 끝을 넘어가면 배경을 왼쪽으로 이동
        else if (player.position.x < startPos.x - repeatOffset)
        {
            backGround.transform.position -= new Vector3(mapWidth, 0, 0);
            startPos = backGround.transform.position;
        }
    }

    // `Background` 안에 있는 모든 `Tilemap`의 크기를 합산하여 `mapWidth` 계산
    private float GetBackgroundWidth()
    {
        float maxWidth = 0f;

        foreach (Tilemap tilemap in backGround.GetComponentsInChildren<Tilemap>())
        {
            BoundsInt bounds = tilemap.cellBounds;
            Vector3 tilemapSize = bounds.size;
            float width = tilemapSize.x * tilemap.cellSize.x;

            if (width > maxWidth)
            {
                maxWidth = width;
            }
        }

        return maxWidth;
    }
}
