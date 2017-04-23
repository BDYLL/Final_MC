using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject[] characters;
	public float arrivalTime;
	public float avgServiceTime;
	public Queue<GameObject> queue;
	IEnumerator coroutine;
	private CharacterBehaviour cb;
    // Use this for initialization
    void Start () {
		double x = Distributions.Poisson(arrivalTime);
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
			Debug.Log (Distributions.Poisson (arrivalTime));

			GameObject people = Instantiate (characters[(int)(Random.Range(0.0f, 4.0f))], this.transform.position, this.transform.rotation);
			cb = people.GetComponent (typeof(CharacterBehaviour)) as CharacterBehaviour;
			cb.serviceTime = Distributions.Exponential (avgServiceTime);
			queue.Enqueue (people);	
		}
	}
}
