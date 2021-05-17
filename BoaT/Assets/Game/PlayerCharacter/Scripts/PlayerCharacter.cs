﻿using UnityEngine;
public class PlayerCharacter : StateMachine
{
    public PlayerData playerData;
    public enum SelectedHand
    {
        Left,
        Right
    }
    [HideInInspector] public SelectedHand selectedHand;
    [HideInInspector] public Rotation rotation;
    [HideInInspector] public Rigidbody playerRB;
    [HideInInspector] public PlayerInputs playerInputs;
    [HideInInspector] public MouseData mouseData;
    public GameObject LeftHand;
    public GameObject RightHand;
    [HideInInspector] public Camera mainCamera;

    private void Awake()
    {
        playerInputs = this.gameObject.GetComponent<PlayerInputs>();
        mouseData = this.gameObject.GetComponent<MouseData>();
        mainCamera = FindObjectOfType<Camera>();
        rotation = FindObjectOfType<Rotation>();
        rotation.rotationEnabled = false;
        playerRB = this.gameObject.GetComponent<Rigidbody>();
        SetState(new Idle(this));
    }
    private void Update()
    {
        _state.StateUpdate();
    }
    private void Start()
    {
        playerData.LeftHandOccupied = false;
        playerData.RightHandOccupied = false;
        playerData.actualSpeed = playerData.movementSpeed;
        _state.Start();
    }
    private void OnCollisionStay(Collision collision)
    {
        _state.Collisions(collision);
    }
    public void UpdateSpeedValue()
    {
        playerData.actualSpeed = playerData.movementSpeed - (playerData.leftHandWeight + playerData.rightHandWeight);
        if (playerData.actualSpeed < playerData.minSpeedValue) playerData.actualSpeed = playerData.minSpeedValue;
    }

    public void PrintStuff(string stringToPrint)
    {
        print(stringToPrint);
    }
}
