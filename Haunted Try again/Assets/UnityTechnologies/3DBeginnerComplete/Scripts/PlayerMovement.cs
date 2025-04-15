using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private static PlayerMovement p_instance;
    //declare player instance
    
    public InputAction MoveAction;
    
    public float turnSpeed = 20f;

    public static PlayerMovement Instance
    {
        get
        {
            return p_instance;
            //make player instance
        }
    }

    [SerializeField] private AudioClip[] coinSoundClip;
    [SerializeField] private AudioClip skullSoundClip;
    [SerializeField] private ParticleSystem coinParticle;

    Animator m_Animator;
    Rigidbody m_Rigidbody;
    AudioSource m_AudioSource;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;


    // Dylan's Inclusion
    public Transform bagTransform;
    public int coinCount = 0;
    public int maxCoins = 50;
    public Vector3 minBagScale = new Vector3(0.2f, 0.1f, 0.2f);
    public Vector3 maxBagScale = new Vector3(0.4f, 0.2f, 0.4f);

    void Start ()
    {
        m_Animator = GetComponent<Animator> ();
        m_Rigidbody = GetComponent<Rigidbody> ();
        m_AudioSource = GetComponent<AudioSource> ();
        
        MoveAction.Enable();

        p_instance = this;
    }

    void FixedUpdate ()
    {
        var pos = MoveAction.ReadValue<Vector2>();
        
        float horizontal = pos.x;
        float vertical = pos.y;
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("IsWalking", isWalking);
        
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop ();
        }

        Vector3 desiredForward = Vector3.RotateTowards (transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation (desiredForward);
    }

    void OnAnimatorMove ()
    {
        m_Rigidbody.MovePosition (m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation (m_Rotation);
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.CompareTag("Pickup")) 
        {
            other.gameObject.SetActive(false);
            coinCount++;

            AudioManager.instance.PlayRandomSoundClip(coinSoundClip, transform, 1f);
            coinParticle.Play();

            UpdateBagScale();
        }
    }

    // Increases coin count
    void UpdateBagScale()
    {
        float norm = Mathf.Clamp01((float)coinCount / maxCoins);   

        float eased = Mathf.Sqrt(norm);

        float scaleMultiplier = Mathf.Lerp(1f, maxBagScale.x / minBagScale.x, eased);

        float newX = minBagScale.x * scaleMultiplier;
        float newY = minBagScale.y * scaleMultiplier;

        float fixedZ = minBagScale.z;


        bagTransform.localScale = new Vector3(newX, newY, fixedZ);
    }
}