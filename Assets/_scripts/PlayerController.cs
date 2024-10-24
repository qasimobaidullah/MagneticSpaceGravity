
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 20f;
    public float maxSpeed = 10f;
    public float pullForce = 10f;
    public float pushForce = 10f;
    public float hoverForce = 5f;
    public float hoverHeight = 2f;
    public float jumpForce = 5f;
	public bool canJump = true;
	//this is joystick from assets store
    public FloatingJoystick variableJoystick;



    private Rigidbody rb;
    private GameObject closestMagnet;
    private Vector3 magnetForceDirection;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //float moveHorizontal =Input.GetAxis("Horizontal");
        //float moveVertical =Input.GetAxis("Vertical");

	    //here we converted the actual axis to floating joytick axis which is priovided inside the script
        Vector3 movement = new Vector3(variableJoystick.Horizontal, 0f, variableJoystick.Vertical).normalized * moveForce;
        if (variableJoystick.Horizontal != 0 || variableJoystick.Vertical != 0)
        {
            if (rb.velocity.magnitude < maxSpeed)
            {
                rb.AddForce(movement, ForceMode.Force);
            }
            PushAwayFromMagnet();
        }

        Hover();

        if (Input.GetKey(KeyCode.E))
        {
            PullTowardsMagnet();
        }

        if (canJump && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


    }
	// this is jump method
    private void Jump()
    {

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void PullTowardsMagnet()
    {
        closestMagnet = FindClosestMagnet();

        if (closestMagnet != null)
        {
            magnetForceDirection = (closestMagnet.transform.position - transform.position).normalized;
            rb.AddForce(magnetForceDirection * pullForce, ForceMode.Force);
        }
        else
        {
            magnetForceDirection = Vector3.zero;
        }

    }

    private GameObject FindClosestMagnet()
    {

        GameObject[] magnets = GameObject.FindGameObjectsWithTag("Magnets");
        GameObject nearestMagnet = null;

        float closestDistance = Mathf.Infinity;

        foreach (GameObject magnet in magnets)
        {
            float distanceToMagnet = Vector3.Distance(transform.position, magnet.transform.position);
            if (distanceToMagnet < closestDistance)
            {
                closestDistance = distanceToMagnet;
                nearestMagnet = magnet;
            }
        }

        return nearestMagnet;
    }

    private void PushAwayFromMagnet()
    {
        closestMagnet = FindClosestMagnet();

        if (closestMagnet != null)
        {

            Vector3 pushDirection = (transform.position - closestMagnet.transform.position).normalized;
            rb.AddForce(pushDirection * pushForce * Time.deltaTime, ForceMode.Force);
        }

    }

    private void Hover()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            float distanceToGround = hit.distance;

            if (distanceToGround < hoverHeight)
            {
                float forceAmount = (hoverHeight - distanceToGround) * hoverForce;
                rb.AddForce(Vector3.up * forceAmount, ForceMode.Acceleration);
            }
        }
    }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        if (closestMagnet != null && magnetForceDirection != Vector3.zero)
        {

            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + magnetForceDirection * 2f);
            Gizmos.DrawSphere(transform.position + magnetForceDirection * 2f, 0.1f);
        }
    }
}
