
using UnityEngine;

public class Interactable : MonoBehaviour {
    // Start is called before the first frame update

    public float radius = 3f;

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
}
