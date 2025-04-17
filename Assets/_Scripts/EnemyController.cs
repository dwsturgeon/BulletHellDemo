using System;
using System.Collections;
using System.Data.Common;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector3 playerPosition;
    private Vector3 enemyPosition;
    private GameObject player;
    private Transform playerTransform;
    private Transform enemyTransform;

    [Header("Variables")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float addedRotation;

    public static EnemyController instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //get player obj
        player = GameObject.FindGameObjectWithTag("Player");

        //get player transform for position
        Transform playerTransform = player.GetComponent<Transform>();

        getPlayerPosition();
        rotateEnemyTowardsPlayer();
    }

    private void getPlayerPosition()
    {
        playerPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, 0);
    }


    private void rotateEnemyTowardsPlayer()
    {
        Vector2 direction = (playerPosition - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + addedRotation;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle);

        //if you are reading this psy, this smooths the rotation.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
    }
}