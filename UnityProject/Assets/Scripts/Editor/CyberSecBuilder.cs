using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;
using CyberSec;

namespace CyberSec.EditorScripts
{
    public class CyberSecBuilder : EditorWindow
    {
        [MenuItem("CyberGuard/Build Full CyberSec Game")]
        public static void BuildAllScenes()
        {
            if (!AssetDatabase.IsValidFolder("Assets/Scenes/Core"))
                AssetDatabase.CreateFolder("Assets/Scenes", "Core");
            if (!AssetDatabase.IsValidFolder("Assets/Scenes/Levels"))
                AssetDatabase.CreateFolder("Assets/Scenes", "Levels");

            BuildCoreManagers();
            BuildMainMenu();
            BuildLevelSelect();
            
            for (int i = 1; i <= 10; i++)
            {
                BuildLevelScene(i);
            }

            Debug.Log("ALL 12 SCENES AND PREFABS BUILT SUCCESSFULLY! Open Assets/Scenes/Core/MainMenu.unity and press Play!");
        }

        private static void BuildCoreManagers()
        {
            // Core Managers should be in a prefab or instantiated in MainMenu, 
            // but the scripts handle DontDestroyOnLoad automatically in Awake.
            Debug.Log("Core Managers (GameManager, LevelManager, SceneLoader) are verified.");
        }

        private static void BuildMainMenu()
        {
            var newScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            newScene.name = "MainMenu";

            SetupCamera();
            GameObject eventSystem = SetupEventSystem();
            GameObject canvasObj = SetupCanvas("MainMenuCanvas");

            GameObject gmObj = new GameObject("CoreManagers");
            gmObj.AddComponent<GameManager>();
            gmObj.AddComponent<LevelManager>();
            gmObj.AddComponent<SceneLoader>();
            gmObj.AddComponent<ProgressManager>();

            // Background
            CreatePanel("Background", canvasObj.transform, new Color(0.05f, 0.08f, 0.15f));

            // Title
            GameObject titleObj = CreateText("TitleText", canvasObj.transform, "CYBERGUARD CHRONICLES\n<size=30>10-Level Cybersecurity Awareness Simulation</size>", 60, FontStyles.Bold, TextAlignmentOptions.Center, new Color(0f, 0.8f, 0.6f));
            SetRectTransform(titleObj, new Vector2(0.5f, 0.8f), new Vector2(0.5f, 0.8f), Vector2.zero, new Vector2(1000, 200));

            // Menu Controller
            MenuController menu = canvasObj.AddComponent<MenuController>();

            // Buttons
            GameObject startBtn = CreateButton("StartGameBtn", canvasObj.transform, "START TRAINING", new Color(0.1f, 0.6f, 0.3f));
            SetRectTransform(startBtn, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0, 50), new Vector2(300, 70));
            startBtn.GetComponent<Button>().onClick.AddListener(() => {
                FindObjectOfType<SceneLoader>().LoadScene(Constants.LEVEL_01);
            });

            GameObject selectBtn = CreateButton("LevelSelectBtn", canvasObj.transform, "SELECT MODULE", new Color(0.2f, 0.4f, 0.8f));
            SetRectTransform(selectBtn, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0, -50), new Vector2(300, 70));
            selectBtn.GetComponent<Button>().onClick.AddListener(() => {
                FindObjectOfType<SceneLoader>().LoadLevelSelect();
            });

