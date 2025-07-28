using UnityEngine;
using UnityEngine.UIElements;

public class InventarioControlUI : MonoBehaviour
{
    private Label labelHuevos;
    private int huevosPrevios = -1;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        labelHuevos = root.Q<Label>("labelHuevos");
    }

    void Update()
    {
        if (GameManagment.instancia.huevo != huevosPrevios)
        {
            huevosPrevios = GameManagment.instancia.huevo;
            labelHuevos.text = $"Huevos: {huevosPrevios}";
        }
    }
}
