using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ProjectOne
{
    partial class PoConnection
    {
        private readonly ConcurrentDictionary<PoNetworkMessageCommands, Action<PoNetworkMessage>> _actionsByCommand
            = new ConcurrentDictionary<PoNetworkMessageCommands, Action<PoNetworkMessage>>();

        protected void AddCommand(PoNetworkMessageCommands command, Action<PoNetworkMessage> func)
        {
            if (_actionsByCommand.TryAdd(command, func)) return;
            PoLogger.Log(PoLogSource.Default, PoLogType.Error, $"Cannot setup command {command.ToString()} for {GetType().Name}");
        }

        protected void RemoveCommand(PoNetworkMessageCommands command)
        {
            _actionsByCommand.TryRemove(command, out var tmp);
        }
    }
}
