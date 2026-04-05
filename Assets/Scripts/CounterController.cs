using UnityEngine;
using UnityEngine.Events;


public class CounterController : MonoBehaviour
{
    //Collision Targets

    public GameObject objectA;// Weight
    public GameObject objectB;// Track
    public GameObject objectC;// Goal

    //Settings
    public bool resetOnWrongHit = false;

    //Trigger Event
    public UnityEvent onSequenceComplete;

    // Defult statute
    private bool _hasHitB = false;

   
    private void OnCollisionEnter(Collision collision)
    {
        ProcessCollision(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        ProcessCollision(other.gameObject);
    }

    private void ProcessCollision(GameObject hitObject)
    {
        // Only collision with object A
        if (gameObject != objectA && !IsChildOfA(gameObject)) return;

        // Find object b 
        if (!_hasHitB)
        {
            if (hitObject == objectB)
            {
                _hasHitB = true;
                Debug.Log("Hitted Object B,waiting for hit object C");
            }
        }
        // get c
        else
        {
            if (hitObject == objectC)
            {
                Debug.Log("Already hitted object C");

                // Refer EZPZ ItemCycler NextItem()
                onSequenceComplete?.Invoke();

                //reset state
                _hasHitB = false;
            }
            else if (resetOnWrongHit && hitObject != objectB)
            {
                // If hitted wrong object,reset all
                _hasHitB = false;
                Debug.Log("Wrong hit sequence,reset");
            }
        }
    }

    private bool IsChildOfA(GameObject obj)
    {
        return objectA != null && obj.transform.IsChildOf(objectA.transform);
    }

    public void ResetSequence()
    {
        _hasHitB = false;
    }
}
