using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTrigger : MonoBehaviour
{
    public StartPanelController startPanel;
    public string gameSceneName;
    private bool canInteract = false;

    void Start()
    {
        if (startPanel != null)
        {
            startPanel.gameObject.SetActive(false);  // ���� ���� �� �г� �����
        }
    }

    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))  // 'E' �Է� �� �г� Ȱ��ȭ
        {
            if (startPanel != null)
            {
                startPanel.SetGameName(gameSceneName);
                startPanel.gameObject.SetActive(true);  // �г��� Ȱ��ȭ
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // �÷��̾ ���� �浹�ϸ�
        {
            canInteract = true;  // ��ȣ�ۿ� ���� ���·� ����
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // ������ �����
        {
            canInteract = false;  // ��ȣ�ۿ� �Ұ���
        }
    }


}
