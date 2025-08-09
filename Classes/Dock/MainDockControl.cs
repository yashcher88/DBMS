using Dock.Avalonia.Controls;
using Dock.Model.Avalonia;
using Dock.Model.Avalonia.Controls;
using Dock.Model.Avalonia.Core;
using Dock.Model.Core;
using Dock.Model.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DBMS.Classes
{
    public class MainDockControl
    {
        DockControl _dock;
        ToolDock leftToolDock = null;
        ToolDock rightToolDock = null;
        DocumentDock documentDock = null;

        private ProportionalDock mainLayout;

        private void CreateLeftTool()
        {
            if (leftToolDock == null)
            {
                leftToolDock = new ToolDock();
                leftToolDock.Id = "LeftPane";
                leftToolDock.Alignment = Alignment.Left;
                leftToolDock.Proportion = 0.25;
                leftToolDock.VisibleDockables = _dock.Factory.CreateList<IDockable>();
                mainLayout.VisibleDockables.Insert(0,new ProportionalDockSplitter());
                mainLayout.VisibleDockables.Insert(0, leftToolDock);
            }
        }
        private void CreateDocumentDock()
        {
            if (documentDock == null)
            {
                documentDock = new DocumentDock();
                documentDock.Id = "Documents";
                documentDock.IsCollapsable = false;
                documentDock.CanCreateDocument = true;
                documentDock.DocumentFactory = () =>
                {
                    var index = documentDock.VisibleDockables?.Count ?? 0;
                    return new Document { Id = $"Doc{index + 1}", Title = $"Document {index + 1}" };
                };
                documentDock.VisibleDockables = _dock.Factory.CreateList<IDockable>();
                /*
                 ToDo
                Сделать невидимым documentDock
                 */
                mainLayout.VisibleDockables.Add(documentDock);
            }
        }
        private void CreateRightTool()
        {
            if (rightToolDock == null)
            {
                rightToolDock = new ToolDock();
                rightToolDock.Id = "LeftPane";
                rightToolDock.Alignment = Alignment.Left;
                rightToolDock.Proportion = 0.25;
                rightToolDock.VisibleDockables = _dock.Factory.CreateList<IDockable>();
                mainLayout.VisibleDockables.Prepend(new ProportionalDockSplitter());
                mainLayout.VisibleDockables.Add(rightToolDock);
            }
        }
        public MainDockControl(DockControl Dock) 
        { 
            _dock = Dock;
            _dock.Factory = new MainDockFactory();
            _dock.Layout = _dock.Factory.CreateRootDock();

            mainLayout = new ProportionalDock {
                Orientation = Orientation.Horizontal
            };

            _dock.Layout.VisibleDockables = _dock.Factory.CreateList<IDockable>(mainLayout);
            _dock.Layout.DefaultDockable = mainLayout;
            CreateDocumentDock();
            _dock.Factory.InitLayout(_dock.Layout);
        }
        public void AddToolLeft(Tool T)
        {
            CreateLeftTool();
            leftToolDock.VisibleDockables.Add(T);
            leftToolDock.Proportion = 0.25;
            leftToolDock.ActiveDockable = T;
            _dock.Factory.InitLayout(_dock.Layout);
        }
        public void AddToolRight(Tool T)
        {
            CreateRightTool();
            rightToolDock.VisibleDockables.Add(T);
            rightToolDock.Proportion = 0.25;
            rightToolDock.ActiveDockable = T;
            _dock.Factory.InitLayout(_dock.Layout);
        }
        public void AddDocument(Document T)
        {
            CreateDocumentDock();
            documentDock.VisibleDockables.Add(T);
            documentDock.ActiveDockable = T;
            _dock.Factory.InitLayout(_dock.Layout);
        }
    }
}
