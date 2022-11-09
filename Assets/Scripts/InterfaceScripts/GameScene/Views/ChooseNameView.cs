using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseNameView : MonoBehaviour, IChooseNameView
{
    [SerializeField] private Button _saveButton;
    [SerializeField] private TMP_InputField _inputField;

    private IChooseNamePresenter _presenter;


    public void SetPresenter(IChooseNamePresenter presenter)
    {
        _presenter = presenter;

        _saveButton.onClick.AddListener(_presenter.OnSaveClick);
    }

    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }

    public void SetCityName(string text)
    {
        _inputField.text = text;
    }
}