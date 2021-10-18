using UnityEngine;
using System.Collections;

/// <summary>
/// This behaviour is attached to the ball.
/// It controls the movement of the ball.
/// </summary>
public class Ball : MonoBehaviour {
	
	
	public Vector3 initialImpulse;
    public GameObject blood;
    //public Collider[] rigColliders;
    public Rigidbody[] rigRigidbodies;

	private Rigidbody rb;
   

    void Start () 
	{
        initialImpulse.x = Random.Range(3,6);
        initialImpulse.y = Random.Range(3,6);
        initialImpulse.z = 0;
        rb = GetComponent<Rigidbody>();
		rb.AddForce(initialImpulse, ForceMode.Impulse);
	}
	
	private void FixedUpdate()
    {
		transform.position = new Vector3(transform.position.x, transform.position.y, 0);
	}
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag=="Diken")
        {
            
            GameObject bloodClone = Instantiate(blood);
            bloodClone.transform.parent = transform;
            bloodClone.transform.localPosition = Vector3.zero;
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            //characterJoint.connectedBody = other.gameObject.GetComponent<Rigidbody>();
            StopBody();
            //gameObject.transform.parent = other.transform;
            //gameObject.transform.localPosition = Vector3.zero;
            rb.velocity = Vector3.zero;
		}
       
       
    }

    //public void Death()
    //{
    //    //wait 2-3 seconds.
    //    foreach (Collider col in rigColliders)
    //    {
    //        col.enabled = false;
    //    }

    //    Invoke("StopBody", 2.0f);
    //}
    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.tag=="Player")
        {
            Debug.Log("CUUUU");
            rb.AddForce(initialImpulse, ForceMode.Impulse);
        }
        if (collision.gameObject.tag== "Wall")
        {
            rb.AddForce(initialImpulse, ForceMode.Impulse);
        }
    }
    void StopBody()
    {
        foreach (Rigidbody rb in rigRigidbodies)
        {
            rb.isKinematic = true;
        }
        //foreach (Collider cl in rigColliders)
        //{
        //    cl.isTrigger = true;
        //}
    }
}
