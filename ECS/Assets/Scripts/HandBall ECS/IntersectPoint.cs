using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectPoint : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player")
        {   
            var contact = other.contacts[0];

            Vector3 dir = contact.point - other.transform.position;
            var angle = Vector3.Angle(dir, other.transform.right);
            Debug.Log(contact.point);
            Debug.Log(angle);

         
        }   
   }
}
