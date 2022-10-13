using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    private bool _isCanPlase;
    private BuildingsObject _flyingBuilding;


    public void StartPlacingBuild(BuildingsObject buildingPrefab)
    {
        if (_flyingBuilding != null)
        {
            Destroy(_flyingBuilding);
        }

        _flyingBuilding = Instantiate(buildingPrefab);
    }

    private void Update()
    {
        if (_flyingBuilding != null)
        {
            // TODO "Collision with another houses (Change alfa or do up object)"
            
            
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Debug.Log(hitInfo.transform.gameObject.layer);
                /*if(hitInfo.transform.gameObject.layer != 6)
                    return;*/

                int x = Mathf.RoundToInt(hitInfo.point.x);
                int y = Mathf.RoundToInt(hitInfo.point.z);


                _flyingBuilding.MoveObject(new Vector3(x,
                    hitInfo.point.y + _flyingBuilding.Size.y, y));
                


                if (Input.GetMouseButtonUp(1))
                {
                    RotateBuilding();
                }


                if (_flyingBuilding.IsCanPlace() && Input.GetMouseButton(0))
                {
                    _flyingBuilding.PlaceFlyingBuilding(hitInfo.point);
                    _flyingBuilding = null;
                }
            }
            
        }
    }



    private void RotateBuilding()
    {
        var rotationToAdd = new Vector3(_flyingBuilding.transform.rotation.x, _flyingBuilding.transform.rotation.y, _flyingBuilding.transform.rotation.z + 90);
        _flyingBuilding.transform.Rotate(rotationToAdd);
    }


    

    
}