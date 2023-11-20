using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventDetection : MonoBehaviour
{
    Animator animator;
    void OnTriggerEnter(Collider other) 
    {
        animator = other.GetComponentInChildren<Animator>();

        if (animator != null)
        {
            Debug.Log($"{other.name} is dancing");
            animator.SetTrigger("DanceTrigger");
        }
        else
        {
            Debug.LogError("Animator component not found.");
        }
        
    }
    void OnTriggerExit(Collider other)
    {
        animator = other.GetComponentInChildren<Animator>();

        if (animator != null)
        {
            Debug.Log($"{other.name} is waving");
            animator.SetTrigger("WaveTrigger");
        }
        else
        {
            Debug.LogError("Animator component not found.");
        }
        
    }
}
