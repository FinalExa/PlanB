﻿using UnityEngine;
using UnityEngine.AI;
public class SoulController : MonoBehaviour
{
    [HideInInspector] public bool isInsideStorageRoom;
    [HideInInspector] public bool collidedWithOther;
    [HideInInspector] public bool isInsideExitDoorCollider;
    public NavMeshAgent thisNavMeshAgent;
    public Rigidbody thisRigidbody;
    [HideInInspector] public GameObject playerIsInRange;
    [HideInInspector] public SoulReferences soulReferences;
    [HideInInspector] public GameObject exit;
    public SoulType[] soulTypes;
    [HideInInspector] public int thisSoulTypeIndex;
    private void Awake()
    {
        soulReferences = this.gameObject.GetComponent<SoulReferences>();
        exit = GameObject.FindGameObjectWithTag("Exit");
    }
    private void Start()
    {
        thisNavMeshAgent.speed = soulReferences.soulData.soulMovementSpeed;
        thisNavMeshAgent.acceleration = soulReferences.soulData.soulAcceleration;
    }
    public void DeactivateAllSoulModels()
    {
        for (int i = 0; i < soulTypes.Length; i++)
        {
            soulTypes[i].soulMainModelObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StorageRoom")) isInsideStorageRoom = true;
        if (other.CompareTag("Exit")) isInsideExitDoorCollider = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("StorageRoom") && !other.CompareTag("Player")) isInsideStorageRoom = false;
        if (other.CompareTag("Exit")) isInsideExitDoorCollider = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Soul")) collidedWithOther = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground") && !collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Soul")) collidedWithOther = false;
    }
}
[System.Serializable]
public class SoulType
{
    public enum SoulColor { Red, Blue, Yellow, Green, Purple };
    public SoulColor soulColor;
    public GameObject soulMainModelObject;
    public GameObject soulMeshContainer;
    public Animator soulAnimator;
}
