using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoookStoreDatabase2.WEB.Models.ViewModels
{
    public class EditProductViewModel : CreateProductViewModel
    {
        public string ExistingPhotoPath { get; set; }
    }
}
