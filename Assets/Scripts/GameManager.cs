using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Target[] targets;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private Button restartButton;
    [SerializeField] private GameObject titleScreen;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private GameObject pauseScreen;

    [HideInInspector] public bool isGameActive;

    private float _spawnRate = 1;

    private int _score;
    private int _lives;
    private bool _paused;

    public void StartGame(int difficulty)
    {
        titleScreen.gameObject.SetActive(false);
        _spawnRate /= difficulty;
        isGameActive = true;
        _score = 0;
        StartCoroutine(SpawnTarget());
        UpdateLives(3);
        UpdateScore(0);
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        scoreText.text = "Score: " + _score;
    }

    public void UpdateLives(int livesToChange)
    {
        _lives += livesToChange;
        livesText.text = "Lives: " + _lives;
        if (_lives <= 0)
        {
            GameOver();
        }
    }

    private void Awake()
    {
        restartButton.onClick.AddListener(delegate { SceneManager.LoadScene(SceneManager.GetActiveScene().name); });
    }

    private void Update()
    {
        //Check if the user has pressed the P key
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }

    private void ChangePaused()
    {
        if (_paused)
        {
            _paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            _paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            int index = Random.Range(0, targets.Length);
            Instantiate(targets[index]);
        }
    }

    private void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
}