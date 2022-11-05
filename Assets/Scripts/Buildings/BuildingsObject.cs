using System;
using System.Linq;
using UnityEngine;

public class BuildingsObject : MonoBehaviour
{
    private Renderer _mainRenderer;
    private BoxCollider _collider;

    private int _groundLayer;

    private void Awake()
    {
        _collider = gameObject.GetComponent<BoxCollider>();
        _mainRenderer = gameObject.GetComponent<MeshRenderer>();
        _groundLayer = LayerMask.GetMask("House","Ground");
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

    public void MoveObject(Vector3 position)
    {
        gameObject.transform.position = position;

        if (IsObjectClose())
        {
            position.y += 10;
            gameObject.transform.position = position;
            //Debug.Log("Da");
        }

        if (DetectGround())
        {
            SetColorStatus(false);
        }
        else
        {
            SetColorStatus(true);
        }
    }

    private bool IsObjectClose()
    {
        var result = false;
        result = DetectHouse(Vector3.left);
        if (result)
            return true;
        result = DetectHouse(Vector3.right);
        if (result)
            return true;
        result = DetectHouse(Vector3.forward);
        if (result)
            return true;
        result = DetectHouse(Vector3.back);
        return result;
    }

    

    public void PlaceFlyingBuilding(Vector3 place)
    {
        gameObject.transform.position = place;
        SetDefaultMaterial();
        _collider.enabled = true;
    }


    public bool DetectGround()
    {
        var renderList = gameObject.GetComponentsInChildren<MeshRenderer>(true).ToList();
        var bounds = renderList[0].bounds;
        for (int i = 1; i < renderList.Count; i++)
        {
            bounds.Encapsulate(renderList[i].bounds);
        }
        
        var result = Physics.BoxCast(bounds.center + 100f * Vector3.up,
            bounds.extents + 0.1f * Vector3.right + 0.1f * Vector3.forward,
            Vector3.down, out var hit, Quaternion.identity, 2000f);
        
        
        Debug.Log("distance:" + hit.distance);
        Debug.Log("layer:" + hit.transform.gameObject.layer);
        return result;
    }
    
    private bool DetectHouse(Vector3 direction)
    {
        var distance = 10;
        var mesh = gameObject.GetComponent<MeshFilter>();
        var vertices = mesh.mesh.vertices;
        var sortedVertices = vertices.OrderBy(x => x.z).ToArray();
        var originalY = sortedVertices.FirstOrDefault();
        var result = false;
        foreach (var minVertices in sortedVertices)
        {
            if (Math.Abs(originalY.z - minVertices.z) != 0.0)
            {
                break;
            }

            var worldPoint = transform.TransformPoint(minVertices);
            var ray = new Ray(worldPoint, direction);
            Debug.DrawRay(worldPoint, direction);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
               // Debug.Log(hitInfo.distance);
                if (hitInfo.transform.gameObject.layer == 7 && hitInfo.distance <= distance)
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
}