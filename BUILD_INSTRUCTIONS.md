# Инструкция по сборке и публикации Flappy Bird Game

## 🎮 Подготовка проекта

### 1. Открыть проект в Unity
- Откройте Unity Hub
- Нажмите "Open" и выберите папку проекта
- Рекомендуемая версия Unity: 2019.4 LTS или выше

### 2. Проверка настроек проекта
Перейдите в `Edit > Project Settings`:
- **Player > Product Name**: FlappyParrotFlying
- **Player > Company Name**: Ваше имя
- **Player > Default Icon**: Установите иконку из Assets/Sprites/512x512 logo.jpg

---

## 🌐 Сборка для WebGL (браузер)

### Шаг 1: Настройки WebGL
1. Откройте `File > Build Settings`
2. Выберите платформу **WebGL**
3. Нажмите "Switch Platform" (если не выбрана)
4. Нажмите "Player Settings"

### Шаг 2: Оптимизация для WebGL
В Player Settings:
- **Publishing Settings > Compression Format**: Gzip
- **Publishing Settings > Enable Exceptions**: None
- **Other Settings > Color Space**: Gamma
- **Quality Settings**: Medium (для лучшей производительности)

### Шаг 3: Сборка
1. В Build Settings нажмите "Add Open Scenes" (добавит Main.unity)
2. Нажмите "Build"
3. Создайте папку `Builds/WebGL`
4. Дождитесь завершения сборки

---

## 📱 Сборка для Android

### Шаг 1: Установка Android Build Support
1. Откройте Unity Hub
2. Перейдите в Installs > ⚙️ > Add Modules
3. Установите:
   - Android Build Support
   - Android SDK & NDK Tools
   - OpenJDK

### Шаг 2: Настройки Android
1. `File > Build Settings` > Выберите **Android**
2. "Switch Platform"
3. Player Settings:
   - **Other Settings > Package Name**: com.yourname.flappybird
   - **Other Settings > Minimum API Level**: Android 5.0 (API 21)
   - **Other Settings > Target API Level**: Automatic (highest installed)
   - **Other Settings > Scripting Backend**: IL2CPP
   - **Other Settings > Target Architectures**: ARM64 ✓

### Шаг 3: Сборка APK
1. В Build Settings нажмите "Build"
2. Создайте папку `Builds/Android`
3. Сохраните как `FlappyBird.apk`
4. Дождитесь завершения

---

## 🚀 Публикация на itch.io

### Регистрация
1. Зайдите на https://itch.io
2. Создайте аккаунт (бесплатно)
3. Перейдите в Dashboard

### Создание страницы игры
1. Нажмите "Create new project"
2. Заполните информацию:
   - **Title**: Flappy Parrot Flying
   - **Project URL**: flappy-parrot-flying (будет доступна по этому адресу)
   - **Short description**: "Classic Flappy Bird style game. Tap to fly and avoid pipes!"
   - **Classification**: Games
   - **Kind of project**: HTML (для WebGL)
   - **Pricing**: Free

### Загрузка WebGL билда
1. В разделе "Uploads" нажмите "Upload files"
2. Выберите ВСЮ папку `Builds/WebGL` (zip её сначала)
3. Или загрузите все файлы из папки WebGL
4. Отметьте "This file will be played in the browser"
5. **Viewport dimensions**: 960 x 600 (или ваше разрешение)
6. **Embed options**: 
   - ✓ Mobile friendly
   - ✓ Automatically start on page load
   - ✓ Fullscreen button

### Загрузка Android APK (опционально)
1. Добавьте новый upload
2. Загрузите `FlappyBird.apk`
3. Отметьте "Android"

### Настройки страницы
1. **Screenshots**: Сделайте 3-5 скриншотов игры
2. **Cover image**: 630 x 500 px
3. **Description**: Подробное описание игры
4. **Genre**: Action, Arcade
5. **Tags**: flappy-bird, casual, mobile, arcade
6. **Visibility**: Public (когда готовы к релизу)

### Публикация
1. Нажмите "Save & View page" внизу
2. Проверьте что всё работает
3. Нажмите "Edit game" > "Visibility: Public"
4. Игра опубликована! 🎉

---

## 🔗 Публикация на GitHub Pages

### Подготовка
1. Соберите WebGL билд
2. Скопируйте содержимое папки `Builds/WebGL` в папку `docs/` проекта

### Настройка GitHub Pages
1. Зайдите в репозиторий на GitHub
2. Settings > Pages
3. **Source**: Deploy from a branch
4. **Branch**: main
5. **Folder**: /docs
6. Нажмите "Save"

### Создание index.html
Создайте файл `docs/index.html`:
```html
<!DOCTYPE html>
<html lang="en-us">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Flappy Parrot Flying</title>
    <style>
        body { margin: 0; padding: 0; background: #222; }
        #gameContainer { width: 100%; height: 100vh; display: flex; justify-content: center; align-items: center; }
        canvas { display: block; }
    </style>
</head>
<body>
    <div id="gameContainer">
        <canvas id="unity-canvas"></canvas>
    </div>
    <script src="Build/UnityLoader.js"></script>
    <script>
        UnityLoader.instantiate("unity-canvas", "Build/WebGL.json");
    </script>
</body>
</html>
```

### Публикация
1. Закоммитьте и запушьте изменения:
```bash
git add docs/
git commit -m "Add WebGL build"
git push origin main
```
2. Подождите 2-5 минут
3. Игра доступна по адресу: `https://yourusername.github.io/e-knot_game/`

---

## 📋 Чеклист перед публикацией

### Тестирование
- [ ] Игра запускается на ПК
- [ ] Работает управление мышью
- [ ] Игра запускается на телефоне
- [ ] Работает тач-управление
- [ ] Звуки воспроизводятся корректно
- [ ] Счёт увеличивается правильно
- [ ] Лучший счёт сохраняется
- [ ] Кнопка паузы работает
- [ ] Кнопка настроек работает
- [ ] Кнопка рестарта работает
- [ ] Нет ошибок в консоли

### Визуал
- [ ] UI читается на всех разрешениях
- [ ] Анимации плавные
- [ ] Нет артефактов графики
- [ ] Иконка игры установлена

### Производительность
- [ ] Игра работает 60 FPS на ПК
- [ ] Игра работает 30+ FPS на мобильных
- [ ] Нет утечек памяти
- [ ] Размер билда оптимизирован

---

## 🛠️ Решение проблем

### WebGL не запускается
- Проверьте, что все файлы из папки Build загружены
- Используйте локальный сервер для тестирования (не открывайте index.html напрямую)
- Проверьте консоль браузера на ошибки

### Низкая производительность
- Уменьшите качество графики в Build Settings
- Оптимизируйте текстуры (сжатие)
- Отключите ненужные эффекты

### Android APK не устанавливается
- Включите "Установка из неизвестных источников" на телефоне
- Проверьте, что подписали APK
- Убедитесь, что выбрана правильная архитектура (ARM64)

---

## 📞 Поддержка

Если возникли проблемы:
1. Проверьте консоль Unity на ошибки
2. Проверьте консоль браузера (F12) для WebGL
3. Проверьте логи Android через `adb logcat`

---

## ✅ Готово!

После успешной публикации:
1. Протестируйте игру по ссылке
2. Поделитесь ссылкой с руководителем практики
3. Добавьте ссылку в README репозитория

**Пример ссылок:**
- itch.io: `https://yourusername.itch.io/flappy-parrot-flying`
- GitHub Pages: `https://yourusername.github.io/e-knot_game/`
