using System;
using System.Collections;
using System.Data.Common;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private Transform playerTransform;

    [Header("Variables")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float addedRotation;
    
    public static EnemyController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        //get player obj
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        //get player transform for position
        playerTransform = player.GetComponent<Transform>();
        
        rotateEnemyTowardsPlayer();
        moveTwoardsPlayer();
    }



    private void rotateEnemyTowardsPlayer()
    {
       Vector3 direction = (playerTransform.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + addedRotation;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

        //if you are reading this psy, this smooths the rotation.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
    }

    private void moveTwoardsPlayer()
    {

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed);
    }
}