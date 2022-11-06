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
        if (IsBuildingNull())
        { 
            if (RaycastHit() != null)
            {
                var hitInfo = RaycastHit();
                if (Input.GetMouseButtonDown(1))
                {
                    if (hitInfo.Value.transform.gameObject.layer == 7)
                    {
                        _flyingBuilding = hitInfo.Value.transform.GetComponent<BuildingsObject>();
                        var collider = _flyingBuilding.GetComponent<Collider>();
                        collider.enabled = false;
                        return; 
                    }
                }
                
            }
        }


        if (!IsBuildingNull())
        {
            // TODO "Collision with another houses (Change alfa or do up object)"
            if (RaycastHit() != null)
            {
                var hitInfo = RaycastHit();
                
                var x = Mathf.RoundToInt(hitInfo.Value.point.x);
                var y = Mathf.RoundToInt(hitInfo.Value.point.z);

                var canPlace = _flyingBuilding.MoveObject(new Vector3(x, hitInfo.Value.point.y, y));


                if (Input.GetMouseButtonDown(1))
                {
                    RotateBuilding();
                    return;
                }


                if (canPlace && Input.GetMouseButton(0))
                {
                    _flyingBuilding.PlaceFlyingBuilding(hitInfo.Value.point);
                    _flyingBuilding = null;
                }
            }
        }
    }

    private RaycastHit? RaycastHit()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            return hitInfo;
        }

        return null;
    }
    

    private bool IsBuildingNull()
    {
        if (_flyingBuilding == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private void RotateBuilding()
    {
        var rotationToAdd = new Vector3(_flyingBuilding.transform.rotation.x, _flyingBuilding.transform.rotation.y,
            _flyingBuilding.transform.rotation.z + 90);
        _flyingBuilding.transform.Rotate(rotationToAdd);
    }
}

