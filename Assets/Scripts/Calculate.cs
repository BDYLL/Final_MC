using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Calculate{

	//número de canales abiertos
	private int m;
	//tasa de llegadas promedio
	private double lambda;
	//tasa de servicio promedio en cada canal
	private double mu;

	public Calculate(int m, double lambda, double mu){
		this.m = m;
		this.lambda = lambda;
		this.mu = mu;

		Debug.Log(zeroClientsInSystem());
		Debug.Log(averageNumberOfClients());
		Debug.Log(averageWaitingTime());
		Debug.Log(clientsOnLine());
		Debug.Log(averageWaitingTimeInQueue());
		Debug.Log(utilizationRate());
	}

	//La probabilidad que haya cero clientes en el sistema
	public double zeroClientsInSystem(){	
		if(m*mu<lambda){
			//LLegan muchos más clientes de los que se atienden
			return 0;
		}
		double suma = 0;
		for(int n=0; n<=m-1; n++){
			suma+= (1/factorial(n)) * Math.Pow((lambda/mu),n);
		}
		suma += (1/factorial(m)) * Math.Pow((lambda/mu),m) * ((m*mu)/(m*mu - lambda));
		return 1/suma;
	}

	//Número promedio de clientes o unidades en el sistema
	public double averageNumberOfClients(){
		return (lambda*mu*Math.Pow(lambda/mu,m)/(factorial(m-1) * Math.Pow(m*mu - lambda, 2))) * zeroClientsInSystem() + lambda/mu;
	}

	//El tiempo promedio que una unidad pasa en linea o recibiendo servicio en el sistema
	public double averageWaitingTime(){
		return averageNumberOfClients()/lambda;
	}	

	//Número promedio de clientes que están esperando para ser atendidos
	public double clientsOnLine(){
		return averageNumberOfClients() - lambda/mu;
	}

	//Tiempo promedio que un cliente pasa en cola
	public double averageWaitingTimeInQueue(){
		return averageWaitingTime() - 1/mu;
	}

	//Tasa de utilización
	public double utilizationRate(){
		return lambda/(m*mu);
	}


	public int factorial(int x){
		int total = 1;
		for(int i=2; i<=x; i++){
			total *= i;
		}
		return total;
	}
}
