using BusinessDomain.Business.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Referentiels.Models
{
    public class ItemListViewModel : ItemViewModel
    {
        public ClasseListe ClasseListe { get; set; }

        public ItemListe ItemLists { get; set; }

        public IEnumerable<ClasseListe> ClasseListes { get; set; }

        public IEnumerable<ItemListe> listItemList { get; set; }

        //public AttachmentFileViewModel Image { get; set; }
    }
}