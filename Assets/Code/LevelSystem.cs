// using UnityEngine;
// using UnityEngine.UI;

// public class LevelSystem : MonoBehaviour
// {
//     public Slider levelBar;  // Ссылка на вашу Level bar (Slider) в Unity

//     private int currentLevel = 1;
//     private int experience;
//     private int experienceToNextLevel;
//   // Количество опыта для перехода на следующий уровень

//     private void Start()
//     {
//         UpdateLevelBar();
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Cube"))  // Замените "LevelObject" тегом вашего объекта
//         {
//             GainExperience(100);  // Увеличиваем опыт при касании объекта. Измените это значение по своему усмотрению.
//             UpdateLevelBar();
//         }
//     }

//     public void GainExperience(int amount)
//     {
//         experience += amount;

//         while (experience >= experienceToNextLevel)
//         {
//             LevelUp();
//         }
//     }

//     private void LevelUp()
//     {
//         currentLevel++;
//         experience -= experienceToNextLevel;
//         experienceToNextLevel = CalculateExperienceForNextLevel();
//     }

//     private int CalculateExperienceForNextLevel()
//     {
//         // Ваш способ расчета опыта для следующего уровня
//         return currentLevel * 100;
//     }

//     private void UpdateLevelBar()
//     {
//         levelBar.value = (float)experience / experienceToNextLevel;
//     }
// }
