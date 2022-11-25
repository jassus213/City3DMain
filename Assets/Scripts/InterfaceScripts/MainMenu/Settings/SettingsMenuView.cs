using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SettingsMenuView : MonoBehaviour, ISettingsMenuView
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Toggle _fullscreenToggle;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private TMP_Dropdown _qualityDropdown;

    private ISettingsMenuPresenter _presenter;

    public void SetPresenter(ISettingsMenuPresenter presenter)
    {
        _presenter = presenter;

        _backButton.onClick.AddListener(_presenter.OnBackClick);
        _fullscreenToggle.onValueChanged.AddListener(_presenter.OnFullscreenToggle);
        _volumeSlider.onValueChanged.AddListener(_presenter.OnVolumeChange);
        _qualityDropdown.onValueChanged.AddListener(_presenter.OnQualityChange);
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }

    public void SetFullScreen(bool value)
    {
        _fullscreenToggle.isOn = value;
    }

    public void SetVolume(float value)
    {
        _volumeSlider.value = value;
    }

    public void SetQuality(int value)
    {
        _qualityDropdown.value = value;
    }
}