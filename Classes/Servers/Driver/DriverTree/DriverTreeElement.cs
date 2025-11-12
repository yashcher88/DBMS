using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using DBMS.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DBMS.Classes
{
    public class DriverTreeElement
    {
        public string _name;
        public string Name { get { return _name; } }
        public string Hint { get; set; } = "";
        public string ObjectId { get; set; } = "";
        public string PopupRuleMap { get; set; } = "";
        public ObjectTreeImage Image { get; set; }
        public IImage ImageSrc { get { return GetImage(); } }
        public ObjectTreeNodeType NodeType { get; set; }
        public DriverTreeElement Parent { get; set; }
        public DriverTreeTemplate Template { get; set; }
        public ObservableCollection<DriverTreeElement> Child { get; set; }

        public DriverTreeElement() 
        { 
            //Parent = _parent;
        }
        //public void GetImage

        public void LoadFromJson(JsonObject J)
        {

        }
        public JsonObject SaveToJson()
        {
            JsonObject J = new JsonObject();

            return J;
        }
        public IImage ConvertImage(string src) 
        {
            var uri = new Uri("avares://DBMS/Sources/TreeIcons/"+src+".bmp");
            return new Bitmap(AssetLoader.Open(uri));
        }
        public IImage GetImage() 
        {
            switch (Image) 
            {
                case ObjectTreeImage.Server: return ConvertImage("Server");
                default: return null;
            }
        }
    }
}