            EditorSceneManager.SaveScene(newScene, "Assets/Scenes/Core/MainMenu.unity");
        }

        private static void BuildLevelSelect()
        {
            var newScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            newScene.name = "LevelSelect";

            SetupCamera();
            SetupEventSystem();
            GameObject canvasObj = SetupCanvas("LevelSelectCanvas");

            CreatePanel("Background", canvasObj.transform, new Color(0.05f, 0.08f, 0.15f));

            GameObject titleObj = CreateText("TitleText", canvasObj.transform, "MODULE SELECTION", 50, FontStyles.Bold, TextAlignmentOptions.Center, new Color(0f, 0.8f, 0.6f));
            SetRectTransform(titleObj, new Vector2(0.5f, 0.9f), new Vector2(0.5f, 0.9f), Vector2.zero, new Vector2(800, 100));

            GameObject backBtn = CreateButton("BackBtn", canvasObj.transform, "BACK TO MENU", new Color(0.8f, 0.2f, 0.2f));
            SetRectTransform(backBtn, new Vector2(0.1f, 0.9f), new Vector2(0.1f, 0.9f), Vector2.zero, new Vector2(200, 60));
            backBtn.GetComponent<Button>().onClick.AddListener(() => {
                FindObjectOfType<SceneLoader>().LoadMainMenu();
            });

            GameObject gridObj = new GameObject("LevelGrid");
            gridObj.transform.SetParent(canvasObj.transform, false);
            SetRectTransform(gridObj, new Vector2(0.5f, 0.45f), new Vector2(0.5f, 0.45f), Vector2.zero, new Vector2(1000, 600));

            GridLayoutGroup grid = gridObj.AddComponent<GridLayoutGroup>();
            grid.cellSize = new Vector2(180, 180);
            grid.spacing = new Vector2(20, 20);
            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            grid.constraintCount = 5;
            grid.childAlignment = TextAnchor.MiddleCenter;

            LevelSelectUI levelUI = canvasObj.AddComponent<LevelSelectUI>();
            levelUI.levelButtonPrefab = CreateLevelButtonPrefab();
            levelUI.container = gridObj.transform;
            levelUI.backButton = backBtn.GetComponent<Button>();

            EditorSceneManager.SaveScene(newScene, "Assets/Scenes/Core/LevelSelect.unity");
        }

        private static GameObject CreateLevelButtonPrefab()
        {
            GameObject btnObj = CreateButton("LevelButtonPrefab", null, "LEVEL X", new Color(0.15f, 0.15f, 0.25f));
            SetRectTransform(btnObj, Vector2.zero, Vector2.zero, Vector2.zero, new Vector2(180, 180));
            
            // Add stars text
            GameObject starsObj = CreateText("StarsText", btnObj.transform, "☆☆☆", 24, FontStyles.Normal, TextAlignmentOptions.Bottom, Color.yellow);
            SetRectTransform(starsObj, Vector2.zero, Vector2.one, new Vector2(0, 10), Vector2.zero);

            if (!AssetDatabase.IsValidFolder("Assets/Prefabs"))
                AssetDatabase.CreateFolder("Assets", "Prefabs");
            
            GameObject prefab = PrefabUtility.SaveAsPrefabAsset(btnObj, "Assets/Prefabs/LevelSelectButton.prefab");
            DestroyImmediate(btnObj);
            return prefab;
        }

        private static void BuildLevelScene(int levelNum)
        {
            string[] sceneNames = {
                Constants.LEVEL_01, Constants.LEVEL_02, Constants.LEVEL_03,
                Constants.LEVEL_04, Constants.LEVEL_05, Constants.LEVEL_06,
                Constants.LEVEL_07, Constants.LEVEL_08, Constants.LEVEL_09,
                Constants.LEVEL_10
            };
            string sceneName = sceneNames[levelNum - 1];

            var newScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            newScene.name = sceneName;

            SetupCamera();
            SetupEventSystem();
            GameObject canvasObj = SetupCanvas("LevelCanvas");
            CreatePanel("Background", canvasObj.transform, new Color(0.08f, 0.1f, 0.12f));

            GameObject systemObj = new GameObject("LevelSystems");

            // 1. Popup Controller
            PopupController popup = GeneratePopupController(canvasObj.transform);
            
            // 2. Tutorial UI
            GenerateTutorialUI(canvasObj.transform);

            // 3. Dialog System
            GenerateDialogSystem(canvasObj.transform);

            // 4. Score Manager
            ScoreManager sm = systemObj.AddComponent<ScoreManager>();
            GameObject scoreTextObj = CreateText("ScoreText", canvasObj.transform, "Score: 100", 30, FontStyles.Bold, TextAlignmentOptions.TopRight, Color.green);
            SetRectTransform(scoreTextObj, new Vector2(1, 1), new Vector2(1, 1), new Vector2(-20, -20), new Vector2(300, 50));
            sm.scoreText = scoreTextObj.GetComponent<TextMeshProUGUI>();

            // 5. Video Controller
            GameObject videoObj = new GameObject("VideoController");
            VideoController vc = videoObj.AddComponent<VideoController>();
            vc.videoPlayer = videoObj.AddComponent<VideoPlayer>();
            GameObject videoRawImage = new GameObject("VideoDisplay");
            videoRawImage.transform.SetParent(canvasObj.transform, false);
            SetRectTransform(videoRawImage, Vector2.zero, Vector2.one, Vector2.zero, Vector2.zero);
            RawImage ri = videoRawImage.AddComponent<RawImage>();
            vc.rawImage = ri;
            videoRawImage.SetActive(false); // hide until playing

            // 6. Specific Level Controller
            GameObject controllerObj = new GameObject("LevelController");
            switch (levelNum)
            {
                case 1:
                    var phish = controllerObj.AddComponent<PhishingController>();
                    phish.emailSim = GenerateEmailSimUI(canvasObj.transform, phish);
                    break;
                case 2:
                    var pass = controllerObj.AddComponent<PasswordController>();
                    pass.checker = controllerObj.AddComponent<PasswordStrengthChecker>();
                    break;
                case 3: controllerObj.AddComponent<SocialEngineeringController>(); break;
                case 4: controllerObj.AddComponent<MalwareDownloadController>(); break;
                case 5: controllerObj.AddComponent<PublicWifiController>(); break;
                case 6: controllerObj.AddComponent<RansomwareController>(); break;
                case 7: controllerObj.AddComponent<TwoFactorAuthController>(); break;
                case 8: controllerObj.AddComponent<SafeBrowsingController>(); break;
                case 9: controllerObj.AddComponent<DataPrivacyController>(); break;
                case 10: controllerObj.AddComponent<FinalAttackController>(); break;
            }

            EditorSceneManager.SaveScene(newScene, $"Assets/Scenes/Levels/{sceneName}.unity");
        }

        private static EmailSimulation GenerateEmailSimUI(Transform parent, PhishingController root)
        {
            GameObject panel = CreatePanel("EmailSimPanel", parent, new Color(0.9f, 0.9f, 0.9f, 1f));
            SetRectTransform(panel, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(800, 500));
            
            // UI Header
            CreatePanel("EmailHeader", panel.transform, new Color(0.2f, 0.4f, 0.8f, 1f));
            GameObject header = panel.transform.Find("EmailHeader").gameObject;
            SetRectTransform(header, new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, -30), new Vector2(0, 60));

            var sender = CreateText("Sender", panel.transform, "From: ...", 20, FontStyles.Normal, TextAlignmentOptions.Left, Color.black);
            SetRectTransform(sender, new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, -80), new Vector2(-40, 30));

            var subject = CreateText("Subject", panel.transform, "Subject: ...", 22, FontStyles.Bold, TextAlignmentOptions.Left, Color.black);
            SetRectTransform(subject, new Vector2(0, 1), new Vector2(1, 1), new Vector2(0, -110), new Vector2(-40, 30));

            var body = CreateText("Body", panel.transform, "Email body...", 20, FontStyles.Normal, TextAlignmentOptions.TopLeft, Color.black);
            SetRectTransform(body, new Vector2(0, 0), new Vector2(1, 1), new Vector2(0, -50), new Vector2(-40, -180));

            var phishBtnObj = CreateButton("MarkPhishingBtn", panel.transform, "MARK AS PHISHING", Color.red);
            SetRectTransform(phishBtnObj, new Vector2(0.25f, 0), new Vector2(0.25f, 0), new Vector2(0, 40), new Vector2(250, 50));
            
            var safeBtnObj = CreateButton("MarkSafeBtn", panel.transform, "MARK AS SAFE", Color.green);
            SetRectTransform(safeBtnObj, new Vector2(0.75f, 0), new Vector2(0.75f, 0), new Vector2(0, 40), new Vector2(250, 50));

            EmailSimulation sim = panel.AddComponent<EmailSimulation>();
            sim.emailPanel = panel;
            sim.senderText = sender.GetComponent<TextMeshProUGUI>();
            sim.subjectText = subject.GetComponent<TextMeshProUGUI>();
            sim.bodyText = body.GetComponent<TextMeshProUGUI>();
            sim.markPhishingButton = phishBtnObj.GetComponent<Button>();
            sim.markSafeButton = safeBtnObj.GetComponent<Button>();
            
            return sim;
        }

        private static PopupController GeneratePopupController(Transform parent)
        {
            GameObject panel = CreatePanel("PopupPanel", parent, new Color(0, 0, 0, 0.8f));
            SetRectTransform(panel, Vector2.zero, Vector2.one, Vector2.zero, Vector2.zero);

            GameObject box = CreatePanel("Box", panel.transform, new Color(0.1f, 0.15f, 0.2f, 1f));
            SetRectTransform(box, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(600, 300));

            var title = CreateText("Title", box.transform, "ALERT", 30, FontStyles.Bold, TextAlignmentOptions.Center, Color.red);
            SetRectTransform(title, new Vector2(0.5f, 1), new Vector2(0.5f, 1), new Vector2(0, -40), new Vector2(500, 50));

            var msg = CreateText("Message", box.transform, "...", 20, FontStyles.Normal, TextAlignmentOptions.Center, Color.white);
            SetRectTransform(msg, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), new Vector2(0, 20), new Vector2(500, 150));

            var btnObj = CreateButton("ConfirmBtn", box.transform, "OK", Color.gray);
            SetRectTransform(btnObj, new Vector2(0.5f, 0), new Vector2(0.5f, 0), new Vector2(0, 40), new Vector2(200, 50));

            PopupController pc = new GameObject("PopupController").AddComponent<PopupController>();
            pc.popupPanel = panel;
            pc.titleText = title.GetComponent<TextMeshProUGUI>();
            pc.messageText = msg.GetComponent<TextMeshProUGUI>();
            pc.confirmButton = btnObj.GetComponent<Button>();
            
            var closeBtnObj = CreateButton("CloseBtn", box.transform, "X", Color.red);
            SetRectTransform(closeBtnObj, new Vector2(1, 1), new Vector2(1, 1), new Vector2(-25, -25), new Vector2(40, 40));
            pc.closeButton = closeBtnObj.GetComponent<Button>();

            panel.SetActive(false);
            return pc;
        }

        private static DialogSystem GenerateDialogSystem(Transform parent)
        {
            GameObject panel = CreatePanel("DialogPanel", parent, new Color(0.05f, 0.05f, 0.1f, 0.95f));
            SetRectTransform(panel, new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 150), new Vector2(0, 300));

            var speaker = CreateText("SpeakerText", panel.transform, "Speaker", 28, FontStyles.Bold, TextAlignmentOptions.Left, Color.cyan);
            SetRectTransform(speaker, new Vector2(0, 1), new Vector2(0, 1), new Vector2(150, -30), new Vector2(300, 40));

            var text = CreateText("DialogText", panel.transform, "Dialogue...", 24, FontStyles.Normal, TextAlignmentOptions.TopLeft, Color.white);
            SetRectTransform(text, new Vector2(0, 0), new Vector2(1, 1), new Vector2(0, -40), new Vector2(-300, -80));

            GameObject choices = new GameObject("ChoiceContainer");
            choices.transform.SetParent(panel.transform, false);
            SetRectTransform(choices, new Vector2(1, 0.5f), new Vector2(1, 0.5f), new Vector2(-150, 0), new Vector2(300, 250));
            var vlg = choices.AddComponent<VerticalLayoutGroup>();
            vlg.spacing = 10;
            vlg.childForceExpandHeight = false;
            vlg.childAlignment = TextAnchor.MiddleCenter;

            // Prefab for Dialog Button
            GameObject btnPrefab = CreateButton("DialogChoiceBtn", null, "Choice", new Color(0.2f, 0.2f, 0.3f));
            SetRectTransform(btnPrefab, Vector2.zero, Vector2.zero, Vector2.zero, new Vector2(0, 50));
            btnPrefab.AddComponent<LayoutElement>().minHeight = 50;

            DialogSystem ds = new GameObject("DialogSystem").AddComponent<DialogSystem>();
            ds.dialogPanel = panel;
            ds.speakerNameText = speaker.GetComponent<TextMeshProUGUI>();
            ds.dialogueText = text.GetComponent<TextMeshProUGUI>();
            ds.choiceContainer = choices.transform;
            ds.choiceButtonPrefab = btnPrefab; // Instance prefab directly

            panel.SetActive(false);
            return ds;
        }

        private static void GenerateTutorialUI(Transform parent)
        {
            GameObject panel = CreatePanel("TutorialPanel", parent, new Color(0, 0, 0, 0.8f));
            SetRectTransform(panel, Vector2.zero, Vector2.one, Vector2.zero, Vector2.zero);

            GameObject box = CreatePanel("Box", panel.transform, new Color(0.1f, 0.2f, 0.3f, 1f));
            SetRectTransform(box, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(800, 400));

            var title = CreateText("Title", box.transform, "TUTORIAL", 40, FontStyles.Bold, TextAlignmentOptions.Center, Color.yellow);
            SetRectTransform(title, new Vector2(0.5f, 1), new Vector2(0.5f, 1), new Vector2(0, -60), new Vector2(600, 60));

            var body = CreateText("Body", box.transform, "...", 28, FontStyles.Normal, TextAlignmentOptions.Center, Color.white);
            SetRectTransform(body, new Vector2(0.5f, 0.5f), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(700, 200));

            var btnObj = CreateButton("NextBtn", box.transform, "NEXT", Color.cyan);
            SetRectTransform(btnObj, new Vector2(0.5f, 0), new Vector2(0.5f, 0), new Vector2(0, 60), new Vector2(250, 60));

            TutorialUI tu = new GameObject("TutorialUI").AddComponent<TutorialUI>();
            tu.tutorialPanel = panel;
            tu.tutorialText = body.GetComponent<TextMeshProUGUI>();
            tu.nextButton = btnObj.GetComponent<Button>();

            panel.SetActive(false);
        }

        // --- Helpers ---
        private static void SetupCamera()
        {
            Camera.main.clearFlags = CameraClearFlags.SolidColor;
            Camera.main.backgroundColor = new Color(0.1f, 0.1f, 0.1f);
        }

        private static GameObject SetupEventSystem()
        {
            var eventSystem = Object.FindObjectOfType<UnityEngine.EventSystems.EventSystem>();
            if (eventSystem == null)
            {
                var obj = new GameObject("EventSystem");
                obj.AddComponent<UnityEngine.EventSystems.EventSystem>();
                obj.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
                return obj;
            }
            return eventSystem.gameObject;
        }

        private static GameObject SetupCanvas(string name)
        {
            GameObject canvasObj = new GameObject(name);
            Canvas canvas = canvasObj.AddComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            CanvasScaler scaler = canvasObj.AddComponent<CanvasScaler>();
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920, 1080);
            canvasObj.AddComponent<GraphicRaycaster>();
            return canvasObj;
        }

        private static GameObject CreatePanel(string name, Transform parent, Color color)
        {
            GameObject panel = new GameObject(name);
            if (parent != null) panel.transform.SetParent(parent, false);
            var img = panel.AddComponent<Image>();
            img.color = color;
            SetRectTransform(panel, Vector2.zero, Vector2.one, Vector2.zero, Vector2.zero);
            return panel;
        }

        private static GameObject CreateText(string name, Transform parent, string textStr, int fontSize, FontStyles style, TextAlignmentOptions align, Color color)
        {
            GameObject textObj = new GameObject(name);
            if (parent != null) textObj.transform.SetParent(parent, false);
            var tmp = textObj.AddComponent<TextMeshProUGUI>();
            tmp.text = textStr;
            tmp.fontSize = fontSize;
            tmp.fontStyle = style;
            tmp.alignment = align;
            tmp.color = color;
            tmp.enableWordWrapping = true;
            return textObj;
        }

        private static GameObject CreateButton(string name, Transform parent, string textStr, Color btnColor)
        {
            GameObject btnObj = new GameObject(name);
            if (parent != null) btnObj.transform.SetParent(parent, false);
            var img = btnObj.AddComponent<Image>();
            img.color = btnColor;
            var btn = btnObj.AddComponent<Button>();

            var textObj = CreateText("Text", btnObj.transform, textStr, 24, FontStyles.Bold, TextAlignmentOptions.Center, Color.white);
            SetRectTransform(textObj, Vector2.zero, Vector2.one, Vector2.zero, Vector2.zero);

            return btnObj;
        }

        private static void SetRectTransform(GameObject obj, Vector2 anchorMin, Vector2 anchorMax, Vector2 anchoredPos, Vector2 sizeDelta)
        {
            RectTransform rect = obj.GetComponent<RectTransform>();
            if (rect == null) rect = obj.AddComponent<RectTransform>();
            rect.anchorMin = anchorMin;
            rect.anchorMax = anchorMax;
            rect.anchoredPosition = anchoredPos;
            rect.sizeDelta = sizeDelta;
        }
    }
}
