using UnityEngine;

public class Rotation : MonoBehaviour
{
    private MouseData mouseData;
    private Transform playerCharacterTransform;
    void Awake()
    {
        mouseData = FindObjectOfType<MouseData>();
        playerCharacterTransform = this.gameObject.transform;
    }
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float angle = CalculateAngle(playerCharacterTransform.position, mouseData.mousePositionInSpace);
        playerCharacterTransform.rotation = Quaternion.Euler(new Vector3(playerCharacterTransform.rotation.x, angle, playerCharacterTransform.rotation.z));
    }

    float CalculateAngle(Vector3 player, Vector3 mouse)
    {
        return Mathf.Atan2(mouse.x - player.x, mouse.z - player.z) * Mathf.Rad2Deg;
    }
}
