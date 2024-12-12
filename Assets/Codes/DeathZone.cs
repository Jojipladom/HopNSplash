using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathZone : MonoBehaviour

{
 public Transform respawnPoint;
 public GameObject Player;
 
 private void OnTriggerEnter2D(Collider2D other)
 {
  if (other.gameObject.CompareTag("Player"))
  {
   other.gameObject.SetActive(false);
  }
  
  if (other.gameObject.CompareTag("Player"))
  {
   Player.transform.position = respawnPoint.position;
   other.gameObject.SetActive(true);
  }
 }
}
