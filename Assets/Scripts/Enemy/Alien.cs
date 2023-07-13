using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour, IGetEffectedOnCollision
{
   public int scoreValue;
   [SerializeField] private GameObject explosion;

   public void CollisionEffect()
   {
      Kill();
   }

   public void Kill()
   {
      AlienMaster.allAliens.Remove(gameObject); // Refactor
      Instantiate(explosion,transform.position, Quaternion.identity); // Refactor
      gameObject.SetActive(false);
   }
}
