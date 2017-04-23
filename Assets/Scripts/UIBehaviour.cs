using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;
using UnityEngine.SceneManagement;

public class UIBehaviour : MonoBehaviour {
    
    
    //Valores de Resultado Esperado Text
    private Text CeroClientesValueREText;
    private Text ClientesSistemaValueREText;
    private Text TiempoSistemaValueREText;
    private Text TasaUtilValueREText;
    private Text TiempoColaValueREText;
    private Text ClientesColaValueREText;
    //valores de Estado Actual Text
    private Text CeroClientesValueEAText;
    private Text ClientesSistemaValueEAText;
    private Text TiempoSistemaValueEAText;
    private Text TasaUtilValueEAText;
    private Text TiempoColaValueEAText;
    private Text ClientesColaValueEAText;
    //Valores de Entrada
    private int m;
    private double mu;
    private double lamda;

    void Start()
    {
        //Valores de Resultado Esperado Text
        CeroClientesValueREText = GameObject.Find("CeroClientesValueRE").GetComponent<Text>();
        ClientesSistemaValueREText = GameObject.Find("ClientesSistemaValueRE").GetComponent<Text>();
        TiempoSistemaValueREText = GameObject.Find("TiempoSistemaValueRE").GetComponent<Text>();
        TasaUtilValueREText = GameObject.Find("TasaUtilValueRE").GetComponent<Text>();
        TiempoColaValueREText = GameObject.Find("TiempoColaValueRE").GetComponent<Text>();
        ClientesColaValueREText = GameObject.Find("ClientesColaValueRE").GetComponent<Text>();
        //valores de Estado Actual Text
        CeroClientesValueEAText = GameObject.Find("CeroClientesValueEA").GetComponent<Text>();
        ClientesSistemaValueEAText = GameObject.Find("ClientesSistemaValueEA").GetComponent<Text>();
        TiempoSistemaValueEAText = GameObject.Find("TiempoSistemaValueEA").GetComponent<Text>();
        TasaUtilValueEAText = GameObject.Find("TasaUtilValueEA").GetComponent<Text>();
        TiempoColaValueEAText = GameObject.Find("TiempoColaValueEA").GetComponent<Text>();
        ClientesColaValueEAText = GameObject.Find("ClientesColaValueEA").GetComponent<Text>();
        m = -1;
        mu = lamda = -1.0f;
        played = paused =  false;
    }
   
    //metodos
    public void limitInteger()
    {
        
        int fieldValue;

        InputField text = GameObject.Find("InputNumCanales").GetComponent<InputField>();
        if(text.text.Length == 0)
        {
            return;
        }
        fieldValue = Int32.Parse(text.text);
        if (fieldValue < 2 || fieldValue > 8)
        {
            EditorUtility.DisplayDialog("Error en la entrada de datos", "Para que este simulador funcione necesita ingresar un valor [2,8]", "Ok");
            if(m < 0)
            {
                text.text = "2";
                m = 2;
            }else
            {
                text.text = m + "";
            }
        }else
        {
            m = fieldValue;
        }
       
    }

    public void greaterthanZero(bool isMu)
    {
        double fieldValue;
        InputField text = isMu ? GameObject.Find("InputTasaServicio").GetComponent<InputField>() : GameObject.Find("InputTasaLlegada").GetComponent<InputField>();
        if (text.text.Length == 0)
        {
            return;
        }
        fieldValue = Double.Parse(text.text);  
        if (fieldValue <= 0.0f)
        {
            EditorUtility.DisplayDialog("Error en la entrada de datos", "Para que este simulador funcione necesita ingresar un valor > 0", "Ok");
            if (isMu)
            {
                if (mu < 0)
                {
                    text.text = "1";
                    mu = 1.0f;
                }
                else
                {
                    text.text = mu + "";
                }
            }
            else
            {
                if (lamda < 0)
                {
                    text.text = "1";
                    lamda = 1.0f;
                }
                else
                {
                    text.text = lamda + "";
                }
            }

        }else
        {
            if (isMu)
            {
                mu = fieldValue;
            }else
            {
                lamda = fieldValue;
            }
        }
    }

    public void showResults()
    {
        Debug.Log("m = " + m + ", lamda = " + lamda + ", mu = " + mu);
        Calculate results = new Calculate(m, lamda, mu);
        CeroClientesValueREText.text = results.zeroClientsInSystem() + "";
        ClientesSistemaValueREText.text = results.averageNumberOfClients() + "";
        TiempoSistemaValueREText.text = results.averageWaitingTime() + "";
        TasaUtilValueREText.text = results.utilizationRate() + "";
        TiempoColaValueREText.text = results.averageWaitingTimeInQueue() + "";
        ClientesColaValueREText.text = results.clientsOnLine() + "";
    }

    private bool played;
    public void playSimulator()
    {
        if (!played)
        {
            if (m > 0 && lamda > 0 && mu > 0)
            {
                showResults();
            }
            else
            {
                EditorUtility.DisplayDialog("Error en la entrada de datos", "Para que este simulador necesita llenar todos los campos", "Ok");

            }
            played = true;
        }
        
    }

    private bool paused;
    public void pauseSimulator()
    {
        if (played)
        {
            Time.timeScale = paused ? 1 : 0;
            paused = !paused;
        }
        
    }

    public void restart()
    {
        SceneManager.LoadScene("test");
    }
}
