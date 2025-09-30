using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace DBMS.Classes
{
    public class SettingObject
    {
        /* Объект для хранения текущих настроек Стиля*/
        public StyleObject Style = new StyleObject(); //User
        /* Объект для хранения текущих настроек Языка*/
        public LanguageObject Language = new LanguageObject(); //User
        /* Настройки для хранения путей, которые используются в программе */
        public Dictionary<string, string> Path = new Dictionary<string, string>(); //User
        public string SelectedLanguage; //User
        public string SelectedStyle; //User
        public bool isUserLanguage; //User
        /* Текущие настройки */
        public Dictionary<string,string> List = new Dictionary<string, string>(); //User

        /* Объект для хранения наборов дефолтных настроек Стиля*/
        public StyleObjectList StyleList = new StyleObjectList(); //System
        /* Объект для хранения наборов пользовательских настроек Стиля*/
        public StyleObjectList UserStyleList = new StyleObjectList(); //User
        /* Объект для хранения наборов дефолтных настроек Языка*/
        public LanguageObjectList LanguageList = new LanguageObjectList(); //System
        /* Настройки для хранения дефолтных путей */
        public Pathes SystemPath = new Pathes();
        /* Дефолтные настройки */
        //public SetObject DefaultSetObject = new SetObject();
        public string DefaultLanguage; //System
        public string DefaultStyle; //System
        string DefName = "Default";
        /* Текущие настройки */
        public Dictionary<string, string> DefaultList = new Dictionary<string, string>(); //System
        public SettingObject() 
        {
            
            DefaultLanguage = DefName;
            DefaultStyle = DefName;
            StyleList.List.Add(DefName, Style);
            LanguageList.List.Add(DefName, Language);
            /* Дефолтные настройки путей */
            /* Дефолтные настройки */

            foreach (var item in DefaultList)
            {
                List[item.Key] = item.Value;
            }
        }
        public void SetLanguage(string LanguageName)
        {
            if (LanguageList.List.ContainsKey(LanguageName))
            {
                Language.ApplyFromLanguageObject(LanguageList.List[LanguageName]);
                SelectedLanguage = LanguageName;
            }
        }
        public void SetStyle(string StyleName)
        {
            if (StyleList.List.ContainsKey(StyleName))
            {
                Style.ApplyFromStyleObject(StyleList.List[StyleName]);
                SelectedLanguage = StyleName;
                isUserLanguage = false;
            }
        }
        public void SetUserStyle(string StyleName)
        {
            if (UserStyleList.List.ContainsKey(StyleName)) 
            {
                Style.ApplyFromStyleObject(UserStyleList.List[StyleName]);
                SelectedLanguage = StyleName;
                isUserLanguage = true;
            }
        }
        public void LoadSystemFromJson(JsonObject J)
        {
            DefaultLanguage = J["DefaultLanguage"].ToString();
            DefaultStyle = J["DefaultStyle"].ToString();
            StyleList.LoadFromJson(J["StyleList"].AsObject());
            LanguageList.LoadFromJson(J["LanguageList"].AsObject());
            DefaultList.Clear();
            foreach (var node in J["DefaultList"].AsObject())
            {
                DefaultList.Add(node.Key,node.Value.ToString());
            }
        }
        public void LoadUserFromJson(JsonObject J)
        {
            Style.LoadFromJson(J["Style"].AsObject());
            Language.LoadFromJson(J["Language"].AsObject());
            Path.Clear();
            foreach (var node in J["Path"].AsObject())
            {
                Path.Add(node.Key, node.Value.ToString());
            }
            SelectedLanguage = J["SelectedLanguage"].ToString();
            SelectedStyle = J["SelectedStyle"].ToString();
            isUserLanguage = Convert.ToBoolean(J["isUserLanguage"].ToString());
            List.Clear();
            foreach (var node in J["List"].AsObject()) 
            {
                List.Add(node.Key, node.Value.ToString());
            }
            UserStyleList.LoadFromJson(J["UserStyleList"].AsObject());
        }
        public JsonObject SaveSystemToJson()
        {
            JsonObject J = new JsonObject();
            J["DefaultLanguage"] = DefaultLanguage;
            J["DefaultStyle"] = DefaultStyle;
            J["StyleList"] = StyleList.SaveToJson();
            J["LanguageList"] = LanguageList.SaveToJson();
            J["DefaultList"] = new JsonObject();
            foreach (var node in DefaultList) 
            {
                J["DefaultList"][node.Key] = node.Value;
            }
            return J;
        }
        public JsonObject SaveUserToJson()
        {
            JsonObject J = new JsonObject();
            J["Style"] = Style.SaveToJson();
            J["SelectedLanguage"] = SelectedLanguage;
            J["SelectedStyle"] = SelectedStyle;
            J["isUserLanguage"] = isUserLanguage.ToString();
            J["UserStyleList"] = UserStyleList.SaveToJson();
            J["List"] = new JsonObject();
            foreach (var node in List)
            {
                J["List"][node.Key] = node.Value;
            }           
            return J;
        }
    }
}
