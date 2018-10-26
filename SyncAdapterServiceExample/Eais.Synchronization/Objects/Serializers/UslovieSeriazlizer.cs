using System.Runtime.Serialization;

namespace Synchronization.SyncAdapter.Serializers
{
    [DataContract]
    public class UslovieSeriazlizer
    {
        private string fZnachenie;
        private string fAtribut;

        [DataMember]
        internal string znachenie
        {
            get
            {
                return fZnachenie;
                
            }
            set
            {
                fZnachenie = value;
            }
        }
        [DataMember]
        internal string atribut
        {
            get
            {
                return fAtribut;
            }
            set
            {
                fAtribut = value;
            }
        }
        public string GetZnachenie()
        {
            return znachenie;
        }

        public string GetAtribut()
        {
            return atribut;
        }
    }
}