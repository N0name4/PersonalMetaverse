using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanelController : MonoBehaviour
{
    public Text gameNameText;
    public Button yesButton;
    public Button noButton;

    private string currentGameName;
    // Start is called before the first frame update
    void Start()
    {
        yesButton.onClick.AddListener(() => ClosePanel());
        noButton.onClick.AddListener(() => ClosePanel());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ClosePanel();
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            ClosePanel();
        }
    }

    public void SetGameName(string gameName)
    {
        currentGameName = gameName;
        gameNameText.text = $"\"{gameName}\" 영역입니다.";
    }

    private void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
