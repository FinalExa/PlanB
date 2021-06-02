using UnityEngine;

[CreateAssetMenu(fileName = "SoulData", menuName = "ScriptableObjects/SoulData", order = 1)]
public class SoulData : ScriptableObject
{
    [Header("Soul Movement")]
    public float soulMovementSpeed;
    public float soulAcceleration;
    [Header("Soul Detection Range")]
    public float soulDetectionRange;
}
