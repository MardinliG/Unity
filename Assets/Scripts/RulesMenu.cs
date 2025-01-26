using UnityEngine;

public class RulesMenu : MonoBehaviour
{
    [SerializeField] private GameObject rulesMenu; // Vérifiez que ce champ est assigné dans l'inspector

    public void Rules() // Cette méthode sera appelée par le bouton
    {
        if (rulesMenu != null)
        {
            rulesMenu.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Rules Menu n'est pas assigné dans l'inspector !");
        }
    }

    public void Close() // Méthode pour fermer le panneau
    {
        if (rulesMenu != null)
        {
            rulesMenu.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Rules Menu n'est pas assigné dans l'inspector !");
        }
    }
}