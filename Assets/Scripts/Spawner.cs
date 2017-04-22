using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject character;
	public float arrivalTime;
	public float avgServiceTime;
	public Queue<GameObject> queue;
	IEnumerator coroutine;
	private CharacterBehaviour cb;
    // Use this for initialization
    void Start () {
		double x = Distributions.Poisson(0.15);
		Debug.Log (x);
		coroutine = Spawn (10.0f);
		StartCoroutine (coroutine);
    }
	
	IEnumerator Spawn(float waitTime)
	{
		while (true)
		{
			yield return new WaitForSeconds(waitTime);

			GameObject people = Instantiate (character, transform.position, transform.rotation);
			cb = people.GetComponent (typeof(CharacterBehaviour)) as CharacterBehaviour;
			cb.serviceTime = Distributions.Exponential (avgServiceTime);
			queue.Enqueue (people);
		}
	}
}
