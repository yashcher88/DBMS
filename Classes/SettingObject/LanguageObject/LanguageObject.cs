using Avalonia.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Nodes;

namespace DBMS.Classes
{
    public class LanguageObject : INotifyPropertyChanged
    {
        public readonly Dictionary<string, string> _text;

        public event PropertyChangedEventHandler PropertyChanged;
        public LanguageObject()
        {
            _text = new Dictionary<string, string>();
            /* Цвета Формы */
            _text["Save"] = "Сохранить";
            _text["Cancel"] = "Отмена";
            _text["RestoreDefaults"] = "Восстановить по умолчанию";
            _text["SavePackage"] = "Сохранить пакет";
        }
        public void ApplyFromLanguageObject(LanguageObject C)
        {
            foreach (var node in C._text)
            {
                _text[node.Key] = node.Value;
            }
        }
        public void LoadFromJson(JsonObject J)
        {
            foreach (var node in J)
            {
                _text[node.Key] = node.Value.ToString();
            }
        }
        public JsonObject SaveToJson() 
        { 
            JsonObject J = new JsonObject();
            foreach (var node in _text)
            {
                J[node.Key] = node.Value.ToString();
            }
            return J;
        }

        public string this[string key]
        {
            get
            {
                var B = _text.TryGetValue(key, out var v);
                if (B)
                {
                    return v;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                _text[key] = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item[]"));
            }
        }
    }
}
