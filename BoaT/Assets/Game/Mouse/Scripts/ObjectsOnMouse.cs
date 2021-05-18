using UnityEngine;

public class ObjectsOnMouse : MonoBehaviour
{
    private MouseData mouseData;

    private void Awake()
    {
        mouseData = this.gameObject.GetComponent<MouseData>();
    }
    public bool CheckForThrowableObject()
    {
        if (mouseData.hit.collider != null && mouseData.hit.collider.GetComponent<IThrowable>() != null)
        {
            return true;
        }
        else return false;
    }

    public GameObject PassThrowableObject()
    {
        return mouseData.hit.collider.gameObject;
    }
}
