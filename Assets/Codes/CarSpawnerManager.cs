using UnityEngine;

public class CarSpawnerManager : MonoBehaviour
{
    public static CarSpawnerManager Instance;

    public Transform[] spawnPoints;
    private bool[] spawnPointsOccupied;

    void Awake()
    {
        Instance = this;
        // Инициализируем массив для отслеживания состояния точек спауна
        spawnPointsOccupied = new bool[spawnPoints.Length];
    }

    public void OnCarArrived(GameObject car)
    {
        // Определите, на какой точке спауна находится пришедшая машина
        int spawnPointIndex = GetSpawnPointIndex(car.transform.position);

        // Пометьте точку спауна как занятую
        spawnPointsOccupied[spawnPointIndex] = true;

        // Вызовите метод для начала анимации прихода на объекте CarController
        CarController carController = car.GetComponent<CarController>();
        if (carController != null)
        {
            //carController.PlayArrivalAnimation();
        }

        // Можете сделать дополнительные действия для занятой точки спауна, если нужно
    }

    public void OnCarLeft(GameObject car)
    {
        // Освободите точку спауна при уходе машины
        int spawnPointIndex = GetSpawnPointIndex(car.transform.position);
        spawnPointsOccupied[spawnPointIndex] = false;
    }

    private int GetSpawnPointIndex(Vector3 position)
    {
        // Реализуйте логику поиска индекса точки спауна на основе её положения
        // Здесь предполагается, что у вас есть массив точек спауна spawnPoints
        // и вы находите ближайшую точку спауна по расстоянию

        int closestIndex = 0;
        float closestDistance = float.MaxValue;

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            float distance = Vector3.Distance(position, spawnPoints[i].position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestIndex = i;
            }
        }

        return closestIndex;
    }

    // Добавьте методы для проверки доступности точек спауна и т.д., если необходимо
}
