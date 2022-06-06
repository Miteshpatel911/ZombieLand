using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] AmmoType ammoType;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] GameObject GunShot;

    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }

    void Update()
    {
        DisplayAmmo();

        if(Input.GetMouseButtonDown(0) && canShoot == true)
        {
           StartCoroutine(Shoot());
        }
    }

    void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();

    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if(ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            ProcessRaycast();
            muzzleFlash.Play();
            ammoSlot.ReduceCurrentAmmo(ammoType);
            GameObject shot = Instantiate(GunShot, transform.position, transform.rotation);
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
   

    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) { return; }
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject hvfx = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(hvfx, .1f);
       
    }
}
