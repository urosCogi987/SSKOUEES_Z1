using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PredmetniZadatak1
{
    public class UndoRedoClear
    {       
        private Stack<UIElement> undoStack;
        private Stack<UIElement> redoStack;        

        public UndoRedoClear()
        {
            undoStack = new Stack<UIElement>();
            redoStack = new Stack<UIElement>();
        }


        public void Clear()
        {
            undoStack.Clear();
            redoStack.Clear();
        }

        public void AddUndoStackItem(UIElement elem)
        {
            undoStack.Push(elem);
        }

        public void AddRedoStackItem(UIElement elem)
        {
            redoStack.Push(elem);
        }    

        public UIElement RemoveUndoStackItem()
        {
            UIElement temp = undoStack.First();
            undoStack.Pop();
            return temp;
        }

        public UIElement RemoveRedoStackItem()
        {
            UIElement temp = redoStack.First();
            redoStack.Pop();
            return temp;
        }

        public bool CheckIfUndoEmpty()
        {
            if (undoStack.Count >= 1)
                return true;

            return false;
        }

        public bool CheckIfRedoEmpty()
        {
            if (redoStack.Count >= 1)
                return true;

            return false;
        }
    }
}
