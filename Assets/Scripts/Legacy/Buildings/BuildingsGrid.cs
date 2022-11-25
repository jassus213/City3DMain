using Buildings;
using UnityEngine;
using Zenject;

public class BuildingsGrid : MonoBehaviour, IRotateble
{
    private bool _isCanPlase;
    private BuildingsObject _flyingBuilding;
    [Inject] private readonly InputState _inputState;

    public BuildingsGrid(InputState inputState)
    {
        _inputState = inputState;
    }
    public void StartPlacingBuild(Building buildingPrefab)
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
                var position = new Vector3(hitInfo.Value.transform.position.x, hitInfo.Value.transform.position.y,
                    hitInfo.Value.transform.position.z);
                if (Input.GetMouseButtonDown(1))
                {
                    if (hitInfo.Value.transform.gameObject.GetComponent<IMovable>() is not null)
                    {
                        _flyingBuilding = hitInfo.Value.transform.GetComponent<BuildingsObject>();
                        _flyingBuilding.GetComponent<Collider>().enabled = false;
                        return;
                    }
                }
            }
        }


        if (!IsBuildingNull())
        {
            var ray = RaycastHit();
            if (ray is not null)
            {
                var x = Mathf.RoundToInt(ray.Value.point.x);
                var y = Mathf.RoundToInt(ray.Value.point.z);

                var canPlace = _flyingBuilding.MoveObject(new Vector3(x, ray.Value.point.y, y));


                if (Input.GetMouseButtonDown(1))
                {
                    Rotate();
                    return;
                }


                if (canPlace && Input.GetMouseButton(0))
                {
                    _flyingBuilding.PlaceFlyingBuilding(ray.Value.point);
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

        return false;
    }


    public void Rotate()
    {
        var rotationEulers =
            new Vector3(_flyingBuilding.transform.rotation.x, 90,
                _flyingBuilding.transform.rotation.z);
        _flyingBuilding.transform.Rotate(rotationEulers, Space.World);
    }
}