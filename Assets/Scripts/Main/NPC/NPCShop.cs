using UnityEngine;

public class NPCShop : MonoBehaviour
{
    public GameObject shopPanel; // UI �г� (������ ����)
    private bool isPlayerInRange = false;

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            shopPanel.SetActive(true); // NPC ���� ����
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
            shopPanel.SetActive(false); // �÷��̾ ����� UI �ݱ�
        }
    }
}
