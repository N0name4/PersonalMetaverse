using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameTrigger : MonoBehaviour
{
    public GameObject miniGamePanel;
    private bool isNear = false;

    // Update is called once per frame
    void Update()
    {
        if (isNear && Input.GetKeyDown(KeyCode.E)) // E Ű�� ������ ����
        {
            miniGamePanel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) // ESC Ű�� ������ �ݱ�
        {
            miniGamePanel.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isNear = false;
            miniGamePanel.SetActive(false);
        }
    }
}
