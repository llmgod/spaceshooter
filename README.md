<div align="center">
  <br>
  <img src="https://raw.githubusercontent.com/Tarikul-Islam-Anik/Animated-Fluent-Emojis/master/Emojis/Animals/Bat.png" width="100" />
  <br><br>
  
  <a href="https://git.io/typing-svg">
    <img src="https://readme-typing-svg.demolab.com?font=Cinzel+Decorative&weight=700&size=40&duration=4000&pause=1000&color=FFFFFF&center=true&vCenter=true&width=800&lines=SPACE+SHOOTER;SYMPHONY+OF+THE+VOID;DIPLOMA+PROJECT+2025" alt="Space Shooter Typing SVG" />
  </a>

  <br>
  <img src="https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/white.gif" width="100%" />
  <br><br>
</div>

### 🎓 Академический статус
> **Данный программный комплекс является выпускной квалификационной работой.**
> 
> Проект успешно защищен в **Компьютерной Академии ТОП** по специальности **«Разработка программного обеспечения»** в 2025 году. По результатам аттестации работа удостоена **высшей оценки** и получила признание комиссии как проект с исключительным качеством программной архитектуры и глубиной проработки игровых систем.

<br><br>

## 🌌 Архитектура контроллера игрока (Player Core)

Программная реализация игрока (`Player.cs`) построена на принципах инкапсуляции и обработки физических взаимодействий в реальном времени. Основные системы включают:

* **Модульная система способностей:** Использование специализированных объектов `Powerup` для управления состоянием стрельбы, щита и множителя очков.
* **Интерфейс состояния (UI Integration):** Динамическое обновление полос здоровья (`HealthBar`) и энергии (`UltaBar`) через прямое взаимодействие со слайдерами Unity.
* **Обработка коллизий:** Комплексная система фильтрации триггеров, различающая типы угроз (Enemy, Meteor, Laser) и применяющая соответствующие модификаторы здоровья и тряски камеры.

<br>
<div align="center">
  <img src="https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/white.gif" width="70%" />
</div>
<br>

## ⚔️ Ключевые программные механики

#### 💠 Искажение Пространства (Dodge System)
Реализована через корутину `Dodge()`, которая на короткое время кратно увеличивает скорость перемещения (`DodgeSpeed`) и активирует режим неуязвимости.
* **Затраты:** Активация рывка полностью обнуляет запас энергии (`Energy`).
* **Регенерация:** Восстановление энергии происходит автоматически через заданный интервал задержки (`energyRecoveryDelay`).

#### 💠 Прогрессивное вооружение (Multi-level Combat)
Система стрельбы динамически меняет паттерн атаки в зависимости от уровня прокачки:
* **Level 1-3:** Переход от одиночного луча к веерным залпам (до 7 лазеров за один цикл), рассчитанных через угловое смещение.

#### 💠 Энергетическое поле (Shielding)
Реализация щита поддерживает несколько уровней прочности (от 1 до 10 единиц емкости). Щит визуально отображается на сцене и блокирует входящий урон до полного истощения заряда.

<br>
<div align="center">
  <img src="https://readme-typing-svg.demolab.com?font=Cinzel+Decorative&weight=600&size=24&duration=3500&pause=2000&color=FFFFFF&center=true&vCenter=true&width=600&lines=CORE+SYSTEMS+STABLE;DIPLOMA+EVALUATION:+EXCELLENT" alt="Sub-header SVG" />
</div>
<br>

## 🛠 Стек технологий и паттерны
* **Среда разработки:** Unity Engine.
* **Язык программирования:** C#.
* **Использованные инструменты:** Coroutines для асинхронных действий, UnityEvents для событийно-ориентированной логики смерти, и Singleton для глобального доступа к системе счета (`Score.Instance`).

<br><br>

## 📂 Структура проекта
```text
space-shooter-project/
├── 📂 Assets
│   ├── 📂 Scripts
│   │   ├── 📄 Player.cs         # Основной контроллер игрока
│   │   ├── 📄 Enemy.cs          # Базовый класс врагов
│   │   ├── 📄 Meteorspauner.cs  # Менеджер разрушаемых тел
│   │   └── 📄 Score.cs          # Система учета прогресса
│   ├── 📂 Prefabs               # Префабы (Laser, Explosion, UI)
│   └── 📂 Scenes                # Основная игровая сцена
└── 📄 README.md
