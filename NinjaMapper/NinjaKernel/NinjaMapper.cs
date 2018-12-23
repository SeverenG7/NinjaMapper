using System;
using System.Reflection;

namespace NinjaMapper
{
    /// <summary>
    /// Represent map class which connect source type properties with receiver type properties
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TReceiver"></typeparam>
    public class NinjaMapper<TSource, TReceiver> where TSource : class where TReceiver : class
    {
        public TSource Source { get; set; }
        public TReceiver Receiver { get; set; }

        /// <summary>
        /// Create NinjaMapper object which can connect source properties and receiver properties with same name
        /// </summary>
        /// <param name="source"></param>
        /// <param name="receiver"></param>
        /// <returns></returns>
        public TReceiver CreateMap(TSource source, TReceiver receiver)
        {
            Type sourceType = source.GetType();
            Type receiverType = receiver.GetType();
            PropertyInfo[] sourceProperties = sourceType.GetProperties();
            PropertyInfo[] receiverProperties = receiverType.GetProperties();
            foreach (PropertyInfo propSource in sourceProperties)
            {
                foreach (PropertyInfo propReceiver in receiverProperties)
                {
                    if (propSource.Name == propReceiver.Name && propSource.GetType() == propReceiver.GetType())
                    {
                        propReceiver.SetValue(receiver, propSource.GetValue(source));
                    }
                }
            }
            return receiver;
        }
    }
}
