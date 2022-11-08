using Buildings;
using JetBrains.Annotations;
using UnityEngine;

public class DestoryController : MonoBehaviour
{

    [SerializeField] private Texture2D cursorDestroyer;
    private bool _isActive = false;
    

    [CanBeNull]
    private GameObject GetGameObject()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hitInfo);
            return hitInfo.transform.gameObject; 

       
    }

    private void StartDestroy()
    {
       

        if (GetGameObject().GetComponent<IRemovable>() != null)
        {
            SetCustomCursor();
            if (Input.GetMouseButton(0))
            {
                GetGameObject().GetComponent<BuildingsObject>().Remove();
                SetDefaultCursor();
                ChangeStatusFunc();
            }
            else
            {
                return;
            }

        }
        SetDefaultCursor();
    }

    public void ChangeStatusFunc()
    {
        _isActive = !_isActive;
    }

    private void SetCustomCursor()
    {
        Cursor.SetCursor(cursorDestroyer, Vector2.zero, CursorMode.ForceSoftware);
    }

    private void SetDefaultCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    private void Update()
    {
        if (_isActive)
        {
            StartDestroy();
        }
    }
}
