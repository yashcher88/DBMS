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
            _text["Connect"] = "Соединить";
            _text["Cancel"] = "Отмена";
            _text["RestoreDefaults"] = "Восстановить по умолчанию";
            _text["SavePackage"] = "Сохранить пакет";
            _text["AvailableLanguage"] = "Доступные языки";
            _text["Add"] = "Добавить";
            _text["Rename"] = "Переименовать";
            _text["Delete"] = "Удалить";
            _text["Name"] = "Название:";
            _text["Driver"] = "Драйвер:";
            _text["NameServer"] = "Имя сервера:";
            _text["Login"] = "Логин:";
            _text["Password"] = "Пароль:";
            _text["SavePassword"] = "Запомнить пароль";
            _text["Port"] = "Порт:";
            _text["Database"] = "База данных:";
            _text["CodePage"] = "Кодировка:";
            _text["StateBar"] = "Строка состояния:";
            _text["Property"] = "Свойство";

            _text["QueryStateConnected"] = "Подключено";
            _text["QueryStateNotConnected"] = "Не подключено";
            _text["QueryStateExecuting"] = "Выполняется";
            _text["QueryStateComplete"] = "Выполнено";
            _text["QueryStateCompleteError"] = "Выполнено с ошибками";
            _text["QueryStateCancel"] = "Отменено";


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
