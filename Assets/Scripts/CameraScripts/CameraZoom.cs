using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera _myCamera;

    private void Awake()
    {
        _myCamera = Camera.main;
    }

    void Update()
    {
        //Debug.Log(Input.mousePosition);
        Zoom();
    }

    void Zoom()
    {
        float zoom = Input.mouseScrollDelta.y;
        if (zoom != 0 && zoom <= 1 && zoom >= -1)
        {
            Vector3 dir = _myCamera.ScreenPointToRay(Input.mousePosition).direction; 
            Vector3 temp = dir * zoom;
            temp = temp * 120f * Time.deltaTime;
            _myCamera.transform.Translate(temp, Space.World);
        }
    }

    
   

    
}
