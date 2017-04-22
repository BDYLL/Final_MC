using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class calculate : MonoBehaviour {

	//número de canales abiertos
	int m;
	//tasa de llegadas promedio
	double lambda;
	//tasa de servicio promedio en cada canal
	double mu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//La probabilidad que haya cero clientes en el sistema
	double zeroClientsInSystem(){	
		if(m*mu<lambda){
			//LLegan muchos más clientes de los que se atienden
			return 0;
		}
		double suma = 0;
		for(int n=0; n<m; n++){
			suma+= (1/factorial(n)) * Math.Pow((lambda/mu),n);
		}
		suma += (1/factorial(m)) * Math.Pow((lambda/mu),m) * (m*mu/(m*mu - lambda));
		return suma;
	}

	//Número promedio de clientes o unidades en el sistema
	double averageNumberOfClients(){
		return (lambda*mu*Math.Pow(lambda/mu,m)/(factorial(m-1) * Math.Pow(m*mu - lambda, 2))) * zeroClientsInSystem() + lambda/mu;
	}

	//El tiempo promedio que una unidad pasa en linea o recibiendo servicio en el sistema
	double averageWaitingTime(){
		return averageNumberOfClients()/lambda;
	}	

	//Número promedio de clientes que están esperando para ser atendidos
	double clientsOnLine(){
		return averageNumberOfClients() - lambda/mu;
	}

	//Tiempo promedio que un cliente pasa en cola
	double averageWaitingTimeInQueue(){
		return averageWaitingTime() - 1/mu;
	}

	//Tasa de utilización
	double utilizationRate(){
		return lambda/(m*mu);
	}


	int factorial(int x){
		int total = 1;
		for(int i=2; i<=x; i++){
			total *= i;
		}
		return total;
	}
}
