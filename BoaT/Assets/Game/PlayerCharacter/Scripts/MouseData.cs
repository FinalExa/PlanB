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
        CheckForCollider();
    }

    void MouseRaycast()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        mousePositionInSpace = hit.point;
    }

    private void CheckForCollider()
    {
        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<iThrowable>() != null)
            {
                print("Pepo");
            }
        }
    }
}
