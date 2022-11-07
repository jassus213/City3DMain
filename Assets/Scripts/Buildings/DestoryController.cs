using Buildings;
using JetBrains.Annotations;
using UnityEngine;

public class DestoryController : MonoBehaviour
{

    [SerializeField] private Texture2D cursorDestroyer;
    private GameObject _building;
    private bool isActive = false;

    [CanBeNull]
    private GameObject GetGameObject()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.transform.gameObject != null)
                return hitInfo.transform.gameObject;
            
        }

        return hitInfo.transform.gameObject;
    }

    private void StartDestroy()
    {
        var worldobject = GetGameObject();
        _building = worldobject;
        if (worldobject.GetComponent<IRemovable>() != null)
        {
            SetCustomCursor();
            Debug.Log(true);
            if (Input.GetMouseButton(0))
            {
                worldobject.GetComponent<BuildingsObject>().Remove();
                SetDefaultCursor();
                Debug.Log(true);
            }

        }
        
    }

    public void StartFunc()
    {
        isActive = !isActive;
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
        if (isActive)
        {
            StartDestroy();
        }
    }
}
