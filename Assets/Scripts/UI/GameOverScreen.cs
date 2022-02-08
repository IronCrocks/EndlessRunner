using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _player.Died += Player_Died;
        _restartButton.onClick.AddListener(OnRestartButtinClick);
        _exitButton.onClick.AddListener(OnExitButtinClick);
    }

    private void OnDisable()
    {
        _player.Died -= Player_Died;
        _restartButton.onClick.RemoveListener(OnRestartButtinClick);
        _exitButton.onClick.RemoveListener(OnExitButtinClick);
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    private void Player_Died()
    {
        Time.timeScale = 0;
        _canvasGroup.alpha = 1;
    }

    private void OnRestartButtinClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnExitButtinClick()
    {
        Application.Quit();
    }
}
