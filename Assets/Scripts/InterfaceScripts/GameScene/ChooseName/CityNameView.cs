using UnityEngine;
using TMPro;

public class CityNameView : MonoBehaviour, ICityNameView
{


    [SerializeField] private TextMeshProUGUI cityNameText;

    private ICityNamePresenter _presenter;

    public void SetPreseneter(ICityNamePresenter presenter)
    {
        _presenter = presenter;
    }

    public void SetCityName()
    {
        cityNameText.SetText(_presenter.GetCityName());
    }


    public void Show(bool show)
    {
        this.gameObject.SetActive(show);
    }
}
