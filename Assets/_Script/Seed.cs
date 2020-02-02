using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Seed 
{
	private static int _value;

	public static int Value
	{
		get { 
			return _value; 
		}
		set {
			if (value < 0)
				value = 0;
			_value = value;
		}
	}

}
