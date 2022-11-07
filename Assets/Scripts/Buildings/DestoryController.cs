using Buildings;
using JetBrains.Annotations;
using UnityEngine;

public class DestoryController : MonoBehaviour
{

    private bool isActive = false;

    [CanBeNull]
    private GameObject IsHouse()
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
        var worldobject = IsHouse();
        if (worldobject.GetComponent<IRemovable>() != null && Input.GetMouseButton(0))
        {
            worldobject.GetComponent<BuildingsObject>().Remove();
            Debug.Log(true);
        }
    }

    public void StartFunc()
    {
        isActive = !isActive;
    }

    private void Update()
    {
        if (isActive)
        {
            StartDestroy();
        }
    }
}
