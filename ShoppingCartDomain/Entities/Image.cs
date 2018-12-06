using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShoppingCartDomain.Entities
{
    public class Image
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string ImageName { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageType { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product{ get; set; }

        public Image()
        {

        }

        public Image(HttpPostedFileBase image, int id)
        {
            ProductId = id;
            ImageName = System.IO.Path.GetFileName(image.FileName);
            ImageType = image.ContentType;
            ImageData = new byte[image.ContentLength];
            image.InputStream.Read(ImageData, 0, ImageData.Length);
        }
    }
}
