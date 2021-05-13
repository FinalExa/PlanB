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
        GetInputs();
    }

    void GetInputs()
    {
        GetLeftHandInput();
        GetRightHandInput();
        GetDashInput();
        GetFrontInput();
        GetSideInput();
    }

    void GetLeftHandInput()
    {
        if (Input.GetButtonDown("Fire1") == true) LeftHandInput = true;
        else LeftHandInput = false;
    }
    void GetRightHandInput()
    {
        if (Input.GetButtonDown("Fire2") == true) RightHandInput = true;
        else RightHandInput = false;
    }
    void GetDashInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true) DashInput = true;
        else DashInput = false;
    }
    void GetFrontInput()
    {
        FrontInput = Input.GetAxis("Horizontal");
    }
    void GetSideInput()
    {
        SideInput = Input.GetAxis("Vertical");
    }
}
