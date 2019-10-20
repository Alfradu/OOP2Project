using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public enum Action { ADD, EDIT, REMOVE }
    class UpdatedEventArgs : EventArgs
    {
        public Action Action { get; set; }
        public DateTime UpdateTime { get; set; }
        public UpdatedEventArgs(Action action, DateTime updateTime)
        {
            Action = action;
            UpdateTime = updateTime;
        }
    }
}
