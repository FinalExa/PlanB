using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public float movementSpeed;
    public float minSpeedValue;
    public float grabRange;
    public float throwSpeed;
    public float dashDistance;
    public float dashDuration;
    public float dashCooldown;
    [HideInInspector] public float actualSpeed;
    public bool LeftHandOccupied { get; set; }
    public bool RightHandOccupied { get; set; }
    [HideInInspector] public float leftHandWeight;
    [HideInInspector] public float rightHandWeight;
    public enum SelectedHand
    {
        Left,
        Right
    }
    [HideInInspector] public SelectedHand selectedHand;
}
