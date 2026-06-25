# 🎮 ПОШАГОВАЯ ИНСТРУКЦИЯ - ЧТО ДЕЛАТЬ В UNITY

## ✅ ЧТО ИСПРАВЛЕНО В КОДЕ:

1. **Физика игры** - теперь легче играть
   - Гравитация увеличена до -15 (быстрее падает)
   - Сила прыжка уменьшена до 5.5 (не взлетает слишком высоко)
   - Промежутки между трубами увеличены (от -0.8 до 0.8 вместо -1.34 до 1.03)

2. **Счет очков** - теперь работает правильно
   - Добавлен ScoreTrigger.cs для подсчета
   - Исправлена проверка триггеров

3. **Визуал** - добавлены новые скрипты для красоты:
   - ModernUIStyle.cs - современный стиль UI
   - EnhancedDeathScreen.cs - красивый экран смерти с анимациями
   - EnhancedStartScreen.cs - анимированное главное меню
   - ParallaxBackground.cs - движущийся фон

---

## 📝 ЧТО НУЖНО СДЕЛАТЬ В UNITY:

### ШАГ 1: Настроить Pipes (Трубы)

1. В Project найди **Assets → Prefabs → Pipes**
2. Двойной клик по **Pipes.prefab** (откроется prefab)
3. В Hierarchy найди внутри Pipes дочерний объект с Trigger Collider (между трубами)
4. Если такого нет, создай:
   - Правый клик на Pipes → Create Empty
   - Назови "ScoreTrigger"
   - Add Component → Box Collider 2D
   - Поставь галочку **Is Trigger** ✓
   - Размер коллайдера: X = 0.5, Y = 5 (вертикальная зона между трубами)
   - Position: X = 0, Y = 0 (по центру между трубами)
5. На этот объект "ScoreTrigger":
   - Add Component → **ScoreTrigger** (наш новый скрипт)
6. Сохрани prefab (Ctrl+S)

### ШАГ 2: Настроить Player (Птичку)

1. В Hierarchy найди объект птички (Flappy Bird)
2. Проверь что у него есть:
   - Tag = "Player" (вверху Inspector)
   - Rigidbody2D (если нет - Add Component)
   - Collider2D (если нет - Add Component → Circle Collider 2D)
3. В Rigidbody2D:
   - Gravity Scale = 1
   - Mass = 1

### ШАГ 3: Улучшить StartScreen (Главное меню)

1. В Hierarchy найди **StartScreenCanvas**
2. Выбери его и в Inspector:
   - Add Component → **EnhancedStartScreen**
   - Add Component → **ModernUIStyle**
3. В компоненте EnhancedStartScreen перетащи:
   - Logo (логотип игры) в поле "Logo"
   - Play Button в поле "Play Button"
   - Settings Button в поле "Settings Button"
   - Если есть текст "Tap to Start" - в поле "Tap To Start Text"

### ШАГ 4: Улучшить DeadCanvas (Экран смерти)

1. В Hierarchy найди **DeadCanvas**
2. Выбери его и в Inspector:
   - Add Component → **EnhancedDeathScreen**
   - Add Component → **ModernUIStyle**
3. В компоненте EnhancedDeathScreen перетащи:
   - Текст с финальным счетом → "Final Score Text"
   - Текст с лучшим счетом → "Best Score Text"
   - Панель (фон) → "Panel"
   - Кнопку Retry → "Retry Button"
   - Кнопку Home → "Home Button"

### ШАГ 5: Улучшить InGameCanvas

1. Найди **InGameCanvas**
2. Выбери его:
   - Add Component → **ModernUIStyle**
3. Это автоматически улучшит все кнопки и текст

### ШАГ 6: Улучшить SettingsCanvas

1. Найди **SettingsCanvas**
2. Выбери его:
   - Add Component → **ModernUIStyle**

### ШАГ 7: Добавить движущийся фон (опционально)

1. Найди фоновый объект (bg или background)
2. Выбери его:
   - Add Component → **ParallaxBackground**
   - Parallax Speed = 0.5
   - Auto Scroll = ✓

---

## 🧪 ТЕСТИРОВАНИЕ

1. Нажми **Play** в Unity
2. Проверь:
   - ✓ Птичка не прыгает слишком высоко
   - ✓ Трубы расположены с нормальным промежутком
   - ✓ Счет увеличивается при пролете через трубы
   - ✓ Лучший счет сохраняется
   - ✓ Главное меню анимируется
   - ✓ Экран смерти выглядит красиво
   - ✓ Кнопки увеличиваются при наведении

---

## 🎨 ДОПОЛНИТЕЛЬНЫЕ УЛУЧШЕНИЯ (если хочешь)

### Цвета UI
В компоненте **ModernUIStyle** можно поменять цвета:
- Primary Color (основной) - синий по умолчанию
- Secondary Color (второстепенный) - золотой
- Background Color (фон) - темный
- Text Color (текст) - белый

### Размер кнопок при наведении
- Button Scale - насколько увеличиваются кнопки (1.1 = +10%)

---

## ❗ ВАЖНО

Если счет всё равно не считается:
1. Убедись что на Pipes prefab есть триггер со скриптом ScoreTrigger
2. Убедись что у птички Tag = "Player"
3. Убедись что триггер расположен между трубами (не на самих трубах)

Если игра всё равно сложная:
1. Можно уменьшить силу прыжка еще больше в FlappyBirdController.cs (строка 74)
2. Можно увеличить промежуток между трубами в GenerateScenario.cs (строка 55)

---

## 🚀 ПОСЛЕ НАСТРОЙКИ

1. Сохрани сцену (Ctrl+S)
2. File → Build Settings
3. Выбери платформу (WebGL для браузера)
4. Build
5. Загрузи на itch.io (инструкция в BUILD_INSTRUCTIONS.md)

**Готово! 🎉**
