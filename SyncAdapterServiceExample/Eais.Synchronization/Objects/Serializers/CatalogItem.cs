using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Iis.Eais.Synchronization;

namespace Synchronization.SyncAdapter.Serializers
{
    [DataContract]
    public class CatalogItem
    {
        private string fType;

        private UslovieSeriazlizer[] fUslovie;

        [DataMember]
        internal string type
        {
            get
            {
                return fType;
            }
            set
            {
                fType = value;
            }
        }

        [DataMember]
        internal UslovieSeriazlizer[] uslovie {
            get
            {
                return fUslovie;
            }
            set
            {
                fUslovie = value;
            }
         }

        public string GetItType()
        {
            return type;
        }

        public List<Uslovie> GetUslovies()
        {
            List<Uslovie> result = new List<Uslovie>();
            foreach (UslovieSeriazlizer item in uslovie)
            {
                result.Add(new Uslovie()
                {
                    Atribut = item.GetAtribut(),
                    Znachenie = (tZnachenie)Enum.Parse(typeof(tZnachenie), item.GetZnachenie())
                });
            }
            return result;
        }
    }
}