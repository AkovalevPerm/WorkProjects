namespace Iis.Eais.Common.log4net
{
    using global::log4net.Layout;
    using global::log4net.Util;

    /// <inheritdoc />
    public class EaisPatternLayout : PatternLayout
    {
        /// <inheritdoc />
        public EaisPatternLayout()
        {
            AddConverter(new ConverterInfo { Name = "appname", Type = typeof(EaisPatternConverter) });
        }
    }
}