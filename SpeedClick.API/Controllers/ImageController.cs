using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Hosting;
using System.Web.Http;

namespace SpeedClick.API.Controllers
{
    public class ImageController : ApiController
    {

        [Route("img/users/{id}")]
        public HttpResponseMessage GetUserAvatar(int id)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            String filePath = HostingEnvironment.MapPath(String.Format("~/Images/users/{0}.png", id));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                Image image = Image.FromStream(fileStream);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, ImageFormat.Png);
                    result.Content = new ByteArrayContent(memoryStream.ToArray());
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                    memoryStream.Close();
                }
                fileStream.Close();
            }
            return result;
        }

        [Route("img/scenes/{id}/bg")]
        public HttpResponseMessage GetSceneBackground(int id)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            String filePath = HostingEnvironment.MapPath(String.Format("~/Images/scenes/{0}/bg.jpg", id));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                Image image = Image.FromStream(fileStream);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, ImageFormat.Jpeg);
                    result.Content = new ByteArrayContent(memoryStream.ToArray());
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
                    memoryStream.Close();
                }
                fileStream.Close();
            }
            return result;
        }

        [Route("img/scenes/{id}/{type}/{index}")]
        public HttpResponseMessage GetSceneBackground(int id, string type, int index)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            String filePath = HostingEnvironment.MapPath(String.Format("~/Images/scenes/{0}/{1}/{2}.png", id, type, index));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                Image image = Image.FromStream(fileStream);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, ImageFormat.Png);
                    result.Content = new ByteArrayContent(memoryStream.ToArray());
                    result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                    memoryStream.Close();
                }
                fileStream.Close();
            }
            return result;
        }

    }
}
