using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Animator animator;

    Rigidbody rb;
    CharacterHands hands;
    BaseCharacterController character;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hands = GetComponent<CharacterHands>();
        character = GetComponent<BaseCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Velocity", rb.velocity.magnitude);
        animator.SetBool("Carrying", hands.carriableInHands != null);
        animator.SetBool("Jumping", !character.grounded);
    }
}
