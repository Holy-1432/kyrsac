//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kyrsac
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;

    public partial class все_заказы
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public все_заказы()
        {
            this.состав_заказа = new HashSet<состав_заказа>();
        }
        [Key]
        public int код_заказа { get; set; } //
        public Nullable<int> код_клиента { get; set; }
        public Nullable<System.DateTime> дата_заказа { get; set; }
        public string место_доставки { get; set; }
        public Nullable<decimal> сумма_заказа { get; set; }
    
        public virtual клиент клиент { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<состав_заказа> состав_заказа { get; set; }
    }
}
