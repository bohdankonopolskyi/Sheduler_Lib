using System;
namespace Sheduler_Lib
{   
    [Serializable]
    public class StandartTask : Task
    {
        protected internal override event TaskStateHandler Created;
        protected internal override event TaskStateHandler ChangedStatus;

        public StandartTask(string name, string comment) : base(name, comment)
        {
            _priority = Priority.Low;
        }

        public override void CompleteTask()
        {
            if (_status == Status.Processing)
            {
                _status = Status.Done;
                ChangedStatus?.Invoke(this, new TaskEventArgs("The task " + _name + " is done.", DateTime.Now));
            }
        }

        public override void OnCreated()
        {
            Created?.Invoke(this, new TaskEventArgs("The low priority task " + _name + " is queued."));
        }
    }
}
