using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoCannon : MonoBehaviour
{
    //script que hace que dispare misiles esta waina

    [SerializeField]
    public GameObject _bullet; // bala
    [SerializeField]
    private Transform bulletPointInstance;
    [SerializeField]
    private float _timer = 2f; // tiempo de disparo cada 2 segundos
    //private float timeCount = 0f; // 

    
    private int _counter; //numero de disparos del bucle
    [SerializeField]
    private int _maxCounter = 20; // max de disparon que puede hacer


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DispararMisiles());
    }

    IEnumerator DispararMisiles() // metodo courutine
    {
        Debug.Log("inicio courutine");
        for(int i= 0; i<_maxCounter; i++) //bucle pa instanciar un num x de misiles
        {
            _counter++; // 1++
            Instantiate(_bullet, bulletPointInstance.position, bulletPointInstance.rotation); //instanciar misil
            yield return new WaitForSeconds(_timer); // espera el tiempo que le ponemos y sale
        }
        Debug.Log("fin courutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
