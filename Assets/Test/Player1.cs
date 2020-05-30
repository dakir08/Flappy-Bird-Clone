
using UnityEngine;

public class Player1 : MonoBehaviour {

    public Transform hitPoint;
    public float hitPointArea;
    public LayerMask whatisEnemy;
    public GameObject effect;
    Rigidbody2D rb;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            // Debug.Log("?");
            RaycastHit2D hitInfo = Physics2D.Raycast(hitPoint.position, Vector2.right, 100f, whatisEnemy);
            Debug.Log(hitInfo.transform.name);
            effect.SetActive(true);
        }
        Debug.DrawRay(hitPoint.position, Vector2.right * 100f, Color.green);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.DrawWireSphere(hitPoint.position, hitPointArea);
    }
}

//Rigidbody chỉ nên dùng khi nào ông dùng physic