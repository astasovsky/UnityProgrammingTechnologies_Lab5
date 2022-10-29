using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    [SerializeField] private int difficulty;
    private Button _button;
    private GameManager _gameManager;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void SetDifficulty()
    {
        Debug.Log(gameObject.name + " was clicked");
        _gameManager.StartGame(difficulty);
    }
}