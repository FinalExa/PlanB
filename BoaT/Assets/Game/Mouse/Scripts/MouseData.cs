using UnityEngine;

public class MouseData : MonoBehaviour
{
    public RaycastHit hit;
    public Ray ray;
    [HideInInspector] public Vector3 mousePositionInSpace;
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
    public RaycastHit GetClickPosition()
    {
        return hit;
    }
}
