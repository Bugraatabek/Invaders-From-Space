using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour, IGetEffectedOnCollision
{
   [SerializeField] private int _scoreValue;
   [SerializeField] private GameObject explosion;
   [SerializeField] private Gun gun;

   Health health;


   private void Awake() 
   {
      health = GetComponent<Health>();
   }

   private void OnEnable() 
   {
      health.onDeath += Kill;
   }
   
   public void CollisionEffect()
   {
      health.TakeDamage(-1);
   }

   public void Kill()
   {
      PlayerUI.Instance.UpdateScore(_scoreValue);
      AlienList.RemoveFromList(gameObject);
      Spawner.Spawn(explosion, transform.position);

      gameObject.SetActive(false);
   }

   public void Shoot()
   {
      gun.Shoot();
   }
}
