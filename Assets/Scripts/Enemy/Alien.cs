using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
   [SerializeField] private int _scoreValue;
   [SerializeField] private Gun gun;

   private bool isDead = false;
   PickupDropper pickupDropper;
   Health health;
   public static event Action<int> scoreIncreased;


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
      isDead = true;
      scoreIncreased?.Invoke(_scoreValue);
      DeactivateEngines();
      GetComponent<AnimatiorControllerHandler>().Death();
   }

   //Animation Event
   private void EndOfDeath()
   {
      AlienList.Instance.RemoveFromList(this);
      pickupDropper.DropPickup();
      gameObject.SetActive(false);
   }

   private void DeactivateEngines()
   {
      for (int i = 0; i < transform.childCount; i++)
      {
         transform.GetChild(i).gameObject.SetActive(false);
      }
   }

   public void Shoot()
   {
      gun.Shoot();
   }

   public bool IsDead()
   {
      return isDead;
   }
}
