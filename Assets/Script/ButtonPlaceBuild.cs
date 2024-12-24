using UnityEngine;

public class ButtonPlaceBiuld: MonoBehaviour
{
    public int damage = 20;
    public GameObject building;
    public void PlaceBuild()
        { 
            Instantiate(building,Vector3.zero, Quaternion.identity);
        }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Player"))
        {
            CarAttack attack = other.GetComponent<CarAttack>();
            attack._health -= damage;
            if(attack._health <= 0)
                Destroy(other.gameObject);
        }
    }
}