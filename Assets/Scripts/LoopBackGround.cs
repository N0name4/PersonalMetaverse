using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LoopBackGround : MonoBehaviour
{
    public GameObject backGround; // Ÿ�ϸ��� �����ϴ� �θ� ������Ʈ
    public Transform player; // �÷��̾� ����
    public float repeatOffset = 10f; // ���� �ݺ��� �Ÿ�

    private Vector3 startPos;
    private float mapWidth;

    void Start()
    {
        // `Background` ���� ��� Tilemap���� ũ�⸦ �ջ��Ͽ� mapWidth ����
        mapWidth = GetBackgroundWidth();
        startPos = backGround.transform.position;
    }

    void Update()
    {
        if (player == null) return;

        // �÷��̾ ���� ������ ���� �Ѿ�� ����� ���������� �̵�
        if (player.position.x > startPos.x + mapWidth - repeatOffset)
        {
            backGround.transform.position += new Vector3(mapWidth, 0, 0);
            startPos = backGround.transform.position;
        }
        // �÷��̾ ���� ���� ���� �Ѿ�� ����� �������� �̵�
        else if (player.position.x < startPos.x - repeatOffset)
        {
            backGround.transform.position -= new Vector3(mapWidth, 0, 0);
            startPos = backGround.transform.position;
        }
    }

    // `Background` �ȿ� �ִ� ��� `Tilemap`�� ũ�⸦ �ջ��Ͽ� `mapWidth` ���
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
