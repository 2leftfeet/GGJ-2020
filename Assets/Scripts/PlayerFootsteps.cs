using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{


    public AudioClip[] audioClips;
    private AudioSource audioSource;
    private Rigidbody rigidbody;
    private BaseCharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        controller = GetComponent<BaseCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rigidbody.velocity.magnitude > 0.5f && controller.grounded && !audioSource.isPlaying)
        {
            audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
            audioSource.Play();
        }
    }
}
