using UnityEngine;

public class Rotation : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    private Camera mainCamera;
    private Transform playerCharacterTransform;
    void Awake()
    {
        mainCamera = FindObjectOfType<Camera>();
        playerCharacterTransform = this.gameObject.transform;
    }
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        float angle = CalculateAngle(playerCharacterTransform.position, hit.point);
        playerCharacterTransform.rotation = Quaternion.Euler(new Vector3(playerCharacterTransform.rotation.x, angle, playerCharacterTransform.rotation.z));
    }

    float CalculateAngle(Vector3 player, Vector3 mouse)
    {
        return Mathf.Atan2(mouse.x - player.x, mouse.z - player.z) * Mathf.Rad2Deg;
    }
}
