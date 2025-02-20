using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartPanelController : MonoBehaviour
{
    public Text gameNameText;
    public Button yesButton;
    public Button noButton;

    private string currentGameName;
    // Start is called before the first frame update
    void Start()
    {
        yesButton.onClick.AddListener(() => LoadGameScene());
        noButton.onClick.AddListener(() => ClosePanel());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            LoadGameScene();
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

    private void LoadGameScene()
    {
        if (!string.IsNullOrEmpty(currentGameName))
        {
            SceneManager.LoadScene(currentGameName); // 씬 전환
        }
    }

    private void ClosePanel()
    {
        gameObject.SetActive(false);
    }
}
