using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
   [SerializeField] private int _scoreValue;
   [SerializeField] private GameObject explosion;
   [SerializeField] private Gun gun;

   PickupDropper pickupDropper;
   Health health;


   private void Awake() 
   {
      health = GetComponent<Health>();
      pickupDropper = GetComponent<PickupDropper>();
   }

   private void OnEnable() 
   {
      health.onDeath += Kill;
   }

   private void OnDisable() 
   {
      health.onDeath -= Kill;
   }

   public void Kill()
   {
      PlayerUI.Instance.UpdateScore(_scoreValue);
      AlienList.RemoveFromList(gameObject);
      Instantiate(explosion, transform.position, Quaternion.identity);
      pickupDropper.DropPickup();
      
      gameObject.SetActive(false);
   }

   public void Shoot()
   {
      gun.Shoot();
   }
}
