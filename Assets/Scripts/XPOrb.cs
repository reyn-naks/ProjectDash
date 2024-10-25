using UnityEngine;

public class XPOrb : MonoBehaviour
{
    [HideInInspector]
    public float XPAmount = 1f;
    [SerializeField]
    float speed = 20f;
    private Vector3 target;
    bool move = false;

    private void Update() {
        if (move){
            var step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("PlayerField")){
            target = other.transform.position;
            move = true;
        }
        if(other.gameObject.CompareTag("Player")){
            //Debug.Log("Player get "+ XPAmount + "XP");
            GameManager.ModifyExperience(XPAmount);
            Destroy(gameObject);
        }
    }

}
