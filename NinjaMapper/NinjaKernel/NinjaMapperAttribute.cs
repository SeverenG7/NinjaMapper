using System;

namespace NinjaMapper
{

    /// <summary>
    /// Attribute for mapping. Get FullName of mapping class
    /// </summary>
    public class NinjaMapperAttribute : Attribute
    {
        public string ReceiverType { get; set; }

        public NinjaMapperAttribute(string Receiver)
        {
            ReceiverType = Receiver;
        }
    }
}
