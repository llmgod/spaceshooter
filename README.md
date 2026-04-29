<div align="center">
  <br>
  <img src="https://raw.githubusercontent.com/AnatolyPak/AnatolyPak/main/bat-pixel.gif" width="60" onerror="this.src='https://raw.githubusercontent.com/Tarikul-Islam-Anik/Animated-Fluent-Emojis/master/Emojis/Animals/Bat.png'" />
  <br><br>
  
  <a href="https://git.io/typing-svg">
    <img src="https://readme-typing-svg.demolab.com?font=Cinzel+Decorative&weight=700&size=42&duration=4000&pause=1000&color=FFFFFF&center=true&vCenter=true&width=900&lines=🌑+SPACE+SHOOTER+🌑;SYMPHONY+OF+THE+VOID;DIPLOMA+PROJECT+2025" alt="Space Shooter Typing SVG" />
  </a>

  <br>
  <img src="https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/white.gif" width="100%" />
  <br><br>
</div>

## 🎓 Академический статус и признание

> **Данный программный комплекс является выпускной квалификационной работой.**
> 
> Проект был успешно защищен в **Компьютерной Академии ТОП** по специальности **«Разработка программного обеспечения»** в 2025 году. По решению аттестационной комиссии работа получила **высший балл** и была отмечена как выдающийся образец программной реализации игровых механик.

<br>
<div align="center">
  <img src="https://raw.githubusercontent.com/AnatolyPak/AnatolyPak/main/bats-flying.gif" width="150" />
</div>
<br>

## 📜 Расширенное описание концепции

**Space Shooter: Symphony of the Void** — это высокотехнологичная реализация 2D-аркады, созданная в среде Unity. Проект демонстрирует применение продвинутых паттернов проектирования и асинхронных операций.

### Основные векторы разработки:
* **Нарративные ветки:** В игровой цикл интегрирована система текстовых сценариев, решения в которых напрямую влияют на дальнейший игровой процесс.
* **Управление ресурсами:** Реализована механика экстренного уклонения (рывка), потребляющая ресурс **энергии**, что требует от игрока стратегического контроля запасов.

<br>
<div align="center">
  <img src="https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/white.gif" width="80%" />
</div>
<br>

## ⚔️ Техническая экспертиза (Core Mechanics)

#### 💠 Система иерархической деструкции (Meteor System)
Вместо удаления объектов при попадании, реализован алгоритм каскадного дробления:
* Уничтожение крупных объектов инициирует генерацию дочерних элементов меньшего радиуса.
* Объекты классифицированы на четыре типа: от «Big» до «Tiny».
* Процесс разрушения сопровождается динамической тряской камеры различной интенсивности.

#### 💠 Прогрессивная сложность и спавн
* **EnemySpawner:** Контролирует лимит активных врагов и динамически повышает сложность в зависимости от количества уничтоженных целей.
* **Боевая система:** Продвинутые противники используют веерный огонь лазерами с расчетом углового смещения снарядов.

<br>
<div align="center">
  <img src="https://raw.githubusercontent.com/AnatolyPak/AnatolyPak/main/bat-hanging.gif" width="80" />
</div>
<br>

## 🛠 Архитектура и Стек

Проект построен на принципах **SOLID** и демонстрирует владение продвинутыми техниками C#:
* **Наследование:** Базовый класс `Enemy` инкапсулирует фундаментальную логику здоровья и коллизий.
* **Оптимизация:** Применение сопрограмм (Coroutines) для распределения вычислительной нагрузки при расчете стрельбы и спавна.
* **Event-Driven:** Генерация событий смерти через `UnityEvent OnDead` для снижения связанности кода.

<br>

```text
space-shooter-project/
├── 📂 Assets
│   ├── 📂 Scripts
│   │   ├── 📄 Enemy.cs           # Базовый абстрактный класс
│   │   ├── 📄 EnemySpawner.cs    # Логика прогрессивного спавна
│   │   ├── 📄 Meteor.cs         # Алгоритм дробления объектов
│   │   └── 📄 EasyEnemy.cs      # Реализация паттернов атаки
│   ├── 📂 Prefabs               # Игровые префабы
│   └── 📂 Scenes                # Сцена "The Void"
└── 📄 README.md
