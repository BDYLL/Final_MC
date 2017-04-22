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
		coroutine = Spawn (2.0f);
		StartCoroutine (coroutine);
		queue = new Queue<GameObject> ();
    }

	IEnumerator Spawn(float waitTime)
	{
		while (true)
		{
			yield return new WaitForSeconds(waitTime);

			GameObject people = Instantiate (character, this.transform.position, this.transform.rotation);
			cb = people.GetComponent (typeof(CharacterBehaviour)) as CharacterBehaviour;
			cb.serviceTime = Distributions.Exponential (avgServiceTime);
			queue.Enqueue (people);
		}
	}
}
