using StudyLab.Models;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StudyLab.Controllers.API
{
    public class UploadController : ApiController
    {
        public ApplicationDbContext _Context;

        public UploadController()
        {
            _Context = new ApplicationDbContext();
        }

        [HttpGet]
        [Route("api/upload")]
        public IHttpActionResult GetAvatar()
        {
            var avatar = _Context.Users.SingleOrDefault(c => c.UserName == "admin@studylab.com");

            if (avatar == null)
                return NotFound();

            Stream stream = new MemoryStream(avatar.Avatar);

            return Ok(stream);

        }

        [HttpPost]
        [Route("api/upload")]
        public IHttpActionResult Upload()
        {
            var update = _Context.Users.SingleOrDefault(c => c.Email == "admin@studylab.com");

            if (update == null)
                return NotFound();

            var file = HttpContext.Current.Request.Files["UploadedImage"]?.InputStream;

            if (file != null && file.Length > 0)
            {
                byte[] imgBytes;

                using (var streamReader = new MemoryStream())

                {
                    file.CopyTo(streamReader);
                    imgBytes = streamReader.ToArray();
                }

                update.Avatar = imgBytes;

                _Context.SaveChanges();
                return Ok();
            }

            // Save to local folder
            //if (file != null && file.ContentLength > 0)
            //{
            //    //var fileName = Path.GetFileName(file.FileName);

            //    var path = Path.Combine("C:\\Users\\Craig\\Downloads",
            //        "avatar.png"
            //    );

            //    file.SaveAs(path);

            //    return Ok();
            //}
            return Ok();
        }
    }
}
