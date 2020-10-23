using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Abstract
{
    public interface ITodoTaskRepository
    {
        IEnumerable<TodoTask> Tasks { get; }
    }
}
