using UnityEngine;

public class DashCooldown : MonoBehaviour
{
    public PlayerData playerData;
    private float dashCooldownTimer;
    [HideInInspector] public bool dashOnCooldown;

    void Update()
    {
        if (dashOnCooldown)
        {
            CooldownExecute();
        }
    }

    public void SetOnCooldown()
    {
        dashCooldownTimer = playerData.dashCooldown;
        dashOnCooldown = true;
    }

    private void CooldownExecute()
    {
        if (dashCooldownTimer > 0) dashCooldownTimer -= Time.deltaTime;
        else dashOnCooldown = false;
    }
}
