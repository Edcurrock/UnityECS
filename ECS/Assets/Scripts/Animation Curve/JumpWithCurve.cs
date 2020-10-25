using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpWithCurve : MonoBehaviour
{
    [SerializeField]
    AnimationCurve jumpCurve;

    Rigidbody rigidbody = null;
    float currentTime = 0;
    float totalTime;
    bool canPress = true;
    bool jumping = false;

    private void Start() 
    {
        rigidbody = GetComponent<Rigidbody>();
        totalTime = jumpCurve.keys[jumpCurve.length-1].time;
    }

    private void Update() {

        if (canPress)
        {
            jumping = Input.GetKeyDown("space");
            canPress = !jumping;
        }

    }

    private void FixedUpdate() 
    {

        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        if (x != 0 || z != 0)
        {
           
            var direction = new Vector3(x, 0, z);
            rigidbody.AddForce(direction.normalized,ForceMode.Impulse);

        }

       
        // print(canPress);
        if(jumping)
        {
            var curPos = transform.position;
            
            curPos.y += jumpCurve.Evaluate(currentTime);
            rigidbody.position = curPos;
            currentTime += Time.fixedDeltaTime;
            if(currentTime >= totalTime)
            {
                currentTime = 0;
                canPress = true;
                jumping = false;
            }
        }

     
            
        }

        private void OnDrawGizmos() {
            Gizmos.DrawLine(transform.position, transform.right * 100f);
        }
    

}
