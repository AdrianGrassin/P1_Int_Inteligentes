using UnityEngine;
using StarterAssets; // Asegúrate de que este 'namespace' coincide

public class EnterExitCar : MonoBehaviour
{
    [Header("Referencias del Coche")]
    public PrometeoCarController carController;
    public GameObject carCamera;

    [Header("Referencias del Jugador")]
    // Hacemos estas referencias públicas para arrastrarlas en el Inspector
    public ThirdPersonController playerController;
    public CharacterController playerCharacterController;
    public StarterAssetsInputs playerInputScript; 
    public GameObject playerCamera;
    public UnityEngine.InputSystem.PlayerInput playerInputComponent;

    [Header("Puntos de Posición")]
    public Transform carSeatPoint;
    public Transform exitPoint;

    [Header("UI")]
    public GameObject enterCarUI;
    public GameObject playerModel;

    private bool isPlayerInside = false;
    private bool isPlayerNear = false;

    private float timeSinceLastAction = 0f;
    private const float actionCooldown = 0.5f;

    void Start()
    {
        carController.enabled = false;
        carController.isPlayerInCar = false;
        carCamera.SetActive(false);
        if (enterCarUI != null)
        {
            enterCarUI.SetActive(false);
        }
    }

    void Update()
    {
        timeSinceLastAction += Time.deltaTime;
        if (timeSinceLastAction < actionCooldown) return;

        // Usamos la variable con el nombre actualizado
        if (isPlayerInside && playerInputScript.interact)
        {
            timeSinceLastAction = 0f;
            ExitCar();
            playerInputScript.interact = false;
        }
        else if (isPlayerNear && !isPlayerInside && playerInputScript.interact)
        {
            timeSinceLastAction = 0f;
            EnterCar();
            playerInputScript.interact = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡JUGADOR DETECTADO! Ahora puedes pulsar E.");
            isPlayerNear = true;
            if (enterCarUI != null)
            {
                enterCarUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador se ha alejado.");
            isPlayerNear = false;
            if (enterCarUI != null)
            {
                enterCarUI.SetActive(false);
            }
        }
    }
    private void EnterCar()
    {
        Debug.Log("Intentando entrar al coche...");

        // PARALIZAMOS AL JUGADOR, NO LO DESACTIVAMOS
        playerController.IsControllable = false;

        // Desactivamos solo el movimiento físico y el modelo visual
        playerCharacterController.enabled = false;
        if (playerModel != null) playerModel.SetActive(false); // Usamos SetActive(false)

        // Activamos el coche
        carController.enabled = true;
        carController.isPlayerInCar = true;

        // Cambiamos cámaras
        playerCamera.SetActive(false);
        carCamera.SetActive(true);

        isPlayerInside = true;
        if (enterCarUI != null)
        {
            enterCarUI.SetActive(false);
        }
    }

    private void ExitCar()
    {
        Debug.Log("Intentando salir del coche...");

        // REACTIVAMOS EL CONTROL DEL JUGADOR
        playerController.IsControllable = true;
        if (playerModel != null) playerModel.SetActive(true); // Usamos SetActive(true)

        // Movemos el CharacterController de forma segura
        playerCharacterController.enabled = false;
        playerController.transform.position = exitPoint.position;
        playerCharacterController.enabled = true;

        // Desactivamos el coche
        carController.isPlayerInCar = false;
        carController.enabled = false;
        carController.ThrottleOff();
        carController.Brakes();

        // Cambiamos cámaras
        carCamera.SetActive(false);
        playerCamera.SetActive(true);

        isPlayerInside = false;
    }
}