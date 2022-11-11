using UnityEngine;
using UnityEngine.UI;

public class DestoyView : MonoBehaviour, IDestoryView
{
    [SerializeField] private Button _destroyButton;
    
    private IDestoryPresenter _presenter;
    
    public void SetPresenter(IDestoryPresenter presenter)
    {
        _presenter = presenter;

         _destroyButton.onClick.AddListener(_presenter.GetGameObject);
    }

    public void Show(bool show)
    {
        this.gameObject.SetActive(show);
    }

    public void DestroyObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
