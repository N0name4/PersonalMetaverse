using UnityEngine;

public class NPCShop : MonoBehaviour
{
    public GameObject shopPanel; // UI 패널 (아이템 선택)
    private bool isPlayerInRange = false;

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            shopPanel.SetActive(true); // NPC 상점 열기
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInRange = false;
            shopPanel.SetActive(false); // 플레이어가 벗어나면 UI 닫기
        }
    }
}
