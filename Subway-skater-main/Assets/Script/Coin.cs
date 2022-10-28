using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	private Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator> ();
	}

    private void OnEnable()
    {
		animator.SetTrigger("Spawn");
    }
    private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			GameManager.Instance.GetCoin ();
			animator.SetTrigger ("Collected");
			
		}
	}
}
