using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseNameView : MonoBehaviour, IChooseNameView
{
    [SerializeField] private Button _saveButton;
    [SerializeField] private TMP_InputField _inputField;

    private Animator _animatorHolder;
    private CommonGameSettings _commonGameSettings;

    private IChooseNamePresenter _presenter;

    private void Awake()
    {
        _animatorHolder = _inputField.GetComponent<Animator>();
    }

    public void SetPresenter(IChooseNamePresenter presenter)
    {
        _presenter = presenter;

        _saveButton.onClick.AddListener(_presenter.OnSaveClick);
    }


    public void Show(bool show)
    {
        gameObject.SetActive(show);
    }

    public string GetCityName()
    {
        return _inputField.text;
    }

    public void SetCityName(string name)
    {
        _inputField.text = name;
    }

    public void ErrorCityName(string textError)
    {
        _animatorHolder.Play("InvalidPassword");


        var placeholder = _inputField.placeholder;
        placeholder.GetComponent<TextMeshProUGUI>().text = textError;
    }
}