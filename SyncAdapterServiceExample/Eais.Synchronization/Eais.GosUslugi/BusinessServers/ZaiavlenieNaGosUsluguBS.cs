﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Iis.Eais.GosUslugi
{
    using System;
    using System.Xml;


    // *** Start programmer edit section *** (Using statements)
    using System.Linq;

    using ICSSoft.STORMNET;

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// ZaiavlenieNaGosUsluguBS.
    /// </summary>
    // *** Start programmer edit section *** (ZaiavlenieNaGosUsluguBS CustomAttributes)

    // *** End programmer edit section *** (ZaiavlenieNaGosUsluguBS CustomAttributes)
    [ICSSoft.STORMNET.AccessType(ICSSoft.STORMNET.AccessType.none)]
    public class ZaiavlenieNaGosUsluguBS : Iis.Eais.Common.CommonBS
    {

        // *** Start programmer edit section *** (ZaiavlenieNaGosUsluguBS CustomMembers)

        // *** End programmer edit section *** (ZaiavlenieNaGosUsluguBS CustomMembers)


        // *** Start programmer edit section *** (OnUpdateZaiavlenieNaGosUslugu CustomAttributes)

        // *** End programmer edit section *** (OnUpdateZaiavlenieNaGosUslugu CustomAttributes)
        public virtual ICSSoft.STORMNET.DataObject[] OnUpdateZaiavlenieNaGosUslugu(Iis.Eais.GosUslugi.ZaiavlenieNaGosUslugu UpdatedObject)
        {
            // *** Start programmer edit section *** (OnUpdateZaiavlenieNaGosUslugu)
            if (UpdatedObject.GetStatus() == ObjectStatus.Created)
            {
                if (!UpdatedObject.GosUsluga.CheckLoadedProperty(nameof(GosUsluga.Requests)))
                {
                    DataService.LoadObject(GosUsluga.Views.GosUslugaE, UpdatedObject.GosUsluga);
                }

                var mvs = UpdatedObject.GosUsluga.Requests.Cast<MVRequestGU>().ToList();
                foreach (var mv in mvs)
                {
                    UpdatedObject.MVRequestZaiavlenie.Add(
                        new MVRequestZaiavlenie
                        {
                            Request = mv.Request
                        });
                }
            }

            if (UpdatedObject.GetStatus() != ObjectStatus.Deleted)
            {
                if (UpdatedObject.IsAlteredProperty(x => x.StatusZaprosa))
                {
                    UpdatedObject.IzmeneniiaStatusa.Add(
                        new IzmenenieStatusaZaiavleniiaNaGU
                        {
                            Status = UpdatedObject.StatusZaprosa,
                            DataVremia = DateTime.Now
                        });
                }
            }

            return new DataObject[0];
            // *** End programmer edit section *** (OnUpdateZaiavlenieNaGosUslugu)
        }
    }
}
