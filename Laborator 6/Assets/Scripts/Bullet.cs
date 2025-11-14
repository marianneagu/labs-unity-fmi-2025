using UnityEngine;

// Adauga o componenta Rigidbody ca dependinta
// Daca se adauga doar scriptul ca componenta, componenta de Rigidbody
// va fi adaugata automat
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        // Obtine referinta la componenta Rigidbody de pe obiectul pe care e atasat scriptul
        rb = GetComponent<Rigidbody>();
    }

    // Aceasta metoda publica va fi apelata de EnemyController pentru a trage glontul
    public void Fire(Vector3 direction, float speed)
    {
        // Adauga o forta obiectului (tipul de forta e optional, dar eu am pus Impulse
        // fiindca pare mai potrivita pentru un glont)
        rb.AddForce(direction * speed, ForceMode.Impulse);

        // In functia de Destroy putem pune optional si un float care reprzinta timpul (in sec) dupa care dorim sa 
        // distrugem un obiect dupa instantierea acestuia in scena

        // Practic, in acest caz, se da destroy la instanta dupa 5 secunde in caz ca nu loveste nimic
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica daca obiectul pe care l-am lovit are tagul "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Bullet hit the Player!");
            // Doar cand atinge player-ul scadem viata
            HealthManager.Instance.GetDamage();
        }

        // Distrugem glontul la orice coliziune (cu orice obiect, nu numai Player-ul)
        Destroy(gameObject);
    }
}