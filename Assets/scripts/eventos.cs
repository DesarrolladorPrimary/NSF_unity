using UnityEngine;
using UnityEngine.Events;

public class eventos : MonoBehaviour
{

    [SerializeField] private UnityEvent miprimerEvento;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("jugador"))
        {
            miprimerEvento.Invoke();

        }
    }
}
