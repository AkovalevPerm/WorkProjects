using ICSSoft.STORMNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBus.ObjectDataModel.FromTU
{
    public enum tPaymentMethod
    {
        [Caption("")]
        Pusto,        

        [Caption("на счет в сбербанк")]
        BankPerevod,       

        [Caption("ведом. для предпр. связи с доставкой")]
        PochtVedomostSDost,

        [Caption("ведом. для предпр. связи без доставки")]
        PochtVedomostBezDost,
        
        [Caption("переводом через предпр. связи")]
        PochtPerevod,

        [Caption("разовым поруч. через предпр. связи")]
        PochtPoruchenie,
        
        [Caption("ведомостью через кассу органа СЗН")]
        Nalichnymi,
        
        [Caption("на счет в альтерн. банк")]
        AlterBankPerevod,
        
        [Caption("ведом. для альтерн. предпр. с доставкой")]
        AlterPochtVedSDost,
        
        [Caption("ведом. для альтерн. предпр. без доставки")]
        AlterPochtVedBezDost,
        
        [Caption("раз. поруч. через альтерн. предпр. связи")]
        AlterPochtPoruchenie,
        
        [Caption("перечисление на счет организации")]
        PerevodNaSchetOrg,
    }
}
