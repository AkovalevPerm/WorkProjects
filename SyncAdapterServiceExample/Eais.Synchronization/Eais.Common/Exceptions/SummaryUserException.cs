namespace Iis.Eais.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Errors;

    /// <summary>
    /// Класс пользовательских исключений.
    /// </summary>
    public class SummaryUserException: UserException
    {
        /// <summary>
        /// Список ошибок.
        /// </summary>
        public List<IError> Errors { get; set; }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="errors">Список ошибок.</param>
        public SummaryUserException(List<IError> errors)
        {
            this.Errors = errors;
        }

        /// <summary>
        /// Текст сообщения об ошибке.
        /// </summary>
        public override string Message
        {
            get
            {
                string message = string.Empty;

                string[] constraintErrors = GetForeignKeyConstraintErrors(Errors);

                if (constraintErrors.Length > 0)
                {
                    string dependentEntities = string.Join(", ", constraintErrors);

                    message = $"Не должно быть зависимых объектов с типом: {dependentEntities}.";
                }


                return message;
            }
        }

        /// <summary>
        /// Вычленяет из общего массива ошибок ошибки ограничения по внешнему ключу.
        /// </summary>
        /// <param name="errors">Общий массив ошибок.</param>
        /// <returns>Ошибки внешнего ключа.</returns>
        private string[] GetForeignKeyConstraintErrors(IEnumerable<IError> errors)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();

            // Выбираем ошибки ограничения по внешенму ключу
            List<ForeignKeyConstraintError> constraintErrors = new List<ForeignKeyConstraintError>(errors
                .Where(e => e.GetType().IsEquivalentTo(typeof(ForeignKeyConstraintError))).Cast<ForeignKeyConstraintError>());

            // Сохраняем в новую коллекцию, без дубликатов.
            foreach (ForeignKeyConstraintError e in constraintErrors)
            {
                temp[e.ForeignType] = e.Text;
                //temp.Add(e.ForeignType, e.Text);
            };

            return temp.Select(e => e.Value).ToArray();
        }
    }
}
