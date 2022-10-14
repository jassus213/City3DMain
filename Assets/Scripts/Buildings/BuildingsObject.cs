using System.Linq;
using UnityEngine;

public class BuildingsObject : MonoBehaviour
{

    private Renderer _mainRenderer;
    private BoxCollider _collider;


    private void Awake()
    {
        _collider = gameObject.GetComponent<BoxCollider>();
        _mainRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    public void SetColorStatus(bool available)
    {
        if (available)
        {
            _mainRenderer.material.color = Color.green;
        }
        else
        {
            _mainRenderer.material.color = Color.red;
        }
    }

    public void SetDefaultMaterial()
    {
        _mainRenderer.material.color = Color.white;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("On Collision Enter: " + collision.collider.name);
    }
 
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("On Collision stay: " + collision.collider.name); 
    }
 
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("On Collision exit: " + collision.collider.name);
    }
    

    public void MoveObject(Vector3 position)
    {
        gameObject.transform.position = position;
        if (IsCanPlace())
        {
            SetColorStatus(true);
        }
        else
        {
            SetColorStatus(false);
        }
    }

    public bool IsCanPlace()
    {
        var mesh = gameObject.GetComponent<MeshFilter>();
        var vertices = mesh.mesh.vertices;
        var sortedVertices = vertices.OrderByDescending(x => x.y).ToArray();
        var originalY = sortedVertices.FirstOrDefault();
        var result = false;
        foreach (var minVertices in sortedVertices)
        {
            if (originalY.y != minVertices.y)
                break;
            
            var worldPoint = transform.TransformPoint(minVertices);
            var ray = new Ray(worldPoint, Vector3.down);
            

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.transform.gameObject.layer == 6)
                {
                    result = true;
                }
                else
                {
                    result = false;
                    break;
                }
            }
        }
        
        return result;
    }
    
    public void PlaceFlyingBuilding(Vector3 place)
    {
        gameObject.transform.position = place;
        SetDefaultMaterial();
        _collider.enabled = true;
    }
}
