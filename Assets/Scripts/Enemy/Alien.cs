using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour, IGetEffectedOnCollision
{
   [SerializeField] private int _scoreValue;
   [SerializeField] private GameObject explosion;
   [SerializeField] private Gun gun;

   public event Action onDeath;

   public void CollisionEffect()
   {
      Kill();
   }

   public void Kill()
   {
      AlienList.RemoveFromList(gameObject);
      Spawner.Spawn(explosion, transform.position);
      onDeath?.Invoke();
      gameObject.SetActive(false);
   }

   public void Shoot()
   {
      gun.Shoot();
   }
}
