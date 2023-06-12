using UnityEngine;

namespace Player.Command
{
    public interface IPlayerCommand<T>
    {
        void Execute(T argument);
    }
}
