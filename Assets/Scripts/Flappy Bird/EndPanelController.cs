using UnityEngine;
using UnityEngine.UI;

public class EndPanelController : MonoBehaviour
{
    public Text finalScoreText;
    public Text finalHighScoreText;
    public Button yesButton;
    public Button noButton;

    private void Start()
    {
        // ��ư Ŭ�� �̺�Ʈ ����
        if (yesButton != null) yesButton.onClick.AddListener(RestartGame);
        if (noButton != null) noButton.onClick.AddListener(GoToMainMenu);

        // EndPanel�� ó������ ��Ȱ��ȭ
        gameObject.SetActive(false);
    }

    public void ShowEndPanel(int score, int highScore)
    {
        if (finalScoreText == null) finalScoreText = GameObject.Find("FinalScoreText")?.GetComponent<Text>();
        if (finalHighScoreText == null) finalHighScoreText = GameObject.Find("FinalHighScoreText")?.GetComponent<Text>();

        if (finalScoreText != null) finalScoreText.text = $"����� ����: {score}";
        if (finalHighScoreText != null) finalHighScoreText.text = $"�ְ� ����: {highScore}";

        gameObject.SetActive(true);
    }

    private void RestartGame()
    {
        GameManager.Instance.RestartGame();
    }

    private void GoToMainMenu()
    {
        GameManager.Instance.GoToMainMenu();
    }
}
