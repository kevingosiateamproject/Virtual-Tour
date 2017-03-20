using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        Debug.Log("Working");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("GONE");
    }
}
