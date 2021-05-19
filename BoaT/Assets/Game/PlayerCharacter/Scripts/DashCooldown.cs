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
            DashCooldownExecute();
        }
    }

    public void SetDashOnCooldown()
    {
        dashCooldownTimer = playerData.dashCooldown;
        dashOnCooldown = true;
    }

    private void DashCooldownExecute()
    {
        if (dashCooldownTimer > 0) dashCooldownTimer -= Time.deltaTime;
        else dashOnCooldown = false;
    }
}
