# 🚨 ИСПРАВЛЕНИЕ РАЗРЕШЕНИЯ И КНОПКИ HOME

## Проблема 1: Края экрана не видно в Unity

### Решение (выбери один вариант):

### ВАРИАНТ А - Изменить разрешение Game View (БЫСТРЕЕ):
1. В Unity найди вкладку **Game** (где играешь)
2. Вверху слева есть выпадающий список (обычно написано "Free Aspect" или разрешение)
3. Нажми на него
4. Выбери **16:9** или **Standalone (1920x1080)**
5. Или выбери **Free Aspect** и растяни окно Game побольше

### ВАРИАНТ Б - Настроить Canvas Scaler:
1. В Hierarchy найди **Canvas** (любой - InGameCanvas, StartScreenCanvas и т.д.)
2. Выбери его
3. В Inspector найди компонент **Canvas Scaler**
4. Измени настройки:
   - **UI Scale Mode** = Scale With Screen Size
   - **Reference Resolution**: X = 1920, Y = 1080
   - **Screen Match Mode** = Match Width Or Height
   - **Match** = 0.5 (между шириной и высотой)
5. Скопируй эти настройки на все остальные Canvas:
   - StartScreenCanvas
   - InGameCanvas
   - DeadCanvas
   - SettingsCanvas

---

## Проблема 2: Кнопка Home на экране смерти не работает

### Решение:

1. В Hierarchy найди **DeadCanvas**
2. Внутри найди кнопку **Home** (или как она называется - может быть RestartButton, BackButton)
3. Выбери эту кнопку
4. В Inspector найди компонент **Button (Script)**
5. Внизу есть **OnClick()**
6. Проверь что там:
   - Должен быть объект **Game_Manager** (перетащи его если нет)
   - Функция должна быть: **Game_Manager → Home**

### Если кнопки Home вообще нет:

1. Выбери **DeadCanvas**
2. Правый клик → **UI → Button**
3. Назови "HomeButton"
4. Настрой позицию (например внизу слева)
5. Измени текст на "MENU" или "HOME"
6. В Inspector этой кнопки:
   - **Button → OnClick()** → нажми **+**
   - Перетащи объект **Game_Manager** из Hierarchy
   - Выбери функцию: **Game_Manager → Home()**

### Проверка что работает:

1. Нажми **Play**
2. Открой **Console** (Window → General → Console)
3. Умри в игре (врежься в трубу)
4. Нажми кнопку Home
5. В Console должно быть:
   - "Home button pressed!"
   - "Returned to main menu"
6. Должно вернуться в главное меню

---

## Проблема 3: Если кнопка Restart тоже не работает

### Решение:

1. Найди кнопку **Restart** на DeadCanvas
2. В Inspector → **Button → OnClick()**
3. Объект: **Game_Manager**
4. Функция: **Game_Manager → StartGame**

---

## 📐 Рекомендуемые настройки Canvas для ВСЕХ Canvas:

```
Canvas Scaler:
├─ UI Scale Mode: Scale With Screen Size
├─ Reference Resolution: 1920 x 1080
├─ Screen Match Mode: Match Width Or Height
└─ Match: 0.5
```

Это сделает игру адаптивной под любое разрешение!

---

## 🎮 Настройка Game View для тестирования:

В Unity Editor:
1. **Game** вкладка → выпадающий список вверху слева
2. Попробуй разные варианты:
   - **16:9 Aspect** - для ПК
   - **9:16 Portrait** - для мобильных
   - **Standalone (1920x1080)** - для десктопа
   - **Free Aspect** - свободное (растяни окно)

---

## Быстрая проверка:

1. Play
2. Смотришь видно ли все углы экрана?
   - Если нет → измени Canvas Scaler
3. Умри в игре
4. Жми Home
5. Смотри Console - должно быть "Home button pressed!"
6. Должно вернуться в меню

Сделай это и скажи что получилось!
