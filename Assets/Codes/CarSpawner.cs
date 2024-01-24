using UnityEngine;
using System.Collections;

public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;  
    public Transform[] spawnPoints;  
    public float spawnInterval = 8f;
    public RuntimeAnimatorController animatorController;

    private void Start()
    {
        StartCoroutine(SpawnCarRoutine());
    }

    private IEnumerator SpawnCarRoutine()
    {
        while (true)
        {
            Transform spawnPoint = GetRandomSpawnPoint();

            // Проверяем, есть ли машина на точке спауна
            if (!IsCarOnSpawnPoint(spawnPoint))
            {
                SpawnCar(spawnPoint);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
    private bool IsCarOnSpawnPoint(Transform spawnPoint)
    {
        // Находим все объекты с тегом "Car" в радиусе 1 от точки спауна
        Collider[] colliders = Physics.OverlapSphere(spawnPoint.position, 1f);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Car") && collider.gameObject != null)
            {
                return true; // Машина с тегом "Car" уже существует на точке спауна
            }
        }

        return false; // На точке спауна нет машин
    }
    private void SpawnCar(Transform spawnPoint)
    {
        // Проверяем, есть ли уже машина на точке спауна
        if (IsCarOnSpawnPoint(spawnPoint))
        {
            return;
        }

        GameObject car = Instantiate(carPrefab, spawnPoint.position, Quaternion.identity);

        car.tag = "Car";

        CarController carController = car.GetComponent<CarController>();
        if (carController == null)
        {
            carController = car.AddComponent<CarController>();
        }

        Animator animator = car.GetComponent<Animator>();
        if (animator == null)
        {
            // Добавляем компонент Animator, если его нет
            animator = car.AddComponent<Animator>();
            animator.runtimeAnimatorController = animatorController;
        }

        car.name = "Car"; // Присваиваем уникальное имя машине

        if (carController != null)
        {
            // Вызываем метод для начала анимации прихода на объекте CarController
            carController.PlayArrivalAnimation();
        }
        else
        {
            Debug.LogError("CarController component is not initialized on the car object.");
        }
    }
}
