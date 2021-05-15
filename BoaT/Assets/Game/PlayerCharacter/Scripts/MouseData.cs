using UnityEngine;

public class MouseData : MonoBehaviour
{
    public RaycastHit hit;
    public Ray ray;
    public Vector3 mousePositionInSpace;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        MouseRaycast();
    }

    void MouseRaycast()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        mousePositionInSpace = hit.point;
    }

    public bool CheckForThrowableObject()
    {
        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<iThrowable>() != null) return true;
            else return false;
        }
        else return false;
    }

    public GameObject PassThrowableObject()
    {
        return hit.collider.gameObject;
    }
}
