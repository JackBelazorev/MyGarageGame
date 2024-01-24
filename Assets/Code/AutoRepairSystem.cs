// using UnityEngine;

// public class AutoRepairSystem : MonoBehaviour
// {
//     public float repairTime = 10f;  // Время автоматической чинки в секундах
//     public int repairLevel = 1;     // Уровень чинки, который даёт машина

//     private float timer = 0f;
//     private bool isRepairing = false;

//     private void Update()
//     {
//         if (isRepairing)
//         {
//             timer -= Time.deltaTime;

//             if (timer <= 0)
//             {
//                 // Машина автоматически чинится
//                 Repair();
//             }
//         }
//     }

//     public void StartAutoRepair()
//     {
//         if (!isRepairing)
//         {
//             timer = repairTime;
//             isRepairing = true;
//         }
//     }

//     private void Repair()
//     {
//         // Добавьте здесь код для чинки машины
//         // Например, увеличение опыта игрока и уровня машины

//         // Пример увеличения уровня игрока
//         LevelSystem levelSystem = FindObjectOfType<LevelSystem>();
//         if (levelSystem != null)
//         {
//             levelSystem.GainExperience(repairLevel * 10);  // Пример: каждый уровень машины дает 10 опыта
//         }

//         // Завершаем процесс чинки
//         isRepairing = false;
//     }
// }
