using UnityEngine;

public class DashCooldown : MonoBehaviour
{
    public PlayerData playerData;
    [HideInInspector] public bool dashOnCooldown;

    void Update()
    {
        if (dashOnCooldown)
        {
            DashCooldownExecute();
        }
    }

    public void SetDashOnCooldown()
    {
        playerData.dashCooldownTimer = playerData.dashCooldown;
        dashOnCooldown = true;
    }

    private void DashCooldownExecute()
    {
        if (playerData.dashCooldownTimer > 0) playerData.dashCooldownTimer -= Time.deltaTime;
        else dashOnCooldown = false;
    }
}
