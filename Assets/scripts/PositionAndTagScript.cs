using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Vector3 position;
    private string etiqueta;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        etiqueta = gameObject.tag;
        position = transform.position;

        Debug.Log("Tag: " + etiqueta + "\n" + "Position: " + position);
        }

        // Update is called once per frame
        void Update()
        {
        
        }
}
