using System.Collections;
using System.Collections.Generic;
using System;
public class Distributions{

	private Distributions(){}

	public static double Poisson(double lambda){
		if (lambda <= 0.0) throw new ArgumentException ();
		double l = Math.Exp (-lambda);
		double k = 0.0;
		double p = 1.0;


		Random r = new Random ();

		while (p > l) {
			k += 1.0;
			p=p*r.NextDouble ();
		}

		return k;
	}

	public static double Exponential(double rate){
		if (rate <= 0.0) throw new ArgumentException ();
		double r = new Random ().NextDouble ();
		return Math.Log (1 - r) / (-rate);
	}
}
