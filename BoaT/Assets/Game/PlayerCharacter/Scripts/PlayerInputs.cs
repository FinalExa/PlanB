using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public bool LeftHandInput { get; private set; }
    public bool RightHandInput { get; private set; }
    public bool DashInput { get; private set; }
    public float FrontInput { get; private set; }
    public float SideInput { get; private set; }
    private void Update()
    {
        Inputs();
    }

    void Inputs()
    {
        LeftHand();
        RightHand();
        Dash();
        Front();
        Side();
    }

    void LeftHand()
    {
        if (Input.GetButtonDown("Fire1") == true) LeftHandInput = true;
        else LeftHandInput = false;
    }
    void RightHand()
    {
        if (Input.GetButtonDown("Fire2") == true) RightHandInput = true;
        else RightHandInput = false;
    }
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true) DashInput = true;
        else DashInput = false;
    }
    void Front()
    {
        FrontInput = Input.GetAxis("Horizontal");
    }
    void Side()
    {
        SideInput = Input.GetAxis("Vertical");
    }
}
