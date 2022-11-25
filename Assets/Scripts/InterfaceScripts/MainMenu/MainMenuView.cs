using UnityEngine;
using UnityEngine.UI;


public class MainMenuView : MonoBehaviour, IMainMenuView
{
    [SerializeField] private Button _newGameButton;
    [SerializeField] private Button _settingsButton;

    private IMainMenuPresenter _presenter;

    public void SetPresenter(IMainMenuPresenter presenter)
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