﻿using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public bool LeftHandInput { get; private set; }
    public bool RightHandInput { get; private set; }
    public bool DashInput { get; private set; }
    public Vector3 MovementInput { get; private set; }
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
        float frontInput = Input.GetAxisRaw("Horizontal");
        float sideInput = Input.GetAxisRaw("Vertical");
        MovementInput = new Vector3(frontInput, 0, sideInput).normalized;
    }
}
