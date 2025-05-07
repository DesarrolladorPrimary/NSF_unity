using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;



public class time : MonoBehaviour
{

    [SerializeField] private UnityEvent tiemposeAcabo, ganar;
    public float timeStart;
    public Text textBox;

    bool timeActive = true;





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textBox.text = timeStart.ToString("F2");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeActive) {
            timeStart -= Time.deltaTime;
            textBox.text = timeStart.ToString("F2");

        }

        if (timeStart <= 0) { 
        
            tiemposeAcabo.Invoke();
        }
    }


    public void pausarTiempo()
    {
        timeActive = !timeActive;
    }

    public void comprobar()
    {
        if(timeStart >= 0)
        {
            ganar.Invoke();
        }
    }


}
