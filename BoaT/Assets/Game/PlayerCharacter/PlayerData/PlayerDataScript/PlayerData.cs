using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    [Header("Movement section")]
    public float movementSpeed;
    public float minSpeedValue;
    [HideInInspector] public float actualSpeed;
    [Header("Hands section")]
    public float grabRange;
    public float throwDistance;
    public float throwFlightTime;
    public float throwStopValue;
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
    [Header("Dash section")]
    public float dashDistance;
    public float dashDuration;
    public float dashCooldown;
}
