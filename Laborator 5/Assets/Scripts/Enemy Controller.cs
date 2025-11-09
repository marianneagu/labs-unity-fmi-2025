using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform bulletSpawnTransform;
    [SerializeField]
    private GameObject bulletPrefab;

    [Header("Enemy Stats")]
    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private float bulletSpeed = 500f;
    [SerializeField]
    private float bulletSpawnDelay = 1f;
    [SerializeField]
    private float enemyZoneDistance = 15f;
    [SerializeField]
    private float minDistanceToPlayer = 2f;

    private Transform playerTransform;
    private Coroutine shootingCoroutine;
    private bool isPlayerInZone = false;

    private void Start()
    {
        // O functie care ne ajuta sa cautam obiecte prin tag
        // Aici o folosim in Start, ceea ce este ok, totusi mare grija ca performanta scade in general
        // cand executam algoritmi de search de genul in Update (la intervale scurte)
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Un null check recomandat, fiindca daca nu avem player-ul ca referinta nu prea putem
        // folosi acest script la nimic si evitam exceptiile de tip NullReferenceException
        if (playerTransform == null)
        {
            Debug.LogWarning("Player not assigned");
            return; // Nu face nimic daca nu gasim jucatorul
        }
            

        // Calculeaza distanta pana la jucator
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        // --- Jucatorul este IN zona ---
        if (distanceToPlayer <= enemyZoneDistance)
        {
            isPlayerInZone = true;

            // 1. Misca-te si orienteaza-te spre jucator
            // Mai intai, priveste spre jucator (dar numai pe axa Y pentru a evita "rasturnarea") - puteti schimba asta pentru a vedea side efectul
            Vector3 targetPosition = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);
            transform.LookAt(targetPosition);

            if (distanceToPlayer >= minDistanceToPlayer)
            {
                // Apoi, misca-te spre pozitia lui
                transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
            }
            

            // 2. Incepe sa tragi in jucator (doar daca nu tragi deja)
            if (shootingCoroutine == null)
            {
                shootingCoroutine = StartCoroutine(ShootCoroutine());
            }
        }
        // --- Jucatorul este IN AFARA zonei ---
        else
        {
            
            isPlayerInZone = false;

            // Opreste corutina de tragere daca ruleaza
            if (shootingCoroutine != null)
            {
                StopCoroutine(shootingCoroutine);
                shootingCoroutine = null;
            }
        }
    }

    // Corutina pentru tragerea gloantelor
    private IEnumerator ShootCoroutine()
    {
        // Aceasta bucla 'while(true)' va rula atat timp cat corutina este activa
        while (true)
        {
            Debug.Log("Instantiate bullet");
            // Creeaza un glont nou
            GameObject bulletGO = Instantiate(bulletPrefab, bulletSpawnTransform.position, bulletSpawnTransform.rotation);

            // Obtine componenta scriptului Bullet
            Bullet bulletScript = bulletGO.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                // Spune-i glontului sa traga inainte
                bulletScript.Fire(bulletSpawnTransform.forward, bulletSpeed);
            }
            else
            {
                Debug.LogError("Bullet prefab is missing the 'Bullet' script!");
            }

            // Asteapta intarzierea specificata inainte de a relua bucla
            yield return new WaitForSeconds(bulletSpawnDelay);
        }
    }

    // BONUS!
    // Aceasta functie va desena ajutoare vizuale in vizualizarea Scene (nu are niciun efect practic, e doar pentru a vizualiza)
    // Se poate vedea si in Game (doar ca debug mode, intr-un build final nu s-ar vedea) daca activati Gizmos in tabul de Game
    private void OnDrawGizmos()
    {
        // Deseneaza o sfera galbena pentru zona inamicului de tragere
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, enemyZoneDistance);

        // Deseneaza o sfera portocalie pentru distanta minima pe care trebuie sa o aiba fata de jucator
        Gizmos.color = Color.orangeRed;
        Gizmos.DrawWireSphere(transform.position, minDistanceToPlayer);

        // Deseneaza raza (linia) catre jucator
        if (playerTransform != null)
        {
            // Deseneaza o linie rosie daca jucatorul este in zona
            if (isPlayerInZone)
            {
                Gizmos.color = Color.red;
            }
            // Deseneaza o linie verde daca este in afara zonei
            else
            {
                Gizmos.color = Color.green;
            }
            Gizmos.DrawLine(transform.position, playerTransform.position);
        }
    }
}