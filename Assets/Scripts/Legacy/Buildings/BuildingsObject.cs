using System.Linq;
using Buildings;
using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(BoxCollider))]
public class BuildingsObject : BuildingsGrid, IRemovable, IMovable
{
    private Renderer _mainRenderer;
    private BoxCollider _collider;

    private int _groundLayer;

    private void Awake()
    {
        _collider = gameObject.GetComponent<BoxCollider>();
        _mainRenderer = gameObject.GetComponent<MeshRenderer>();
        _groundLayer = LayerMask.GetMask("House", "Ground");
    }

    private void SetColorStatus(bool available)
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

    private void SetDefaultMaterial()
    {
        _mainRenderer.material.color = Color.white;
    }

    public bool MoveObject(Vector3 position)
    {
        gameObject.transform.position = position;

        if (DetectGround())
        {
            SetColorStatus(true);
            return true;
        }

        SetColorStatus(false);
        return false;
    }


    public void PlaceFlyingBuilding(Vector3 place)
    {
        gameObject.transform.position = place;
        SetDefaultMaterial();
        _collider.enabled = true;
    }


    private bool DetectGround()
    {
        var renderList = gameObject.GetComponentsInChildren<MeshRenderer>(true).ToList();
        var bounds = renderList[0].bounds;

        for (int i = 1; i < renderList.Count; i++)
        {
            bounds.Encapsulate(renderList[i].bounds);
        }

        var result = Physics.BoxCast(bounds.center + 100f * Vector3.up,
            bounds.extents + 0.1f * Vector3.right + 0.1f * Vector3.forward,
            Vector3.down, out var hit, Quaternion.identity, 2000f, _groundLayer);

        if (!result)
            return false;

        if (hit.transform.gameObject.layer != 6)
        {
            //var objectSize = Vector3.Scale(transform.localScale, bounds.size);
            var position = gameObject.transform.position;
            position = new Vector3(position.x, position.y + bounds.size.y, position.z);
            //gameObject.transform.position = position;
            return false;
        }

        return result;
    }


    public void Remove()
    {
        Destroy(this.gameObject);
    }

    public BuildingsObject(InputState inputState) : base(inputState)
    {
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}