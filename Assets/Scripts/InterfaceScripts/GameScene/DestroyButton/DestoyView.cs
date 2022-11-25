using UnityEngine;
using UnityEngine.UI;

public class DestoyView : MonoBehaviour, IDestoryView
{
    [SerializeField] private Button _destroyButton;

    private IDestroyPresenter _presenter;

    public void SetPresenter(IDestroyPresenter presenter)
    {
        _presenter = presenter;

        _destroyButton.onClick.AddListener(_presenter.StartDestroyMode);
    }

    

    public void Show(bool show)
    {
        this.gameObject.SetActive(show);
    }
}