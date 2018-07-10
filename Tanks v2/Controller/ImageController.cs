using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
   public class ImageController
    {
        private Model.ImageModel imageModel;

        public ImageController() => imageModel = new Model.ImageModel();

        public void LoadImages() => imageModel.LoadImages();
        public Entities.Image GetImages() => imageModel.GetImages();
    }
}