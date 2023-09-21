using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEngine.Networking;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
public class SOSetting : EditorWindow
{
    const string URL = "https://docs.google.com/spreadsheets/d/1NxnZF-FhWW7MrYz6Azf41KYLOLKbymHj20fuu4UTjeA/export?format=tsv&range=2:1000&gid={0}";
    
    [MenuItem("Tools/SOSetting")]
    public static void ShowWindow()
    {
        SOSetting win = GetWindow<SOSetting>();
        win.minSize = new Vector2(350, 250);
        win.maxSize = new Vector2(350, 250);
    }

    private Button characterDataBtn;
    private Button settingBtn;
    private Label soNameText;

    private void OnEnable()
    {
        VisualTreeAsset xml = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/10.EditorWindow/SOSetting.uxml");

        TemplateContainer tree = xml.CloneTree();
        rootVisualElement.Add(tree);

        settingBtn = rootVisualElement.Q<Button>("settingBtn");
        characterDataBtn = rootVisualElement.Q<Button>("CharacterBtn");
        soNameText = rootVisualElement.Q<Label>("SONameText");

        //settingBtn.RegisterCallback<MouseUpEvent>(x => );
    }

}
