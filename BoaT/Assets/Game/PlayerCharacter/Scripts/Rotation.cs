using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] public bool rotationEnabled;
    private MouseData mouseData;
    private Transform playerCharacterTransform;
    void Awake()
    {
        mouseData = FindObjectOfType<MouseData>();
        playerCharacterTransform = this.gameObject.transform;
    }
    private void Start()
    {
        rotationEnabled = true;
    }
    void Update()
    {
        if (rotationEnabled == true) Rotate();
    }

    private void Rotate()
    {
        float angle = CalculateAngle(playerCharacterTransform.position, mouseData.mousePositionInSpace);
        playerCharacterTransform.rotation = Quaternion.Euler(new Vector3(playerCharacterTransform.rotation.x, angle, playerCharacterTransform.rotation.z));
    }

    private float CalculateAngle(Vector3 player, Vector3 mouse)
    {
        return Mathf.Atan2(mouse.x - player.x, mouse.z - player.z) * Mathf.Rad2Deg;
    }
    public void RotateObjectToLaunch(Transform objectToLaunch)
    {
        float angle = CalculateAngle(objectToLaunch.position, mouseData.mousePositionInSpace);
        playerCharacterTransform.rotation = Quaternion.Euler(new Vector3(objectToLaunch.rotation.x, angle, playerCharacterTransform.rotation.z));
    }
}
