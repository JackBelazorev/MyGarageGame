using UnityEngine;
using System.Collections;

public class CarManager : MonoBehaviour
{
    public GameObject carPrefab; // Префаб вашей машины
    public Transform spawnPoint; // Точка спауна машины
    public Transform waitingPoint; // Точка ожидания действия от игрока
    public Transform leavingPoint; // Точка для анимации ухода

    public float spawnInterval = 10f; // Интервал спауна машины

    private Animator carAnimator;
    private bool isPlayerActionDone = false; // Флаг, указывающий, выполнено ли действие игрока

    void Start()
    {
        carAnimator = Instantiate(carPrefab, spawnPoint.position, Quaternion.identity).GetComponent<Animator>();
        InvokeRepeating("SpawnCar", 0f, spawnInterval);
    }

    void Update()
    {
        // Проверяем, выполнено ли действие игрока
        if (isPlayerActionDone)
        {
            // Запускаем анимацию ухода после выполнения действия игрока
            carAnimator.SetTrigger("LeaveTrigger");
            isPlayerActionDone = false; // Сбрасываем флаг
        }
    }

    void SpawnCar()
    {
        // Проверяем, нет ли другой машины на точке ожидания
        if (!Physics.Raycast(waitingPoint.position, Vector3.forward, 1f))
        {
            // Запускаем анимацию прихода
            carAnimator.SetTrigger("ArriveTrigger");

            // Ожидаем действия игрока (в вашем случае, когда он подойдет к машине)
            // Вам нужно реализовать свой механизм ожидания действия игрока

            // После выполнения действия игрока, устанавливаем флаг
            isPlayerActionDone = true;
        }
    }
}
