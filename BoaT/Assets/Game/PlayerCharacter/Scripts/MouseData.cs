using UnityEngine;

public class MouseData : MonoBehaviour
{
    public RaycastHit hit;
    public Ray ray;
    public Vector3 mousePositionInSpace;
    private Camera mainCamera;
    IThrowable lastCollider;

    private void Awake()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        MouseRaycast();
        HighlightThrowableObject();
    }

    void MouseRaycast()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        mousePositionInSpace = hit.point;
    }

    public RaycastHit GetClickPosition()
    {
        return hit;
    }

    public bool CheckForThrowableObject()
    {
        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<IThrowable>() != null)
            {
                lastCollider = hit.collider.GetComponent<IThrowable>();
                return true;
            }
            else return false;
        }
        else return false;
    }

    public GameObject PassThrowableObject()
    {
        return hit.collider.gameObject;
    }

    public void HighlightThrowableObject()
    {
        if (lastCollider != null)
        {
            if (CheckForThrowableObject()) lastCollider.Highlighted(true);
            else lastCollider.Highlighted(false);
        }
        else
        {
            CheckForThrowableObject();
        }
    }
}
