using UnityEngine;

public class CameraMovment : MonoBehaviour
{

    private Camera _myCamera;
    
    void Awake()
    {
       _myCamera = Camera.main;
    }
    
    void Update()
    {
        CameraMove();
    }

    void CameraMove()
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
            var xforce = Mathf.Abs(xDirection) * 100 / xCenter;
            var yforce = Mathf.Abs(yDirection) * 100 / yCenter;
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


            _myCamera.transform.position = new Vector3(_myCamera.transform.position.x + xMovement * Time.deltaTime,
                _myCamera.transform.position.y, _myCamera.transform.position.z + yMovement * Time.deltaTime);

        }
    }
}
