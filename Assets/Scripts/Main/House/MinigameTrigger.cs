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
            startPanel.gameObject.SetActive(false);  // 게임 시작 시 패널 숨기기
        }
    }

    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))  // 'E' 입력 시 패널 활성화
        {
            if (startPanel != null)
            {
                startPanel.SetGameName(gameSceneName);
                startPanel.gameObject.SetActive(true);  // 패널을 활성화
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // 플레이어가 벽과 충돌하면
        {
            canInteract = true;  // 상호작용 가능 상태로 변경
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // 벽에서 벗어나면
        {
            canInteract = false;  // 상호작용 불가능
        }
    }


}
