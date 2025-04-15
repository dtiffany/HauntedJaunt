using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;

    private AudioSource alarmAudio;

    bool m_IsPlayerInRange;

    public static float ViewRadius =3.5f;
    //radius of observer view
    public static float ViewDegree = 90;

    void Start()
    {
        alarmAudio = GetComponent<AudioSource>();
    }


    void OnTriggerEnter (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    void OnTriggerExit (Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    private PlayerMovement IsPlayerInView()
    {
        Vector3 ObserverPosition = transform.position;
        //Observer vector

        Vector3 ToPlayer = PlayerMovement.Instance.transform.position - ObserverPosition;
        //distance between player and observer

        ToPlayer.y = 0;

        if (ToPlayer.magnitude <= ViewRadius)
        //play is in view radius

        {
            if (Vector3.Dot(ToPlayer.normalized, transform.forward) > Mathf.Cos(ViewDegree * 0.5f * Mathf.Deg2Rad))
            {
                Debug.Log("Player is in view!");
                alarmAudio.Play();
                return PlayerMovement.Instance;

            }
            else alarmAudio.Stop();
           
        }
        else alarmAudio.Stop();
        return null;
    }

    void Update ()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;
            
            if (Physics.Raycast (ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player)
                {
                    gameEnding.CaughtPlayer ();
                }
            }
        }

        IsPlayerInView();
    }
}
