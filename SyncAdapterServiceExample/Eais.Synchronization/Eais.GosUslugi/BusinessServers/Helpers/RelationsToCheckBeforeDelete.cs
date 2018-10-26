using static Iis.Eais.Common.CommonBS;

namespace Iis.Eais.GosUslugi.Helpers
{
    /// <summary>
    /// Класс для проверки наличия связанных объектов перед удалением мастера
    /// </summary>
    public static class RelationsToCheckBeforeDelete
    {
        /// <summary>
        /// Связи которые нужно проверить перед удалением СтатусЗапроса
        /// </summary>
        public static Limits[] StatusZaprosa = new Limits[] {
            new Limits { Name = "Изменение статуса заявления на гос. услугу", ObjectType = typeof(IzmenenieStatusaZaiavleniiaNaGU), Relation = "Status"},
            new Limits { Name = "Заявление на гос. услугу", ObjectType = typeof(ZaiavlenieNaGosUslugu), Relation = "StatusZaprosa"},
            new Limits { Name = "Статус гос. услуги", ObjectType = typeof(StatusyGU), Relation = "Status"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением ГосУслуга
        /// </summary>
        public static Limits[] GosUsluga = new Limits[] {
            new Limits { Name = "Назначение исполнителей гос.услуг", ObjectType = typeof(NaznGUSpetc), Relation = "GosUsluga"},
            new Limits { Name = "Заявление об оказании услуг с портала гос. услуг", ObjectType = typeof(ZaiavlenieNaGosUslugu), Relation = "GosUsluga"},
            new Limits { Name = "Наименование операции рассмотрения ведомством", ObjectType = typeof(NaimOperRassmotrVedom), Relation = "GosUsluga"},
            new Limits { Name = "Причина отказа по заявлению на ГУ ", ObjectType = typeof(PrichinaOtkazaPoZaprosuPortalaGosUslug), Relation = "GosUsluga"},
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением НаимРассмотрВедомства
        /// </summary>
        public static Limits[] NaimOperRassmotrVedom = new Limits[] {
            new Limits { Name = "Заявление об оказании услуг с портала гос. услуг", ObjectType = typeof(ZaiavlenieNaGosUslugu), Relation = "Rezultat"},
            new Limits { Name = "Изменение статуса заявления на гос. услугу", ObjectType = typeof(IzmenenieStatusaZaiavleniiaNaGU), Relation = "PromezhutochnoeReshenie"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением ПричинаОтказаПоЗапросуПорталаГосУслуг
        /// </summary>
        public static Limits[] PrichinaOtkazaPoZaprosuPortalaGosUslug = new Limits[] {
            new Limits { Name = "Заявление об оказании услуг с портала гос. услуг", ObjectType = typeof(ZaiavlenieNaGosUslugu), Relation = "PrichinaOtkaza"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением Личность
        /// </summary>
        public static Limits[] Leechnost = new Limits[] {
            new Limits { Name = "Заявление об оказании услуг с портала гос. услуг", ObjectType = typeof(ZaiavlenieNaGosUslugu), Relation = "Zaiavitel"},
            new Limits { Name = "Заявление об оказании услуг с портала гос. услуг", ObjectType = typeof(ZaiavlenieNaGosUslugu), Relation = "Opekaemyi"},
            new Limits { Name = "Член семьи", ObjectType = typeof(ChlenSemi), Relation = "Leechnost"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением РодствОтн
        /// </summary>
        public static Limits[] RodstvOtn = new Limits[] {
            new Limits { Name = "Член семьи", ObjectType = typeof(ChlenSemi), Relation = "RodstvOtn"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением Специалист
        /// </summary>
        public static Limits[] Specialist = new Limits[] {
            new Limits { Name = "Заявление об оказании услуг с портала гос. услуг", ObjectType = typeof(ZaiavlenieNaGosUslugu), Relation = "Ispolnitel"},
            new Limits { Name = "Назначение исполнителей гос.услуг", ObjectType = typeof(NaznGUSpetc), Relation = "Specialist"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением ОрганСЗ
        /// </summary>
        public static Limits[] OrganSZ = new Limits[] {
            new Limits { Name = "Заявление об оказании услуг с портала гос. услуг", ObjectType = typeof(ZaiavlenieNaGosUslugu), Relation = "OrganSZ"}
        };
    }
}
