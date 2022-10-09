using System;
using System.Linq;
using UnityEngine;

public class BuildingsObject : MonoBehaviour
{

    public Renderer MainRenderer;
    public Vector2Int Size = Vector2Int.one;
    private BoxCollider _collider;


    private void Awake()
    {
        _collider = gameObject.GetComponent<BoxCollider>();
    }

    public void SetColorStatus(bool available)
    {
        if (available)
        {
            MainRenderer.material.color = Color.green;
        }
        else
        {
            MainRenderer.material.color = Color.red;
        }
    }

    public void SetDefaultMaterial()
    {
        MainRenderer.material.color = Color.white;
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

    private void OnDrawGizmosSelected()
    {
        for (int x = 0; x < Size.x; x++)
        {
            for (int y = 0; y < Size.y; y++)
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
        
        Debug.Log(result);
        return result;
    }
    
    public void PlaceFlyingBuilding(Vector3 place)
    {
        gameObject.transform.position = place;
        SetDefaultMaterial();
        _collider.enabled = true;
    }
}
