using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetController : MonoBehaviour
{

    public float outerMagnetRadius = 10f;
    public float innerMagneticRadius = 5f;
    public float outermaxMagneticForce = 50f;
    public float innerMaxMagneticForce = 100f;
    public float minimumMagneticForce = 5f;

	// use the fixed update to manipulate physics inside project
    void FixedUpdate()
    {


        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Rigidbody playerRB = player.GetComponent<Rigidbody>();

            if (playerRB != null)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

                if (distanceToPlayer <= outerMagnetRadius)
                {
                    Vector3 directionToMagnet = (transform.position - player.transform.position).normalized;

                    float forceMagnitude;
                    if (distanceToPlayer <= innerMagneticRadius)
                    {
                        forceMagnitude = Mathf.Max(innerMaxMagneticForce / Mathf.Pow(distanceToPlayer, 2), minimumMagneticForce);

                    }
                    else
                    {
                        forceMagnitude = Mathf.Max(outermaxMagneticForce / Mathf.Pow(distanceToPlayer, 2), minimumMagneticForce);
                    }

                    playerRB.AddForce(directionToMagnet * forceMagnitude, ForceMode.Force);
                }


            }

        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, outerMagnetRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, innerMagneticRadius);

    }


}
