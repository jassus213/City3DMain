using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartMenuView : MonoBehaviour, IStartMenuView
{
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _settingsButton;

    private IStartMenuPresenter _presenter;

    public void SetPresenter(IStartMenuPresenter presenter)
    {
        _presenter = presenter;

        _newGameButton.onClick.AddListener(_presenter.OnNewGameClick);
        
        _settingsButton.onClick.AddListener(_presenter.OnSettingsClick);
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }

    
}