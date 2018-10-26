namespace Synchronization.Utils
{
    using System;
    using System.Reflection;
    using ICSSoft.STORMNET;
    using IIS.University.Tools;

    public static class Helper
    {
        private static readonly MethodInfo PKHelperMethod = typeof(PKHelper).GetMethod(
            nameof(PKHelper.CreateDataObject),
            BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly,
            null,
            CallingConventions.Any,
            new[] {typeof(object)},
            null);

        public static DataObject CreateDataObject(Type type, object pk)
        {
            object result = null;
            if (PKHelperMethod != null)
            {
                var generic = PKHelperMethod.MakeGenericMethod(type);
                result = generic.Invoke(null, new[] {pk});
            }

            return result as DataObject;
        }

        public static string GetDatePartAsString(DateTime? fromDate, DateTime? toDate)
        {
            var datePart = "";
            if (fromDate.HasValue || toDate.HasValue)
            {
                if (fromDate.HasValue && toDate.HasValue)
                {
                    datePart = $" за период с {fromDate.Value:G} по {toDate.Value:G}";
                }
                else if (fromDate.HasValue)
                {
                    datePart = $" с {fromDate.Value:G}";
                }
                else
                {
                    datePart = $" до {toDate.Value:G}";
                }
            }

            return datePart;
        }
    }
}