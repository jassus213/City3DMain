using UnityEngine;public interface IDestoryView{    void SetPresenter(IDestoryPresenter presenter);    void Show(bool show);    void DestroyObject(GameObject gameObject);}