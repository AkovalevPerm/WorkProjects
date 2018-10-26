using static Iis.Eais.Common.CommonBS;

namespace Iis.Eais.Leechnost.Helpers
{
    /// <summary>
    /// Класс для проверки наличия связанных объектов перед удалением мастера
    /// </summary>
    public static class RelationsToCheckBeforeDelete
    {
        /// <summary>
        /// Связи которые нужно проверить перед удалением Личности
        /// </summary>
        public static Limits[] Leechnost = new Limits[] {
            new Limits { Name = "Состояние на учёте личности", ObjectType = typeof(UchetLeechnosti), Relation = "Leechnost"},
            new Limits { Name = "Факт получения льготы", ObjectType = typeof(FaktLgot), Relation = "Izhdivenetc"},
            new Limits { Name = "Факт получения льготы", ObjectType = typeof(FaktLgot), Relation = "Poluchatel"},
            new Limits { Name = "Назначение выплаты", ObjectType = typeof(NaznachenieVyplaty), Relation = "Izhdivenetc"},
            new Limits { Name = "Назначение выплаты", ObjectType = typeof(NaznachenieVyplaty), Relation = "Nositel"},
            new Limits { Name = "Изменение назначения выплаты", ObjectType = typeof(IzmenenieNaznachVypl), Relation = "Poluchatel"},
            new Limits { Name = "Состояние на учете", ObjectType = typeof(UchetLeechnosti), Relation = "Leechnost"},
            new Limits { Name = "Перемещение", ObjectType = typeof(Peremeshchenie), Relation = "Leechnost"},
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением ВидУдостДок
        /// </summary>
        public static Limits[] VidUdostDok = new Limits[] {
            new Limits { Name = "Удостоверяющий документ", ObjectType = typeof(UdostDokument), Relation = "VidUdostDok"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением ОрганВыдДок
        /// </summary>
        public static Limits[] OrganVydDok = new Limits[] {
            new Limits { Name = "Удостоверяющий документ", ObjectType = typeof(UdostDokument), Relation = "KemVydan"},
            new Limits { Name = "Инвалидность", ObjectType = typeof(Invalidnost), Relation = "KemVydSprMSE"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением ОрганСЗ
        /// </summary>
        public static Limits[] OrganSZ = new Limits[] {
            new Limits { Name = "Состояние на учете", ObjectType = typeof(UchetLeechnosti), Relation = "OrganSZ"},
            new Limits { Name = "Назначение выплаты", ObjectType = typeof(IzmenenieNaznachVypl), Relation = "OrganSZ"},
            new Limits { Name = "Факт получения льготы", ObjectType = typeof(FaktLgot), Relation = "OrganSZ"},
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением Льготы
        /// </summary>
        public static Limits[] Lgota = new Limits[] {
            new Limits { Name = "Назначение выплаты", ObjectType = typeof(NaznachenieVyplaty), Relation = "Lgota"},
            new Limits { Name = "Факт получения льготы", ObjectType = typeof(FaktLgot), Relation = "Lgota"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением ЛгКатЛичности
        /// </summary>
        public static Limits[] LgKatLeechnosti = new Limits[] {
            new Limits { Name = "Факт получения льготы", ObjectType = typeof(FaktLgot), Relation = "NositelLgoty"},
            new Limits { Name = "Изменение назначения выплаты", ObjectType = typeof(IzmenenieNaznachVypl), Relation = "LgKatLeechnosti"},
            new Limits { Name = "Инвалидность", ObjectType = typeof(Invalidnost), Relation = "LgKatLeechnosti"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением ЛогтКат
        /// </summary>
        public static Limits[] LgotKat = new Limits[] {
            new Limits { Name = "Льготная категория личности", ObjectType = typeof(LgKatLeechnosti), Relation = "LgotKat"},
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением ПричиныСнятия
        /// </summary>
        public static Limits[] PrichinaSnyatiya = new Limits[] {
            new Limits { Name = "Состояние на учете", ObjectType = typeof(UchetLeechnosti), Relation = "PrichinaSnyatiya"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением Инвалидности
        /// </summary>
        public static Limits[] Invalidnost = new Limits[] {
            new Limits { Name = "Льготная категория личности", ObjectType = typeof(LgKatLeechnosti), Relation = "AktInvalidnosti"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением УдостДокумента
        /// </summary>
        public static Limits[] UdostDokument = new Limits[] {
            new Limits { Name = "Льготная категория личности", ObjectType = typeof(LgKatLeechnosti), Relation = "Dokument"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением Проживания
        /// </summary>
        public static Limits[] Prozhivanie = new Limits[] {
            new Limits { Name = "Личность", ObjectType = typeof(Leechnost), Relation = "Prozhivanie"},
            new Limits { Name = "Личность", ObjectType = typeof(Leechnost), Relation = "Propiska"},
            new Limits { Name = "Перемещение", ObjectType = typeof(Peremeshchenie), Relation = "AdresUbytiia"},
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением ПричиныПеремещения
        /// </summary>
        public static Limits[] PrichinaPeremeshcheniia = new Limits[] {
            new Limits { Name = "Перемещение", ObjectType = typeof(Peremeshchenie), Relation = "PrichinaPeremeshcheniia"},
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением Страны
        /// </summary>
        public static Limits[] Strana = new Limits[] {
            new Limits { Name = "Личность", ObjectType = typeof(Leechnost), Relation = "Grazhdanstvo"},
        };
    }
}
