using UnityEngine;

public class sTouchManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Mascot"))
                {
                    hit.collider.GetComponent<sMascotController>().MascotTouched();
                }
            }
        }

        //Following If Statement is only to check the functionality on Computer
#if UNITY_EDITOR
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Mascot"))
                {
                    hit.collider.GetComponent<sMascotController>().MascotTouched();
                }
            }
        }

#endif
        
    }
}
