using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringManager : MonoBehaviour {
    public struct Strings {
        public string[] strings;
    }

    public static StringManager Instance;

    private Dictionary<string, string> translations = new Dictionary<string, string>();

    //public string CurrentLanguage { get; private set; } = "en_US"; // Default to English

    //*
    private void Awake(){
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
    //*/

    private void Start() {
        LoadLanguage("pt_BR");
        //LoadLanguage("en_US");
        Debug.Log(GetString("item.iron_shovel.name"));
    }

    public void LoadLanguage(string language){
        string path = "Lang/" + language;
        TextAsset jsonFile = Resources.Load<TextAsset>(path);

        if(jsonFile != null) {
            //Dictionary<string, string> strings = JsonUtility.FromJson<Dictionary<string, string>>(jsonFile.text);
            Strings strings = JsonUtility.FromJson<Strings>(jsonFile.text);
            //CurrentLanguage = language;

            //Debug.Log(translations.Count);
            //Debug.Log(jsonFile);

            foreach(var s in strings.strings) {
                int i = s.IndexOf("=");

                if(i < 1) {
                    continue;
                }

                translations.Add(s.Substring(0, i), s.Substring(i + 1, s.Length - i - 1));
            }
        }
        else{
            Debug.LogError("Translation file not found for language: " + language);
        }
    }

    public string GetString(string key){
        if(translations.ContainsKey(key)){
            return translations[key];
        }
        else{
            Debug.LogWarning("Translation not found for key: " + key);
            return key;
        }
    }
}
