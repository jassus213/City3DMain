using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    public Vector2Int GridSize = new Vector2Int(10, 10);

    private Building[,] grid;
    private Building _flyingBuilding;
    private Camera _mainCamera;

    private void Awake()
    {
        grid = new Building[GridSize.x, GridSize.y];
        _mainCamera = Camera.main;
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
        if (_flyingBuilding != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);

                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);

                bool available = true;

                if (x < 0 || x > GridSize.x - _flyingBuilding.Size.x) available = false;
                if (y < 0 || y > GridSize.y - _flyingBuilding.Size.y) available = false;

                if (available && IsPlaceTaken(x, y)) available = false;

                _flyingBuilding.transform.position = new Vector3(x, 0, y);
                _flyingBuilding.SetTransperent(available);
                
                

                if (available && Input.GetMouseButton(0))
                {
                    PlaceFlyingBuilding(x,y);
                }
            }
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x < GridSize.x; x++)
        {
            for (int y = 0; y < GridSize.y; y++)
            {
                if ((x + y) % 2 == 0)
                {
                    Gizmos.color = new Color(0.88f, 0f, 1f, 0.3f); 
                }
                else
                {
                    Gizmos.color = new Color(1f, 0.68f, 0f, 0.3f); 
                }
                    
                Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, 1f, 1));
            }
        }
        
    }

    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < _flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < _flyingBuilding.Size.y; y++)
            {
                if (grid[placeX + x, placeY + y] != null)
                    return true;
            }
        }

        return false;
    }

    private void PlaceFlyingBuilding(int placeX, int placeY)
    {
        for (int x = 0; x < _flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < _flyingBuilding.Size.y; y++)
            {
                grid[placeX + x, placeY + y] = _flyingBuilding;
            }
        }
        _flyingBuilding.SetDefaultMaterial();
        _flyingBuilding = null;
    }
    //test//
}