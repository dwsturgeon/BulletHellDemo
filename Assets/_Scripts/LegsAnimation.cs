using UnityEngine;
using TopDown.Movement;


[RequireComponent(typeof(Animator))]
public class LegsAnimation : MonoBehaviour
{
    [SerializeField] private Movement playerMover;
    private Animator legsAnimator;

    private void Awake()
    {
        legsAnimator = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        legsAnimator.SetBool("moving", playerMover.CurrentInput != Vector3.zero);
    }
}
