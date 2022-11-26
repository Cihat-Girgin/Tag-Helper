using Razor.Introduction.Tag.Helper.Web.Models;
using System.Text;

namespace Razor.Introduction.Tag.Helper.Web.UserCards
{
    public abstract class UserCardTemplate
    {
        protected User User { get; set; }

        public void SetUser(User User)
        {
            this.User = User;
        }

        public string Build()
        {
            if (User == null) throw new ArgumentNullException(nameof(Models.User));

            var sb = new StringBuilder();

            sb.Append("<div class='card'>");
            sb.Append(SetPicture());
            sb.Append($@"<div class='card-body'>
                          <h5>{User.Username}</h5>
                          <p>{User.Description}</p>");
            sb.Append(SetFooter());
            sb.Append("</div>");
            sb.Append("</div>");

            return sb.ToString();
        }

        protected abstract string SetFooter();

        protected abstract string SetPicture();
    }
}
