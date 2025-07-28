using UnityEngine;

using UnityEngine;

public class GameManagment : MonoBehaviour
{
    public static GameManagment instancia;
    int contadorHuevo;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarHuevo()
    {
        contadorHuevo++;
        Debug.Log(contadorHuevo);
    }

    public int huevo => contadorHuevo; // ← Esto es lo que necesitás
}
