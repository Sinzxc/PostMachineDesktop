using Xunit;
using System.Collections.Generic;
using PostMachine;

namespace PostMachine.Tests
{
    public class CommandsTests
    {
        // Тест проверяет, что добавление операции увеличивает количество операций в списке.
        [Fact]
        public void AddCommand_AddsOperationToList()
        {
            // Устанавливаем начальное состояние
            var commands = new Commands();
            var initialCount = commands.GetCommands().Count; // Получаем начальное количество операций в списке

            // Действие - добавление новой операции
            commands.AddCommand(1, 2);

            // Проверка - количество операций увеличилось на 1
            Assert.Equal(initialCount + 1, commands.GetCommands().Count);
        }

        // Тест проверяет, что удаление последней операции уменьшает количество операций в списке.
        [Fact]
        public void RemoveLastCommand_RemovesLastOperationFromList()
        {
            // Устанавливаем начальное состояние с несколькими операциями в списке
            var commands = new Commands();
            commands.AddCommand(1, 2);
            commands.AddCommand(2, 3);
            var initialCount = commands.GetCommands().Count; // Получаем начальное количество операций в списке

            // Действие - удаление последней операции
            commands.RemoveLastCommand();

            // Проверка - количество операций уменьшилось на 1
            Assert.Equal(initialCount - 1, commands.GetCommands().Count);
        }

        // Тест проверяет, что удаление операции из пустого списка не изменяет его.
        [Fact]
        public void RemoveLastCommand_DoesNotRemoveFromEmptyList()
        {
            // Устанавливаем начальное состояние с пустым списком операций
            var commands = new Commands();

            // Действие - удаление последней операции (в пустом списке)
            commands.RemoveLastCommand();

            // Проверка - список остается пустым
            Assert.Empty(commands.GetCommands());
        }
    }
}
