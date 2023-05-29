using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class FinishPanel : MonoBehaviour
{
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Ball ball;

    private CanvasGroup _screenFinish;

    private void Awake()
    {
        _screenFinish = GetComponent<CanvasGroup>();
        _screenFinish.alpha = 0;
    }
    private void OnEnable()
    {
        ball.Finish += OnFinish;
        nextLevelButton.onClick.AddListener(OnLevelButton);
    }
    private void OnDisable()
    {
        ball.Finish -= OnFinish;
        nextLevelButton.onClick.RemoveListener(OnLevelButton);
    }

    private void OnLevelButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnFinish()
    {
        _screenFinish.alpha = 1;
        Time.timeScale = 0;
    }


}
