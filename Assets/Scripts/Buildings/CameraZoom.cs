using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private Camera MyCamera;

    private void Awake()
    {
        MyCamera = Camera.main;
    }

    void Update()
    {
        //Debug.Log(Input.mousePosition);
        Zoom();
        MovementCamera();
    }

    void Zoom()
    {
        float zoom = Input.mouseScrollDelta.y;
        if (zoom != 0 && zoom <= 1 && zoom >= -1)
        {
            Vector3 dir = MyCamera.ScreenPointToRay(Input.mousePosition).direction;
            Vector3 temp = dir * zoom;
            temp = temp * 120f * Time.deltaTime;
            MyCamera.transform.Translate(temp, Space.World);
        }
    }

    void MovementCamera()
    {
        // TODO "Refactoring"
        
        Vector3 mousePos = Input.mousePosition;
        var xCenter = Screen.width / 2;
        var yCenter = Screen.height / 2;
        var xDirection = mousePos.x - xCenter;
        var yDirection = mousePos.y - yCenter;
        var move = Input.GetMouseButton(2);
        if (move)
        {
            var xforce = Mathf.Abs(xDirection)* 100/xCenter;
            var yforce = Mathf.Abs(yDirection)* 100/yCenter;
            if (mousePos.x > Screen.width || mousePos.x < 0)
            {
                xforce = 100;
            }
            
            if (mousePos.y > Screen.height || mousePos.y < 0)
            {
                yforce = 100;
            }
            
            
            float xMovement = 0;
            if (xDirection < 0)
            {
                xMovement = -0.3f * xforce;
            }
            else
            {
                xMovement = 0.3f * xforce;
            }
            
            float yMovement = 0;
            if (yDirection < 0)
            {
                yMovement = -0.3f * yforce;
            }
            else
            {
                yMovement = 0.3f * yforce;
            }


            MyCamera.transform.position = new Vector3(MyCamera.transform.position.x + xMovement * Time.deltaTime, MyCamera.transform.position.y, MyCamera.transform.position.z + yMovement * Time.deltaTime);
            
        }
    }

    
}
