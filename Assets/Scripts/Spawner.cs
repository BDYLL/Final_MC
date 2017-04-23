using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject[] characters;
	public float arrivalTime;
	public float avgServiceTime;
	public float interval;
	public Queue<GameObject> queue;
	private int counter, times;
	IEnumerator coroutine;
	private CharacterBehaviour cb;
	private float rep;
    // Use this for initialization
    void Start () {
		double x = Distributions.Poisson(arrivalTime);
		Debug.Log (x);
		coroutine = Spawn (interval);
		StartCoroutine (coroutine);
		queue = new Queue<GameObject> ();
		counter = 0;
    }


	public void createPerson(){
		if(counter++ < times){
			GameObject people = Instantiate (characters[(int)(Random.Range(0.0f, 4.0f))], this.transform.position, this.transform.rotation);
			cb = people.GetComponent (typeof(CharacterBehaviour)) as CharacterBehaviour;
			cb.serviceTime = Distributions.Exponential (avgServiceTime);
			queue.Enqueue (people);	
		}
		CancelInvoke ();
		counter = 0;
	}

	IEnumerator Spawn(float waitTime)
	{
		while (true)
		{
			yield return new WaitForSeconds(waitTime);
			times = (int) Distributions.Poisson (arrivalTime);
			rep = interval / times;
			Debug.Log (times);
			InvokeRepeating ("createPerson", 0.0f, rep);

		}
	}
}
