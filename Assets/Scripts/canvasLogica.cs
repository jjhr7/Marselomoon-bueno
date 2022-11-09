using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvasLogica : MonoBehaviour
{

    public Transform arcamera;
    private void Update()
    {

        float distancia = Vector3.Distance(transform.position, arcamera.position);
        print(distancia);

    }
    public void moto()
    {
        SceneManager.LoadScene("MotoScene");
    }
    public void video()
    {
        SceneManager.LoadScene("VideoScene");
    }

    public void instrucciones()
    {
        SceneManager.LoadScene("InstruccionesScene");
    }

    public void home()
    {
        SceneManager.LoadScene("SampleScene");
    }
}