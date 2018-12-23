using System;
using System.Reflection;

namespace NinjaMapper
{
    public static class NinjaMethods
    {
        /// <summary>
        /// Automatically create map between receiver type and source in parametr which based on NinjaAttribute type.
        /// </summary>
        /// <param name="source">
        /// Source from which takes mapping fields.
        /// </param>
        /// <returns></returns>
        public static Object NinjaConnect(Object source)
        {
            Type sourceType = source.GetType();
            NinjaMapperAttribute NinjaAttribute = (NinjaMapperAttribute)
                CustomAttributeExtensions.GetCustomAttribute(sourceType, typeof(NinjaMapperAttribute));
            Type receiverType = Type.GetType(NinjaAttribute.ReceiverType);
            ConstructorInfo constructor = receiverType.GetConstructor(new Type[] { });
            Object receiver = constructor.Invoke(new object[] { });
            return Mapping(source, receiver);
        }

        /// <summary>
        /// Mapping properties with same name's
        /// </summary>
        /// <param name="source">
        /// Source object from which takes properties values
        /// </param>
        /// <param name="receiver">
        /// Receiver object which get source's object properties values
        /// </param>
        /// <returns></returns>
        private static Object Mapping(Object source, Object receiver)
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
