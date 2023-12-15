using System.Collections;
using UnityEngine;

public class Monster4 : MonoBehaviour
{
    public static float globalMoveSpeed = 5.0f;
    private static float lastTeleportTime = 0.0f;
    private UnityEngine.Transform player;
    public GameObject teleportPrefab;
    private void ActivateMonster()
    {
        // Activa el monstruo y establece la dirección inicial
        gameObject.SetActive(true);
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameObject.SetActive(false);
        Invoke("ActivateMonster", 14.0f);
    }

    private void Update()
    {
        if (player != null)
        {
            if (Time.time - lastTeleportTime >= 5.0f)
            {
                StartCoroutine(TeleportSequence());
                lastTeleportTime = Time.time;
            }

            Vector3 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * globalMoveSpeed * Time.deltaTime);
        }
    }

    private IEnumerator TeleportSequence()
    {
        // Guarda las coordenadas antes del teleport
        Vector3 monsterPositionBeforeTeleport = transform.position;

        // Instancia el prefab de Teleport en las coordenadas originales del monstruo
        GameObject teleportEffectBeforeTeleport = Instantiate(teleportPrefab, monsterPositionBeforeTeleport, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);

        TeleportToPlayerWithRandomOffset();

        // Instancia el prefab de Teleport en las nuevas coordenadas del monstruo
        GameObject teleportEffectAfterTeleport = Instantiate(teleportPrefab, transform.position, Quaternion.identity);

        Destroy(teleportEffectBeforeTeleport);
        yield return new WaitForSeconds(0.5f);

        // Desactiva el monstruo para que no aparezca en ambas posiciones al mismo tiempo
        gameObject.SetActive(false);

        Destroy(teleportEffectAfterTeleport);
        // Activa el monstruo después del segundo efecto de Teleport
        gameObject.SetActive(true);
    }

    private void TeleportToPlayerWithRandomOffset()
    {
        float randomXOffset = UnityEngine.Random.Range(-10.0f, 10.0f);
        float randomYOffset = UnityEngine.Random.Range(-10.0f, 10.0f);

        Vector3 playerPositionWithOffset = new Vector3(player.position.x + randomXOffset, player.position.y + randomYOffset, player.position.z);

        transform.position = playerPositionWithOffset;
    }

    public static void IncreaseGlobalSpeed()
    {
        globalMoveSpeed += 2;
    }

    public static void DecreaseGlobalSpeed()
    {
        globalMoveSpeed -= 1;
    }
}
