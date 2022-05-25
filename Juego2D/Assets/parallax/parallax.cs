using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour 
{

[SerializeField] float velocidad;
[SerializeField] float anchoImg;
Vector3 posInicial;
float resto;

	void Start () 
	
	{
		posInicial = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{

	resto = Mathf.Repeat(velocidad * Time.time, anchoImg);
	transform.position = posInicial + resto * Vector3.left;
	
	}
}

