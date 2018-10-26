namespace Iis.Eais.Common
{
    using System;
    using System.Reflection;

    /// <summary>
    ///     Потокобезопасный generic Singleton с отложенной инициализацией.
    /// </summary>
    /// <typeparam name="T">Singleton class.</typeparam>
    public class Singleton<T>
        where T : class
    {
        /// <summary>
        ///     Защищённый конструктор необходим для того, чтобы предотвратить создание экземпляра класса Singleton.
        ///     Он будет вызван из закрытого конструктора наследственного класса.
        /// </summary>
        protected Singleton() { }

        /// <summary>
        ///     Фабрика используется для отложенной инициализации экземпляра класса.
        /// </summary>
        /// <typeparam name="T1">Singleton class.</typeparam>
        internal sealed class SingletonCreator<T1>
            where T1 : class
        {
            // Используется Reflection для создания экземпляра класса без публичного конструктора.

            public static T1 CreatorInstance { get; } = (T1)
                typeof(T1).GetConstructor(
                    BindingFlags.Instance | BindingFlags.NonPublic,
                    null,
                    new Type[0],
                    new ParameterModifier[0]).Invoke(null);
        }

        /// <summary>
        ///     Экземпляр generic Singleton.
        /// </summary>
        public static T Instance => SingletonCreator<T>.CreatorInstance;
    }
}