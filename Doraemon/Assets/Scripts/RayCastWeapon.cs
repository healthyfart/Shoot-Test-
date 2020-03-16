using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour {

	public Transform firePoint;
    public Transform firePointCrouch;
    public int damage = 40;
	public GameObject impactEffect;
	public LineRenderer lineRenderer;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			StartCoroutine(Shoot());
		}
	}

	IEnumerator Shoot ()
	{
        if (Input.GetButtonDown("Crouch"))
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(firePointCrouch.position, firePointCrouch.right);
            if (hitInfo)
            {
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }

                Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

                lineRenderer.SetPosition(0, firePointCrouch.position);
                lineRenderer.SetPosition(1, hitInfo.point);
            }
            else
            {
                lineRenderer.SetPosition(0, firePointCrouch.position);
                lineRenderer.SetPosition(1, firePointCrouch.position + firePointCrouch.right * 100);
            }

            lineRenderer.enabled = true;

            yield return new WaitForSeconds(0.02f);

            lineRenderer.enabled = false;
        }
        else
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
            if (hitInfo)
            {
                Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }

                Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, hitInfo.point);
            }
            else
            {
                lineRenderer.SetPosition(0, firePoint.position);
                lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
            }

            lineRenderer.enabled = true;

            yield return new WaitForSeconds(0.02f);

            lineRenderer.enabled = false;
        }


         
	}
}
