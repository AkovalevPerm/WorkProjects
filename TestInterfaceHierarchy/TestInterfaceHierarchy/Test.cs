using System;
namespace Test
{
    // Использование
    public class AppController
    {
        private readonly ICommandHandler<AddUserCommand, int> _addUserCommandHandler;
        private readonly ICommandHandler<UpdateTaskCommand, bool> _updateTaskCommandHandler;
        public AppController(
            ICommandHandler<AddUserCommand, int> addUserCommandHandler,
            ICommandHandler<UpdateTaskCommand, bool> updateTaskCommandHandler)
        {
            _addUserCommandHandler = addUserCommandHandler;
            _updateTaskCommandHandler = updateTaskCommandHandler;
            int addUser(AddUserCommand command)
            {
                return _addUserCommandHandler.Invoke(command);
            }
            bool updateTask(UpdateTaskCommand command)
            {
                return _updateTaskCommandHandler.Invoke(command);
            }
        }
    }

    // Где то DI будет собирать ICommandHandler примерно так
    public class DI
    {
        ICommandHandler<AddUserCommand, int> resolveAddUserHandler()
        {
            var addUserCommandHanlder = new AddUserCommandHandler();
            var logDecorated = new LogDecorator<AddUserCommand, int>(addUserCommandHanlder);
            var exceptionDecorated = new CatchUnhadledErrorDecorator<AddUserCommand, int>(logDecorated);
            return exceptionDecorated;
        }
        ICommandHandler<UpdateTaskCommand, bool> resolveUpdateTaskHandler()
        {
            var updateTaskCommandHanlder = new UpdateTaskCommandHandler();
            var logDecorated = new LogDecorator<UpdateTaskCommand, bool>(updateTaskCommandHanlder);
            var exceptionDecorated = new CatchUnhadledErrorDecorator<UpdateTaskCommand, bool>(logDecorated);
            return exceptionDecorated;
        }
    }

    public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand
    {
        TResult Invoke(TCommand command);
    }

    public interface ICommand
    {
        Guid Id { get; set; }
    }

    public class AddUserCommand : ICommand
    {
        public AddUserCommand()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class UpdateTaskCommand : ICommand
    {
        public UpdateTaskCommand()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string NewTaskName { get; set; }
    }
    public class AddUserCommandHandler : ICommandHandler<AddUserCommand, int>
    {
        public AddUserCommandHandler( /*Инжектишь репозитории и все такое*/)
        {
        }
        public int Invoke(AddUserCommand command)
        {
            /*Сохраняешь пользователя*/
            return 1;
        }
    }

    public class UpdateTaskCommandHandler : ICommandHandler<UpdateTaskCommand, bool>
    {
        public UpdateTaskCommandHandler( /*Инжектишь репозитории и все такое*/)
        {
        }
        public bool Invoke(UpdateTaskCommand command)
        {
            /*Изменяешь таск пользователя*/
            return true;
        }
    }
    public class LogDecorator<T, To> : ICommandHandler<T, To> where T : ICommand
    {
        private readonly ICommandHandler<T, To> _commandHandler;
        public LogDecorator(ICommandHandler<T, To> commandHandler /*LogService*/)
        {
            _commandHandler = commandHandler;
        }
        public To Invoke(T command)
        {
            // _logServcie.log(command);
            return _commandHandler.Invoke(command);
        }
    }
    public class CatchUnhadledErrorDecorator<T, To> : ICommandHandler<T, To> where T : ICommand
    {
        private readonly ICommandHandler<T, To> _commandHandler;
        public CatchUnhadledErrorDecorator(ICommandHandler<T, To> commandHandler)
        {
            _commandHandler = commandHandler;
        }
        public To Invoke(T command)
        {
            try
            {
                return _commandHandler.Invoke(command);
            }
            catch (Exception e)
            {
                throw new Exception("Что то сломалось");
            }
        }
    }
}