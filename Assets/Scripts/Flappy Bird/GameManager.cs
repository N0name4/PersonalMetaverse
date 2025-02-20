using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Text scoreText;
    public Text highScoreText;
    public EndPanelController endPanelController;

    private int score = 0;
    private int highScore = 0;
    private bool isGameOver = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // 🔥 씬이 로드될 때 자동으로 UI 요소를 찾도록 이벤트 등록
            SceneManager.sceneLoaded += HandleSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        FindUIElements();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreUI();
    }

    // 🔥 씬이 로드될 때 자동으로 UI 요소를 다시 찾도록 하는 메서드
    private void HandleSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindUIElements();
        isGameOver = false;
    }

    private void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                RestartGame();
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                GoToMainMenu();
            }
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null) scoreText.text = $"현재 점수: {score}";
        if (highScoreText != null) highScoreText.text = $"최고 점수: {highScore}";
    }

    private void FindUIElements()
    {
        scoreText = GameObject.Find("ScoreText")?.GetComponent<Text>();
        highScoreText = GameObject.Find("HighScoreText")?.GetComponent<Text>();
        if (endPanelController == null)
        {
            GameObject endPanelObject = GameObject.Find("EndPanel");

            if (endPanelObject != null)
            {
                endPanelController = endPanelObject.GetComponent<EndPanelController>();
            }
        }
        // UI 요소가 없으면 콘솔에 경고 출력
        if (scoreText == null) Debug.LogWarning("ScoreText를 찾을 수 없습니다.");
        if (highScoreText == null) Debug.LogWarning("HighScoreText를 찾을 수 없습니다.");
        if (endPanelController == null) Debug.LogWarning("EndPanelController를 찾을 수 없습니다.");
    }

    public void GameOver()
    {
        FindUIElements(); // UI 요소 다시 찾기
        isGameOver = true;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        if (endPanelController != null)
        {
            Debug.Log("EndPanelController를 찾았습니다. EndPanel을 활성화합니다.");
            endPanelController.ShowEndPanel(score, highScore);
        }
        else
        {
            Debug.LogError("EndPanelController가 없습니다! EndPanel이 씬에 있는지 확인하세요.");
        }
    }

    public void RestartGame()
    {
        isGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        isGameOver = false;
        SceneManager.LoadScene("MainScene");
    }
}
