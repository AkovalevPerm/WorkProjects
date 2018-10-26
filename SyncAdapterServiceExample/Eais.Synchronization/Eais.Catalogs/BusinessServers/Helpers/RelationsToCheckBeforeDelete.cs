using static Iis.Eais.Common.CommonBS;

namespace Iis.Eais.Catalogs.Helpers
{
    /// <summary>
    /// Класс для проверки наличия связанных объектов перед удалением мастера
    /// </summary>
    public static class RelationsToCheckBeforeDelete
    {
        /// <summary>
        /// Связи которые нужно проверить перед удалением ТипУдостДок
        /// </summary>
        public static Limits[] TipUdostDok = new Limits[] {
            new Limits { Name = "Вид удостоверяющего документа", ObjectType = typeof(VidUdostDok), Relation = "TipUdostDok"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением ТипУдостДок
        /// </summary>
        public static Limits[] Territoriia = new Limits[] {
            new Limits { Name = "Проживание", ObjectType = typeof(Prozhivanie), Relation = "Territoriia"},
            new Limits { Name = "Иерархия", ObjectType = typeof(Territoriia), Relation = "Ierarhiia"},
            new Limits { Name = "Улица", ObjectType = typeof(Ulitca), Relation = "Territoriia"},
            new Limits { Name = "Орган СЗ", ObjectType = typeof(OrganSZ), Relation = "Territoriia"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением ТипУдостДок
        /// </summary>
        public static Limits[] Ulitca = new Limits[] {
            new Limits { Name = "Проживание", ObjectType = typeof(Prozhivanie), Relation = "Ulitca"},
            new Limits { Name = "Улица", ObjectType = typeof(Ulitca), Relation = "NovoeNazv"},
            new Limits { Name = "Строение", ObjectType = typeof(Stroenie), Relation = "Ulitca"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением Строение
        /// </summary>
        public static Limits[] Stroenie = new Limits[] {
            new Limits { Name = "Проживание", ObjectType = typeof(Prozhivanie), Relation = "Stroenie"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением Строение
        /// </summary>
        public static Limits[] OrganSZ = new Limits[] {
            new Limits { Name = "Территория", ObjectType = typeof(Territoriia), Relation = "OrganSZ"},
            new Limits { Name = "Иерархия", ObjectType = typeof(OrganSZ), Relation = "Ierarhiia"},
            new Limits { Name = "Орган выдавший документ", ObjectType = typeof(OrganVydDok), Relation = "OrganSZ"},
            new Limits { Name = "Специалист", ObjectType = typeof(Specialist), Relation = "OrganSZ"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением Строение
        /// </summary>
        public static Limits[] Lgota = new Limits[] {
            new Limits { Name = "Иерархия", ObjectType = typeof(Lgota), Relation = "Ierarhiia"},
            new Limits { Name = "Льготная категория", ObjectType = typeof(LgotaDliaKat), Relation = "Lgota"},
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением Строение
        /// </summary>
        public static Limits[] TipLgoty = new Limits[] {
            new Limits { Name = "Льгота", ObjectType = typeof(Lgota), Relation = "Tip"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением Строение
        /// </summary>
        public static Limits[] LgotKat = new Limits[] {
            new Limits { Name = "Иерархия", ObjectType = typeof(LgotKat), Relation = "Ierarhiia"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением Строение
        /// </summary>
        public static Limits[] IstochnikFin = new Limits[] {
            new Limits { Name = "Льготная категория", ObjectType = typeof(LgotaDliaKat), Relation = "IstochnikFin"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением Строение
        /// </summary>
        public static Limits[] StatiaAkta = new Limits[] {
            new Limits { Name = "Льготная категория", ObjectType = typeof(LgotaDliaKat), Relation = "Osnovanie"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением Строение
        /// </summary>
        public static Limits[] UrovenVlasti = new Limits[] {
            new Limits { Name = "Нормативный акт", ObjectType = typeof(NormAkt), Relation = "Izdatel"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением Строение
        /// </summary>
        public static Limits[] TipNormAkta = new Limits[] {
            new Limits { Name = "Нормативный акт", ObjectType = typeof(NormAkt), Relation = "Tip"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением Строение
        /// </summary>
        public static Limits[] Catalog = new Limits[] {
            new Limits { Name = "Перекодировочный справочник", ObjectType = typeof(CatalogTransformation), Relation = "ForeignCatalog"}
        };

        /// <summary>
        /// Связи которые нужно проверить перед удалением Строение
        /// </summary>
        public static Limits[] ForeignCatValue = new Limits[] {
            new Limits { Name = "Transformation", ObjectType = typeof(Transformation), Relation = "ForeignValue"}
        };
    }
}
