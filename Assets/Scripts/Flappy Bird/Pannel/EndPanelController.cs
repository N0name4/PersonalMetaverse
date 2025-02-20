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
        // 버튼 클릭 이벤트 연결
        if (yesButton != null) yesButton.onClick.AddListener(RestartGame);
        if (noButton != null) noButton.onClick.AddListener(GoToMainMenu);

        // EndPanel을 처음에는 비활성화
        gameObject.SetActive(false);
    }

    public void ShowEndPanel(int score, int highScore)
    {
        if (finalScoreText == null) finalScoreText = GameObject.Find("FinalScoreText")?.GetComponent<Text>();
        if (finalHighScoreText == null) finalHighScoreText = GameObject.Find("FinalHighScoreText")?.GetComponent<Text>();

        if (finalScoreText != null) finalScoreText.text = $"당신의 점수: {score}";
        if (finalHighScoreText != null) finalHighScoreText.text = $"최고 점수: {highScore}";

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
